using Spartane.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Spartane.Web.Filters
{
    public class UnHandledException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            LoggerHelper.LogError(context.Exception.Message, context.Exception);
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception);
        }
    }
}
