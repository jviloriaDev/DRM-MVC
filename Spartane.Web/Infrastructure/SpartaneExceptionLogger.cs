using Spartane.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Spartane.Web.Infrastructure
{
    public class SpartaneExceptionLogger : IExceptionLogger
    {
        public Task LogAsync(ExceptionLoggerContext context, System.Threading.CancellationToken cancellationToken)
        {
            try
            {
                LoggerHelper.LogError(context.Exception.Message, context.Exception);
            }
            catch(Exception)
            {
                //TODO: Ver que sucede si el log del error da error!!
            }
            return Task.FromResult(0);
        }
    }
}
