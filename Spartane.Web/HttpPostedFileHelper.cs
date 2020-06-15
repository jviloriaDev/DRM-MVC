using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web
{
    public static class HttpPostedFileHelper
    {
        /// <summary>
        /// Used to get the posted file in form of array
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static byte[] GetPostedFileAsBytes(HttpPostedFileBase file)
        {
            try
            {
                if (file == null)
                    return null;

                using (Stream inputStream = file.InputStream)
                {
                    var memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    return memoryStream.ToArray();
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
