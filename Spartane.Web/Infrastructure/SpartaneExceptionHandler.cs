using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Spartane.Web.Infrastructure
{
    public class SpartaneExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            this.Handle(context);
            return base.HandleAsync(context, cancellationToken);
        }
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ExceptionContext exceptionContext = context.ExceptionContext;
            Exception exception = exceptionContext.Exception;

            HttpRequestMessage request = exceptionContext.Request;

            if (request == null)
            {
                throw new ArgumentException("exceptionContext.Request");
            }

            if (exceptionContext.CatchBlock == ExceptionCatchBlocks.IExceptionFilter)
            {
                // The exception filter stage propagates unhandled exceptions by default (when no filter handles the
                // exception).
                return;
            }

            context.Result = new ResponseMessageResult(request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                exception));
        }

        public class ErrorMessageResult : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public ErrorMessageResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }

    }
}
