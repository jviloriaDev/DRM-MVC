using Spartane.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Spartane.Web.Infrastructure
{
    public class SpartaneApiControllerActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            var result = base.InvokeActionAsync(actionContext, cancellationToken);

            if (result.Exception != null && result.Exception.GetBaseException() != null)
            {
                var baseException = result.Exception.GetBaseException();

                LoggerHelper.LogError(baseException.Message, baseException);

                return Task.Run<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(baseException.Message),
                    ReasonPhrase = "Error"
                });
            }

            return result;
        }
    }
}
