using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Controllers
{
  
    public class WFSendController : Controller
    {
        #region "variable declaration"


        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public WFSendController()
        {
         
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"


        public ActionResult Index()
        {
            string Phase = Request.QueryString["Phase"]; 
            string PhaseName = Request.QueryString["Name"];

            string Page = Request.QueryString["Page"];

            Session["Phase"] = Phase;
            Session["PhaseName"] = PhaseName;
            //string[] splitQueryString = Page.Split('?');
            //if(splitQueryString.Length > 1)
            //{
            //    string split
            //}
            


            return Redirect(Page);
            
        }

       

        #endregion "Controller Methods"

    }
}
