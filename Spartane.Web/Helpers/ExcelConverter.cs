using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spartane.Web.Helpers
{
    public static class ExcelConverter
    {
        public static void ExportToExcel(DataTable dt, string fileName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string attachment = "attachment; filename=" + fileName + ".xls";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;       
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel; charset=utf-8";
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                HttpContext.Current.Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            HttpContext.Current.Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                HttpContext.Current.Response.Write("\n");
            }
            sw.Stop();
            int seconds = sw.Elapsed.Seconds;

            HttpContext.Current.Response.Write(seconds.ToString());
            HttpContext.Current.Response.End();
        }


        public static void ExportToExcelUsingWriter(DataTable dt, string fileName)
        {
           
            string attachment = "attachment; filename=" + fileName + ".xls";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            string tab = "";

            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Response.OutputStream,Encoding.UTF8))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                foreach (DataColumn dc in dt.Columns)
                {
                    writer.Write(tab + dc.ColumnName);
                    tab = "\t";
                }

                writer.Write("\n");

                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        writer.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    writer.Write("\n");
                }

                sw.Stop();
                int seconds = sw.Elapsed.Seconds;

                HttpContext.Current.Response.Write(seconds.ToString());
            }

            HttpContext.Current.Response.End();
           
            
           
        }
    }
}
