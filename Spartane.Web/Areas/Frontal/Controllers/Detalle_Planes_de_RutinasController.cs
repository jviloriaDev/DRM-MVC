using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Planes_de_Rutinas;
using Spartane.Core.Domain.Dias_de_la_semana;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Planes_de_Rutinas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Dias_de_la_semana;

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
    public class Detalle_Planes_de_RutinasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Planes_de_RutinasService service = null;
        private IDetalle_Planes_de_RutinasApiConsumer _IDetalle_Planes_de_RutinasApiConsumer;
        private IDias_de_la_semanaApiConsumer _IDias_de_la_semanaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Planes_de_RutinasController(IDetalle_Planes_de_RutinasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Planes_de_RutinasApiConsumer Detalle_Planes_de_RutinasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IDias_de_la_semanaApiConsumer Dias_de_la_semanaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Planes_de_RutinasApiConsumer = Detalle_Planes_de_RutinasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IDias_de_la_semanaApiConsumer = Dias_de_la_semanaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Planes_de_Rutinas
        [ObjectAuth(ObjectId = (ModuleObjectId)44571, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44571);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Planes_de_Rutinas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44571, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44571);
            ViewBag.Permission = permission;
            var varDetalle_Planes_de_Rutinas = new Detalle_Planes_de_RutinasModel();
			
            ViewBag.ObjectId = "44571";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Planes_de_RutinasData = _IDetalle_Planes_de_RutinasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Planes_de_Rutinass[0];
                if (Detalle_Planes_de_RutinasData == null)
                    return HttpNotFound();

                varDetalle_Planes_de_Rutinas = new Detalle_Planes_de_RutinasModel
                {
                    Folio = (int)Detalle_Planes_de_RutinasData.Folio
                    ,Numero_de_Dia = Detalle_Planes_de_RutinasData.Numero_de_Dia
                    ,Numero_de_DiaDia = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_RutinasData.Numero_de_Dia), "Dias_de_la_semana") ??  (string)Detalle_Planes_de_RutinasData.Numero_de_Dia_Dias_de_la_semana.Dia
                    ,Fecha = (Detalle_Planes_de_RutinasData.Fecha == null ? string.Empty : Convert.ToDateTime(Detalle_Planes_de_RutinasData.Fecha).ToString(ConfigurationProperty.DateFormat))
                    ,Realizado = Detalle_Planes_de_RutinasData.Realizado.GetValueOrDefault()

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IDias_de_la_semanaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dias_de_la_semanas_Numero_de_Dia = _IDias_de_la_semanaApiConsumer.SelAll(true);
            if (Dias_de_la_semanas_Numero_de_Dia != null && Dias_de_la_semanas_Numero_de_Dia.Resource != null)
                ViewBag.Dias_de_la_semanas_Numero_de_Dia = Dias_de_la_semanas_Numero_de_Dia.Resource.Where(m => m.Dia != null).OrderBy(m => m.Dia).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dias_de_la_semana", "Dia") ?? m.Dia.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Planes_de_Rutinas);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Planes_de_Rutinas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44571);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Planes_de_RutinasModel varDetalle_Planes_de_Rutinas= new Detalle_Planes_de_RutinasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Planes_de_RutinassData = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll(0, 1000, "Detalle_Planes_de_Rutinas.Folio=" + id, "").Resource.Detalle_Planes_de_Rutinass;
				
				if (Detalle_Planes_de_RutinassData != null && Detalle_Planes_de_RutinassData.Count > 0)
                {
					var Detalle_Planes_de_RutinasData = Detalle_Planes_de_RutinassData.First();
					varDetalle_Planes_de_Rutinas= new Detalle_Planes_de_RutinasModel
					{
						Folio  = Detalle_Planes_de_RutinasData.Folio 
	                    ,Numero_de_Dia = Detalle_Planes_de_RutinasData.Numero_de_Dia
                    ,Numero_de_DiaDia = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_RutinasData.Numero_de_Dia), "Dias_de_la_semana") ??  (string)Detalle_Planes_de_RutinasData.Numero_de_Dia_Dias_de_la_semana.Dia
                    ,Fecha = (Detalle_Planes_de_RutinasData.Fecha == null ? string.Empty : Convert.ToDateTime(Detalle_Planes_de_RutinasData.Fecha).ToString(ConfigurationProperty.DateFormat))
                    ,Realizado = Detalle_Planes_de_RutinasData.Realizado.GetValueOrDefault()

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IDias_de_la_semanaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dias_de_la_semanas_Numero_de_Dia = _IDias_de_la_semanaApiConsumer.SelAll(true);
            if (Dias_de_la_semanas_Numero_de_Dia != null && Dias_de_la_semanas_Numero_de_Dia.Resource != null)
                ViewBag.Dias_de_la_semanas_Numero_de_Dia = Dias_de_la_semanas_Numero_de_Dia.Resource.Where(m => m.Dia != null).OrderBy(m => m.Dia).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dias_de_la_semana", "Dia") ?? m.Dia.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Planes_de_Rutinas", varDetalle_Planes_de_Rutinas);
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
        public ActionResult GetDias_de_la_semanaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDias_de_la_semanaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDias_de_la_semanaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Dia).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dias_de_la_semana", "Dia")?? m.Dia,
                    Value = Convert.ToString(m.Clave)
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Planes_de_RutinasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Planes_de_Rutinass == null)
                result.Detalle_Planes_de_Rutinass = new List<Detalle_Planes_de_Rutinas>();

            return Json(new
            {
                data = result.Detalle_Planes_de_Rutinass.Select(m => new Detalle_Planes_de_RutinasGridModel
                    {
                    Folio = m.Folio
                        ,Numero_de_DiaDia = CultureHelper.GetTraduction(m.Numero_de_Dia_Dias_de_la_semana.Clave.ToString(), "Dia") ?? (string)m.Numero_de_Dia_Dias_de_la_semana.Dia
                        ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Realizado = m.Realizado

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
                _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Planes_de_Rutinas varDetalle_Planes_de_Rutinas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Planes_de_RutinasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Planes_de_RutinasModel varDetalle_Planes_de_Rutinas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Planes_de_RutinasInfo = new Detalle_Planes_de_Rutinas
                    {
                        Folio = varDetalle_Planes_de_Rutinas.Folio
                        ,Numero_de_Dia = varDetalle_Planes_de_Rutinas.Numero_de_Dia
                        ,Fecha = (!String.IsNullOrEmpty(varDetalle_Planes_de_Rutinas.Fecha)) ? DateTime.ParseExact(varDetalle_Planes_de_Rutinas.Fecha, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Realizado = varDetalle_Planes_de_Rutinas.Realizado

                    };

                    result = !IsNew ?
                        _IDetalle_Planes_de_RutinasApiConsumer.Update(Detalle_Planes_de_RutinasInfo, null, null).Resource.ToString() :
                         _IDetalle_Planes_de_RutinasApiConsumer.Insert(Detalle_Planes_de_RutinasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Planes_de_Rutinas script
        /// </summary>
        /// <param name="oDetalle_Planes_de_RutinasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Planes_de_RutinasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Planes_de_RutinasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Rutinas.js")))
            {
                strDetalle_Planes_de_RutinasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Planes_de_Rutinas element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Planes_de_RutinasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Planes_de_RutinasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Planes_de_RutinasScript.Substring(indexOfArray, strDetalle_Planes_de_RutinasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Planes_de_RutinasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Planes_de_RutinasScript.Substring(indexOfArrayHistory, strDetalle_Planes_de_RutinasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Planes_de_RutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Planes_de_RutinasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Planes_de_RutinasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Planes_de_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Planes_de_RutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Planes_de_RutinasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Planes_de_RutinasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Planes_de_RutinasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Rutinas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Rutinas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Rutinas.js")))
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
        public ActionResult Detalle_Planes_de_RutinasPropertyBag()
        {
            return PartialView("Detalle_Planes_de_RutinasPropertyBag", "Detalle_Planes_de_Rutinas");
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

            _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Planes_de_RutinasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Planes_de_Rutinass == null)
                result.Detalle_Planes_de_Rutinass = new List<Detalle_Planes_de_Rutinas>();

            var data = result.Detalle_Planes_de_Rutinass.Select(m => new Detalle_Planes_de_RutinasGridModel
            {
                Folio = m.Folio
                ,Numero_de_DiaDia = (string)m.Numero_de_Dia_Dias_de_la_semana.Dia
                ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
                ,Realizado = m.Realizado

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Planes_de_RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Planes_de_RutinasList_" + DateTime.Now.ToString());
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

            _IDetalle_Planes_de_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Planes_de_RutinasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Planes_de_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Planes_de_Rutinass == null)
                result.Detalle_Planes_de_Rutinass = new List<Detalle_Planes_de_Rutinas>();

            var data = result.Detalle_Planes_de_Rutinass.Select(m => new Detalle_Planes_de_RutinasGridModel
            {
                Folio = m.Folio
                ,Numero_de_DiaDia = (string)m.Numero_de_Dia_Dias_de_la_semana.Dia
                ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
                ,Realizado = m.Realizado

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
