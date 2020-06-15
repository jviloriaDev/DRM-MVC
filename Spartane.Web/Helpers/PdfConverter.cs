using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Spartane.Web.Helpers
{
    public static class PdfConverter
    {
        public static void ExportToPdf(DataTable dt, string fileName ,bool lastRowIsTotal = false)
        {

            var pdfDoc = new Document();
            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            var pdfStream = new MemoryStream();

            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, pdfStream);

            pdfDoc.Open(); //Open Document to write
            pdfDoc.NewPage();


            Font font8 = FontFactory.GetFont("ARIAL", 7);

            Font font9 = FontFactory.GetFont("ARIAL", 8);
            font9.SetStyle("bold");

            int columnsCount = dt.Columns.Count;

            var pdfTable = new PdfPTable(columnsCount);
            pdfTable.WidthPercentage = 100;
            PdfPCell pdfPCell = null;
            Phrase phrase;

            // Add Date
            phrase = new Phrase();
            string today = "Date:" + DateTime.Now.ToString("d");
            phrase.Add(new Chunk(today, FontFactory.GetFont("TIMES_ROMAN", 10, Font.NORMAL, BaseColor.BLACK)));
            pdfPCell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT, PdfPCell.ALIGN_LEFT);
            pdfPCell.Colspan = columnsCount;
            pdfTable.AddCell(pdfPCell);

            // Add Document Heading
            phrase = new Phrase();
            string printheading = fileName;
            phrase.Add(new Chunk(printheading, FontFactory.GetFont("TIMES_ROMAN", 10, Font.BOLD, BaseColor.BLACK)));
            pdfPCell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER, PdfPCell.ALIGN_CENTER);
            pdfPCell.Colspan = columnsCount;
            pdfTable.AddCell(pdfPCell);



            //Add Header of the pdf table
            for (int column = 0; column < dt.Columns.Count; column++)
            {
                pdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Columns[column].Caption, font9)));
                pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(pdfPCell);
            }

            //How add the data from datatable to pdf table
            string valor = "";
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                for (int column = 0; column < dt.Columns.Count; column++)
                {
                    Int64 n;
                    bool isNumeric = Int64.TryParse(dt.Rows[row][column].ToString(), out n);
                    if (isNumeric == true && dt.Columns[column].DataType != typeof(System.Int32)
                        && dt.Columns[column].DataType != typeof(System.Int64)
                        && dt.Columns[column].DataType != typeof(System.Int16))
                    {
                        valor = string.Format("{0:#,#.00}", Convert.ToDecimal(n) / 10000);
                    }
                    else
                    {
                        valor = dt.Rows[row][column].ToString();
                    }
                    if ((row == (dt.Rows.Count - 1)) && lastRowIsTotal)
                    {
                        pdfPCell = new PdfPCell(new Phrase(new Chunk(valor, font9)));
                        pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    }
                    else
                        pdfPCell = new PdfPCell(new Phrase(new Chunk(valor, font8)));
                    pdfTable.AddCell(pdfPCell);
                }
            }

            pdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table            
            pdfDoc.Add(pdfTable); // add pdf table to the document
            pdfDoc.Close();
            pdfWriter.Close();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/pdf; charset=utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
            HttpContext.Current.Response.BinaryWrite(pdfStream.ToArray());
            HttpContext.Current.Response.End();
        }


        private static PdfPCell PhraseCell(Phrase phrase, int Valign, int Halign)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = Valign;
            cell.HorizontalAlignment = Halign;
            phrase.Font.SetFamily("TIMES_ROMAN");
            cell.PaddingBottom = 5f;
            cell.PaddingTop = 3f;
            cell.PaddingLeft = 3f;
            cell.PaddingRight = 3f;
            phrase.Font.Size = 10f;

            return cell;
        }
    }
}
