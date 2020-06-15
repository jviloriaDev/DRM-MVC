using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Especialistas_Pacientes;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Estatus_Paciente;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Especialistas_Pacientes;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Especialistas_Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Paciente;

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
    public class Detalle_Especialistas_PacientesController : Controller
    {
        #region "variable declaration"

        private IDetalle_Especialistas_PacientesService service = null;
        private IDetalle_Especialistas_PacientesApiConsumer _IDetalle_Especialistas_PacientesApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;
        private IEstatus_PacienteApiConsumer _IEstatus_PacienteApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Especialistas_PacientesController(IDetalle_Especialistas_PacientesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Especialistas_PacientesApiConsumer Detalle_Especialistas_PacientesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , IEstatus_PacienteApiConsumer Estatus_PacienteApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Especialistas_PacientesApiConsumer = Detalle_Especialistas_PacientesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._IEstatus_PacienteApiConsumer = Estatus_PacienteApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Especialistas_Pacientes
        [ObjectAuth(ObjectId = (ModuleObjectId)44446, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44446);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Especialistas_Pacientes/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44446, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44446);
            ViewBag.Permission = permission;
            var varDetalle_Especialistas_Pacientes = new Detalle_Especialistas_PacientesModel();
			
            ViewBag.ObjectId = "44446";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Especialistas_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Especialistas_PacientesData = _IDetalle_Especialistas_PacientesApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Especialistas_Pacientess[0];
                if (Detalle_Especialistas_PacientesData == null)
                    return HttpNotFound();

                varDetalle_Especialistas_Pacientes = new Detalle_Especialistas_PacientesModel
                {
                    Folio = (int)Detalle_Especialistas_PacientesData.Folio
                    ,Especialista = Detalle_Especialistas_PacientesData.Especialista
                    ,EspecialistaName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Especialistas_PacientesData.Especialista), "Spartan_User") ??  (string)Detalle_Especialistas_PacientesData.Especialista_Spartan_User.Name
                    ,Especialidad = Detalle_Especialistas_PacientesData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Especialistas_PacientesData.Especialidad), "Especialidades") ??  (string)Detalle_Especialistas_PacientesData.Especialidad_Especialidades.Especialidad
                    ,Fecha_inicio = (Detalle_Especialistas_PacientesData.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Especialistas_PacientesData.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Especialistas_PacientesData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Especialistas_PacientesData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Cantidad_consultas = Detalle_Especialistas_PacientesData.Cantidad_consultas
                    ,Principal = Detalle_Especialistas_PacientesData.Principal.GetValueOrDefault()
                    ,Estatus = Detalle_Especialistas_PacientesData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Especialistas_PacientesData.Estatus), "Estatus_Paciente") ??  (string)Detalle_Especialistas_PacientesData.Estatus_Estatus_Paciente.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Especialista = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Especialista != null && Spartan_Users_Especialista.Resource != null)
                ViewBag.Spartan_Users_Especialista = Spartan_Users_Especialista.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Pacientes_Estatus = _IEstatus_PacienteApiConsumer.SelAll(true);
            if (Estatus_Pacientes_Estatus != null && Estatus_Pacientes_Estatus.Resource != null)
                ViewBag.Estatus_Pacientes_Estatus = Estatus_Pacientes_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Especialistas_Pacientes);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Especialistas_Pacientes(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44446);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Especialistas_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Especialistas_PacientesModel varDetalle_Especialistas_Pacientes= new Detalle_Especialistas_PacientesModel();


            if (id.ToString() != "0")
            {
                var Detalle_Especialistas_PacientessData = _IDetalle_Especialistas_PacientesApiConsumer.ListaSelAll(0, 1000, "Detalle_Especialistas_Pacientes.Folio=" + id, "").Resource.Detalle_Especialistas_Pacientess;
				
				if (Detalle_Especialistas_PacientessData != null && Detalle_Especialistas_PacientessData.Count > 0)
                {
					var Detalle_Especialistas_PacientesData = Detalle_Especialistas_PacientessData.First();
					varDetalle_Especialistas_Pacientes= new Detalle_Especialistas_PacientesModel
					{
						Folio  = Detalle_Especialistas_PacientesData.Folio 
	                    ,Especialista = Detalle_Especialistas_PacientesData.Especialista
                    ,EspecialistaName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Especialistas_PacientesData.Especialista), "Spartan_User") ??  (string)Detalle_Especialistas_PacientesData.Especialista_Spartan_User.Name
                    ,Especialidad = Detalle_Especialistas_PacientesData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Especialistas_PacientesData.Especialidad), "Especialidades") ??  (string)Detalle_Especialistas_PacientesData.Especialidad_Especialidades.Especialidad
                    ,Fecha_inicio = (Detalle_Especialistas_PacientesData.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Especialistas_PacientesData.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Especialistas_PacientesData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Especialistas_PacientesData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Cantidad_consultas = Detalle_Especialistas_PacientesData.Cantidad_consultas
                    ,Principal = Detalle_Especialistas_PacientesData.Principal.GetValueOrDefault()
                    ,Estatus = Detalle_Especialistas_PacientesData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Especialistas_PacientesData.Estatus), "Estatus_Paciente") ??  (string)Detalle_Especialistas_PacientesData.Estatus_Estatus_Paciente.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Especialista = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Especialista != null && Spartan_Users_Especialista.Resource != null)
                ViewBag.Spartan_Users_Especialista = Spartan_Users_Especialista.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Pacientes_Estatus = _IEstatus_PacienteApiConsumer.SelAll(true);
            if (Estatus_Pacientes_Estatus != null && Estatus_Pacientes_Estatus.Resource != null)
                ViewBag.Estatus_Pacientes_Estatus = Estatus_Pacientes_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Especialistas_Pacientes", varDetalle_Especialistas_Pacientes);
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
        public ActionResult GetSpartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name")?? m.Name,
                    Value = Convert.ToString(m.Id_User)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEspecialidadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEspecialidadesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad")?? m.Especialidad,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_PacienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Paciente", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Especialistas_PacientesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Especialistas_PacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Especialistas_Pacientess == null)
                result.Detalle_Especialistas_Pacientess = new List<Detalle_Especialistas_Pacientes>();

            return Json(new
            {
                data = result.Detalle_Especialistas_Pacientess.Select(m => new Detalle_Especialistas_PacientesGridModel
                    {
                    Folio = m.Folio
                        ,EspecialistaName = CultureHelper.GetTraduction(m.Especialista_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Especialista_Spartan_User.Name
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_consultas = m.Cantidad_consultas
			,Principal = m.Principal
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Paciente.Descripcion

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
                _IDetalle_Especialistas_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Especialistas_Pacientes varDetalle_Especialistas_Pacientes = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Especialistas_PacientesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Especialistas_PacientesModel varDetalle_Especialistas_Pacientes)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Especialistas_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Especialistas_PacientesInfo = new Detalle_Especialistas_Pacientes
                    {
                        Folio = varDetalle_Especialistas_Pacientes.Folio
                        ,Especialista = varDetalle_Especialistas_Pacientes.Especialista
                        ,Especialidad = varDetalle_Especialistas_Pacientes.Especialidad
                        ,Fecha_inicio = (!String.IsNullOrEmpty(varDetalle_Especialistas_Pacientes.Fecha_inicio)) ? DateTime.ParseExact(varDetalle_Especialistas_Pacientes.Fecha_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin = (!String.IsNullOrEmpty(varDetalle_Especialistas_Pacientes.Fecha_fin)) ? DateTime.ParseExact(varDetalle_Especialistas_Pacientes.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Cantidad_consultas = varDetalle_Especialistas_Pacientes.Cantidad_consultas
                        ,Principal = varDetalle_Especialistas_Pacientes.Principal
                        ,Estatus = varDetalle_Especialistas_Pacientes.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Especialistas_PacientesApiConsumer.Update(Detalle_Especialistas_PacientesInfo, null, null).Resource.ToString() :
                         _IDetalle_Especialistas_PacientesApiConsumer.Insert(Detalle_Especialistas_PacientesInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Especialistas_Pacientes script
        /// </summary>
        /// <param name="oDetalle_Especialistas_PacientesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Especialistas_PacientesModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Especialistas_PacientesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Especialistas_PacientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Especialistas_PacientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Especialistas_PacientesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Especialistas_PacientesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Especialistas_PacientesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Especialistas_Pacientes.js")))
            {
                strDetalle_Especialistas_PacientesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Especialistas_Pacientes element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Especialistas_PacientesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Especialistas_PacientesScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Especialistas_PacientesScript.Substring(indexOfArray, strDetalle_Especialistas_PacientesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Especialistas_PacientesScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Especialistas_PacientesScript.Substring(indexOfArrayHistory, strDetalle_Especialistas_PacientesScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Especialistas_PacientesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Especialistas_PacientesScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Especialistas_PacientesScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Especialistas_PacientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Especialistas_PacientesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Especialistas_PacientesScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Especialistas_PacientesScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Especialistas_PacientesScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Especialistas_Pacientes.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Especialistas_Pacientes.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Especialistas_Pacientes.js")))
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
        public ActionResult Detalle_Especialistas_PacientesPropertyBag()
        {
            return PartialView("Detalle_Especialistas_PacientesPropertyBag", "Detalle_Especialistas_Pacientes");
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

            _IDetalle_Especialistas_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Especialistas_PacientesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Especialistas_PacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Especialistas_Pacientess == null)
                result.Detalle_Especialistas_Pacientess = new List<Detalle_Especialistas_Pacientes>();

            var data = result.Detalle_Especialistas_Pacientess.Select(m => new Detalle_Especialistas_PacientesGridModel
            {
                Folio = m.Folio
                ,EspecialistaName = (string)m.Especialista_Spartan_User.Name
                ,EspecialidadEspecialidad = (string)m.Especialidad_Especialidades.Especialidad
                ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Cantidad_consultas = m.Cantidad_consultas
                ,Principal = m.Principal
                ,EstatusDescripcion = (string)m.Estatus_Estatus_Paciente.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Especialistas_PacientesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Especialistas_PacientesList_" + DateTime.Now.ToString());
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

            _IDetalle_Especialistas_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Especialistas_PacientesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Especialistas_PacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Especialistas_Pacientess == null)
                result.Detalle_Especialistas_Pacientess = new List<Detalle_Especialistas_Pacientes>();

            var data = result.Detalle_Especialistas_Pacientess.Select(m => new Detalle_Especialistas_PacientesGridModel
            {
                Folio = m.Folio
                ,EspecialistaName = (string)m.Especialista_Spartan_User.Name
                ,EspecialidadEspecialidad = (string)m.Especialidad_Especialidades.Especialidad
                ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Cantidad_consultas = m.Cantidad_consultas
                ,Principal = m.Principal
                ,EstatusDescripcion = (string)m.Estatus_Estatus_Paciente.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
