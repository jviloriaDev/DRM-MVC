using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public interface ISqlPropertyMapper
    {
        string GetPropertyName(string propertyName);
        string GetOperatorString(object value, string columnName);
        SqlOperationType GetOperationType(string columnName);
    }
}
