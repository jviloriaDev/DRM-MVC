using Spartane.Web.Areas.Frontal.Models;
using System.Security.Principal;

namespace Spartane.Web.AuthenticationExt
{
    public class Authentication : IAuthentication
    {
        public Authentication()
        {
        }

        public IIdentity Identity { get; private set; }

        public Authentication(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public UserContextViewModel UserContext
        {
            get;
            set;
        }

        public bool IsInRole(string permissions)
        {
            if ((UserContext != null))
            {
                string[] roleArray = permissions.Split(',');
                for (int i = 0; i < roleArray.Length; i++)
                {
                    var isContain = UserContext.Permisssion.Contains(roleArray[i]);
                    if (isContain)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}