using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.GeneratePDF
{
    public interface IGeneratePDFApiConsumer
    {
        void SetAuthHeader(string token);
        ApiResponse<byte[]> GeneratePDF(int idFormat, string RecordId);
        ApiResponse<string> GenerateHTML(int idFormat, string RecordId);
        int SelCount();
    }
}