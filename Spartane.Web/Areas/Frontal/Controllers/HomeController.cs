using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Editor;
using System.Web.Script.Serialization;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Detail;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Config_Detail;
using Spartane.Core.Domain.Dashboard_Editor;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Core.Domain.Dashboard_Config_Detail;
using System;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using System.Configuration;
using System.Globalization;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Helpers;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class HomeController : Controller
    {
        #region "variable declaration"

        private IDashboard_EditorApiConsumer _IDashboard_EditorApiConsumer;
        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ITemplate_Dashboard_DetailApiConsumer _ITemplate_Dashboard_DetailApiConsumer;
        private ITemplate_Dashboard_EditorApiConsumer _ITemplate_Dashboard_EditorApiConsumer;
        private IDashboard_Config_DetailApiConsumer _IDashboard_Config_DetailApiConsumer;

        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private ISpartan_Report_Presentation_TypeApiConsumer _ISpartan_Report_Presentation_TypeApiConsumer;
        private ISpartan_ReportApiConsumer _ISpartan_ReportApiConsumer;

        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartaneObjectApiConsumer _ISpartan_ObjectApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public HomeController(ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, 
            ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, IDashboard_EditorApiConsumer Dashboard_EditorApiConsumer, ITemplate_Dashboard_DetailApiConsumer Template_Dashboard_DetailApiConsumer,
            ITemplate_Dashboard_EditorApiConsumer Template_Dashboard_EditorApiConsumer, IDashboard_Config_DetailApiConsumer Dashboard_Config_DetailApiConsumer,
            ISpartan_Report_Presentation_TypeApiConsumer Spartan_Report_Presentation_TypeApiConsumer, ISpartan_ReportApiConsumer Spartan_ReportApiConsumer, ISpartane_FileApiConsumer ISpartane_FileApiConsumer, ISpartan_UserApiConsumer ISpartan_UserApiConsumer,
            ISpartaneObjectApiConsumer Spartan_ObjectApiConsumer)
        {
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IDashboard_EditorApiConsumer = Dashboard_EditorApiConsumer;
            this._ITemplate_Dashboard_EditorApiConsumer = Template_Dashboard_EditorApiConsumer;
            this._ITemplate_Dashboard_DetailApiConsumer = Template_Dashboard_DetailApiConsumer;
            this._IDashboard_Config_DetailApiConsumer = Dashboard_Config_DetailApiConsumer;
            this._ISpartan_Report_Presentation_TypeApiConsumer = Spartan_Report_Presentation_TypeApiConsumer;
            this._ISpartan_ReportApiConsumer = Spartan_ReportApiConsumer;
            this._ISpartane_FileApiConsumer = ISpartane_FileApiConsumer;
            this._ISpartan_UserApiConsumer = ISpartan_UserApiConsumer;
            this._ISpartan_ObjectApiConsumer = Spartan_ObjectApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"
        
        // GET: Frontal/Home
        public ActionResult Index(int ModuleId = 0, string page = "", string dashboard = "")
        {
            if (page == "")
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                int userroleid = Convert.ToInt32(Session["USERROLEID"]);
                int userId = Convert.ToInt32(Session["USERID"]);
                var result = _IDashboard_EditorApiConsumer.ListaSelAll(0, 100, "Dashboard_Editor.Status=1", "");
                
                IList<Dashboard_Editor> model = new List<Dashboard_Editor>();

                if (result.Success && result.Resource != null)
                {
                    foreach (var dash in result.Resource.Dashboard_Editors)
	                {
                        if(PermissionHelper.GetRoleObjectPermission(userroleid, dash.Dashboard_Id - (dash.Dashboard_Id * 2)).Consult
                            || dash.Registration_User == userId)
                        {
                            model.Add(dash);
                        }
	                }
                }
                if (Session["_dshbxWizardTempleteDefaut"] != null)
                {
                    ViewBag.ActiveDash = (int)Session["_dshbxWizardTempleteDefaut"];
                    Session.Remove("_dshbxWizardTempleteDefaut");
                }
                if (dashboard != "")
                    ViewBag.DashboardId = dashboard;
                
                return View(model);
            }                
            else
                return Redirect(page);
        }

        [HttpGet]
        public JsonResult GetDashboardDetail(int idTemplate, int idDashboard)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                //var result = _ITemplate_Dashboard_EditorApiConsumer.GetByKeyComplete(idTemplate);

                var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(0, 100, "Template_Dashboard_Detail.Template=" + idTemplate, "");

                if (!_tokenManager.GenerateToken())
                    return null;
                _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var resultConfig = _IDashboard_Config_DetailApiConsumer.ListaSelAll(0, 100, "Dashboard_Config_Detail.Dashboard=" + idDashboard, "");

                List<List<string>> rows = new List<List<string>>();
                for (int i = 0; i < result.Resource.RowCount; i++)
                {
                    var nuevaRow = new List<string>();

                    var row = result.Resource.Template_Dashboard_Details[i];
                    for (int j = 0; j < row.Columns; j++)
                    {
                        var dashboardConfigDetail = resultConfig.Resource.Dashboard_Config_Details.SingleOrDefault(cd => (cd.ConfigRow - 1) == i && (cd.ConfigColumn - 1) == j);
                        string reportId = null;
                        if (dashboardConfigDetail != null)
	                    {
		                   if (dashboardConfigDetail.Report_Id != null)
	                        {
		                        reportId = dashboardConfigDetail.Report_Id.ToString();
	                        }
	                    }                        

                        nuevaRow.Add(reportId);
                    }

                    rows.Add(nuevaRow);
                }

                var res = new { Success = true, Rows = rows };

                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpGet]
        public JsonResult RemoveReportFromDashboard(int dashboardId, int row, int column)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var resultConfig = _IDashboard_Config_DetailApiConsumer.ListaSelAll(0, 100, "Dashboard_Config_Detail.Dashboard=" + dashboardId + " AND Dashboard_Config_Detail.ConfigRow=" + row + " AND Dashboard_Config_Detail.ConfigColumn=" + column, "");

                if (resultConfig.Success && resultConfig.Resource.RowCount > 0 && resultConfig.Resource.Dashboard_Config_Details.Any())
                {
                    var dashboardConfig = resultConfig.Resource.Dashboard_Config_Details.First();

                    //dashboardConfig.Report_Id = null;
                    //dashboardConfig.Report_Name = null;

                    _IDashboard_Config_DetailApiConsumer.Delete(dashboardConfig.Detail_Id, null, null);
                }
                else
                {
                    return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
                }


                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult HomePropertyBag()
        {
            return PartialView("HomePropertyBag", "Home");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }

        public ActionResult OpenWizard(int dashboardId, int templateId, int row, int column)
        {
            ViewBag.DashboardId = dashboardId;
            ViewBag.TemplateId = templateId;
            ViewBag.Row = row;
            ViewBag.Column = column;

            return PartialView("_Wizard");
        }

        public ActionResult WizardStep2(string selPresType, string selPresText)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var resultTypes = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(false);
            var presentationTypeId = resultTypes.Resource.Where(x => x.Description.Equals(selPresType)).Select(x => x.PresentationTypeId).SingleOrDefault();

            if (presentationTypeId <= 0)
                return Json(new { success = false, errorText = string.Format(Resources.Resources.TypeNotExist, selPresText) }, JsonRequestBehavior.AllowGet);

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_ReportApiConsumer.SelAll(true).Resource.Where(x => x.Presentation_Type == presentationTypeId).OrderBy(x => x.Report_Name);

            if (result.Count() == 0)
                return Json(new { success = false, errorText = Resources.Resources.ItemsNotFound }, JsonRequestBehavior.AllowGet);

            return Json(new
            {
                success = true,
                data = result.Select(m => new Spartan_ReportGridModel { ReportId = m.ReportId, Report_Name = m.Report_Name }).ToList(),
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WizardComplete(int idDashboard, int reportId, int row, int column)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            var resultConfig = _IDashboard_Config_DetailApiConsumer.ListaSelAll(0, 100, "Dashboard_Config_Detail.Dashboard=" + idDashboard + " AND Dashboard_Config_Detail.ConfigRow=" + row + " AND Dashboard_Config_Detail.ConfigColumn=" + column, "");
            string result;

            //Estoy editando
            if (resultConfig.Success && resultConfig.Resource.RowCount > 0 && resultConfig.Resource.Dashboard_Config_Details.Any())
            {
                var dashboardConfig = resultConfig.Resource.Dashboard_Config_Details.First();

                dashboardConfig.Report_Id = reportId;
                dashboardConfig.Report_Name = reportId.ToString();

                result = _IDashboard_Config_DetailApiConsumer.Update(dashboardConfig, null, null).Resource.ToString();
            }
            //Creo nuevo registro
            else
            {
                var Dashboard_Config_DetailInfo = new Dashboard_Config_Detail
                {
                    Detail_Id = -1,
                    Dashboard = idDashboard,
                    Report_Id = reportId,
                    Report_Name = reportId.ToString(),
                    ConfigRow = (short)row,
                    ConfigColumn = (short)column
                };

                result = _IDashboard_Config_DetailApiConsumer.Insert(Dashboard_Config_DetailInfo, null, null).Resource.ToString();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Dashboard_Templete_Create(Dashboard_EditorWizardModel model)
        {
            try
            {

                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);

                int userId = Convert.ToInt32(Session["USERID"]);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);

                var user = _ISpartan_UserApiConsumer.GetByKey(userId, false).Resource;

                int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;

                string fecharegistro = DateTime.Today.ToString("dd-MM-yyyy");

                var obj = new Dashboard_Editor();
                obj.Name = model.DashboardEditFormNombre;
                obj.Registration_Date = (!String.IsNullOrEmpty(fecharegistro) ? DateTime.ParseExact(fecharegistro, Spartane.Web.Helpers.ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null);
                obj.Registration_User = userId;
                obj.Registration_User_Spartan_User = user;
                obj.Show_in_Home = true;
                obj.Dashboard_Template = model.DashboardEditFormTemplete;
                //obj.Spartan_Object = 987; // model.DashboardEditFormTipoElemento;
                obj.Status = (short)1;

                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var APIMsg = _IDashboard_EditorApiConsumer.Insert(obj, null, null);
                Session["_dshbxWizardTempleteDefaut"] = APIMsg.Resource;

                //INSERTO en SPARTANE OBJECT
                _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
                var so = new Core.Domain.SpartaneObject.SpartaneObject()
                {
                    Object_Id = APIMsg.Resource - (APIMsg.Resource * 2),
                    Object_Type = 5,
                    Name = model.DashboardEditFormNombre,
                    Description = model.DashboardEditFormNombre,
                    Status = 1,
                    URL = "Home/Index?dashboard=" + APIMsg.Resource,
                    Tags = ""
                };
                int ObjectId = _ISpartan_ObjectApiConsumer.Insert(so, null, null).Resource;
                //FileWritter.AddSpartaneObject(so.Object_Id, model.DashboardEditFormNombre);
                Resources.Objects.InsertUpdateObject(so.Object_Id, model.DashboardEditFormNombre, "es-es");
                Resources.Objects.InsertUpdateObject(so.Object_Id, model.DashboardEditFormNombre, "en-us");
                return Json(APIMsg, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }


        }

        public PartialViewResult Dashboard_Config_Card_SearchElement()
        {
            IList<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor> olist2 = new List<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>();
            if (!_tokenManager.GenerateToken())
                return null;

            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var olist = _ITemplate_Dashboard_EditorApiConsumer.SelAll(true);
            if (olist.Resource.Count > 0)
            {
                foreach (var item in olist.Resource)
                {
                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    item.Template_Image_Thumbnail_Spartane_File = _ISpartane_FileApiConsumer.GetByKey(item.Template_Image_Thumbnail).Resource;
                }
                olist2 = olist.Resource.OrderBy(x => x.Description).ToList();
            }

            return PartialView("DashBoardWizardP2", olist2);
        }

        #endregion "Controller Methods"

        #region "Custom methods"
		
        #endregion "Custom methods"
    }
}
