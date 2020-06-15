using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Contratos_Empresa;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Tipos_de_Contrato;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Contratos_Empresa;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Contratos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Contrato;

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
    public class Detalle_Contratos_EmpresaController : Controller
    {
        #region "variable declaration"

        private IDetalle_Contratos_EmpresaService service = null;
        private IDetalle_Contratos_EmpresaApiConsumer _IDetalle_Contratos_EmpresaApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private ITipos_de_ContratoApiConsumer _ITipos_de_ContratoApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Contratos_EmpresaController(IDetalle_Contratos_EmpresaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Contratos_EmpresaApiConsumer Detalle_Contratos_EmpresaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , ITipos_de_ContratoApiConsumer Tipos_de_ContratoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Contratos_EmpresaApiConsumer = Detalle_Contratos_EmpresaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._ITipos_de_ContratoApiConsumer = Tipos_de_ContratoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Contratos_Empresa
        [ObjectAuth(ObjectId = (ModuleObjectId)44413, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44413);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Contratos_Empresa/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44413, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44413);
            ViewBag.Permission = permission;
            var varDetalle_Contratos_Empresa = new Detalle_Contratos_EmpresaModel();
			
            ViewBag.ObjectId = "44413";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Contratos_EmpresaData = _IDetalle_Contratos_EmpresaApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Contratos_Empresas[0];
                if (Detalle_Contratos_EmpresaData == null)
                    return HttpNotFound();

                varDetalle_Contratos_Empresa = new Detalle_Contratos_EmpresaModel
                {
                    Folio = (int)Detalle_Contratos_EmpresaData.Folio
                    ,Suscripcion = Detalle_Contratos_EmpresaData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contratos_EmpresaData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Contratos_EmpresaData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Tipo_de_Contrato = Detalle_Contratos_EmpresaData.Tipo_de_Contrato
                    ,Tipo_de_ContratoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contratos_EmpresaData.Tipo_de_Contrato), "Tipos_de_Contrato") ??  (string)Detalle_Contratos_EmpresaData.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
                    ,Documento = Detalle_Contratos_EmpresaData.Documento
                    ,Fecha_de_Firma_de_Contrato = (Detalle_Contratos_EmpresaData.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(Detalle_Contratos_EmpresaData.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.DocumentoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Contratos_Empresa.Documento).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipos_de_ContratoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Contratos_Tipo_de_Contrato = _ITipos_de_ContratoApiConsumer.SelAll(true);
            if (Tipos_de_Contratos_Tipo_de_Contrato != null && Tipos_de_Contratos_Tipo_de_Contrato.Resource != null)
                ViewBag.Tipos_de_Contratos_Tipo_de_Contrato = Tipos_de_Contratos_Tipo_de_Contrato.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Contrato", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Contratos_Empresa);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Contratos_Empresa(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44413);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Contratos_EmpresaModel varDetalle_Contratos_Empresa= new Detalle_Contratos_EmpresaModel();


            if (id.ToString() != "0")
            {
                var Detalle_Contratos_EmpresasData = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll(0, 1000, "Detalle_Contratos_Empresa.Folio=" + id, "").Resource.Detalle_Contratos_Empresas;
				
				if (Detalle_Contratos_EmpresasData != null && Detalle_Contratos_EmpresasData.Count > 0)
                {
					var Detalle_Contratos_EmpresaData = Detalle_Contratos_EmpresasData.First();
					varDetalle_Contratos_Empresa= new Detalle_Contratos_EmpresaModel
					{
						Folio  = Detalle_Contratos_EmpresaData.Folio 
	                    ,Suscripcion = Detalle_Contratos_EmpresaData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contratos_EmpresaData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Contratos_EmpresaData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Tipo_de_Contrato = Detalle_Contratos_EmpresaData.Tipo_de_Contrato
                    ,Tipo_de_ContratoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Contratos_EmpresaData.Tipo_de_Contrato), "Tipos_de_Contrato") ??  (string)Detalle_Contratos_EmpresaData.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
                    ,Documento = Detalle_Contratos_EmpresaData.Documento
                    ,Fecha_de_Firma_de_Contrato = (Detalle_Contratos_EmpresaData.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(Detalle_Contratos_EmpresaData.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.DocumentoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Contratos_Empresa.Documento).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipos_de_ContratoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Contratos_Tipo_de_Contrato = _ITipos_de_ContratoApiConsumer.SelAll(true);
            if (Tipos_de_Contratos_Tipo_de_Contrato != null && Tipos_de_Contratos_Tipo_de_Contrato.Resource != null)
                ViewBag.Tipos_de_Contratos_Tipo_de_Contrato = Tipos_de_Contratos_Tipo_de_Contrato.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Contrato", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Contratos_Empresa", varDetalle_Contratos_Empresa);
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
        public ActionResult GetPlanes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan")?? m.Nombre_del_Plan,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipos_de_ContratoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_ContratoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_ContratoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Contrato", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Contratos_EmpresaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Contratos_Empresas == null)
                result.Detalle_Contratos_Empresas = new List<Detalle_Contratos_Empresa>();

            return Json(new
            {
                data = result.Detalle_Contratos_Empresas.Select(m => new Detalle_Contratos_EmpresaGridModel
                    {
                    Folio = m.Folio
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                        ,Tipo_de_ContratoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Contrato_Tipos_de_Contrato.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
			,Documento = m.Documento
                        ,Fecha_de_Firma_de_Contrato = (m.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))

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
                _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Contratos_Empresa varDetalle_Contratos_Empresa = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Contratos_EmpresaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Contratos_EmpresaModel varDetalle_Contratos_Empresa)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_Contratos_Empresa.DocumentoRemoveAttachment != 0 && varDetalle_Contratos_Empresa.DocumentoFile == null)
                    {
                        varDetalle_Contratos_Empresa.Documento = 0;
                    }

                    if (varDetalle_Contratos_Empresa.DocumentoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Contratos_Empresa.DocumentoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Contratos_Empresa.Documento = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Contratos_Empresa.DocumentoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_Contratos_EmpresaInfo = new Detalle_Contratos_Empresa
                    {
                        Folio = varDetalle_Contratos_Empresa.Folio
                        ,Suscripcion = varDetalle_Contratos_Empresa.Suscripcion
                        ,Tipo_de_Contrato = varDetalle_Contratos_Empresa.Tipo_de_Contrato
                        ,Documento = (varDetalle_Contratos_Empresa.Documento.HasValue && varDetalle_Contratos_Empresa.Documento != 0) ? ((int?)Convert.ToInt32(varDetalle_Contratos_Empresa.Documento.Value)) : null

                        ,Fecha_de_Firma_de_Contrato = (!String.IsNullOrEmpty(varDetalle_Contratos_Empresa.Fecha_de_Firma_de_Contrato)) ? DateTime.ParseExact(varDetalle_Contratos_Empresa.Fecha_de_Firma_de_Contrato, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                    };

                    result = !IsNew ?
                        _IDetalle_Contratos_EmpresaApiConsumer.Update(Detalle_Contratos_EmpresaInfo, null, null).Resource.ToString() :
                         _IDetalle_Contratos_EmpresaApiConsumer.Insert(Detalle_Contratos_EmpresaInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Contratos_Empresa script
        /// </summary>
        /// <param name="oDetalle_Contratos_EmpresaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Contratos_EmpresaModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Contratos_EmpresaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Contratos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Contratos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Contratos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Contratos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Contratos_EmpresaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Contratos_Empresa.js")))
            {
                strDetalle_Contratos_EmpresaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Contratos_Empresa element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Contratos_EmpresaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Contratos_EmpresaScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Contratos_EmpresaScript.Substring(indexOfArray, strDetalle_Contratos_EmpresaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Contratos_EmpresaScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Contratos_EmpresaScript.Substring(indexOfArrayHistory, strDetalle_Contratos_EmpresaScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Contratos_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Contratos_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Contratos_EmpresaScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Contratos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Contratos_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Contratos_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Contratos_EmpresaScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Contratos_EmpresaScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Contratos_Empresa.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Contratos_Empresa.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Contratos_Empresa.js")))
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
        public ActionResult Detalle_Contratos_EmpresaPropertyBag()
        {
            return PartialView("Detalle_Contratos_EmpresaPropertyBag", "Detalle_Contratos_Empresa");
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

            _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Contratos_EmpresaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Contratos_Empresas == null)
                result.Detalle_Contratos_Empresas = new List<Detalle_Contratos_Empresa>();

            var data = result.Detalle_Contratos_Empresas.Select(m => new Detalle_Contratos_EmpresaGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Tipo_de_ContratoDescripcion = (string)m.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
                ,Fecha_de_Firma_de_Contrato = (m.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Contratos_EmpresaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Contratos_EmpresaList_" + DateTime.Now.ToString());
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

            _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Contratos_EmpresaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Contratos_Empresas == null)
                result.Detalle_Contratos_Empresas = new List<Detalle_Contratos_Empresa>();

            var data = result.Detalle_Contratos_Empresas.Select(m => new Detalle_Contratos_EmpresaGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Tipo_de_ContratoDescripcion = (string)m.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
                ,Fecha_de_Firma_de_Contrato = (m.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
