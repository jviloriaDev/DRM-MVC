using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Antecedentes_Familiares;
using Spartane.Core.Domain.Padecimientos;
using Spartane.Core.Domain.Parentesco;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Antecedentes_Familiares;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Antecedentes_Familiares;
using Spartane.Web.Areas.WebApiConsumer.Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Parentesco;

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
    public class Detalle_Antecedentes_FamiliaresController : Controller
    {
        #region "variable declaration"

        private IDetalle_Antecedentes_FamiliaresService service = null;
        private IDetalle_Antecedentes_FamiliaresApiConsumer _IDetalle_Antecedentes_FamiliaresApiConsumer;
        private IPadecimientosApiConsumer _IPadecimientosApiConsumer;
        private IParentescoApiConsumer _IParentescoApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Antecedentes_FamiliaresController(IDetalle_Antecedentes_FamiliaresService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Antecedentes_FamiliaresApiConsumer Detalle_Antecedentes_FamiliaresApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPadecimientosApiConsumer PadecimientosApiConsumer , IParentescoApiConsumer ParentescoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Antecedentes_FamiliaresApiConsumer = Detalle_Antecedentes_FamiliaresApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPadecimientosApiConsumer = PadecimientosApiConsumer;
            this._IParentescoApiConsumer = ParentescoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Antecedentes_Familiares
        [ObjectAuth(ObjectId = (ModuleObjectId)44341, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44341);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Antecedentes_Familiares/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44341, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44341);
            ViewBag.Permission = permission;
            var varDetalle_Antecedentes_Familiares = new Detalle_Antecedentes_FamiliaresModel();
			
            ViewBag.ObjectId = "44341";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Antecedentes_FamiliaresData = _IDetalle_Antecedentes_FamiliaresApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Antecedentes_Familiaress[0];
                if (Detalle_Antecedentes_FamiliaresData == null)
                    return HttpNotFound();

                varDetalle_Antecedentes_Familiares = new Detalle_Antecedentes_FamiliaresModel
                {
                    Folio = (int)Detalle_Antecedentes_FamiliaresData.Folio
                    ,Enfermedad = Detalle_Antecedentes_FamiliaresData.Enfermedad
                    ,EnfermedadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_FamiliaresData.Enfermedad), "Padecimientos") ??  (string)Detalle_Antecedentes_FamiliaresData.Enfermedad_Padecimientos.Descripcion
                    ,Parentesco = Detalle_Antecedentes_FamiliaresData.Parentesco
                    ,ParentescoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_FamiliaresData.Parentesco), "Parentesco") ??  (string)Detalle_Antecedentes_FamiliaresData.Parentesco_Parentesco.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Padecimientoss_Enfermedad = _IPadecimientosApiConsumer.SelAll(true);
            if (Padecimientoss_Enfermedad != null && Padecimientoss_Enfermedad.Resource != null)
                ViewBag.Padecimientoss_Enfermedad = Padecimientoss_Enfermedad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IParentescoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Parentescos_Parentesco = _IParentescoApiConsumer.SelAll(true);
            if (Parentescos_Parentesco != null && Parentescos_Parentesco.Resource != null)
                ViewBag.Parentescos_Parentesco = Parentescos_Parentesco.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Parentesco", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Antecedentes_Familiares);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Antecedentes_Familiares(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44341);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Antecedentes_FamiliaresModel varDetalle_Antecedentes_Familiares= new Detalle_Antecedentes_FamiliaresModel();


            if (id.ToString() != "0")
            {
                var Detalle_Antecedentes_FamiliaressData = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll(0, 1000, "Detalle_Antecedentes_Familiares.Folio=" + id, "").Resource.Detalle_Antecedentes_Familiaress;
				
				if (Detalle_Antecedentes_FamiliaressData != null && Detalle_Antecedentes_FamiliaressData.Count > 0)
                {
					var Detalle_Antecedentes_FamiliaresData = Detalle_Antecedentes_FamiliaressData.First();
					varDetalle_Antecedentes_Familiares= new Detalle_Antecedentes_FamiliaresModel
					{
						Folio  = Detalle_Antecedentes_FamiliaresData.Folio 
	                    ,Enfermedad = Detalle_Antecedentes_FamiliaresData.Enfermedad
                    ,EnfermedadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_FamiliaresData.Enfermedad), "Padecimientos") ??  (string)Detalle_Antecedentes_FamiliaresData.Enfermedad_Padecimientos.Descripcion
                    ,Parentesco = Detalle_Antecedentes_FamiliaresData.Parentesco
                    ,ParentescoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_FamiliaresData.Parentesco), "Parentesco") ??  (string)Detalle_Antecedentes_FamiliaresData.Parentesco_Parentesco.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Padecimientoss_Enfermedad = _IPadecimientosApiConsumer.SelAll(true);
            if (Padecimientoss_Enfermedad != null && Padecimientoss_Enfermedad.Resource != null)
                ViewBag.Padecimientoss_Enfermedad = Padecimientoss_Enfermedad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IParentescoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Parentescos_Parentesco = _IParentescoApiConsumer.SelAll(true);
            if (Parentescos_Parentesco != null && Parentescos_Parentesco.Resource != null)
                ViewBag.Parentescos_Parentesco = Parentescos_Parentesco.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Parentesco", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Antecedentes_Familiares", varDetalle_Antecedentes_Familiares);
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
        public ActionResult GetPadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPadecimientosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetParentescoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IParentescoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IParentescoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Parentesco", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Antecedentes_FamiliaresPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Antecedentes_Familiaress == null)
                result.Detalle_Antecedentes_Familiaress = new List<Detalle_Antecedentes_Familiares>();

            return Json(new
            {
                data = result.Detalle_Antecedentes_Familiaress.Select(m => new Detalle_Antecedentes_FamiliaresGridModel
                    {
                    Folio = m.Folio
                        ,EnfermedadDescripcion = CultureHelper.GetTraduction(m.Enfermedad_Padecimientos.Clave.ToString(), "Descripcion") ?? (string)m.Enfermedad_Padecimientos.Descripcion
                        ,ParentescoDescripcion = CultureHelper.GetTraduction(m.Parentesco_Parentesco.Clave.ToString(), "Descripcion") ?? (string)m.Parentesco_Parentesco.Descripcion

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
                _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Antecedentes_Familiares varDetalle_Antecedentes_Familiares = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Antecedentes_FamiliaresApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Antecedentes_FamiliaresModel varDetalle_Antecedentes_Familiares)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Antecedentes_FamiliaresInfo = new Detalle_Antecedentes_Familiares
                    {
                        Folio = varDetalle_Antecedentes_Familiares.Folio
                        ,Enfermedad = varDetalle_Antecedentes_Familiares.Enfermedad
                        ,Parentesco = varDetalle_Antecedentes_Familiares.Parentesco

                    };

                    result = !IsNew ?
                        _IDetalle_Antecedentes_FamiliaresApiConsumer.Update(Detalle_Antecedentes_FamiliaresInfo, null, null).Resource.ToString() :
                         _IDetalle_Antecedentes_FamiliaresApiConsumer.Insert(Detalle_Antecedentes_FamiliaresInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Antecedentes_Familiares script
        /// </summary>
        /// <param name="oDetalle_Antecedentes_FamiliaresElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Antecedentes_FamiliaresModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Antecedentes_FamiliaresModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Antecedentes_FamiliaresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Antecedentes_FamiliaresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Antecedentes_FamiliaresModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Antecedentes_FamiliaresModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Antecedentes_FamiliaresScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_Familiares.js")))
            {
                strDetalle_Antecedentes_FamiliaresScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Antecedentes_Familiares element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Antecedentes_FamiliaresModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Antecedentes_FamiliaresScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Antecedentes_FamiliaresScript.Substring(indexOfArray, strDetalle_Antecedentes_FamiliaresScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Antecedentes_FamiliaresScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Antecedentes_FamiliaresScript.Substring(indexOfArrayHistory, strDetalle_Antecedentes_FamiliaresScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Antecedentes_FamiliaresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Antecedentes_FamiliaresScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Antecedentes_FamiliaresScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Antecedentes_FamiliaresModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Antecedentes_FamiliaresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Antecedentes_FamiliaresScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Antecedentes_FamiliaresScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Antecedentes_FamiliaresScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_Familiares.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_Familiares.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_Familiares.js")))
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
        public ActionResult Detalle_Antecedentes_FamiliaresPropertyBag()
        {
            return PartialView("Detalle_Antecedentes_FamiliaresPropertyBag", "Detalle_Antecedentes_Familiares");
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

            _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Antecedentes_FamiliaresPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Antecedentes_Familiaress == null)
                result.Detalle_Antecedentes_Familiaress = new List<Detalle_Antecedentes_Familiares>();

            var data = result.Detalle_Antecedentes_Familiaress.Select(m => new Detalle_Antecedentes_FamiliaresGridModel
            {
                Folio = m.Folio
                ,EnfermedadDescripcion = (string)m.Enfermedad_Padecimientos.Descripcion
                ,ParentescoDescripcion = (string)m.Parentesco_Parentesco.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Antecedentes_FamiliaresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Antecedentes_FamiliaresList_" + DateTime.Now.ToString());
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

            _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Antecedentes_FamiliaresPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Antecedentes_Familiaress == null)
                result.Detalle_Antecedentes_Familiaress = new List<Detalle_Antecedentes_Familiares>();

            var data = result.Detalle_Antecedentes_Familiaress.Select(m => new Detalle_Antecedentes_FamiliaresGridModel
            {
                Folio = m.Folio
                ,EnfermedadDescripcion = (string)m.Enfermedad_Padecimientos.Descripcion
                ,ParentescoDescripcion = (string)m.Parentesco_Parentesco.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
