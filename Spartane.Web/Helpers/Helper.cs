using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Microsoft.Ajax.Utilities;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Spartane.Web.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// Convert One class entity to another similar class entity
        /// </summary>
        /// <typeparam name="T">Parameter T would be Output type entity</typeparam>
        /// <param name="InputEntity">Input entity would be convert to output type entity</param>
        /// <returns>Return Output entity</returns>
        public static T ConvertToEntity<T>(object InputEntity) where T : new()
        {           
            // Create object for return output entity 
            T returnObject = new T();

            // Input entity property loop to set each property value to output property
            foreach (PropertyInfo pInfo in InputEntity.GetType().GetProperties())
            {
                // Oupput property loop for match input and output property
                foreach (PropertyInfo pOutputInfo in returnObject.GetType().GetProperties())
                {
                    // check property name 
                    if (pOutputInfo.Name == pInfo.Name)
                    {
                        // set value of entity from input to output
                        pOutputInfo.SetValue(returnObject, pInfo.GetValue(InputEntity, null), null);
                        break;
                    }
                }               
            }
            return returnObject;
        }

        /// <summary>
        /// Convert One class List entity to another similar class List entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="X"></typeparam>
        /// <param name="oList"></param>
        /// <returns></returns>
        public static IList<T> ConvertToList<T, X>(IList<X> oList) where T : new()
        {
            // Create object for return output List entity 
            IList<T> data = new List<T>();
            // Loop for records in input list
            if (oList != null)
            {
                for (int i = 0; i < oList.Count; i++)
                {
                    T returnObject = new T();
                    // call Convert Entity function
                    returnObject = ConvertToEntity<T>(oList[i]);
                    // Added object of entity to list
                    data.Add(returnObject);
                }    
            }
            // return list of output entity
            return data;
        }

        /// <summary>
        /// Get IP Address of User who is using portal
        /// </summary>
        /// <returns></returns>
        public static string IPAddress()
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        /// <summary>
        /// Send Email to Users using SMTP settings
        /// </summary>
        /// <param name="ToEMail"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <returns></returns>
        public static bool SendEmail(List<string> ToEMail, string Subject, string Body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Convert.ToString(ConfigurationManager.AppSettings["SMTP_MAIL_SERVER"]));
                mail.From = new MailAddress(Convert.ToString(ConfigurationManager.AppSettings["DISPLAY_ADDR"]));
                foreach (string email in ToEMail)
                {
                    mail.To.Add(email);
                }                
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"]);
                SmtpServer.Credentials = new System.Net.NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["FROM_ADDR"]), Convert.ToString(ConfigurationManager.AppSettings["FROM_ADDR_PASS"]));
                SmtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EmailEnableSSL"]);
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static  string ReplaceGlobal(string where)
        {
            Regex rx = new Regex(@"GLOBAL00([^\]]+)00");
            MatchCollection matches = rx.Matches(where);

            foreach (Match match in matches)
            {
                var nameOfVar = match.Groups[1].Value;
                var valueOfVar = "'" + System.Web.HttpContext.Current.Session[nameOfVar.ToString()] + "'";
                where = where.Replace(match.Value, valueOfVar.ToString());
            }
            return where;
        }
    }



}
