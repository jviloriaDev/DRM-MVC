using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Contactos_Empresa;
using Spartane.Core.Domain.areas_Empresas;
using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Contactos_Empresa;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Contactos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.areas_Empresas;
using Spartane.Web.Areas.WebApiConsumer.Estatus;

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
    public class Detalle_Contactos_EmpresaController : Controller
    {
        #region "variable declaration"

        private IDetalle_Contactos_EmpresaService service = null;
        private IDetalle_Contactos_EmpresaApiConsumer _IDetalle_Contactos_EmpresaApiConsumer;
        private Iareas_EmpresasApiConsumer _Iareas_EmpresasApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Contactos_EmpresaController(IDetalle_Contactos_EmpresaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Contactos_EmpresaApiConsumer Detalle_Contactos_EmpresaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , Iareas_EmpresasApiConsumer areas_EmpresasApiConsumer , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Contactos_EmpresaApiConsumer = Detalle_Contactos_EmpresaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._Iareas_EmpresasApiConsumer = areas_EmpresasApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Contactos_Empresa
        [ObjectAuth(ObjectId = (ModuleObjectId)44412, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44412);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Contactos_Empresa/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44412, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44412);
            ViewBag.Permission = permission;
            var varDetalle_Contactos_Empresa = new Detalle_Contactos_EmpresaModel();
			
            ViewBag.ObjectId = "44412";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Contactos_EmpresaData = _IDetalle_Contactos_EmpresaApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Contactos_Empresas[0];
                if (Detalle_Contactos_EmpresaData == null)
                    return HttpNotFound();

                varDetalle_Contactos_Empresa = new Detalle_Contactos_EmpresaModel
                {
                    Folio = (int)Detalle_Contactos_EmpresaData.Folio
                    ,Nombre_completo = Detalle_Contactos_EmpresaData.Nombre_completo
                    ,Correo = Detalle_Contactos_EmpresaData.Correo
                    ,Telefono = Detalle_Contactos_EmpresaData.Telefono
                    ,Contacto_Principal = Detalle_Contactos_EmpresaData.Contacto_Principal.GetValueOrDefault()
                    ,Area = Detalle_Contactos_EmpresaData.Area
                    ,AreaNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contactos_EmpresaData.Area), "areas_Empresas") ??  (string)Detalle_Contactos_EmpresaData.Area_areas_Empresas.Nombre
                    ,Acceso_al_Sistema = Detalle_Contactos_EmpresaData.Acceso_al_Sistema.GetValueOrDefault()
                    ,Nombre_de_usuario = Detalle_Contactos_EmpresaData.Nombre_de_usuario
                    ,Recibe_Alertas = Detalle_Contactos_EmpresaData.Recibe_Alertas.GetValueOrDefault()
                    ,Estatus = Detalle_Contactos_EmpresaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contactos_EmpresaData.Estatus), "Estatus") ??  (string)Detalle_Contactos_EmpresaData.Estatus_Estatus.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _Iareas_EmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var areas_Empresass_Area = _Iareas_EmpresasApiConsumer.SelAll(true);
            if (areas_Empresass_Area != null && areas_Empresass_Area.Resource != null)
                ViewBag.areas_Empresass_Area = areas_Empresass_Area.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "areas_Empresas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Contactos_Empresa);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Contactos_Empresa(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44412);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Contactos_EmpresaModel varDetalle_Contactos_Empresa= new Detalle_Contactos_EmpresaModel();


            if (id.ToString() != "0")
            {
                var Detalle_Contactos_EmpresasData = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll(0, 1000, "Detalle_Contactos_Empresa.Folio=" + id, "").Resource.Detalle_Contactos_Empresas;
				
				if (Detalle_Contactos_EmpresasData != null && Detalle_Contactos_EmpresasData.Count > 0)
                {
					var Detalle_Contactos_EmpresaData = Detalle_Contactos_EmpresasData.First();
					varDetalle_Contactos_Empresa= new Detalle_Contactos_EmpresaModel
					{
						Folio  = Detalle_Contactos_EmpresaData.Folio 
	                    ,Nombre_completo = Detalle_Contactos_EmpresaData.Nombre_completo
                    ,Correo = Detalle_Contactos_EmpresaData.Correo
                    ,Telefono = Detalle_Contactos_EmpresaData.Telefono
                    ,Contacto_Principal = Detalle_Contactos_EmpresaData.Contacto_Principal.GetValueOrDefault()
                    ,Area = Detalle_Contactos_EmpresaData.Area
                    ,AreaNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contactos_EmpresaData.Area), "areas_Empresas") ??  (string)Detalle_Contactos_EmpresaData.Area_areas_Empresas.Nombre
                    ,Acceso_al_Sistema = Detalle_Contactos_EmpresaData.Acceso_al_Sistema.GetValueOrDefault()
                    ,Nombre_de_usuario = Detalle_Contactos_EmpresaData.Nombre_de_usuario
                    ,Recibe_Alertas = Detalle_Contactos_EmpresaData.Recibe_Alertas.GetValueOrDefault()
                    ,Estatus = Detalle_Contactos_EmpresaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contactos_EmpresaData.Estatus), "Estatus") ??  (string)Detalle_Contactos_EmpresaData.Estatus_Estatus.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _Iareas_EmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var areas_Empresass_Area = _Iareas_EmpresasApiConsumer.SelAll(true);
            if (areas_Empresass_Area != null && areas_Empresass_Area.Resource != null)
                ViewBag.areas_Empresass_Area = areas_Empresass_Area.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "areas_Empresas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Contactos_Empresa", varDetalle_Contactos_Empresa);
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
        public ActionResult Getareas_EmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _Iareas_EmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _Iareas_EmpresasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "areas_Empresas", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Contactos_EmpresaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Contactos_Empresas == null)
                result.Detalle_Contactos_Empresas = new List<Detalle_Contactos_Empresa>();

            return Json(new
            {
                data = result.Detalle_Contactos_Empresas.Select(m => new Detalle_Contactos_EmpresaGridModel
                    {
                    Folio = m.Folio
			,Nombre_completo = m.Nombre_completo
			,Correo = m.Correo
			,Telefono = m.Telefono
			,Contacto_Principal = m.Contacto_Principal
                        ,AreaNombre = CultureHelper.GetTraduction(m.Area_areas_Empresas.Clave.ToString(), "Nombre") ?? (string)m.Area_areas_Empresas.Nombre
			,Acceso_al_Sistema = m.Acceso_al_Sistema
			,Nombre_de_usuario = m.Nombre_de_usuario
			,Recibe_Alertas = m.Recibe_Alertas
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

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
                _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Contactos_Empresa varDetalle_Contactos_Empresa = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Contactos_EmpresaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Contactos_EmpresaModel varDetalle_Contactos_Empresa)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Contactos_EmpresaInfo = new Detalle_Contactos_Empresa
                    {
                        Folio = varDetalle_Contactos_Empresa.Folio
                        ,Nombre_completo = varDetalle_Contactos_Empresa.Nombre_completo
                        ,Correo = varDetalle_Contactos_Empresa.Correo
                        ,Telefono = varDetalle_Contactos_Empresa.Telefono
                        ,Contacto_Principal = varDetalle_Contactos_Empresa.Contacto_Principal
                        ,Area = varDetalle_Contactos_Empresa.Area
                        ,Acceso_al_Sistema = varDetalle_Contactos_Empresa.Acceso_al_Sistema
                        ,Nombre_de_usuario = varDetalle_Contactos_Empresa.Nombre_de_usuario
                        ,Recibe_Alertas = varDetalle_Contactos_Empresa.Recibe_Alertas
                        ,Estatus = varDetalle_Contactos_Empresa.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Contactos_EmpresaApiConsumer.Update(Detalle_Contactos_EmpresaInfo, null, null).Resource.ToString() :
                         _IDetalle_Contactos_EmpresaApiConsumer.Insert(Detalle_Contactos_EmpresaInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Contactos_Empresa script
        /// </summary>
        /// <param name="oDetalle_Contactos_EmpresaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Contactos_EmpresaModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Contactos_EmpresaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Contactos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Contactos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Contactos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Contactos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Contactos_EmpresaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Contactos_Empresa.js")))
            {
                strDetalle_Contactos_EmpresaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Contactos_Empresa element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Contactos_EmpresaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Contactos_EmpresaScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Contactos_EmpresaScript.Substring(indexOfArray, strDetalle_Contactos_EmpresaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Contactos_EmpresaScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Contactos_EmpresaScript.Substring(indexOfArrayHistory, strDetalle_Contactos_EmpresaScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Contactos_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Contactos_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Contactos_EmpresaScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Contactos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Contactos_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Contactos_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Contactos_EmpresaScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Contactos_EmpresaScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Contactos_Empresa.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Contactos_Empresa.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Contactos_Empresa.js")))
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
        public ActionResult Detalle_Contactos_EmpresaPropertyBag()
        {
            return PartialView("Detalle_Contactos_EmpresaPropertyBag", "Detalle_Contactos_Empresa");
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

            _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Contactos_EmpresaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Contactos_Empresas == null)
                result.Detalle_Contactos_Empresas = new List<Detalle_Contactos_Empresa>();

            var data = result.Detalle_Contactos_Empresas.Select(m => new Detalle_Contactos_EmpresaGridModel
            {
                Folio = m.Folio
                ,Nombre_completo = m.Nombre_completo
                ,Correo = m.Correo
                ,Telefono = m.Telefono
                ,Contacto_Principal = m.Contacto_Principal
                ,AreaNombre = (string)m.Area_areas_Empresas.Nombre
                ,Acceso_al_Sistema = m.Acceso_al_Sistema
                ,Nombre_de_usuario = m.Nombre_de_usuario
                ,Recibe_Alertas = m.Recibe_Alertas
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Contactos_EmpresaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Contactos_EmpresaList_" + DateTime.Now.ToString());
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

            _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Contactos_EmpresaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Contactos_Empresas == null)
                result.Detalle_Contactos_Empresas = new List<Detalle_Contactos_Empresa>();

            var data = result.Detalle_Contactos_Empresas.Select(m => new Detalle_Contactos_EmpresaGridModel
            {
                Folio = m.Folio
                ,Nombre_completo = m.Nombre_completo
                ,Correo = m.Correo
                ,Telefono = m.Telefono
                ,Contacto_Principal = m.Contacto_Principal
                ,AreaNombre = (string)m.Area_areas_Empresas.Nombre
                ,Acceso_al_Sistema = m.Acceso_al_Sistema
                ,Nombre_de_usuario = m.Nombre_de_usuario
                ,Recibe_Alertas = m.Recibe_Alertas
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
