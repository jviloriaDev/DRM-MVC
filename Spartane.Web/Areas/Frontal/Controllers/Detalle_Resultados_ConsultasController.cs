using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Resultados_Consultas;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Indicadores_Consultas;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Resultados_Consultas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Resultados_Consultas;
using Spartane.Web.Areas.WebApiConsumer.Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Indicadores_Consultas;

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
    public class Detalle_Resultados_ConsultasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Resultados_ConsultasService service = null;
        private IDetalle_Resultados_ConsultasApiConsumer _IDetalle_Resultados_ConsultasApiConsumer;
        private IPacientesApiConsumer _IPacientesApiConsumer;
        private IIndicadores_ConsultasApiConsumer _IIndicadores_ConsultasApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Resultados_ConsultasController(IDetalle_Resultados_ConsultasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Resultados_ConsultasApiConsumer Detalle_Resultados_ConsultasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPacientesApiConsumer PacientesApiConsumer , IIndicadores_ConsultasApiConsumer Indicadores_ConsultasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Resultados_ConsultasApiConsumer = Detalle_Resultados_ConsultasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPacientesApiConsumer = PacientesApiConsumer;
            this._IIndicadores_ConsultasApiConsumer = Indicadores_ConsultasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Resultados_Consultas
        [ObjectAuth(ObjectId = (ModuleObjectId)44405, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44405);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Resultados_Consultas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44405, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44405);
            ViewBag.Permission = permission;
            var varDetalle_Resultados_Consultas = new Detalle_Resultados_ConsultasModel();
			
            ViewBag.ObjectId = "44405";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Resultados_ConsultasData = _IDetalle_Resultados_ConsultasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Resultados_Consultass[0];
                if (Detalle_Resultados_ConsultasData == null)
                    return HttpNotFound();

                varDetalle_Resultados_Consultas = new Detalle_Resultados_ConsultasModel
                {
                    Folio = (int)Detalle_Resultados_ConsultasData.Folio
                    ,Folio_Pacientes = Detalle_Resultados_ConsultasData.Folio_Pacientes
                    ,Folio_PacientesNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Detalle_Resultados_ConsultasData.Folio_Pacientes), "Pacientes") ??  (string)Detalle_Resultados_ConsultasData.Folio_Pacientes_Pacientes.Nombre_Completo
                    ,Fecha_de_Consulta = (Detalle_Resultados_ConsultasData.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(Detalle_Resultados_ConsultasData.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                    ,Indicador = Detalle_Resultados_ConsultasData.Indicador
                    ,IndicadorNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Resultados_ConsultasData.Indicador), "Indicadores_Consultas") ??  (string)Detalle_Resultados_ConsultasData.Indicador_Indicadores_Consultas.Nombre
                    ,Resultado = Detalle_Resultados_ConsultasData.Resultado
                    ,Interpretacion = Detalle_Resultados_ConsultasData.Interpretacion
                    ,IMC = Detalle_Resultados_ConsultasData.IMC
                    ,IMC_Pediatria = Detalle_Resultados_ConsultasData.IMC_Pediatria

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Folio_Pacientes = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Folio_Pacientes != null && Pacientess_Folio_Pacientes.Resource != null)
                ViewBag.Pacientess_Folio_Pacientes = Pacientess_Folio_Pacientes.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IIndicadores_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Indicadores_Consultass_Indicador = _IIndicadores_ConsultasApiConsumer.SelAll(true);
            if (Indicadores_Consultass_Indicador != null && Indicadores_Consultass_Indicador.Resource != null)
                ViewBag.Indicadores_Consultass_Indicador = Indicadores_Consultass_Indicador.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Indicadores_Consultas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Resultados_Consultas);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Resultados_Consultas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44405);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Resultados_ConsultasModel varDetalle_Resultados_Consultas= new Detalle_Resultados_ConsultasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Resultados_ConsultassData = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll(0, 1000, "Detalle_Resultados_Consultas.Folio=" + id, "").Resource.Detalle_Resultados_Consultass;
				
				if (Detalle_Resultados_ConsultassData != null && Detalle_Resultados_ConsultassData.Count > 0)
                {
					var Detalle_Resultados_ConsultasData = Detalle_Resultados_ConsultassData.First();
					varDetalle_Resultados_Consultas= new Detalle_Resultados_ConsultasModel
					{
						Folio  = Detalle_Resultados_ConsultasData.Folio 
	                    ,Folio_Pacientes = Detalle_Resultados_ConsultasData.Folio_Pacientes
                    ,Folio_PacientesNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Detalle_Resultados_ConsultasData.Folio_Pacientes), "Pacientes") ??  (string)Detalle_Resultados_ConsultasData.Folio_Pacientes_Pacientes.Nombre_Completo
                    ,Fecha_de_Consulta = (Detalle_Resultados_ConsultasData.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(Detalle_Resultados_ConsultasData.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                    ,Indicador = Detalle_Resultados_ConsultasData.Indicador
                    ,IndicadorNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Resultados_ConsultasData.Indicador), "Indicadores_Consultas") ??  (string)Detalle_Resultados_ConsultasData.Indicador_Indicadores_Consultas.Nombre
                    ,Resultado = Detalle_Resultados_ConsultasData.Resultado
                    ,Interpretacion = Detalle_Resultados_ConsultasData.Interpretacion
                    ,IMC = Detalle_Resultados_ConsultasData.IMC
                    ,IMC_Pediatria = Detalle_Resultados_ConsultasData.IMC_Pediatria

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Folio_Pacientes = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Folio_Pacientes != null && Pacientess_Folio_Pacientes.Resource != null)
                ViewBag.Pacientess_Folio_Pacientes = Pacientess_Folio_Pacientes.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IIndicadores_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Indicadores_Consultass_Indicador = _IIndicadores_ConsultasApiConsumer.SelAll(true);
            if (Indicadores_Consultass_Indicador != null && Indicadores_Consultass_Indicador.Resource != null)
                ViewBag.Indicadores_Consultass_Indicador = Indicadores_Consultass_Indicador.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Indicadores_Consultas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Resultados_Consultas", varDetalle_Resultados_Consultas);
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
        public ActionResult GetPacientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPacientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo")?? m.Nombre_Completo,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetIndicadores_ConsultasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIndicadores_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIndicadores_ConsultasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Indicadores_Consultas", "Nombre")?? m.Nombre,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Resultados_ConsultasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Resultados_Consultass == null)
                result.Detalle_Resultados_Consultass = new List<Detalle_Resultados_Consultas>();

            return Json(new
            {
                data = result.Detalle_Resultados_Consultass.Select(m => new Detalle_Resultados_ConsultasGridModel
                    {
                    Folio = m.Folio
                        ,Folio_PacientesNombre_Completo = CultureHelper.GetTraduction(m.Folio_Pacientes_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Folio_Pacientes_Pacientes.Nombre_Completo
                        ,Fecha_de_Consulta = (m.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                        ,IndicadorNombre = CultureHelper.GetTraduction(m.Indicador_Indicadores_Consultas.Clave.ToString(), "Nombre") ?? (string)m.Indicador_Indicadores_Consultas.Nombre
			,Resultado = m.Resultado
			,Interpretacion = m.Interpretacion
			,IMC = m.IMC
			,IMC_Pediatria = m.IMC_Pediatria

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
                _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Resultados_Consultas varDetalle_Resultados_Consultas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Resultados_ConsultasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Resultados_ConsultasModel varDetalle_Resultados_Consultas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Resultados_ConsultasInfo = new Detalle_Resultados_Consultas
                    {
                        Folio = varDetalle_Resultados_Consultas.Folio
                        ,Folio_Pacientes = varDetalle_Resultados_Consultas.Folio_Pacientes
                        ,Fecha_de_Consulta = (!String.IsNullOrEmpty(varDetalle_Resultados_Consultas.Fecha_de_Consulta)) ? DateTime.ParseExact(varDetalle_Resultados_Consultas.Fecha_de_Consulta, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Indicador = varDetalle_Resultados_Consultas.Indicador
                        ,Resultado = varDetalle_Resultados_Consultas.Resultado
                        ,Interpretacion = varDetalle_Resultados_Consultas.Interpretacion
                        ,IMC = varDetalle_Resultados_Consultas.IMC
                        ,IMC_Pediatria = varDetalle_Resultados_Consultas.IMC_Pediatria

                    };

                    result = !IsNew ?
                        _IDetalle_Resultados_ConsultasApiConsumer.Update(Detalle_Resultados_ConsultasInfo, null, null).Resource.ToString() :
                         _IDetalle_Resultados_ConsultasApiConsumer.Insert(Detalle_Resultados_ConsultasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Resultados_Consultas script
        /// </summary>
        /// <param name="oDetalle_Resultados_ConsultasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Resultados_ConsultasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Resultados_ConsultasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Resultados_ConsultasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Resultados_ConsultasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Resultados_ConsultasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Resultados_ConsultasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Resultados_ConsultasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Resultados_Consultas.js")))
            {
                strDetalle_Resultados_ConsultasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Resultados_Consultas element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Resultados_ConsultasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Resultados_ConsultasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Resultados_ConsultasScript.Substring(indexOfArray, strDetalle_Resultados_ConsultasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Resultados_ConsultasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Resultados_ConsultasScript.Substring(indexOfArrayHistory, strDetalle_Resultados_ConsultasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Resultados_ConsultasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Resultados_ConsultasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Resultados_ConsultasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Resultados_ConsultasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Resultados_ConsultasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Resultados_ConsultasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Resultados_ConsultasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Resultados_ConsultasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Resultados_Consultas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Resultados_Consultas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Resultados_Consultas.js")))
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
        public ActionResult Detalle_Resultados_ConsultasPropertyBag()
        {
            return PartialView("Detalle_Resultados_ConsultasPropertyBag", "Detalle_Resultados_Consultas");
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

            _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Resultados_ConsultasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Resultados_Consultass == null)
                result.Detalle_Resultados_Consultass = new List<Detalle_Resultados_Consultas>();

            var data = result.Detalle_Resultados_Consultass.Select(m => new Detalle_Resultados_ConsultasGridModel
            {
                Folio = m.Folio
                ,Folio_PacientesNombre_Completo = (string)m.Folio_Pacientes_Pacientes.Nombre_Completo
                ,Fecha_de_Consulta = (m.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                ,IndicadorNombre = (string)m.Indicador_Indicadores_Consultas.Nombre
                ,Resultado = m.Resultado
                ,Interpretacion = m.Interpretacion
                ,IMC = m.IMC
                ,IMC_Pediatria = m.IMC_Pediatria

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Resultados_ConsultasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Resultados_ConsultasList_" + DateTime.Now.ToString());
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

            _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Resultados_ConsultasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Resultados_Consultass == null)
                result.Detalle_Resultados_Consultass = new List<Detalle_Resultados_Consultas>();

            var data = result.Detalle_Resultados_Consultass.Select(m => new Detalle_Resultados_ConsultasGridModel
            {
                Folio = m.Folio
                ,Folio_PacientesNombre_Completo = (string)m.Folio_Pacientes_Pacientes.Nombre_Completo
                ,Fecha_de_Consulta = (m.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                ,IndicadorNombre = (string)m.Indicador_Indicadores_Consultas.Nombre
                ,Resultado = m.Resultado
                ,Interpretacion = m.Interpretacion
                ,IMC = m.IMC
                ,IMC_Pediatria = m.IMC_Pediatria

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
