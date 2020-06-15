using Spartane.Web.Areas.Frontal.Models;
using System.Security.Principal;

namespace Spartane.Web.AuthenticationExt
{
    internal interface IAuthentication : IPrincipal
    {
        UserContextViewModel UserContext { get; set; }
    }
}