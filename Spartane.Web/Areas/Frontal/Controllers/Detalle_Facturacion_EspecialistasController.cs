using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Facturacion_Especialistas;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Facturacion_Especialistas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Facturacion_Especialistas;

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
    public class Detalle_Facturacion_EspecialistasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Facturacion_EspecialistasService service = null;
        private IDetalle_Facturacion_EspecialistasApiConsumer _IDetalle_Facturacion_EspecialistasApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Facturacion_EspecialistasController(IDetalle_Facturacion_EspecialistasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Facturacion_EspecialistasApiConsumer Detalle_Facturacion_EspecialistasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Facturacion_EspecialistasApiConsumer = Detalle_Facturacion_EspecialistasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Facturacion_Especialistas
        [ObjectAuth(ObjectId = (ModuleObjectId)44447, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44447);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Facturacion_Especialistas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44447, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44447);
            ViewBag.Permission = permission;
            var varDetalle_Facturacion_Especialistas = new Detalle_Facturacion_EspecialistasModel();
			
            ViewBag.ObjectId = "44447";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Facturacion_EspecialistasData = _IDetalle_Facturacion_EspecialistasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Facturacion_Especialistass[0];
                if (Detalle_Facturacion_EspecialistasData == null)
                    return HttpNotFound();

                varDetalle_Facturacion_Especialistas = new Detalle_Facturacion_EspecialistasModel
                {
                    Folio = (int)Detalle_Facturacion_EspecialistasData.Folio
                    ,Fecha_de_Registro = (Detalle_Facturacion_EspecialistasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Detalle_Facturacion_EspecialistasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Folio_Factura = Detalle_Facturacion_EspecialistasData.Folio_Factura
                    ,Periodo_Facturado = Detalle_Facturacion_EspecialistasData.Periodo_Facturado
                    ,Cantidad = Detalle_Facturacion_EspecialistasData.Cantidad
                    ,Archivo_XML = Detalle_Facturacion_EspecialistasData.Archivo_XML
                    ,Archivo_PDF = Detalle_Facturacion_EspecialistasData.Archivo_PDF
                    ,Estatus = Detalle_Facturacion_EspecialistasData.Estatus
                    ,Fecha_programada_de_Pago = (Detalle_Facturacion_EspecialistasData.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Facturacion_EspecialistasData.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Pagada = Detalle_Facturacion_EspecialistasData.Pagada.GetValueOrDefault()
                    ,Fecha_de_pago = (Detalle_Facturacion_EspecialistasData.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(Detalle_Facturacion_EspecialistasData.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_XMLSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Facturacion_Especialistas.Archivo_XML).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_PDFSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Facturacion_Especialistas.Archivo_PDF).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Facturacion_Especialistas);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Facturacion_Especialistas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44447);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Facturacion_EspecialistasModel varDetalle_Facturacion_Especialistas= new Detalle_Facturacion_EspecialistasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Facturacion_EspecialistassData = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll(0, 1000, "Detalle_Facturacion_Especialistas.Folio=" + id, "").Resource.Detalle_Facturacion_Especialistass;
				
				if (Detalle_Facturacion_EspecialistassData != null && Detalle_Facturacion_EspecialistassData.Count > 0)
                {
					var Detalle_Facturacion_EspecialistasData = Detalle_Facturacion_EspecialistassData.First();
					varDetalle_Facturacion_Especialistas= new Detalle_Facturacion_EspecialistasModel
					{
						Folio  = Detalle_Facturacion_EspecialistasData.Folio 
	                    ,Fecha_de_Registro = (Detalle_Facturacion_EspecialistasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Detalle_Facturacion_EspecialistasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Folio_Factura = Detalle_Facturacion_EspecialistasData.Folio_Factura
                    ,Periodo_Facturado = Detalle_Facturacion_EspecialistasData.Periodo_Facturado
                    ,Cantidad = Detalle_Facturacion_EspecialistasData.Cantidad
                    ,Archivo_XML = Detalle_Facturacion_EspecialistasData.Archivo_XML
                    ,Archivo_PDF = Detalle_Facturacion_EspecialistasData.Archivo_PDF
                    ,Estatus = Detalle_Facturacion_EspecialistasData.Estatus
                    ,Fecha_programada_de_Pago = (Detalle_Facturacion_EspecialistasData.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Facturacion_EspecialistasData.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Pagada = Detalle_Facturacion_EspecialistasData.Pagada.GetValueOrDefault()
                    ,Fecha_de_pago = (Detalle_Facturacion_EspecialistasData.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(Detalle_Facturacion_EspecialistasData.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_XMLSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Facturacion_Especialistas.Archivo_XML).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_PDFSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Facturacion_Especialistas.Archivo_PDF).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddDetalle_Facturacion_Especialistas", varDetalle_Facturacion_Especialistas);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Facturacion_EspecialistasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Facturacion_Especialistass == null)
                result.Detalle_Facturacion_Especialistass = new List<Detalle_Facturacion_Especialistas>();

            return Json(new
            {
                data = result.Detalle_Facturacion_Especialistass.Select(m => new Detalle_Facturacion_EspecialistasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Folio_Factura = m.Folio_Factura
			,Periodo_Facturado = m.Periodo_Facturado
			,Cantidad = m.Cantidad
			,Archivo_XML = m.Archivo_XML
			,Archivo_PDF = m.Archivo_PDF
			,Estatus = m.Estatus
                        ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Pagada = m.Pagada
                        ,Fecha_de_pago = (m.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))

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
                _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Facturacion_Especialistas varDetalle_Facturacion_Especialistas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Facturacion_EspecialistasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Facturacion_EspecialistasModel varDetalle_Facturacion_Especialistas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_Facturacion_Especialistas.Archivo_XMLRemoveAttachment != 0 && varDetalle_Facturacion_Especialistas.Archivo_XMLFile == null)
                    {
                        varDetalle_Facturacion_Especialistas.Archivo_XML = 0;
                    }

                    if (varDetalle_Facturacion_Especialistas.Archivo_XMLFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Facturacion_Especialistas.Archivo_XMLFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Facturacion_Especialistas.Archivo_XML = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Facturacion_Especialistas.Archivo_XMLFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varDetalle_Facturacion_Especialistas.Archivo_PDFRemoveAttachment != 0 && varDetalle_Facturacion_Especialistas.Archivo_PDFFile == null)
                    {
                        varDetalle_Facturacion_Especialistas.Archivo_PDF = 0;
                    }

                    if (varDetalle_Facturacion_Especialistas.Archivo_PDFFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Facturacion_Especialistas.Archivo_PDFFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Facturacion_Especialistas.Archivo_PDF = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Facturacion_Especialistas.Archivo_PDFFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_Facturacion_EspecialistasInfo = new Detalle_Facturacion_Especialistas
                    {
                        Folio = varDetalle_Facturacion_Especialistas.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varDetalle_Facturacion_Especialistas.Fecha_de_Registro)) ? DateTime.ParseExact(varDetalle_Facturacion_Especialistas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Folio_Factura = varDetalle_Facturacion_Especialistas.Folio_Factura
                        ,Periodo_Facturado = varDetalle_Facturacion_Especialistas.Periodo_Facturado
                        ,Cantidad = varDetalle_Facturacion_Especialistas.Cantidad
                        ,Archivo_XML = (varDetalle_Facturacion_Especialistas.Archivo_XML.HasValue && varDetalle_Facturacion_Especialistas.Archivo_XML != 0) ? ((int?)Convert.ToInt32(varDetalle_Facturacion_Especialistas.Archivo_XML.Value)) : null

                        ,Archivo_PDF = (varDetalle_Facturacion_Especialistas.Archivo_PDF.HasValue && varDetalle_Facturacion_Especialistas.Archivo_PDF != 0) ? ((int?)Convert.ToInt32(varDetalle_Facturacion_Especialistas.Archivo_PDF.Value)) : null

                        ,Estatus = varDetalle_Facturacion_Especialistas.Estatus
                        ,Fecha_programada_de_Pago = (!String.IsNullOrEmpty(varDetalle_Facturacion_Especialistas.Fecha_programada_de_Pago)) ? DateTime.ParseExact(varDetalle_Facturacion_Especialistas.Fecha_programada_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pagada = varDetalle_Facturacion_Especialistas.Pagada
                        ,Fecha_de_pago = (!String.IsNullOrEmpty(varDetalle_Facturacion_Especialistas.Fecha_de_pago)) ? DateTime.ParseExact(varDetalle_Facturacion_Especialistas.Fecha_de_pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                    };

                    result = !IsNew ?
                        _IDetalle_Facturacion_EspecialistasApiConsumer.Update(Detalle_Facturacion_EspecialistasInfo, null, null).Resource.ToString() :
                         _IDetalle_Facturacion_EspecialistasApiConsumer.Insert(Detalle_Facturacion_EspecialistasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Facturacion_Especialistas script
        /// </summary>
        /// <param name="oDetalle_Facturacion_EspecialistasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Facturacion_EspecialistasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Facturacion_EspecialistasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Facturacion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Facturacion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Facturacion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Facturacion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Facturacion_EspecialistasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Facturacion_Especialistas.js")))
            {
                strDetalle_Facturacion_EspecialistasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Facturacion_Especialistas element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Facturacion_EspecialistasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Facturacion_EspecialistasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Facturacion_EspecialistasScript.Substring(indexOfArray, strDetalle_Facturacion_EspecialistasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Facturacion_EspecialistasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Facturacion_EspecialistasScript.Substring(indexOfArrayHistory, strDetalle_Facturacion_EspecialistasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Facturacion_EspecialistasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Facturacion_EspecialistasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Facturacion_EspecialistasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Facturacion_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Facturacion_EspecialistasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Facturacion_EspecialistasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Facturacion_EspecialistasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Facturacion_EspecialistasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Facturacion_Especialistas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Facturacion_Especialistas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Facturacion_Especialistas.js")))
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
        public ActionResult Detalle_Facturacion_EspecialistasPropertyBag()
        {
            return PartialView("Detalle_Facturacion_EspecialistasPropertyBag", "Detalle_Facturacion_Especialistas");
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

            _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Facturacion_EspecialistasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Facturacion_Especialistass == null)
                result.Detalle_Facturacion_Especialistass = new List<Detalle_Facturacion_Especialistas>();

            var data = result.Detalle_Facturacion_Especialistass.Select(m => new Detalle_Facturacion_EspecialistasGridModel
            {
                Folio = m.Folio
                ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                ,Folio_Factura = m.Folio_Factura
                ,Periodo_Facturado = m.Periodo_Facturado
                ,Cantidad = m.Cantidad
                ,Estatus = m.Estatus
                ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,Pagada = m.Pagada
                ,Fecha_de_pago = (m.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Facturacion_EspecialistasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Facturacion_EspecialistasList_" + DateTime.Now.ToString());
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

            _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Facturacion_EspecialistasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Facturacion_Especialistass == null)
                result.Detalle_Facturacion_Especialistass = new List<Detalle_Facturacion_Especialistas>();

            var data = result.Detalle_Facturacion_Especialistass.Select(m => new Detalle_Facturacion_EspecialistasGridModel
            {
                Folio = m.Folio
                ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                ,Folio_Factura = m.Folio_Factura
                ,Periodo_Facturado = m.Periodo_Facturado
                ,Cantidad = m.Cantidad
                ,Estatus = m.Estatus
                ,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,Pagada = m.Pagada
                ,Fecha_de_pago = (m.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
