using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Examenes_Laboratorio;
using Spartane.Core.Domain.Indicadores_Laboratorio;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Examenes_Laboratorio;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Examenes_Laboratorio;
using Spartane.Web.Areas.WebApiConsumer.Indicadores_Laboratorio;

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
    public class Detalle_Examenes_LaboratorioController : Controller
    {
        #region "variable declaration"

        private IDetalle_Examenes_LaboratorioService service = null;
        private IDetalle_Examenes_LaboratorioApiConsumer _IDetalle_Examenes_LaboratorioApiConsumer;
        private IIndicadores_LaboratorioApiConsumer _IIndicadores_LaboratorioApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Examenes_LaboratorioController(IDetalle_Examenes_LaboratorioService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Examenes_LaboratorioApiConsumer Detalle_Examenes_LaboratorioApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IIndicadores_LaboratorioApiConsumer Indicadores_LaboratorioApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Examenes_LaboratorioApiConsumer = Detalle_Examenes_LaboratorioApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IIndicadores_LaboratorioApiConsumer = Indicadores_LaboratorioApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Examenes_Laboratorio
        [ObjectAuth(ObjectId = (ModuleObjectId)44344, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44344);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Examenes_Laboratorio/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44344, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44344);
            ViewBag.Permission = permission;
            var varDetalle_Examenes_Laboratorio = new Detalle_Examenes_LaboratorioModel();
			
            ViewBag.ObjectId = "44344";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Examenes_LaboratorioData = _IDetalle_Examenes_LaboratorioApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Examenes_Laboratorios[0];
                if (Detalle_Examenes_LaboratorioData == null)
                    return HttpNotFound();

                varDetalle_Examenes_Laboratorio = new Detalle_Examenes_LaboratorioModel
                {
                    Folio = (int)Detalle_Examenes_LaboratorioData.Folio
                    ,Indicador = Detalle_Examenes_LaboratorioData.Indicador
                    ,IndicadorIndicador = CultureHelper.GetTraduction(Convert.ToString(Detalle_Examenes_LaboratorioData.Indicador), "Indicadores_Laboratorio") ??  (string)Detalle_Examenes_LaboratorioData.Indicador_Indicadores_Laboratorio.Indicador
                    ,Resultado = Detalle_Examenes_LaboratorioData.Resultado
                    ,Unidad = Detalle_Examenes_LaboratorioData.Unidad
                    ,Intervalo_de_Referencia = Detalle_Examenes_LaboratorioData.Intervalo_de_Referencia
                    ,Fecha_de_Resultado = (Detalle_Examenes_LaboratorioData.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(Detalle_Examenes_LaboratorioData.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus_Indicador = Detalle_Examenes_LaboratorioData.Estatus_Indicador

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IIndicadores_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Indicadores_Laboratorios_Indicador = _IIndicadores_LaboratorioApiConsumer.SelAll(true);
            if (Indicadores_Laboratorios_Indicador != null && Indicadores_Laboratorios_Indicador.Resource != null)
                ViewBag.Indicadores_Laboratorios_Indicador = Indicadores_Laboratorios_Indicador.Resource.Where(m => m.Indicador != null).OrderBy(m => m.Indicador).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Indicadores_Laboratorio", "Indicador") ?? m.Indicador.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Examenes_Laboratorio);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Examenes_Laboratorio(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44344);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Examenes_LaboratorioModel varDetalle_Examenes_Laboratorio= new Detalle_Examenes_LaboratorioModel();


            if (id.ToString() != "0")
            {
                var Detalle_Examenes_LaboratoriosData = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll(0, 1000, "Detalle_Examenes_Laboratorio.Folio=" + id, "").Resource.Detalle_Examenes_Laboratorios;
				
				if (Detalle_Examenes_LaboratoriosData != null && Detalle_Examenes_LaboratoriosData.Count > 0)
                {
					var Detalle_Examenes_LaboratorioData = Detalle_Examenes_LaboratoriosData.First();
					varDetalle_Examenes_Laboratorio= new Detalle_Examenes_LaboratorioModel
					{
						Folio  = Detalle_Examenes_LaboratorioData.Folio 
	                    ,Indicador = Detalle_Examenes_LaboratorioData.Indicador
                    ,IndicadorIndicador = CultureHelper.GetTraduction(Convert.ToString(Detalle_Examenes_LaboratorioData.Indicador), "Indicadores_Laboratorio") ??  (string)Detalle_Examenes_LaboratorioData.Indicador_Indicadores_Laboratorio.Indicador
                    ,Resultado = Detalle_Examenes_LaboratorioData.Resultado
                    ,Unidad = Detalle_Examenes_LaboratorioData.Unidad
                    ,Intervalo_de_Referencia = Detalle_Examenes_LaboratorioData.Intervalo_de_Referencia
                    ,Fecha_de_Resultado = (Detalle_Examenes_LaboratorioData.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(Detalle_Examenes_LaboratorioData.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus_Indicador = Detalle_Examenes_LaboratorioData.Estatus_Indicador

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IIndicadores_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Indicadores_Laboratorios_Indicador = _IIndicadores_LaboratorioApiConsumer.SelAll(true);
            if (Indicadores_Laboratorios_Indicador != null && Indicadores_Laboratorios_Indicador.Resource != null)
                ViewBag.Indicadores_Laboratorios_Indicador = Indicadores_Laboratorios_Indicador.Resource.Where(m => m.Indicador != null).OrderBy(m => m.Indicador).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Indicadores_Laboratorio", "Indicador") ?? m.Indicador.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Examenes_Laboratorio", varDetalle_Examenes_Laboratorio);
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
        public ActionResult GetIndicadores_LaboratorioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIndicadores_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIndicadores_LaboratorioApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Indicador).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Indicadores_Laboratorio", "Indicador")?? m.Indicador,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Examenes_LaboratorioPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Examenes_Laboratorios == null)
                result.Detalle_Examenes_Laboratorios = new List<Detalle_Examenes_Laboratorio>();

            return Json(new
            {
                data = result.Detalle_Examenes_Laboratorios.Select(m => new Detalle_Examenes_LaboratorioGridModel
                    {
                    Folio = m.Folio
                        ,IndicadorIndicador = CultureHelper.GetTraduction(m.Indicador_Indicadores_Laboratorio.Folio.ToString(), "Indicador") ?? (string)m.Indicador_Indicadores_Laboratorio.Indicador
			,Resultado = m.Resultado
			,Unidad = m.Unidad
			,Intervalo_de_Referencia = m.Intervalo_de_Referencia
                        ,Fecha_de_Resultado = (m.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
			,Estatus_Indicador = m.Estatus_Indicador

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
                _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Examenes_Laboratorio varDetalle_Examenes_Laboratorio = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Examenes_LaboratorioApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Examenes_LaboratorioModel varDetalle_Examenes_Laboratorio)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Examenes_LaboratorioInfo = new Detalle_Examenes_Laboratorio
                    {
                        Folio = varDetalle_Examenes_Laboratorio.Folio
                        ,Indicador = varDetalle_Examenes_Laboratorio.Indicador
                        ,Resultado = varDetalle_Examenes_Laboratorio.Resultado
                        ,Unidad = varDetalle_Examenes_Laboratorio.Unidad
                        ,Intervalo_de_Referencia = varDetalle_Examenes_Laboratorio.Intervalo_de_Referencia
                        ,Fecha_de_Resultado = (!String.IsNullOrEmpty(varDetalle_Examenes_Laboratorio.Fecha_de_Resultado)) ? DateTime.ParseExact(varDetalle_Examenes_Laboratorio.Fecha_de_Resultado, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus_Indicador = varDetalle_Examenes_Laboratorio.Estatus_Indicador

                    };

                    result = !IsNew ?
                        _IDetalle_Examenes_LaboratorioApiConsumer.Update(Detalle_Examenes_LaboratorioInfo, null, null).Resource.ToString() :
                         _IDetalle_Examenes_LaboratorioApiConsumer.Insert(Detalle_Examenes_LaboratorioInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Examenes_Laboratorio script
        /// </summary>
        /// <param name="oDetalle_Examenes_LaboratorioElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Examenes_LaboratorioModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Examenes_LaboratorioModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Examenes_LaboratorioModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Examenes_LaboratorioModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Examenes_LaboratorioModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Examenes_LaboratorioModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Examenes_LaboratorioScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Examenes_Laboratorio.js")))
            {
                strDetalle_Examenes_LaboratorioScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Examenes_Laboratorio element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Examenes_LaboratorioModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Examenes_LaboratorioScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Examenes_LaboratorioScript.Substring(indexOfArray, strDetalle_Examenes_LaboratorioScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Examenes_LaboratorioScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Examenes_LaboratorioScript.Substring(indexOfArrayHistory, strDetalle_Examenes_LaboratorioScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Examenes_LaboratorioScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Examenes_LaboratorioScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Examenes_LaboratorioScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Examenes_LaboratorioModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Examenes_LaboratorioScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Examenes_LaboratorioScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Examenes_LaboratorioScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Examenes_LaboratorioScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Examenes_Laboratorio.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Examenes_Laboratorio.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Examenes_Laboratorio.js")))
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
        public ActionResult Detalle_Examenes_LaboratorioPropertyBag()
        {
            return PartialView("Detalle_Examenes_LaboratorioPropertyBag", "Detalle_Examenes_Laboratorio");
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

            _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Examenes_LaboratorioPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Examenes_Laboratorios == null)
                result.Detalle_Examenes_Laboratorios = new List<Detalle_Examenes_Laboratorio>();

            var data = result.Detalle_Examenes_Laboratorios.Select(m => new Detalle_Examenes_LaboratorioGridModel
            {
                Folio = m.Folio
                ,IndicadorIndicador = (string)m.Indicador_Indicadores_Laboratorio.Indicador
                ,Resultado = m.Resultado
                ,Unidad = m.Unidad
                ,Intervalo_de_Referencia = m.Intervalo_de_Referencia
                ,Fecha_de_Resultado = (m.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
                ,Estatus_Indicador = m.Estatus_Indicador

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Examenes_LaboratorioList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Examenes_LaboratorioList_" + DateTime.Now.ToString());
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

            _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Examenes_LaboratorioPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Examenes_Laboratorios == null)
                result.Detalle_Examenes_Laboratorios = new List<Detalle_Examenes_Laboratorio>();

            var data = result.Detalle_Examenes_Laboratorios.Select(m => new Detalle_Examenes_LaboratorioGridModel
            {
                Folio = m.Folio
                ,IndicadorIndicador = (string)m.Indicador_Indicadores_Laboratorio.Indicador
                ,Resultado = m.Resultado
                ,Unidad = m.Unidad
                ,Intervalo_de_Referencia = m.Intervalo_de_Referencia
                ,Fecha_de_Resultado = (m.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
                ,Estatus_Indicador = m.Estatus_Indicador

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
