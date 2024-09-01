using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestuarantProject.App_Code;

namespace RestuarantProject.Account
{
    public partial class ShowAllRatings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateGvIntern();
        }

        protected void populateGvIntern()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from Resturant";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvShowAllRatings.DataSource = dr;
            gvShowAllRatings.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("restuarant.aspx");
        }
        protected DataTable getDt()
        {
            string mySql = @"select visitorName, Hotel, hotelRatingCriteria, HotelRatingCriteriaPoint
                             from HotelRatings h inner join hotelRatingCriteria ho on h.hotelRatingCriteriaId = ho.hotelRatingCriteriaId";

            CRUD myCrud = new CRUD();
            // mySql = @"select * from v_dsTemplate order by refno";// sepcify any data in db  created in case above 
            DataTable dt = myCrud.getDT(mySql);
            return dt;
        }
        protected DataTable GetRecipients()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select visitorName, Hotel, hotelRatingCriteria, HotelRatingCriteriaPoint
                             from HotelRatings h inner join hotelRatingCriteria ho on h.hotelRatingCriteriaId = ho.hotelRatingCriteriaId";
            DataTable dt = myCrud.getDT(mySql);
            return dt;
        }
        protected void btnExportToWordPdf_Click(object sender, EventArgs e)
        {
            DataTable hotelRatings = GetRecipients();

            var visitors = hotelRatings.AsEnumerable()
                .GroupBy(row => row.Field<string>("visitorName"));

            string resultPath = Server.MapPath("~/Result/");
            if (!Directory.Exists(resultPath))
                Directory.CreateDirectory(resultPath);

            using (WordDocument template = new WordDocument())
            {
                // Opens the template Word document
                template.Open(Server.MapPath("~/myTemplate/hotel visitor Rating template.docx"));

                foreach (var visitorGroup in visitors)
                {
                    string visitorName = visitorGroup.Key;

                    // Clone the template document for each visitor
                    WordDocument document = template.Clone();

                    // Add the visitor's name to the first line
                    document.Replace("«visitorName»", visitorName, true, true);

                    bool firstTable = true;
                    foreach (var hotelGroup in visitorGroup.GroupBy(row => row.Field<string>("Hotel")))
                    {
                        IWTable table;
                        if (firstTable)
                        {
                            // Use the pre-defined table for the first hotel
                            table = document.Sections[0].Tables[0] as IWTable;
                            firstTable = false;
                        }
                        else
                        {
                            // Clone the pre-defined table for subsequent hotels
                            WTable templateTable = document.Sections[0].Tables[0] as WTable;
                            table = templateTable.Clone();
                            document.Sections[0].Body.ChildEntities.Add(table);
                        }

                        // Clear existing rows from the table (except header rows)
                        while (table.Rows.Count > 2)
                        {
                            table.Rows.RemoveAt(2);
                        }

                        // Replace hotel name in the cloned table
                        table[0, 0].Paragraphs[0].Text = hotelGroup.Key;

                        int rowIndex = 2;
                        foreach (var row in hotelGroup)
                        {
                            WTableRow dataRow = table.AddRow();
                            dataRow.Cells[0].AddParagraph().AppendText(row["hotelRatingCriteria"].ToString());
                            dataRow.Cells[1].AddParagraph().AppendText(row["HotelRatingCriteriaPoint"].ToString() + "⭐️");
                            rowIndex++;
                        }

                        // Add a line break between tables if not the last one
                        if (!hotelGroup.Equals(visitorGroup.Last()))
                        {
                            IWParagraph paragraph = document.Sections[0].AddParagraph();
                            paragraph.ParagraphFormat.AfterSpacing = 12;
                        }
                    }

                    #region To save as Word
                    string wordFilePath = Server.MapPath($"~/Result/HotelRatings_{visitorName}.docx");
                    document.Save(wordFilePath, FormatType.Docx);
                    #endregion

                    #region To save as PDF
                    // Creates an instance of the DocToPDFConverter
                    DocToPDFConverter converter = new DocToPDFConverter();
                    // Converts Word document to PDF document
                    PdfDocument pdfDocument = converter.ConvertToPDF(document);
                    // Closes the instance of Word document object
                    document.Close();
                    converter.Dispose();

                    string pdfFilePath = Server.MapPath($"~/Result/HotelRatings_{visitorName}.pdf");
                    pdfDocument.Save(pdfFilePath);
                    pdfDocument.Close(true);
                    #endregion
                }
            }

            lblOutput.Text = "Export Completed!";
        }
    }
}
