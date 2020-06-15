using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.GeneratePDF
{
    public class GeneratePDFApiConsumer : BaseApiConsumer, IGeneratePDFApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;
        public string DirectoryImg { get; set; }

        public GeneratePDFApiConsumer()
            : base(string.Empty)
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/GeneratePDF";
            DirectoryImg = baseApi + "/api/Spartan_File/Files/";

        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<byte[]> GeneratePDF(int idFormat, string RecordId)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<byte[]>(baseApi, ApiControllerUrl + "/GeneratePDF?idFormat=" + idFormat + "&RecordId=" + RecordId + "&ImgDirectory=" + DirectoryImg, Method.GET, ApiHeader);
                return new ApiResponse<byte[]>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<byte[]>(false, null);
            }
        }

        public ApiResponse<string> GenerateHTML(int idFormat, string RecordId)
        {
            try
            {
                var varHtml = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/GenerateHTML?idFormat=" + idFormat + "&RecordId=" + RecordId + "&ImgDirectory=" + DirectoryImg, Method.GET, ApiHeader);

                return new ApiResponse<string>(true, varHtml);
            }
            catch (Exception)
            {
                return new ApiResponse<string>(false, string.Empty);
            }
        }
    }
}