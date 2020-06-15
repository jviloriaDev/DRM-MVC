using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Spartane.Web.Helpers
{
    public static class CsvConverter
    {

        public static void ExportToCSV(DataTable dt, string fileName)
        {
             string attachment = "attachment; filename=" + fileName + ".csv";
            HttpContext.Current.Response.ClearContent();

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv; charset=utf-8";
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
            HttpContext.Current.Response.End();
        }

    }
}