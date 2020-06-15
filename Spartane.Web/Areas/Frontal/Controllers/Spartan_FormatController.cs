using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Format;
using Spartane.Core.Domain.Spartan_Format_Type;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Format;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Type;

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
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Core.Domain.Spartan_Metadata;
using System.Net;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Core.Domain.Spartan_Format_Field;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using System.Data;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format_Related;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_FormatController : Controller
    {
        #region "variable declaration"

        private ISpartan_FormatService service = null;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_TypeApiConsumer _ISpartan_Format_TypeApiConsumer;

        private ISpartaneObjectApiConsumer _ISpartaneObjectApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;

        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer = null;
        private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;
        private Spartane_Credential _userCredential = null;
        private ISpartan_UserApiConsumer _IUserApiConsumer;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"


        public Spartan_FormatController(ISpartan_FormatService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_Format_TypeApiConsumer Spartan_Format_TypeApiConsumer, ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartaneObjectApiConsumer SpartaneObjectApiConsumer, ISpartan_UserApiConsumer UserApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartaneQueryApiConsumer SpartaneQueryApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_FormatRelatedApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_Format_TypeApiConsumer = Spartan_Format_TypeApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._ISpartaneObjectApiConsumer = SpartaneObjectApiConsumer;
            this._IUserApiConsumer = UserApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
            this._ISpartan_FormatRelatedApiConsumer = Spartan_FormatRelatedApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Format
        [ObjectAuth(ObjectId = (ModuleObjectId)31754, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31754);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Format/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)31754, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0, int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31754);
            ViewBag.Permission = permission;
            var varSpartan_Format = new Spartan_FormatModel();

            varSpartan_Format.Registration_Date = DateTime.Today.ToString("dd-MM-yyyy");
            varSpartan_Format.Registration_Hour = DateTime.Now.ToShortTimeString();
            varSpartan_Format.Registration_User = SessionHelper.UserEntity.Id_User;
            ViewBag.ObjectId = "31754";
            ViewBag.Operation = "new";

            ViewBag.IsNew = true;

            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || (Id.GetType() == typeof(int) && Id.ToString() != "0"))
            {
                ViewBag.IsNew = false;
                ViewBag.Operation = "edit";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_FormatData = _ISpartan_FormatApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Formats[0];
                if (Spartan_FormatData == null)
                    return HttpNotFound();

                varSpartan_Format = new Spartan_FormatModel
                {
                    FormatId = Spartan_FormatData.FormatId
                    ,
                    Registration_Date = (Spartan_FormatData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_FormatData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                    Registration_Hour = Spartan_FormatData.Registration_Hour
                    ,
                    Registration_User = Spartan_FormatData.Registration_User
                    ,
                    Format_Name = Spartan_FormatData.Format_Name
                    ,
                    Format_Type = Spartan_FormatData.Format_Type
                    ,
                    Format_TypeDescription = (string)Spartan_FormatData.Format_Type_Spartan_Format_Type.Description
                    ,
                    Search = Spartan_FormatData.Search
                    ,
                    Object = Spartan_FormatData.Object
                    ,
                    Header = Spartan_FormatData.Header
                    ,
                    Body = Spartan_FormatData.Body
                    ,
                    Footer = Spartan_FormatData.Footer
                    ,
                    Filter = Spartan_FormatData.Filter

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Format_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Format_Types = _ISpartan_Format_TypeApiConsumer.SelAll(true);
            if (Spartan_Format_Types != null && Spartan_Format_Types.Resource != null)
                ViewBag.Spartan_Format_Types = Spartan_Format_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.FormatTypeId)
                }).ToList();


            ViewBag.Spartan_Objects = GetAllObjectListItem();

            _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects = _ISpartaneObjectApiConsumer.SelAll(true);
            if (Spartan_Objects != null && Spartan_Objects.Resource != null)
                ViewBag.Spartan_Objects = Spartan_Objects.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.Object_Id)
                }).ToList();

            _IUserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Users = _IUserApiConsumer.SelAll(false);
            if (Users != null && Users.Resource != null)
            {
                ViewBag.Users = Users.Resource.Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();

            }

            ViewBag.Consult = consult == 1;
            if (consult == 1)
                ViewBag.Operation = "consult";
            return View(varSpartan_Format);
        }

        private List<SelectListItem> GetAllObjectListItem()
        {
            _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects = _ISpartaneObjectApiConsumer.SelAll(true);
            if (Spartan_Objects == null || Spartan_Objects.Resource == null)
                return null;

            var data = Spartan_Objects.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
            {
                Text = m.Description.ToString(),
                Value = Convert.ToString(m.Object_Id)
            }).ToList();

            return data;
        }
        [HttpGet]
        public ActionResult FilterObjects(string filter)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;

                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                if (filter != string.Empty)
                {
                    var whereClause = "Spartan_Object.Name IS NOT NULL AND(Spartan_Metadata.Class_Name LIKE '%" + filter + "%' OR Spartan_Metadata.Physical_Name LIKE '%" + filter + "%'  OR Spartan_Metadata.Logical_Name  LIKE '%" + filter + "%') ";
                    var orderClause = "Spartan_Metadata.Object_Id";
                    var Spartan_Metadatas = _ISpartan_MetadataApiConsumer.SelAll(true, whereClause, orderClause);
                    var data = Spartan_Metadatas.Resource.GroupBy(obj => new { obj.Object_Id, obj.Spartan_Object.Name }).Select(o => o.First()).Select(m => new SelectListItem
                    {
                        Text = m.Spartan_Object.Name.ToString(),
                        Value = Convert.ToString(m.Object_Id)
                    }).OrderBy(obj => obj.Text).ToList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(GetAllObjectListItem(), JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { Saved = false, Message = ex.Message });

            }
        }


        #region jsTree
        /// <summary>
        /// FillComponentsTree (Action que se ejecuta cuando se asigna un valor al objectId)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FillComponentsTree(int id)
        {
            try
            {
                IList<Spartan_Metadata> components = GetSpantan_Metadata(id);
                var data = RenderTreeView(null, components, new List<JsTreeNodeModel>());
                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { Saved = false, Message = ex.Message });

            }
        }


        /// <summary>
        ///  GetSpantan_Metadata (Este metodo busca los elementos de la tabla Spartan_Metadata para llenar el arbol)
        /// </summary>
        /// <param name="Object_Id">Id del objeto</param>
        /// <returns>Lista de elemntos Spartan_Metadata</returns>
        private IList<Spartan_Metadata> GetSpantan_Metadata(int Object_Id)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var whereClause = "Spartan_Metadata.Object_Id=" + Object_Id + " AND (Spartan_Metadata.Related_Object_Id IS NULL OR Spartan_Metadata.Identifier_Type IS NULL ) ";
            var orderClause = "Spartan_Metadata.ScreenOrder";
            var Spartan_Metadatas = _ISpartan_MetadataApiConsumer.SelAll(true, whereClause, orderClause);
            if (Spartan_Metadatas != null && Spartan_Metadatas.Resource != null)
                return Spartan_Metadatas.Resource.ToList();

            return null;
        }

       /// <summary>
        /// RenderTreeView (Esta es la funcion que arma el arbol con sus hijos)
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        private List<JsTreeNodeModel> RenderTreeView(JsTreeNodeModel parent, IList<Spartan_Metadata> components, List<JsTreeNodeModel> nodes)
        {

            foreach (Spartan_Metadata comp in components)
            {
                JsTreeNodeModel rootNode = new JsTreeNodeModel { text = comp.Logical_Name.ToString(), children = new List<JsTreeNodeModel>(), li_attr = new JsTreeAttributeModel { draggable = true, className = comp.Class_Name, physicalName = comp.Physical_Name, logicalName = comp.Logical_Name, objectName = comp.Spartan_Object.Name, atributteId = comp.AttributeId.ToString(), classId = comp.Class_Id.ToString() } };

                if (parent != null)
                {
                    rootNode.li_attr.fieldPath = parent.li_attr.fieldPath + "." + rootNode.li_attr.atributteId;
                    parent.children.Add(rootNode);
                    rootNode.id = parent.id + "." + rootNode.li_attr.fieldPath;
                }
                else
                {
                    rootNode.li_attr.fieldPath = comp.Class_Id.ToString();
                    rootNode.id = comp.AttributeId.ToString();
                }

                rootNode.state = new JsTreeNodeStateModel { opened = false, selected = false, disabled = false };
                if (comp.Related_Object_Id != null && comp.Object_Id != comp.Related_Object_Id)
                {
                    var rootNodeAttr = rootNode.id.Split('.');
                    if (rootNodeAttr.AsEnumerable().Where(c => c == comp.AttributeId.ToString()).Count() <= 2)
                        RenderTreeView(rootNode, GetSpantan_Metadata(Convert.ToInt32(comp.Related_Object_Id)), nodes);
                }

                nodes.Add(rootNode);
            }
            return nodes;

        }


        #endregion
        [HttpGet]
        public ActionResult AddSpartan_Format(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31754);
            ViewBag.Permission = permission;
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            Spartan_FormatModel varSpartan_Format = new Spartan_FormatModel();


            if (id != 0)
            {
                var Spartan_FormatData = _ISpartan_FormatApiConsumer.GetByKey(id, true).Resource;

                varSpartan_Format = new Spartan_FormatModel
                {
                    FormatId = Spartan_FormatData.FormatId
                    ,
                    Registration_Date = (Spartan_FormatData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_FormatData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                    Registration_Hour = Spartan_FormatData.Registration_Hour
                    ,
                    Registration_User = Spartan_FormatData.Registration_User
                    ,
                    Format_Name = Spartan_FormatData.Format_Name
                    ,
                    Format_Type = Spartan_FormatData.Format_Type
                    ,
                    Format_TypeDescription = (string)Spartan_FormatData.Format_Type_Spartan_Format_Type.Description
                    ,
                    Search = Spartan_FormatData.Search
                    ,
                    Object = Spartan_FormatData.Object
                    ,
                    Header = Spartan_FormatData.Header
                    ,
                    Body = Spartan_FormatData.Body
                    ,
                    Footer = Spartan_FormatData.Footer

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Format_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Format_Types = _ISpartan_Format_TypeApiConsumer.SelAll(true);
            if (Spartan_Format_Types != null && Spartan_Format_Types.Resource != null)
                ViewBag.Spartan_Format_Types = Spartan_Format_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.FormatTypeId)
                }).ToList();


            return PartialView("AddSpartan_Format", varSpartan_Format);
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
        public ActionResult GetSpartan_Format_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Format_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Format_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_FormatAdvanceSearchModel model)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Format_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Format_Types = _ISpartan_Format_TypeApiConsumer.SelAll(true);
            if (Spartan_Format_Types != null && Spartan_Format_Types.Resource != null)
                ViewBag.Spartan_Format_Types = Spartan_Format_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.FormatTypeId)
                }).ToList();


            return View(model);
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Format_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Format_Types = _ISpartan_Format_TypeApiConsumer.SelAll(true);
            if (Spartan_Format_Types != null && Spartan_Format_Types.Resource != null)
                ViewBag.Spartan_Format_Types = Spartan_Format_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.FormatTypeId)
                }).ToList();


            var previousFiltersObj = new Spartan_FormatAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_FormatAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_FormatAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_FormatPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_FormatApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Formats == null)
                result.Spartan_Formats = new List<Spartan_Format>();

            return Json(new
            {
                data = result.Spartan_Formats.Select(m => new Spartan_FormatGridModel
                {
                    FormatId = m.FormatId
                    ,
                    Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
        ,
                    Registration_Hour = m.Registration_Hour
        ,
                    Registration_User = m.Registration_User
        ,
                    Format_Name = m.Format_Name
                    ,
                    Format_TypeDescription = (string)m.Format_Type_Spartan_Format_Type.Description
        ,
                    Search = m.Search
        ,
                    Object = m.Object
        ,
                    Header = m.Header
        ,
                    Body = m.Body
        ,
                    Footer = m.Footer

                }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Format from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Format Entity</returns>
        public ActionResult GetSpartan_FormatList(int sEcho, int iDisplayStart, int iDisplayLength)
        {
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (Request.QueryString["iSortCol_0"] != null)
            {
                sortColumn = int.Parse(Request.QueryString["iSortCol_0"]);
            }
            if (Request.QueryString["sSortDir_0"] != null)
            {
                sortDirection = Request.QueryString["sSortDir_0"];
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_FormatPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_FormatAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_FormatPropertyMapper oSpartan_FormatPropertyMapper = new Spartan_FormatPropertyMapper();

            configuration.OrderByClause = oSpartan_FormatPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_FormatApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Formats == null)
                result.Spartan_Formats = new List<Spartan_Format>();

            return Json(new
            {
                aaData = result.Spartan_Formats.Select(m => new Spartan_FormatGridModel
                {
                    FormatId = m.FormatId
                            ,
                    Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                ,
                    Registration_Hour = m.Registration_Hour
                ,
                    Registration_User = m.Registration_User
                ,
                    Registration_UserName = m.User_Spartan_Format_User.Name
                ,
                    Format_Name = m.Format_Name
                            ,
                    Format_TypeDescription = (string)m.Format_Type_Spartan_Format_Type.Description
                ,
                    Search = m.Search
                ,
                    ObjectName = m.Spartan_Object_Spartan_Format_Object.Name
                ,
                    Header = WebUtility.HtmlDecode(m.Header)
                ,
                    Body = WebUtility.HtmlDecode(m.Body)
                ,
                    Footer = WebUtility.HtmlDecode(m.Footer)

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Format from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Format Entity</returns>
        public ActionResult GetSpartan_FormatListRelated(int formatId, int object_id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_FormatApiConsumer.ListaSelAll(0, 5000, "Spartan_Format.Object = " + object_id + " AND Spartan_Format.FormatId <>" + formatId, "").Resource;
            if (result.Spartan_Formats == null)
                result.Spartan_Formats = new List<Spartan_Format>();

            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);


            var relacionados = formatId > 0 ? _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + formatId, "").Resource : null;

            var listaResult = new List<Spartan_Format_RelatedGridModel>();
            foreach (Spartan_Format item in result.Spartan_Formats)
            {
                var rela = new Spartan_Format_RelatedGridModel();
                rela.FormatId = item.FormatId;
                rela.FormatName = item.Format_Name;
                rela.Selected = false;
                if (relacionados != null && relacionados.Spartan_Format_Relateds != null && relacionados.Spartan_Format_Relateds.Count() > 0)
                {
                    var ralacionado = relacionados.Spartan_Format_Relateds.Where(r => r.FormatId_Related == item.FormatId).FirstOrDefault();
                    rela.Selected = ralacionado != null;
                    rela.Order = ralacionado != null ? ralacionado.Order : 9999;
                }
                listaResult.Add(rela);
            }
            return Json(listaResult.OrderBy(or => or.Order).ToList(), JsonRequestBehavior.AllowGet);
        }


        [NonAction]
        public string GetAdvanceFilter(Spartan_FormatAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFormatId) || !string.IsNullOrEmpty(filter.ToFormatId))
            {
                if (!string.IsNullOrEmpty(filter.FromFormatId))
                    where += " AND Spartan_Format.FormatId >= " + filter.FromFormatId;
                if (!string.IsNullOrEmpty(filter.ToFormatId))
                    where += " AND Spartan_Format.FormatId <= " + filter.ToFormatId;
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Date) || !string.IsNullOrEmpty(filter.ToRegistration_Date))
            {
                var Registration_DateFrom = DateTime.ParseExact(filter.FromRegistration_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Registration_DateTo = DateTime.ParseExact(filter.ToRegistration_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromRegistration_Date))
                    where += " AND Spartan_Format.Registration_Date >= '" + Registration_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Date))
                    where += " AND Spartan_Format.Registration_Date <= '" + Registration_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Hour) || !string.IsNullOrEmpty(filter.ToRegistration_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Format.Registration_Hour) >='" + filter.FromRegistration_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Format.Registration_Hour) <='" + filter.ToRegistration_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_User) || !string.IsNullOrEmpty(filter.ToRegistration_User))
            {
                if (!string.IsNullOrEmpty(filter.FromRegistration_User))
                    where += " AND Spartan_Format.Registration_User >= " + filter.FromRegistration_User;
                if (!string.IsNullOrEmpty(filter.ToRegistration_User))
                    where += " AND Spartan_Format.Registration_User <= " + filter.ToRegistration_User;
            }

            if (!string.IsNullOrEmpty(filter.Format_Name))
            {
                switch (filter.Format_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format.Format_Name LIKE '" + filter.Format_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format.Format_Name LIKE '%" + filter.Format_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format.Format_Name = '" + filter.Format_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format.Format_Name LIKE '%" + filter.Format_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceFormat_Type))
            {
                switch (filter.Format_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format_Type.Description LIKE '" + filter.AdvanceFormat_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format_Type.Description LIKE '%" + filter.AdvanceFormat_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format_Type.Description = '" + filter.AdvanceFormat_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format_Type.Description LIKE '%" + filter.AdvanceFormat_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvanceFormat_TypeMultiple != null && filter.AdvanceFormat_TypeMultiple.Count() > 0)
            {
                var Format_TypeIds = string.Join(",", filter.AdvanceFormat_TypeMultiple);

                where += " AND Spartan_Format.Format_Type In (" + Format_TypeIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Search))
            {
                switch (filter.SearchFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format.Search LIKE '" + filter.Search + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format.Search LIKE '%" + filter.Search + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format.Search = '" + filter.Search + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format.Search LIKE '%" + filter.Search + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromObject) || !string.IsNullOrEmpty(filter.ToObject))
            {
                if (!string.IsNullOrEmpty(filter.FromObject))
                    where += " AND Spartan_Format.Object >= " + filter.FromObject;
                if (!string.IsNullOrEmpty(filter.ToObject))
                    where += " AND Spartan_Format.Object <= " + filter.ToObject;
            }

            if (!string.IsNullOrEmpty(filter.Header))
            {
                switch (filter.HeaderFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format.Header LIKE '" + filter.Header + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format.Header LIKE '%" + filter.Header + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format.Header = '" + filter.Header + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format.Header LIKE '%" + filter.Header + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Body))
            {
                switch (filter.BodyFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format.Body LIKE '" + filter.Body + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format.Body LIKE '%" + filter.Body + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format.Body = '" + filter.Body + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format.Body LIKE '%" + filter.Body + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Footer))
            {
                switch (filter.FooterFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format.Footer LIKE '" + filter.Footer + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format.Footer LIKE '%" + filter.Footer + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format.Footer = '" + filter.Footer + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format.Footer LIKE '%" + filter.Footer + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
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
                _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_Format varSpartan_Format = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_FormatApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_FormatModel varSpartan_Format)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var result = "";

                    varSpartan_Format.Registration_Date = "01-01-2018";
                    var Spartan_FormatInfo = new Spartan_Format
                    {
                        FormatId = varSpartan_Format.FormatId
                        ,
                        Registration_Date = DateTime.ParseExact(varSpartan_Format.Registration_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider)
                        ,
                        Registration_Hour = DateTime.Now.ToShortTimeString()
                        ,
                        Registration_User = SessionHelper.Role
                        ,
                        Format_Name = varSpartan_Format.Format_Name
                        ,
                        Format_Type = varSpartan_Format.Format_Type
                        ,
                        Search = varSpartan_Format.Search
                        ,
                        Object = varSpartan_Format.Object
                        ,
                        Header = System.Net.WebUtility.HtmlDecode(varSpartan_Format.Header)
                        ,
                        Body = System.Net.WebUtility.HtmlDecode(varSpartan_Format.Body)
                        ,
                        Footer = System.Net.WebUtility.HtmlDecode(varSpartan_Format.Footer)
                        ,
                        Filter = varSpartan_Format.Filter.Trim()

                    };

                    Spartan_FormatInfo.Format_Field_Spartan_Format_Field = GetSpartan_Format_FieldList(Spartan_FormatInfo);
                    result = !IsNew ?
                   _ISpartan_FormatApiConsumer.Update(Spartan_FormatInfo, null, null).Resource.ToString() :
                    _ISpartan_FormatApiConsumer.Insert(Spartan_FormatInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_Format_Relates(List<Spartan_Format_RelatedGridModel> items, int MasterId)
        {
            try
            {
                bool result = true;

                if (items != null && items.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

                    ///Borro todos los formatos relacionados
                    var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 1000, "Spartan_Format.FormatId=" + MasterId, string.Empty).Resource.Spartan_Format_Relateds;
                    if (relacionados != null)
                    {
                        foreach (var rel in relacionados)
                        {
                            var delete = _ISpartan_FormatRelatedApiConsumer.Delete(rel.Clave, null, null).Resource;
                        }
                    }

                    short i = 1;
                    foreach (var itemRelated in items)
                    {

                        var itemRelatedData = new Spartan_Format_Related
                        {
                            Clave = 0,
                            FormatId = MasterId,
                            FormatId_Related = itemRelated.FormatId_Related,
                            Order = i
                        };

                        var resultId = _ISpartan_FormatRelatedApiConsumer.Insert(itemRelatedData, null, null).Resource;
                        result = result && resultId != -1;
                        i++;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        private List<Spartan_Format_Field> GetSpartan_Format_FieldList(Spartan_Format Spartan_FormatInfo)
        {
            var fiels = new List<Spartan_Format_Field>();

            Regex regex = new Regex("<span class=\"h-card\"[^>]*>(.*?)</span>");

            if (!string.IsNullOrEmpty(Spartan_FormatInfo.Header) && regex.IsMatch(Spartan_FormatInfo.Header))
            {
                MatchCollection collection = regex.Matches(Spartan_FormatInfo.Header);
                foreach (Match m in collection)
                    fiels.Add(GetField(Spartan_FormatInfo, m, FormatFieldTypeHtml.Header.ToString()));
            }
            if (!string.IsNullOrEmpty(Spartan_FormatInfo.Body) && regex.IsMatch(Spartan_FormatInfo.Body))
            {
                MatchCollection collection = regex.Matches(Spartan_FormatInfo.Body);
                foreach (Match m in collection)
                {
                    var f = GetField(Spartan_FormatInfo, m, FormatFieldTypeHtml.Body.ToString());
                    if (fiels.Where(fld => fld.Field_Path == f.Field_Path).Count() == 0)
                        fiels.Add(f);
                }

            }
            if (!string.IsNullOrEmpty(Spartan_FormatInfo.Footer) && regex.IsMatch(Spartan_FormatInfo.Footer))
            {
                MatchCollection collection = regex.Matches(Spartan_FormatInfo.Footer);
                foreach (Match m in collection)
                    fiels.Add(GetField(Spartan_FormatInfo, m, FormatFieldTypeHtml.Footer.ToString()));
            }

            return fiels;
        }
        private Spartan_Format_Field GetField(Spartan_Format Spartan_FormatInfo, Match m, string Type_Html)
        {
            var datas = m.Value.Split(' ');
            var field_Path = datas.FirstOrDefault(str => str.Contains("data-fieldpath")).Split('=')[1].Replace("\"", string.Empty);
            var logicalName = datas.FirstOrDefault(str => str.Contains("data-logical_name")).Split('=')[1].Replace("\"", string.Empty);
            var physicallName = datas.FirstOrDefault(str => str.Contains("data-physical_name")).Split('=')[1].Replace("\"", string.Empty);
            return new Spartan_Format_Field { Field_Path = field_Path, Type_Html = Type_Html, Logical_Field_Name = logicalName, Physical_Field_Name = physicallName, Creation_Date = Spartan_FormatInfo.Registration_Date, Creation_Hour = Spartan_FormatInfo.Registration_Hour, Creation_User = Spartan_FormatInfo.Registration_User };
        }

        /// <summary>
        /// Write Element Array of Spartan_Format script
        /// </summary>
        /// <param name="oSpartan_FormatElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_FormatModuleAttributeList)
        {
            for (int i = 0; i < Spartan_FormatModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_FormatModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_FormatModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_FormatModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_FormatModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
            if (Spartan_FormatModuleAttributeList.ChildModuleAttributeList != null)
            {
                for (int i = 0; i < Spartan_FormatModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(Spartan_FormatModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
                    {
                        Spartan_FormatModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
                    }
                    if (string.IsNullOrEmpty(Spartan_FormatModuleAttributeList.ChildModuleAttributeList[i].HelpText))
                    {
                        Spartan_FormatModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
                    }
                }
            }
            string strSpartan_FormatScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Format.js")))
            {
                strSpartan_FormatScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Format element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_FormatModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_FormatScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_FormatScript.Substring(indexOfArray, strSpartan_FormatScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_FormatModuleAttributeList.ChildModuleAttributeList);
            int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
            if (Spartan_FormatModuleAttributeList.ChildModuleAttributeList != null)
            {
                indexOfArrayHistory = strSpartan_FormatScript.IndexOf("inpuElementChildArray");
                splittedStringHistory = strSpartan_FormatScript.Substring(indexOfArrayHistory, strSpartan_FormatScript.Length - indexOfArrayHistory);
                indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
                endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
            }
            string finalResponse = strSpartan_FormatScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_FormatScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_FormatScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_FormatModuleAttributeList.ChildModuleAttributeList != null)
            {
                finalResponse = strSpartan_FormatScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_FormatScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_FormatScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_FormatScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
            }



            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Format.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Format.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Format.js")))
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
        public ActionResult Spartan_FormatPropertyBag()
        {
            return PartialView("Spartan_FormatPropertyBag", "Spartan_Format");
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

            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_FormatPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_FormatApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Formats == null)
                result.Spartan_Formats = new List<Spartan_Format>();

            var data = result.Spartan_Formats.Select(m => new Spartan_FormatGridModel
            {
                FormatId = m.FormatId
                ,
                Registration_Hour = m.Registration_Hour
                ,
                Registration_UserName = m.User_Spartan_Format_User.Name
                ,
                Format_Name = m.Format_Name
                ,
                Search = m.Search
                ,
                ObjectName = m.Spartan_Object_Spartan_Format_Object.Name
                ,
                Header = m.Header
                ,
                Body = m.Body
                ,
                Footer = m.Footer

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_FormatList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_FormatList_" + DateTime.Now.ToString());
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

            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_FormatPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_FormatApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Formats == null)
                result.Spartan_Formats = new List<Spartan_Format>();

            var data = result.Spartan_Formats.Select(m => new Spartan_FormatGridModel
            {
                FormatId = m.FormatId
                ,
                Registration_Hour = m.Registration_Hour
                ,
                Registration_User = m.Registration_User
                ,
                Format_Name = m.Format_Name
                ,
                Search = m.Search
                ,
                Object = m.Object
                ,
                Header = m.Header
                ,
                Body = m.Body
                ,
                Footer = m.Footer

            }).ToList();

            return PartialView("_Print", data);
        }

        [HttpGet]
        public ActionResult GetSetting(int id)
        {
            string QBID;
            string QBLabel;
            string propertyInputType;
            string plugin;
            pluginConfig pluginConfig = null;
            QueryBuilderDataType QBDataType;
            QueryBuilderInputType QBInputType;
            Dictionary<string, string> dropdownValues = new Dictionary<string, string>();

            QueryBuilderSettings settings = new QueryBuilderSettings();

            // plugins
            settings.plugins.Add("bt-tooltip-errors");
            settings.plugins.Add("not-group");
            settings.plugins.Add("sortable");

            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            var table = JsonConvert.DeserializeObject<DataTable>(_ISpartaneQueryApiConsumer.ExecuteRawQuery("exec spGetConfiguracionFiltrosFormatos " + id).Resource);

            List<Format_Filter> PropertyNames = new List<Format_Filter>();
            PropertyNames = (from DataRow dr in table.Rows
                             select new Format_Filter()
                             {
                                 Nombre = dr["Nombre"].ToString(),
                                 Nombre_de_Tabla = dr["Nombre_de_Tabla"].ToString(),
                                 Nombre_de_Campo = dr["Nombre_de_Campo"].ToString(),
                                 Query_Condition = dr["Query_Condicion"].ToString(),
                                 Tipo_de_Campo = Convert.ToInt64(dr["Tipo_de_Campo"])
                             }).ToList();
            foreach (var propertyName in PropertyNames)
            {
                QBID = propertyName.Nombre_de_Tabla != "" ? propertyName.Nombre_de_Tabla + "." + propertyName.Nombre_de_Campo : propertyName.Nombre_de_Campo;
                QBLabel = propertyName.Nombre;

                propertyInputType = Enum.GetName(typeof(Tipo_De_Campo), propertyName.Tipo_de_Campo);
                QBDataType = QueryBuilderFilter.GetQueryBuilderDataType(propertyInputType);
                QBInputType = QueryBuilderFilter.GetQueryBuilderInputType(propertyInputType);
                plugin = QueryBuilderFilter.GePluginType(propertyInputType);

                if (plugin != "" && plugin != null)
                {
                    pluginConfig = QueryBuilderFilter.GePluginConfig(plugin);
                }
                if (propertyName.Query_Condition != null)
                {
                    dropdownValues = _ISpartaneQueryApiConsumer.ExecuteQueryDictionary(propertyName.Query_Condition).Resource;
                }
                settings.filters.Add(new QueryBuilderFilter(QBID, QBLabel, QBDataType, QBInputType, dropdownValues, plugin, pluginConfig));
                dropdownValues = new Dictionary<string, string>(); //Clear the Dictionary or it will add up all dropdown from different properties
            }
            return Json(settings, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult PreviewHtml(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            var stringHtml = _IGeneratePDFApiConsumer.GenerateHTML(idFormat, RecordId);

            return Content(stringHtml.Resource, "text/html");
        }

        [HttpGet]
        public ActionResult PreviewPDF(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);

            MemoryStream ms = new MemoryStream();
            ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
        #endregion "Custom methods"
    }
}
