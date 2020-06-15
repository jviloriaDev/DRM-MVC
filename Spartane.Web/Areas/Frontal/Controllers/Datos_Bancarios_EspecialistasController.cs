using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Datos_Bancarios_Especialistas;
using Spartane.Core.Domain.Bancos;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Datos_Bancarios_Especialistas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Datos_Bancarios_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Bancos;

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
    public class Datos_Bancarios_EspecialistasController : Controller
    {
        #region "variable declaration"

        private IDatos_Bancarios_EspecialistasService service = null;
        private IDatos_Bancarios_EspecialistasApiConsumer _IDatos_Bancarios_EspecialistasApiConsumer;
        private IBancosApiConsumer _IBancosApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Datos_Bancarios_EspecialistasController(IDatos_Bancarios_EspecialistasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDatos_Bancarios_EspecialistasApiConsumer Datos_Bancarios_EspecialistasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IBancosApiConsumer BancosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDatos_Bancarios_EspecialistasApiConsumer = Datos_Bancarios_EspecialistasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IBancosApiConsumer = BancosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Datos_Bancarios_Especialistas
        [ObjectAuth(ObjectId = (ModuleObjectId)44424, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44424);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Datos_Bancarios_Especialistas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44424, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44424);
            ViewBag.Permission = permission;
            var varDatos_Bancarios_Especialistas = new Datos_Bancarios_EspecialistasModel();
			
            ViewBag.ObjectId = "44424";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDatos_Bancarios_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Datos_Bancarios_EspecialistasData = _IDatos_Bancarios_EspecialistasApiConsumer.GetByKeyComplete(Id).Resource.Datos_Bancarios_Especialistass[0];
                if (Datos_Bancarios_EspecialistasData == null)
                    return HttpNotFound();

                varDatos_Bancarios_Especialistas = new Datos_Bancarios_EspecialistasModel
                {
                    Folio = (int)Datos_Bancarios_EspecialistasData.Folio
                    ,Banco = Datos_Bancarios_EspecialistasData.Banco
                    ,BancoNombre = CultureHelper.GetTraduction(Convert.ToString(Datos_Bancarios_EspecialistasData.Banco), "Bancos") ??  (string)Datos_Bancarios_EspecialistasData.Banco_Bancos.Nombre
                    ,CLABE_Interbancaria = Datos_Bancarios_EspecialistasData.CLABE_Interbancaria
                    ,Num_Cuenta = Datos_Bancarios_EspecialistasData.Num_Cuenta
                    ,Nombre_del_Titular = Datos_Bancarios_EspecialistasData.Nombre_del_Titular
                    ,Principal = Datos_Bancarios_EspecialistasData.Principal.GetValueOrDefault()

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDatos_Bancarios_Especialistas);
        }
		
	[HttpGet]
        public ActionResult AddDatos_Bancarios_Especialistas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44424);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDatos_Bancarios_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Datos_Bancarios_EspecialistasModel varDatos_Bancarios_Especialistas= new Datos_Bancarios_EspecialistasModel();


            if (id.ToString() != "0")
            {
                var Datos_Bancarios_EspecialistassData = _IDatos_Bancarios_EspecialistasApiConsumer.ListaSelAll(0, 1000, "Datos_Bancarios_Especialistas.Folio=" + id, "").Resource.Datos_Bancarios_Especialistass;
				
				if (Datos_Bancarios_EspecialistassData != null && Datos_Bancarios_EspecialistassData.Count > 0)
                {
					var Datos_Bancarios_EspecialistasData = Datos_Bancarios_EspecialistassData.First();
					varDatos_Bancarios_Especialistas= new Datos_Bancarios_EspecialistasModel
					{
						Folio  = Datos_Bancarios_EspecialistasData.Folio 
	                    ,Banco = Datos_Bancarios_EspecialistasData.Banco
                    ,BancoNombre = CultureHelper.GetTraduction(Convert.ToString(Datos_Bancarios_EspecialistasData.Banco), "Bancos") ??  (string)Datos_Bancarios_EspecialistasData.Banco_Bancos.Nombre
                    ,CLABE_Interbancaria = Datos_Bancarios_EspecialistasData.CLABE_Interbancaria
                    ,Num_Cuenta = Datos_Bancarios_EspecialistasData.Num_Cuenta
                    ,Nombre_del_Titular = Datos_Bancarios_EspecialistasData.Nombre_del_Titular
                    ,Principal = Datos_Bancarios_EspecialistasData.Principal.GetValueOrDefault()

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDatos_Bancarios_Especialistas", varDatos_Bancarios_Especialistas);
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
        public ActionResult GetBancosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IBancosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre")?? m.Nombre,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Datos_Bancarios_EspecialistasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDatos_Bancarios_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Datos_Bancarios_Especialistass == null)
                result.Datos_Bancarios_Especialistass = new List<Datos_Bancarios_Especialistas>();

            return Json(new
            {
                data = result.Datos_Bancarios_Especialistass.Select(m => new Datos_Bancarios_EspecialistasGridModel
                    {
                    Folio = m.Folio
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Num_Cuenta = m.Num_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular
			,Principal = m.Principal

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
                _IDatos_Bancarios_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Datos_Bancarios_Especialistas varDatos_Bancarios_Especialistas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDatos_Bancarios_EspecialistasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Datos_Bancarios_EspecialistasModel varDatos_Bancarios_Especialistas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDatos_Bancarios_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Datos_Bancarios_EspecialistasInfo = new Datos_Bancarios_Especialistas
                    {
                        Folio = varDatos_Bancarios_Especialistas.Folio
                        ,Banco = varDatos_Bancarios_Especialistas.Banco
                        ,CLABE_Interbancaria = varDatos_Bancarios_Especialistas.CLABE_Interbancaria
                        ,Num_Cuenta = varDatos_Bancarios_Especialistas.Num_Cuenta
                        ,Nombre_del_Titular = varDatos_Bancarios_Especialistas.Nombre_del_Titular
                        ,Principal = varDatos_Bancarios_Especialistas.Principal

                    };

                    result = !IsNew ?
                        _IDatos_Bancarios_EspecialistasApiConsumer.Update(Datos_Bancarios_EspecialistasInfo, null, null).Resource.ToString() :
                         _IDatos_Bancarios_EspecialistasApiConsumer.Insert(Datos_Bancarios_EspecialistasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Datos_Bancarios_Especialistas script
        /// </summary>
        /// <param name="oDatos_Bancarios_EspecialistasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Datos_Bancarios_EspecialistasModuleAttributeList)
        {
            for (int i = 0; i < Datos_Bancarios_EspecialistasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Datos_Bancarios_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Datos_Bancarios_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Datos_Bancarios_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Datos_Bancarios_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDatos_Bancarios_EspecialistasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Datos_Bancarios_Especialistas.js")))
            {
                strDatos_Bancarios_EspecialistasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Datos_Bancarios_Especialistas element attributes
            string userChangeJson = jsSerialize.Serialize(Datos_Bancarios_EspecialistasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDatos_Bancarios_EspecialistasScript.IndexOf("inpuElementArray");
            string splittedString = strDatos_Bancarios_EspecialistasScript.Substring(indexOfArray, strDatos_Bancarios_EspecialistasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDatos_Bancarios_EspecialistasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDatos_Bancarios_EspecialistasScript.Substring(indexOfArrayHistory, strDatos_Bancarios_EspecialistasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDatos_Bancarios_EspecialistasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDatos_Bancarios_EspecialistasScript.Substring(endIndexOfMainElement + indexOfArray, strDatos_Bancarios_EspecialistasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Datos_Bancarios_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDatos_Bancarios_EspecialistasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDatos_Bancarios_EspecialistasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDatos_Bancarios_EspecialistasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDatos_Bancarios_EspecialistasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Datos_Bancarios_Especialistas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Datos_Bancarios_Especialistas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Datos_Bancarios_Especialistas.js")))
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
        public ActionResult Datos_Bancarios_EspecialistasPropertyBag()
        {
            return PartialView("Datos_Bancarios_EspecialistasPropertyBag", "Datos_Bancarios_Especialistas");
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

            _IDatos_Bancarios_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Datos_Bancarios_EspecialistasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDatos_Bancarios_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Datos_Bancarios_Especialistass == null)
                result.Datos_Bancarios_Especialistass = new List<Datos_Bancarios_Especialistas>();

            var data = result.Datos_Bancarios_Especialistass.Select(m => new Datos_Bancarios_EspecialistasGridModel
            {
                Folio = m.Folio
                ,BancoNombre = (string)m.Banco_Bancos.Nombre
                ,CLABE_Interbancaria = m.CLABE_Interbancaria
                ,Num_Cuenta = m.Num_Cuenta
                ,Nombre_del_Titular = m.Nombre_del_Titular
                ,Principal = m.Principal

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Datos_Bancarios_EspecialistasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Datos_Bancarios_EspecialistasList_" + DateTime.Now.ToString());
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

            _IDatos_Bancarios_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Datos_Bancarios_EspecialistasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDatos_Bancarios_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Datos_Bancarios_Especialistass == null)
                result.Datos_Bancarios_Especialistass = new List<Datos_Bancarios_Especialistas>();

            var data = result.Datos_Bancarios_Especialistass.Select(m => new Datos_Bancarios_EspecialistasGridModel
            {
                Folio = m.Folio
                ,BancoNombre = (string)m.Banco_Bancos.Nombre
                ,CLABE_Interbancaria = m.CLABE_Interbancaria
                ,Num_Cuenta = m.Num_Cuenta
                ,Nombre_del_Titular = m.Nombre_del_Titular
                ,Principal = m.Principal

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
