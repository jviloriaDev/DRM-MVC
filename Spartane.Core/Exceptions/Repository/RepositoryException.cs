using Spartane.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Exceptions.Repository
{
    public class RepositoryException : ExceptionBase
    {
        public RepositoryException(string message)
            : base(message)
        {
        }

        public RepositoryException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
