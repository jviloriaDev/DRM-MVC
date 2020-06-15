using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Titulos_Medicos;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Titulos_Medicos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Titulos_Medicos;

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
    public class Detalle_Titulos_MedicosController : Controller
    {
        #region "variable declaration"

        private IDetalle_Titulos_MedicosService service = null;
        private IDetalle_Titulos_MedicosApiConsumer _IDetalle_Titulos_MedicosApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Titulos_MedicosController(IDetalle_Titulos_MedicosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Titulos_MedicosApiConsumer Detalle_Titulos_MedicosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Titulos_MedicosApiConsumer = Detalle_Titulos_MedicosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Titulos_Medicos
        [ObjectAuth(ObjectId = (ModuleObjectId)44408, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44408);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Titulos_Medicos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44408, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44408);
            ViewBag.Permission = permission;
            var varDetalle_Titulos_Medicos = new Detalle_Titulos_MedicosModel();
			
            ViewBag.ObjectId = "44408";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Titulos_MedicosData = _IDetalle_Titulos_MedicosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Titulos_Medicoss[0];
                if (Detalle_Titulos_MedicosData == null)
                    return HttpNotFound();

                varDetalle_Titulos_Medicos = new Detalle_Titulos_MedicosModel
                {
                    Folio = (int)Detalle_Titulos_MedicosData.Folio
                    ,Nombre_del_Titulo = Detalle_Titulos_MedicosData.Nombre_del_Titulo
                    ,Institucion_Facultad = Detalle_Titulos_MedicosData.Institucion_Facultad
                    ,Fecha_de_Titulacion = (Detalle_Titulos_MedicosData.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(Detalle_Titulos_MedicosData.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
                    ,Titulo = Detalle_Titulos_MedicosData.Titulo
                    ,Numero_de_Cedula = Detalle_Titulos_MedicosData.Numero_de_Cedula
                    ,Fecha_de_Expedicion = (Detalle_Titulos_MedicosData.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(Detalle_Titulos_MedicosData.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))
                    ,Cedula_Frente = Detalle_Titulos_MedicosData.Cedula_Frente
                    ,Cedula_Reverso = Detalle_Titulos_MedicosData.Cedula_Reverso

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.TituloSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Titulos_Medicos.Titulo).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_FrenteSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Titulos_Medicos.Cedula_Frente).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_ReversoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Titulos_Medicos.Cedula_Reverso).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Titulos_Medicos);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Titulos_Medicos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44408);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Titulos_MedicosModel varDetalle_Titulos_Medicos= new Detalle_Titulos_MedicosModel();


            if (id.ToString() != "0")
            {
                var Detalle_Titulos_MedicossData = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll(0, 1000, "Detalle_Titulos_Medicos.Folio=" + id, "").Resource.Detalle_Titulos_Medicoss;
				
				if (Detalle_Titulos_MedicossData != null && Detalle_Titulos_MedicossData.Count > 0)
                {
					var Detalle_Titulos_MedicosData = Detalle_Titulos_MedicossData.First();
					varDetalle_Titulos_Medicos= new Detalle_Titulos_MedicosModel
					{
						Folio  = Detalle_Titulos_MedicosData.Folio 
	                    ,Nombre_del_Titulo = Detalle_Titulos_MedicosData.Nombre_del_Titulo
                    ,Institucion_Facultad = Detalle_Titulos_MedicosData.Institucion_Facultad
                    ,Fecha_de_Titulacion = (Detalle_Titulos_MedicosData.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(Detalle_Titulos_MedicosData.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
                    ,Titulo = Detalle_Titulos_MedicosData.Titulo
                    ,Numero_de_Cedula = Detalle_Titulos_MedicosData.Numero_de_Cedula
                    ,Fecha_de_Expedicion = (Detalle_Titulos_MedicosData.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(Detalle_Titulos_MedicosData.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))
                    ,Cedula_Frente = Detalle_Titulos_MedicosData.Cedula_Frente
                    ,Cedula_Reverso = Detalle_Titulos_MedicosData.Cedula_Reverso

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.TituloSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Titulos_Medicos.Titulo).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_FrenteSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Titulos_Medicos.Cedula_Frente).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_ReversoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Titulos_Medicos.Cedula_Reverso).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddDetalle_Titulos_Medicos", varDetalle_Titulos_Medicos);
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




        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Titulos_MedicosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Titulos_Medicoss == null)
                result.Detalle_Titulos_Medicoss = new List<Detalle_Titulos_Medicos>();

            return Json(new
            {
                data = result.Detalle_Titulos_Medicoss.Select(m => new Detalle_Titulos_MedicosGridModel
                    {
                    Folio = m.Folio
			,Nombre_del_Titulo = m.Nombre_del_Titulo
			,Institucion_Facultad = m.Institucion_Facultad
                        ,Fecha_de_Titulacion = (m.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
			,Titulo = m.Titulo
			,Numero_de_Cedula = m.Numero_de_Cedula
                        ,Fecha_de_Expedicion = (m.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))
			,Cedula_Frente = m.Cedula_Frente
			,Cedula_Reverso = m.Cedula_Reverso

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
                _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Titulos_Medicos varDetalle_Titulos_Medicos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Titulos_MedicosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Titulos_MedicosModel varDetalle_Titulos_Medicos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_Titulos_Medicos.TituloRemoveAttachment != 0 && varDetalle_Titulos_Medicos.TituloFile == null)
                    {
                        varDetalle_Titulos_Medicos.Titulo = 0;
                    }

                    if (varDetalle_Titulos_Medicos.TituloFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Titulos_Medicos.TituloFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Titulos_Medicos.Titulo = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Titulos_Medicos.TituloFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varDetalle_Titulos_Medicos.Cedula_FrenteRemoveAttachment != 0 && varDetalle_Titulos_Medicos.Cedula_FrenteFile == null)
                    {
                        varDetalle_Titulos_Medicos.Cedula_Frente = 0;
                    }

                    if (varDetalle_Titulos_Medicos.Cedula_FrenteFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Titulos_Medicos.Cedula_FrenteFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Titulos_Medicos.Cedula_Frente = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Titulos_Medicos.Cedula_FrenteFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varDetalle_Titulos_Medicos.Cedula_ReversoRemoveAttachment != 0 && varDetalle_Titulos_Medicos.Cedula_ReversoFile == null)
                    {
                        varDetalle_Titulos_Medicos.Cedula_Reverso = 0;
                    }

                    if (varDetalle_Titulos_Medicos.Cedula_ReversoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Titulos_Medicos.Cedula_ReversoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Titulos_Medicos.Cedula_Reverso = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Titulos_Medicos.Cedula_ReversoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_Titulos_MedicosInfo = new Detalle_Titulos_Medicos
                    {
                        Folio = varDetalle_Titulos_Medicos.Folio
                        ,Nombre_del_Titulo = varDetalle_Titulos_Medicos.Nombre_del_Titulo
                        ,Institucion_Facultad = varDetalle_Titulos_Medicos.Institucion_Facultad
                        ,Fecha_de_Titulacion = (!String.IsNullOrEmpty(varDetalle_Titulos_Medicos.Fecha_de_Titulacion)) ? DateTime.ParseExact(varDetalle_Titulos_Medicos.Fecha_de_Titulacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Titulo = (varDetalle_Titulos_Medicos.Titulo.HasValue && varDetalle_Titulos_Medicos.Titulo != 0) ? ((int?)Convert.ToInt32(varDetalle_Titulos_Medicos.Titulo.Value)) : null

                        ,Numero_de_Cedula = varDetalle_Titulos_Medicos.Numero_de_Cedula
                        ,Fecha_de_Expedicion = (!String.IsNullOrEmpty(varDetalle_Titulos_Medicos.Fecha_de_Expedicion)) ? DateTime.ParseExact(varDetalle_Titulos_Medicos.Fecha_de_Expedicion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Cedula_Frente = (varDetalle_Titulos_Medicos.Cedula_Frente.HasValue && varDetalle_Titulos_Medicos.Cedula_Frente != 0) ? ((int?)Convert.ToInt32(varDetalle_Titulos_Medicos.Cedula_Frente.Value)) : null

                        ,Cedula_Reverso = (varDetalle_Titulos_Medicos.Cedula_Reverso.HasValue && varDetalle_Titulos_Medicos.Cedula_Reverso != 0) ? ((int?)Convert.ToInt32(varDetalle_Titulos_Medicos.Cedula_Reverso.Value)) : null


                    };

                    result = !IsNew ?
                        _IDetalle_Titulos_MedicosApiConsumer.Update(Detalle_Titulos_MedicosInfo, null, null).Resource.ToString() :
                         _IDetalle_Titulos_MedicosApiConsumer.Insert(Detalle_Titulos_MedicosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Titulos_Medicos script
        /// </summary>
        /// <param name="oDetalle_Titulos_MedicosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Titulos_MedicosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Titulos_MedicosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Titulos_MedicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Titulos_MedicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Titulos_MedicosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Titulos_MedicosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Titulos_MedicosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Titulos_Medicos.js")))
            {
                strDetalle_Titulos_MedicosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Titulos_Medicos element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Titulos_MedicosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Titulos_MedicosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Titulos_MedicosScript.Substring(indexOfArray, strDetalle_Titulos_MedicosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Titulos_MedicosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Titulos_MedicosScript.Substring(indexOfArrayHistory, strDetalle_Titulos_MedicosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Titulos_MedicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Titulos_MedicosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Titulos_MedicosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Titulos_MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Titulos_MedicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Titulos_MedicosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Titulos_MedicosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Titulos_MedicosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Titulos_Medicos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Titulos_Medicos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Titulos_Medicos.js")))
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
        public ActionResult Detalle_Titulos_MedicosPropertyBag()
        {
            return PartialView("Detalle_Titulos_MedicosPropertyBag", "Detalle_Titulos_Medicos");
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

            _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Titulos_MedicosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Titulos_Medicoss == null)
                result.Detalle_Titulos_Medicoss = new List<Detalle_Titulos_Medicos>();

            var data = result.Detalle_Titulos_Medicoss.Select(m => new Detalle_Titulos_MedicosGridModel
            {
                Folio = m.Folio
                ,Nombre_del_Titulo = m.Nombre_del_Titulo
                ,Institucion_Facultad = m.Institucion_Facultad
                ,Fecha_de_Titulacion = (m.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
                ,Numero_de_Cedula = m.Numero_de_Cedula
                ,Fecha_de_Expedicion = (m.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Titulos_MedicosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Titulos_MedicosList_" + DateTime.Now.ToString());
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

            _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Titulos_MedicosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Titulos_Medicoss == null)
                result.Detalle_Titulos_Medicoss = new List<Detalle_Titulos_Medicos>();

            var data = result.Detalle_Titulos_Medicoss.Select(m => new Detalle_Titulos_MedicosGridModel
            {
                Folio = m.Folio
                ,Nombre_del_Titulo = m.Nombre_del_Titulo
                ,Institucion_Facultad = m.Institucion_Facultad
                ,Fecha_de_Titulacion = (m.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
                ,Numero_de_Cedula = m.Numero_de_Cedula
                ,Fecha_de_Expedicion = (m.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
