using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Spartane.Web.Helpers
{
    public static class EncryptHelper
    {
        public static string CalculateMD5Hash(string text)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(text)).Select(s => s.ToString("x2")));
        }
    }
}