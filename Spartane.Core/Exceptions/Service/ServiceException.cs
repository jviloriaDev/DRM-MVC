using Spartane.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Exceptions.Service
{
    public class ServiceException : ExceptionBase
    {
        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
