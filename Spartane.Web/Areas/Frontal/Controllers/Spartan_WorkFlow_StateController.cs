using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_WorkFlow_State;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_WorkFlow_StateController : Controller
    {
        #region "variable declaration"

        private ISpartan_WorkFlow_StateService service = null;
        private ISpartan_WorkFlow_StateApiConsumer _ISpartan_WorkFlow_StateApiConsumer;
        private ISpartan_WorkFlow_PhasesApiConsumer _ISpartan_WorkFlow_PhasesApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_WorkFlow_StateController(ISpartan_WorkFlow_StateService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_WorkFlow_StateApiConsumer Spartan_WorkFlow_StateApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_WorkFlow_PhasesApiConsumer Spartan_WorkFlow_PhasesApiConsumer , ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_WorkFlow_StateApiConsumer = Spartan_WorkFlow_StateApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_WorkFlow_State
        [ObjectAuth(ObjectId = (ModuleObjectId)127, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 127);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_WorkFlow_State/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)127, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 127);
            ViewBag.Permission = permission;
            var varSpartan_WorkFlow_State = new Spartan_WorkFlow_StateModel();
			
            ViewBag.ObjectId = "127";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_WorkFlow_StateData = _ISpartan_WorkFlow_StateApiConsumer.GetByKeyComplete(Id).Resource.Spartan_WorkFlow_States[0];
                if (Spartan_WorkFlow_StateData == null)
                    return HttpNotFound();

                varSpartan_WorkFlow_State = new Spartan_WorkFlow_StateModel
                {
                    StateId = (int)Spartan_WorkFlow_StateData.StateId
                    ,Phase = Spartan_WorkFlow_StateData.Phase
                    ,PhaseName =  (string)Spartan_WorkFlow_StateData.Phase_Spartan_WorkFlow_Phases.Name
                    ,Attribute = Spartan_WorkFlow_StateData.Attribute
                    ,AttributeLogical_Name =  (string)Spartan_WorkFlow_StateData.Attribute_Spartan_Metadata.Logical_Name
                    ,State_Code = Spartan_WorkFlow_StateData.State_Code
                    ,Name = Spartan_WorkFlow_StateData.Name
                    ,Value = Spartan_WorkFlow_StateData.Value
                    ,Text = Spartan_WorkFlow_StateData.Text

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Phasess_Phase = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Phasess_Phase != null && Spartan_WorkFlow_Phasess_Phase.Resource != null)
                ViewBag.Spartan_WorkFlow_Phasess_Phase = Spartan_WorkFlow_Phasess_Phase.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.PhasesId)
                }).ToList();
   _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_Attribute = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_Attribute != null && Spartan_Metadatas_Attribute.Resource != null)
                ViewBag.Spartan_Metadatas_Attribute = Spartan_Metadatas_Attribute.Resource.OrderBy(m => m.Logical_Name).Select(m => new SelectListItem
                {
                    Text = m.Logical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_WorkFlow_State);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_WorkFlow_State(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 127);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_WorkFlow_StateModel varSpartan_WorkFlow_State= new Spartan_WorkFlow_StateModel();


            if (id.ToString() != "0")
            {
                var Spartan_WorkFlow_StatesData = _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll(0, 1000, "StateId=" + id, "").Resource.Spartan_WorkFlow_States;
				
				if (Spartan_WorkFlow_StatesData != null && Spartan_WorkFlow_StatesData.Count > 0)
                {
					var Spartan_WorkFlow_StateData = Spartan_WorkFlow_StatesData.First();
					varSpartan_WorkFlow_State= new Spartan_WorkFlow_StateModel
					{
						StateId  = Spartan_WorkFlow_StateData.StateId 
	                    ,Phase = Spartan_WorkFlow_StateData.Phase
                    ,PhaseName =  (string)Spartan_WorkFlow_StateData.Phase_Spartan_WorkFlow_Phases.Name
                    ,Attribute = Spartan_WorkFlow_StateData.Attribute
                    ,AttributeLogical_Name =  (string)Spartan_WorkFlow_StateData.Attribute_Spartan_Metadata.Logical_Name
                    ,State_Code = Spartan_WorkFlow_StateData.State_Code
                    ,Name = Spartan_WorkFlow_StateData.Name
                    ,Value = Spartan_WorkFlow_StateData.Value
                    ,Text = Spartan_WorkFlow_StateData.Text

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Phasess_Phase = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Phasess_Phase != null && Spartan_WorkFlow_Phasess_Phase.Resource != null)
                ViewBag.Spartan_WorkFlow_Phasess_Phase = Spartan_WorkFlow_Phasess_Phase.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.PhasesId)
                }).ToList();
   _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_Attribute = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_Attribute != null && Spartan_Metadatas_Attribute.Resource != null)
                ViewBag.Spartan_Metadatas_Attribute = Spartan_Metadatas_Attribute.Resource.OrderBy(m => m.Logical_Name).Select(m => new SelectListItem
                {
                    Text = m.Logical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            return PartialView("AddSpartan_WorkFlow_State", varSpartan_WorkFlow_State);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_PhasesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_MetadataAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_StatePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_States == null)
                result.Spartan_WorkFlow_States = new List<Spartan_WorkFlow_State>();

            return Json(new
            {
                data = result.Spartan_WorkFlow_States.Select(m => new Spartan_WorkFlow_StateGridModel
                    {
                    StateId = m.StateId
                        ,PhaseName = (string)m.Phase_Spartan_WorkFlow_Phases.Name
                        ,AttributeLogical_Name = (string)m.Attribute_Spartan_Metadata.Logical_Name
			,State_Code = m.State_Code
			,Name = m.Name
			,Value = m.Value
			,Text = m.Text

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetSpartan_WorkFlow_State_Attribute_Spartan_Metadata(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartan_MetadataApiConsumer.ListaSelAll(1, 20, " (cast(Spartan_Metadata.AttributeId as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Spartan_Metadata.Logical_Name as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where, " Spartan_Metadata.Logical_Name ASC ").Resource;
                return Json(result.Spartan_Metadatas.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





       

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_WorkFlow_State varSpartan_WorkFlow_State = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_WorkFlow_StateApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_WorkFlow_StateModel varSpartan_WorkFlow_State)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_WorkFlow_StateInfo = new Spartan_WorkFlow_State
                    {
                        StateId = varSpartan_WorkFlow_State.StateId
                        ,Phase = varSpartan_WorkFlow_State.Phase
                        ,Attribute = varSpartan_WorkFlow_State.Attribute
                        ,State_Code = varSpartan_WorkFlow_State.State_Code
                        ,Name = varSpartan_WorkFlow_State.Name
                        ,Value = varSpartan_WorkFlow_State.Value
                        ,Text = varSpartan_WorkFlow_State.Text

                    };

                    result = !IsNew ?
                        _ISpartan_WorkFlow_StateApiConsumer.Update(Spartan_WorkFlow_StateInfo, null, null).Resource.ToString() :
                         _ISpartan_WorkFlow_StateApiConsumer.Insert(Spartan_WorkFlow_StateInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_WorkFlow_State script
        /// </summary>
        /// <param name="oSpartan_WorkFlow_StateElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_WorkFlow_StateModuleAttributeList)
        {
            for (int i = 0; i < Spartan_WorkFlow_StateModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_WorkFlow_StateModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_WorkFlow_StateModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_WorkFlow_StateModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_WorkFlow_StateModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_WorkFlow_StateScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_State.js")))
            {
                strSpartan_WorkFlow_StateScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_WorkFlow_State element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_WorkFlow_StateModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_WorkFlow_StateScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_WorkFlow_StateScript.Substring(indexOfArray, strSpartan_WorkFlow_StateScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_WorkFlow_StateScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_WorkFlow_StateScript.Substring(indexOfArrayHistory, strSpartan_WorkFlow_StateScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_WorkFlow_StateScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_WorkFlow_StateScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_WorkFlow_StateScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_WorkFlow_StateModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_WorkFlow_StateScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_WorkFlow_StateScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_WorkFlow_StateScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_WorkFlow_StateScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_State.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_State.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_State.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
				if (indexOfChildArray != -1)
                {
					oCustomElementAttribute.ChildElement = ChildElementList.ToString();
				}
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Spartan_WorkFlow_StatePropertyBag()
        {
            return PartialView("Spartan_WorkFlow_StatePropertyBag", "Spartan_WorkFlow_State");
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



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_StatePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_States == null)
                result.Spartan_WorkFlow_States = new List<Spartan_WorkFlow_State>();

            var data = result.Spartan_WorkFlow_States.Select(m => new Spartan_WorkFlow_StateGridModel
            {
                StateId = m.StateId
                ,State_Code = m.State_Code
                ,Name = m.Name
                ,Value = m.Value
                ,Text = m.Text

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_WorkFlow_StateList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_WorkFlow_StateList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_StatePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_States == null)
                result.Spartan_WorkFlow_States = new List<Spartan_WorkFlow_State>();

            var data = result.Spartan_WorkFlow_States.Select(m => new Spartan_WorkFlow_StateGridModel
            {
                StateId = m.StateId
                ,State_Code = m.State_Code
                ,Name = m.Name
                ,Value = m.Value
                ,Text = m.Text

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
