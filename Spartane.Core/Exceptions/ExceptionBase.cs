using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Log;

namespace Spartane.Core.Exceptions
{
    public abstract partial class ExceptionBase : Exception
    {
        
        public ExceptionBase(string message)
            : base(message)
        {
            LoggerHelper.LogError(message, this);
        }

        public ExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        {
            LoggerHelper.LogError(message, this);
        }
    }
}
