using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Core.Domain.Identificaciones_Oficiales;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Web.Areas.WebApiConsumer.Identificaciones_Oficiales;

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
    public class Detalle_Identificacion_Oficial_MedicosController : Controller
    {
        #region "variable declaration"

        private IDetalle_Identificacion_Oficial_MedicosService service = null;
        private IDetalle_Identificacion_Oficial_MedicosApiConsumer _IDetalle_Identificacion_Oficial_MedicosApiConsumer;
        private IIdentificaciones_OficialesApiConsumer _IIdentificaciones_OficialesApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Identificacion_Oficial_MedicosController(IDetalle_Identificacion_Oficial_MedicosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Identificacion_Oficial_MedicosApiConsumer Detalle_Identificacion_Oficial_MedicosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IIdentificaciones_OficialesApiConsumer Identificaciones_OficialesApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Identificacion_Oficial_MedicosApiConsumer = Detalle_Identificacion_Oficial_MedicosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IIdentificaciones_OficialesApiConsumer = Identificaciones_OficialesApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Identificacion_Oficial_Medicos
        [ObjectAuth(ObjectId = (ModuleObjectId)44380, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44380);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Identificacion_Oficial_Medicos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44380, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44380);
            ViewBag.Permission = permission;
            var varDetalle_Identificacion_Oficial_Medicos = new Detalle_Identificacion_Oficial_MedicosModel();
			
            ViewBag.ObjectId = "44380";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Identificacion_Oficial_MedicosData = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Identificacion_Oficial_Medicoss[0];
                if (Detalle_Identificacion_Oficial_MedicosData == null)
                    return HttpNotFound();

                varDetalle_Identificacion_Oficial_Medicos = new Detalle_Identificacion_Oficial_MedicosModel
                {
                    Folio = (int)Detalle_Identificacion_Oficial_MedicosData.Folio
                    ,Tipo_de_Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData.Tipo_de_Identificacion_Oficial
                    ,Tipo_de_Identificacion_OficialDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Identificacion_Oficial_MedicosData.Tipo_de_Identificacion_Oficial), "Identificaciones_Oficiales") ??  (string)Detalle_Identificacion_Oficial_MedicosData.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion
                    ,Documento = Detalle_Identificacion_Oficial_MedicosData.Documento

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.DocumentoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Identificacion_Oficial_Medicos.Documento).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IIdentificaciones_OficialesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial = _IIdentificaciones_OficialesApiConsumer.SelAll(true);
            if (Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial != null && Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial.Resource != null)
                ViewBag.Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial = Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Identificaciones_Oficiales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Identificacion_Oficial_Medicos);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Identificacion_Oficial_Medicos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44380);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Identificacion_Oficial_MedicosModel varDetalle_Identificacion_Oficial_Medicos= new Detalle_Identificacion_Oficial_MedicosModel();


            if (id.ToString() != "0")
            {
                var Detalle_Identificacion_Oficial_MedicossData = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll(0, 1000, "Detalle_Identificacion_Oficial_Medicos.Folio=" + id, "").Resource.Detalle_Identificacion_Oficial_Medicoss;
				
				if (Detalle_Identificacion_Oficial_MedicossData != null && Detalle_Identificacion_Oficial_MedicossData.Count > 0)
                {
					var Detalle_Identificacion_Oficial_MedicosData = Detalle_Identificacion_Oficial_MedicossData.First();
					varDetalle_Identificacion_Oficial_Medicos= new Detalle_Identificacion_Oficial_MedicosModel
					{
						Folio  = Detalle_Identificacion_Oficial_MedicosData.Folio 
	                    ,Tipo_de_Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData.Tipo_de_Identificacion_Oficial
                    ,Tipo_de_Identificacion_OficialDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Identificacion_Oficial_MedicosData.Tipo_de_Identificacion_Oficial), "Identificaciones_Oficiales") ??  (string)Detalle_Identificacion_Oficial_MedicosData.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion
                    ,Documento = Detalle_Identificacion_Oficial_MedicosData.Documento

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.DocumentoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Identificacion_Oficial_Medicos.Documento).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IIdentificaciones_OficialesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial = _IIdentificaciones_OficialesApiConsumer.SelAll(true);
            if (Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial != null && Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial.Resource != null)
                ViewBag.Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial = Identificaciones_Oficialess_Tipo_de_Identificacion_Oficial.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Identificaciones_Oficiales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Identificacion_Oficial_Medicos", varDetalle_Identificacion_Oficial_Medicos);
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
        public ActionResult GetIdentificaciones_OficialesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIdentificaciones_OficialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIdentificaciones_OficialesApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Identificaciones_Oficiales", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Identificacion_Oficial_MedicosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Identificacion_Oficial_Medicoss == null)
                result.Detalle_Identificacion_Oficial_Medicoss = new List<Detalle_Identificacion_Oficial_Medicos>();

            return Json(new
            {
                data = result.Detalle_Identificacion_Oficial_Medicoss.Select(m => new Detalle_Identificacion_Oficial_MedicosGridModel
                    {
                    Folio = m.Folio
                        ,Tipo_de_Identificacion_OficialDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Clave.ToString(), "Identificaciones_Oficiales") ?? (string)m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion
			,Documento = m.Documento

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIdentificaciones_OficialesApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Identificaciones_Oficiales.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Identificaciones_Oficiales.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IIdentificaciones_OficialesApiConsumer.ListaSelAll(1, 20,elWhere , " Identificaciones_Oficiales.Descripcion ASC ").Resource;
               
                foreach (var item in result.Identificaciones_Oficialess)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Identificaciones_Oficiales", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Identificaciones_Oficialess.ToArray(), JsonRequestBehavior.AllowGet);
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
                _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Identificacion_Oficial_Medicos varDetalle_Identificacion_Oficial_Medicos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Identificacion_Oficial_MedicosModel varDetalle_Identificacion_Oficial_Medicos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_Identificacion_Oficial_Medicos.DocumentoRemoveAttachment != 0 && varDetalle_Identificacion_Oficial_Medicos.DocumentoFile == null)
                    {
                        varDetalle_Identificacion_Oficial_Medicos.Documento = 0;
                    }

                    if (varDetalle_Identificacion_Oficial_Medicos.DocumentoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Identificacion_Oficial_Medicos.DocumentoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Identificacion_Oficial_Medicos.Documento = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Identificacion_Oficial_Medicos.DocumentoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_Identificacion_Oficial_MedicosInfo = new Detalle_Identificacion_Oficial_Medicos
                    {
                        Folio = varDetalle_Identificacion_Oficial_Medicos.Folio
                        ,Tipo_de_Identificacion_Oficial = varDetalle_Identificacion_Oficial_Medicos.Tipo_de_Identificacion_Oficial
                        ,Documento = (varDetalle_Identificacion_Oficial_Medicos.Documento.HasValue && varDetalle_Identificacion_Oficial_Medicos.Documento != 0) ? ((int?)Convert.ToInt32(varDetalle_Identificacion_Oficial_Medicos.Documento.Value)) : null


                    };

                    result = !IsNew ?
                        _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Update(Detalle_Identificacion_Oficial_MedicosInfo, null, null).Resource.ToString() :
                         _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Insert(Detalle_Identificacion_Oficial_MedicosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Identificacion_Oficial_Medicos script
        /// </summary>
        /// <param name="oDetalle_Identificacion_Oficial_MedicosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Identificacion_Oficial_MedicosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Identificacion_Oficial_MedicosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Identificacion_Oficial_MedicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Identificacion_Oficial_MedicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Identificacion_Oficial_MedicosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Identificacion_Oficial_MedicosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Identificacion_Oficial_MedicosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Identificacion_Oficial_Medicos.js")))
            {
                strDetalle_Identificacion_Oficial_MedicosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Identificacion_Oficial_Medicos element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Identificacion_Oficial_MedicosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Identificacion_Oficial_MedicosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Identificacion_Oficial_MedicosScript.Substring(indexOfArray, strDetalle_Identificacion_Oficial_MedicosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Identificacion_Oficial_MedicosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Identificacion_Oficial_MedicosScript.Substring(indexOfArrayHistory, strDetalle_Identificacion_Oficial_MedicosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Identificacion_Oficial_MedicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Identificacion_Oficial_MedicosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Identificacion_Oficial_MedicosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Identificacion_Oficial_MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Identificacion_Oficial_MedicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Identificacion_Oficial_MedicosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Identificacion_Oficial_MedicosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Identificacion_Oficial_MedicosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Identificacion_Oficial_Medicos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Identificacion_Oficial_Medicos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Identificacion_Oficial_Medicos.js")))
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
        public ActionResult Detalle_Identificacion_Oficial_MedicosPropertyBag()
        {
            return PartialView("Detalle_Identificacion_Oficial_MedicosPropertyBag", "Detalle_Identificacion_Oficial_Medicos");
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

            _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Identificacion_Oficial_MedicosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Identificacion_Oficial_Medicoss == null)
                result.Detalle_Identificacion_Oficial_Medicoss = new List<Detalle_Identificacion_Oficial_Medicos>();

            var data = result.Detalle_Identificacion_Oficial_Medicoss.Select(m => new Detalle_Identificacion_Oficial_MedicosGridModel
            {
                Folio = m.Folio
                ,Tipo_de_Identificacion_OficialDescripcion = (string)m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Identificacion_Oficial_MedicosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Identificacion_Oficial_MedicosList_" + DateTime.Now.ToString());
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

            _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Identificacion_Oficial_MedicosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Identificacion_Oficial_Medicoss == null)
                result.Detalle_Identificacion_Oficial_Medicoss = new List<Detalle_Identificacion_Oficial_Medicos>();

            var data = result.Detalle_Identificacion_Oficial_Medicoss.Select(m => new Detalle_Identificacion_Oficial_MedicosGridModel
            {
                Folio = m.Folio
                ,Tipo_de_Identificacion_OficialDescripcion = (string)m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
