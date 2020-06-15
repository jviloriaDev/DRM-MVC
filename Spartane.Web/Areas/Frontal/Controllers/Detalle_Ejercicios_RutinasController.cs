using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Ejercicios_Rutinas;
using Spartane.Core.Domain.Ejercicios;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Ejercicios_Rutinas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Ejercicios_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Ejercicios;

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
    public class Detalle_Ejercicios_RutinasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Ejercicios_RutinasService service = null;
        private IDetalle_Ejercicios_RutinasApiConsumer _IDetalle_Ejercicios_RutinasApiConsumer;
        private IEjerciciosApiConsumer _IEjerciciosApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Ejercicios_RutinasController(IDetalle_Ejercicios_RutinasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Ejercicios_RutinasApiConsumer Detalle_Ejercicios_RutinasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IEjerciciosApiConsumer EjerciciosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Ejercicios_RutinasApiConsumer = Detalle_Ejercicios_RutinasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IEjerciciosApiConsumer = EjerciciosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Ejercicios_Rutinas
        [ObjectAuth(ObjectId = (ModuleObjectId)44575, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44575);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Ejercicios_Rutinas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44575, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44575);
            ViewBag.Permission = permission;
            var varDetalle_Ejercicios_Rutinas = new Detalle_Ejercicios_RutinasModel();
			
            ViewBag.ObjectId = "44575";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Ejercicios_RutinasData = _IDetalle_Ejercicios_RutinasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Ejercicios_Rutinass[0];
                if (Detalle_Ejercicios_RutinasData == null)
                    return HttpNotFound();

                varDetalle_Ejercicios_Rutinas = new Detalle_Ejercicios_RutinasModel
                {
                    Folio = (int)Detalle_Ejercicios_RutinasData.Folio
                    ,Orden_de_realizacion = Detalle_Ejercicios_RutinasData.Orden_de_realizacion
                    ,Numero_de_serie = Detalle_Ejercicios_RutinasData.Numero_de_serie
                    ,Ejercicio = Detalle_Ejercicios_RutinasData.Ejercicio
                    ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(Convert.ToString(Detalle_Ejercicios_RutinasData.Ejercicio), "Ejercicios") ??  (string)Detalle_Ejercicios_RutinasData.Ejercicio_Ejercicios.Nombre_del_Ejercicio
                    ,Cantidad_de_Repeticiones = Detalle_Ejercicios_RutinasData.Cantidad_de_Repeticiones

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ejercicioss_Ejercicio = _IEjerciciosApiConsumer.SelAll(true);
            if (Ejercicioss_Ejercicio != null && Ejercicioss_Ejercicio.Resource != null)
                ViewBag.Ejercicioss_Ejercicio = Ejercicioss_Ejercicio.Resource.Where(m => m.Nombre_del_Ejercicio != null).OrderBy(m => m.Nombre_del_Ejercicio).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ejercicios", "Nombre_del_Ejercicio") ?? m.Nombre_del_Ejercicio.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Ejercicios_Rutinas);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Ejercicios_Rutinas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44575);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Ejercicios_RutinasModel varDetalle_Ejercicios_Rutinas= new Detalle_Ejercicios_RutinasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Ejercicios_RutinassData = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll(0, 1000, "Detalle_Ejercicios_Rutinas.Folio=" + id, "").Resource.Detalle_Ejercicios_Rutinass;
				
				if (Detalle_Ejercicios_RutinassData != null && Detalle_Ejercicios_RutinassData.Count > 0)
                {
					var Detalle_Ejercicios_RutinasData = Detalle_Ejercicios_RutinassData.First();
					varDetalle_Ejercicios_Rutinas= new Detalle_Ejercicios_RutinasModel
					{
						Folio  = Detalle_Ejercicios_RutinasData.Folio 
	                    ,Orden_de_realizacion = Detalle_Ejercicios_RutinasData.Orden_de_realizacion
                    ,Numero_de_serie = Detalle_Ejercicios_RutinasData.Numero_de_serie
                    ,Ejercicio = Detalle_Ejercicios_RutinasData.Ejercicio
                    ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(Convert.ToString(Detalle_Ejercicios_RutinasData.Ejercicio), "Ejercicios") ??  (string)Detalle_Ejercicios_RutinasData.Ejercicio_Ejercicios.Nombre_del_Ejercicio
                    ,Cantidad_de_Repeticiones = Detalle_Ejercicios_RutinasData.Cantidad_de_Repeticiones

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ejercicioss_Ejercicio = _IEjerciciosApiConsumer.SelAll(true);
            if (Ejercicioss_Ejercicio != null && Ejercicioss_Ejercicio.Resource != null)
                ViewBag.Ejercicioss_Ejercicio = Ejercicioss_Ejercicio.Resource.Where(m => m.Nombre_del_Ejercicio != null).OrderBy(m => m.Nombre_del_Ejercicio).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ejercicios", "Nombre_del_Ejercicio") ?? m.Nombre_del_Ejercicio.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Ejercicios_Rutinas", varDetalle_Ejercicios_Rutinas);
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
        public ActionResult GetEjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEjerciciosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Ejercicio).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ejercicios", "Nombre_del_Ejercicio")?? m.Nombre_del_Ejercicio,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Ejercicios_RutinasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Ejercicios_Rutinass == null)
                result.Detalle_Ejercicios_Rutinass = new List<Detalle_Ejercicios_Rutinas>();

            return Json(new
            {
                data = result.Detalle_Ejercicios_Rutinass.Select(m => new Detalle_Ejercicios_RutinasGridModel
                    {
                    Folio = m.Folio
			,Orden_de_realizacion = m.Orden_de_realizacion
			,Numero_de_serie = m.Numero_de_serie
                        ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(m.Ejercicio_Ejercicios.Clave.ToString(), "Nombre_del_Ejercicio") ?? (string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
			,Cantidad_de_Repeticiones = m.Cantidad_de_Repeticiones

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
                _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Ejercicios_Rutinas varDetalle_Ejercicios_Rutinas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Ejercicios_RutinasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Ejercicios_RutinasModel varDetalle_Ejercicios_Rutinas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Ejercicios_RutinasInfo = new Detalle_Ejercicios_Rutinas
                    {
                        Folio = varDetalle_Ejercicios_Rutinas.Folio
                        ,Orden_de_realizacion = varDetalle_Ejercicios_Rutinas.Orden_de_realizacion
                        ,Numero_de_serie = varDetalle_Ejercicios_Rutinas.Numero_de_serie
                        ,Ejercicio = varDetalle_Ejercicios_Rutinas.Ejercicio
                        ,Cantidad_de_Repeticiones = varDetalle_Ejercicios_Rutinas.Cantidad_de_Repeticiones

                    };

                    result = !IsNew ?
                        _IDetalle_Ejercicios_RutinasApiConsumer.Update(Detalle_Ejercicios_RutinasInfo, null, null).Resource.ToString() :
                         _IDetalle_Ejercicios_RutinasApiConsumer.Insert(Detalle_Ejercicios_RutinasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Ejercicios_Rutinas script
        /// </summary>
        /// <param name="oDetalle_Ejercicios_RutinasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Ejercicios_RutinasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Ejercicios_RutinasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Ejercicios_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Ejercicios_RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Ejercicios_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Ejercicios_RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Ejercicios_RutinasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Ejercicios_Rutinas.js")))
            {
                strDetalle_Ejercicios_RutinasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Ejercicios_Rutinas element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Ejercicios_RutinasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Ejercicios_RutinasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Ejercicios_RutinasScript.Substring(indexOfArray, strDetalle_Ejercicios_RutinasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Ejercicios_RutinasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Ejercicios_RutinasScript.Substring(indexOfArrayHistory, strDetalle_Ejercicios_RutinasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Ejercicios_RutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Ejercicios_RutinasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Ejercicios_RutinasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Ejercicios_RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Ejercicios_RutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Ejercicios_RutinasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Ejercicios_RutinasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Ejercicios_RutinasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Ejercicios_Rutinas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Ejercicios_Rutinas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Ejercicios_Rutinas.js")))
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
        public ActionResult Detalle_Ejercicios_RutinasPropertyBag()
        {
            return PartialView("Detalle_Ejercicios_RutinasPropertyBag", "Detalle_Ejercicios_Rutinas");
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

            _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Ejercicios_RutinasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Ejercicios_Rutinass == null)
                result.Detalle_Ejercicios_Rutinass = new List<Detalle_Ejercicios_Rutinas>();

            var data = result.Detalle_Ejercicios_Rutinass.Select(m => new Detalle_Ejercicios_RutinasGridModel
            {
                Folio = m.Folio
                ,Orden_de_realizacion = m.Orden_de_realizacion
                ,Numero_de_serie = m.Numero_de_serie
                ,EjercicioNombre_del_Ejercicio = (string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
                ,Cantidad_de_Repeticiones = m.Cantidad_de_Repeticiones

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Ejercicios_RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Ejercicios_RutinasList_" + DateTime.Now.ToString());
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

            _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Ejercicios_RutinasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Ejercicios_Rutinass == null)
                result.Detalle_Ejercicios_Rutinass = new List<Detalle_Ejercicios_Rutinas>();

            var data = result.Detalle_Ejercicios_Rutinass.Select(m => new Detalle_Ejercicios_RutinasGridModel
            {
                Folio = m.Folio
                ,Orden_de_realizacion = m.Orden_de_realizacion
                ,Numero_de_serie = m.Numero_de_serie
                ,EjercicioNombre_del_Ejercicio = (string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
                ,Cantidad_de_Repeticiones = m.Cantidad_de_Repeticiones

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
