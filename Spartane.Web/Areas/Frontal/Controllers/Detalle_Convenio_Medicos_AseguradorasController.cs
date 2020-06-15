using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Core.Domain.Aseguradoras;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Web.Areas.WebApiConsumer.Aseguradoras;

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
    public class Detalle_Convenio_Medicos_AseguradorasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Convenio_Medicos_AseguradorasService service = null;
        private IDetalle_Convenio_Medicos_AseguradorasApiConsumer _IDetalle_Convenio_Medicos_AseguradorasApiConsumer;
        private IAseguradorasApiConsumer _IAseguradorasApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Convenio_Medicos_AseguradorasController(IDetalle_Convenio_Medicos_AseguradorasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Convenio_Medicos_AseguradorasApiConsumer Detalle_Convenio_Medicos_AseguradorasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IAseguradorasApiConsumer AseguradorasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Convenio_Medicos_AseguradorasApiConsumer = Detalle_Convenio_Medicos_AseguradorasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IAseguradorasApiConsumer = AseguradorasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Convenio_Medicos_Aseguradoras
        [ObjectAuth(ObjectId = (ModuleObjectId)44421, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44421);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Convenio_Medicos_Aseguradoras/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44421, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44421);
            ViewBag.Permission = permission;
            var varDetalle_Convenio_Medicos_Aseguradoras = new Detalle_Convenio_Medicos_AseguradorasModel();
			
            ViewBag.ObjectId = "44421";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Convenio_Medicos_AseguradorasData = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Convenio_Medicos_Aseguradorass[0];
                if (Detalle_Convenio_Medicos_AseguradorasData == null)
                    return HttpNotFound();

                varDetalle_Convenio_Medicos_Aseguradoras = new Detalle_Convenio_Medicos_AseguradorasModel
                {
                    Folio = (int)Detalle_Convenio_Medicos_AseguradorasData.Folio
                    ,Aseguradora_medico = Detalle_Convenio_Medicos_AseguradorasData.Aseguradora_medico
                    ,Aseguradora_medicoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Convenio_Medicos_AseguradorasData.Aseguradora_medico), "Aseguradoras") ??  (string)Detalle_Convenio_Medicos_AseguradorasData.Aseguradora_medico_Aseguradoras.Nombre

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IAseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Aseguradorass_Aseguradora_medico = _IAseguradorasApiConsumer.SelAll(true);
            if (Aseguradorass_Aseguradora_medico != null && Aseguradorass_Aseguradora_medico.Resource != null)
                ViewBag.Aseguradorass_Aseguradora_medico = Aseguradorass_Aseguradora_medico.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Aseguradoras", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Convenio_Medicos_Aseguradoras);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Convenio_Medicos_Aseguradoras(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44421);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Convenio_Medicos_AseguradorasModel varDetalle_Convenio_Medicos_Aseguradoras= new Detalle_Convenio_Medicos_AseguradorasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Convenio_Medicos_AseguradorassData = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll(0, 1000, "Detalle_Convenio_Medicos_Aseguradoras.Folio=" + id, "").Resource.Detalle_Convenio_Medicos_Aseguradorass;
				
				if (Detalle_Convenio_Medicos_AseguradorassData != null && Detalle_Convenio_Medicos_AseguradorassData.Count > 0)
                {
					var Detalle_Convenio_Medicos_AseguradorasData = Detalle_Convenio_Medicos_AseguradorassData.First();
					varDetalle_Convenio_Medicos_Aseguradoras= new Detalle_Convenio_Medicos_AseguradorasModel
					{
						Folio  = Detalle_Convenio_Medicos_AseguradorasData.Folio 
	                    ,Aseguradora_medico = Detalle_Convenio_Medicos_AseguradorasData.Aseguradora_medico
                    ,Aseguradora_medicoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Convenio_Medicos_AseguradorasData.Aseguradora_medico), "Aseguradoras") ??  (string)Detalle_Convenio_Medicos_AseguradorasData.Aseguradora_medico_Aseguradoras.Nombre

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IAseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Aseguradorass_Aseguradora_medico = _IAseguradorasApiConsumer.SelAll(true);
            if (Aseguradorass_Aseguradora_medico != null && Aseguradorass_Aseguradora_medico.Resource != null)
                ViewBag.Aseguradorass_Aseguradora_medico = Aseguradorass_Aseguradora_medico.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Aseguradoras", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Convenio_Medicos_Aseguradoras", varDetalle_Convenio_Medicos_Aseguradoras);
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
        public ActionResult GetAseguradorasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IAseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IAseguradorasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Aseguradoras", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Convenio_Medicos_AseguradorasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Convenio_Medicos_Aseguradorass == null)
                result.Detalle_Convenio_Medicos_Aseguradorass = new List<Detalle_Convenio_Medicos_Aseguradoras>();

            return Json(new
            {
                data = result.Detalle_Convenio_Medicos_Aseguradorass.Select(m => new Detalle_Convenio_Medicos_AseguradorasGridModel
                    {
                    Folio = m.Folio
                        ,Aseguradora_medicoNombre = CultureHelper.GetTraduction(m.Aseguradora_medico_Aseguradoras.Folio.ToString(), "Nombre") ?? (string)m.Aseguradora_medico_Aseguradoras.Nombre

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
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
                _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Convenio_Medicos_Aseguradoras varDetalle_Convenio_Medicos_Aseguradoras = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Convenio_Medicos_AseguradorasModel varDetalle_Convenio_Medicos_Aseguradoras)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Convenio_Medicos_AseguradorasInfo = new Detalle_Convenio_Medicos_Aseguradoras
                    {
                        Folio = varDetalle_Convenio_Medicos_Aseguradoras.Folio
                        ,Aseguradora_medico = varDetalle_Convenio_Medicos_Aseguradoras.Aseguradora_medico

                    };

                    result = !IsNew ?
                        _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Update(Detalle_Convenio_Medicos_AseguradorasInfo, null, null).Resource.ToString() :
                         _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Insert(Detalle_Convenio_Medicos_AseguradorasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Convenio_Medicos_Aseguradoras script
        /// </summary>
        /// <param name="oDetalle_Convenio_Medicos_AseguradorasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Convenio_Medicos_AseguradorasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Convenio_Medicos_AseguradorasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Convenio_Medicos_Aseguradoras.js")))
            {
                strDetalle_Convenio_Medicos_AseguradorasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Convenio_Medicos_Aseguradoras element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Convenio_Medicos_AseguradorasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Convenio_Medicos_AseguradorasScript.Substring(indexOfArray, strDetalle_Convenio_Medicos_AseguradorasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Convenio_Medicos_AseguradorasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Convenio_Medicos_AseguradorasScript.Substring(indexOfArrayHistory, strDetalle_Convenio_Medicos_AseguradorasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Convenio_Medicos_AseguradorasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Convenio_Medicos_AseguradorasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Convenio_Medicos_AseguradorasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Convenio_Medicos_AseguradorasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Convenio_Medicos_AseguradorasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Convenio_Medicos_AseguradorasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Convenio_Medicos_AseguradorasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Convenio_Medicos_AseguradorasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Convenio_Medicos_Aseguradoras.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Convenio_Medicos_Aseguradoras.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Convenio_Medicos_Aseguradoras.js")))
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
        public ActionResult Detalle_Convenio_Medicos_AseguradorasPropertyBag()
        {
            return PartialView("Detalle_Convenio_Medicos_AseguradorasPropertyBag", "Detalle_Convenio_Medicos_Aseguradoras");
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

            _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Convenio_Medicos_AseguradorasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Convenio_Medicos_Aseguradorass == null)
                result.Detalle_Convenio_Medicos_Aseguradorass = new List<Detalle_Convenio_Medicos_Aseguradoras>();

            var data = result.Detalle_Convenio_Medicos_Aseguradorass.Select(m => new Detalle_Convenio_Medicos_AseguradorasGridModel
            {
                Folio = m.Folio
                ,Aseguradora_medicoNombre = (string)m.Aseguradora_medico_Aseguradoras.Nombre

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Convenio_Medicos_AseguradorasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Convenio_Medicos_AseguradorasList_" + DateTime.Now.ToString());
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

            _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Convenio_Medicos_AseguradorasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Convenio_Medicos_Aseguradorass == null)
                result.Detalle_Convenio_Medicos_Aseguradorass = new List<Detalle_Convenio_Medicos_Aseguradoras>();

            var data = result.Detalle_Convenio_Medicos_Aseguradorass.Select(m => new Detalle_Convenio_Medicos_AseguradorasGridModel
            {
                Folio = m.Folio
                ,Aseguradora_medicoNombre = (string)m.Aseguradora_medico_Aseguradoras.Nombre

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
