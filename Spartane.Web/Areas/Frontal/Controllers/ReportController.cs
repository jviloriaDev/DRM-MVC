using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Report;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;


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
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using System.Data;
using Newtonsoft.Json.Linq;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Core.Domain.SpartaneObject;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Advance_Filter;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]    
    public class ReportController : Controller
    {
        #region "variable declaration"

        private ISpartan_ReportService service = null;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private ISpartan_ReportApiConsumer _ISpartanReportApiConsumer;
        private ISpartan_Report_PermissionsApiConsumer _ISpartanReportPermissionsApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartanQueryApiConsumer;
        private ISpartaneObjectApiConsumer _ISpartaneObjectApiConsumer;
        private ISpartan_Report_FilterApiConsumer _ISpartan_Report_FilterApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_Metadata;

        private ISpartan_Report_Advance_FilterApiConsumer _ISpartan_Report_Advance_FilterApiConsumer;
        enum GrantAccessTypes
        {
            NotFound = -1,
            Denied = 0,
            Disabled = 1,
            Allow = 2
        };
        #endregion "variable declaration"

        #region "Constructor Declaration"


        public ReportController(ISpartan_ReportService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_ReportApiConsumer SpartanReportApiConsumer, ISpartan_Report_PermissionsApiConsumer SpartanReportPermissionsApiConsumer, ISpartaneQueryApiConsumer SpartanQueryApiConsumer, ISpartaneObjectApiConsumer SpartaneObjectApiConsumer, ISpartan_Report_FilterApiConsumer Spartan_Report_FilterApiConsumer, ISpartan_MetadataApiConsumer Spartan_Metadata, ISpartan_Report_Advance_FilterApiConsumer Spartan_Report_Advance_FilterApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartanReportApiConsumer = SpartanReportApiConsumer;
            this._ISpartanReportPermissionsApiConsumer = SpartanReportPermissionsApiConsumer;
            this._ISpartanQueryApiConsumer = SpartanQueryApiConsumer;
            this._ISpartaneObjectApiConsumer = SpartaneObjectApiConsumer;
            this._ISpartan_Report_FilterApiConsumer = Spartan_Report_FilterApiConsumer;
            this._ISpartan_Metadata = Spartan_Metadata;
            this._ISpartan_Report_Advance_FilterApiConsumer = Spartan_Report_Advance_FilterApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Report
        //[ObjectAuth(ObjectId = (ModuleObjectId)31960, PermissionType = PermissionTypes.Consult)]

        #region Get Report by type
        public ActionResult Index(int? id, bool renderInPartial = false)
        {
            //var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31960);
            //ViewBag.Permission = permission;
            //ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;

            if (!id.HasValue)
            {
                return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            }

            Core.Domain.Spartan_Report.Spartan_Report report = new Core.Domain.Spartan_Report.Spartan_Report();
            var grantType = GetGrantAccessType(id.Value, SessionHelper.Role, ref report);

            ViewBag.DeniedReport = false;
            ViewBag.DeniedType = 0;
            if (grantType == GrantAccessTypes.Denied || grantType == GrantAccessTypes.NotFound)
            {
                ViewBag.DeniedReport = true;
                ViewBag.DeniedType = 1;
            }

            if(grantType == GrantAccessTypes.Disabled)
            {
                ViewBag.DeniedReport = true;
                ViewBag.DeniedType = 2;
            }
            // Detailed Report
            if (report.Presentation_View == 1) return RedirectToAction("DetailedReport", "Report", new { id = id.Value, renderInPartial = renderInPartial });
            if (report.Presentation_View == 2) return RedirectToAction("CrossTable", "Report", new { id = id.Value, renderInPartial = renderInPartial });
            if (report.Presentation_View == 3) return RedirectToAction("BarsGraphic", "Report", new { id = id.Value, renderInPartial = renderInPartial });
            if (report.Presentation_View == 4) return RedirectToAction("LinesGraphic", "Report", new { id = id.Value, renderInPartial = renderInPartial });
            if (report.Presentation_View == 5) return RedirectToAction("PieGraphic", "Report", new { id = id.Value, renderInPartial = renderInPartial });

            return View();
        }

        public ActionResult DetailedReport(int id = 0, DataResult data = null, bool renderInPartial = false)
        {
            return GetReportGeneric(id, data, 1, renderInPartial);
        }

        public ActionResult CrossTable(int id = 0, DataResult data = null, bool renderInPartial = false)
        {
            return GetReportGeneric(id, data, 2, renderInPartial);
        }

        public ActionResult BarsGraphic(int id = 0, DataResult data = null, bool renderInPartial = false)
        {
            return GetReportGeneric(id, data, 3, renderInPartial);
        }

        public ActionResult LinesGraphic(int id = 0, DataResult data = null, bool renderInPartial = false)
        {
            return GetReportGeneric(id, data, 4, renderInPartial);
        }
        public ActionResult PieGraphic(int id = 0, DataResult data = null, bool renderInPartial = false)
        {
            return GetReportGeneric(id, data, 5, renderInPartial);
        }

        private ActionResult GetReportGeneric(int id = 0, DataResult data = null, int type=0, bool renderInPartial = false)
        {
            _tokenManager.GenerateToken();
            string token = _tokenManager.Token;
            bool isQuickFilter = false;
            bool isAdvanceFilter = false;
            Session["QuickReportFilter"] = null;
            Session["AdvanceReportFilter"] = null;
            List<Filter> quickFilters = null;
            List<Filter> advanceFilters = null;
            if (id == 0 && data == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });
            if (id == 0)
            {
                id = data.id;
                if (String.IsNullOrEmpty(data.type))
                {
                    Session["QuickReportFilter"] = data.filters;
                    isQuickFilter = true;
                }
                else
                {
                    Session["AdvanceReportFilter"] = data.filters;
                    isAdvanceFilter = true;
                }
            }
            quickFilters = GetQuickFilters(id, token);
            advanceFilters = GetCompleteAdvanceFilters(id);
            var report = GetReport(id);

            ViewBag.ReportName = report.Report_Name;

            if (report == null) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });

            if (report.Presentation_View != type) return RedirectToAction("Index", new { area = "Frontal", controller = "Home" });



            SpartaneObject obj = GetObject(report.Object.Value);
            if (report.Object.HasValue)
            {
                ViewBag.Object = obj;
                ViewBag.ObjectId = report.Object.Value;
            }
            var response = GetDataReport(obj, report.Query, quickFilters, advanceFilters, id);
            if (isQuickFilter || isAdvanceFilter)
                return Json(response.Resource);


            string json = response.Resource;
            var objects = JArray.Parse(json);

            if (objects.Count() != 0)
            {
                int countData = objects[0].Count();
                if (report.TotalColumns)
                {
                    ViewBag.TotalColumns = true;
                    //json = GetJsonWithTotalColumns(json, countData);
                }
                if (report.TotalRows)
                {
                    ViewBag.TotalRows = true;
                    //json = GetJsonWithTotalRows(json, countData);
                }
            }
            ViewBag.dataReport = json;

            ViewBag.IdReport = id;

            string htmlFilters = ConvertFiltersToHTML(quickFilters);
            ViewBag.Filters = htmlFilters;

            if (renderInPartial)
            {
                if (type == 1) return View("_DetailedReport");
                if (type == 2) return View("_CrossTable");
                if (type == 3) return View("_BarsGraphic");
                if (type == 4) return View("_LinesGraphic");
                if (type == 5) return View("_PieGraphic");
            }

            return View();           
        }   

        [HttpGet]
        public void Export(int id, int format, string iSortCol, string sSortDir)
        {

            var Report = GetData(id, iSortCol, sSortDir);
            var exportFormatType = (ExportFormatType)Enum.Parse(typeof(ExportFormatType), format.ToString(), true);

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(Report.Data, Report.Report_Name, true);
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(Report.Data, Report.Report_Name);
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(Report.Data, Report.Report_Name);
                    break;
            }

        }

        [HttpGet]
        public ActionResult Print(int id, string iSortCol, string sSortDir)
        {
            var Report = GetData(id, iSortCol, sSortDir);
            return PartialView("_Print", Report);
        }
        private PrintReport GetData(int idReport, string iSortCol, string sSortDir)
        {
            _tokenManager.GenerateToken();
            string token = _tokenManager.Token;

            List<Filter> quickFilters = null;
            List<Filter> advanceFilters = null;
            if (idReport == 0) return null;

            quickFilters = GetQuickFilters(idReport, token);
            advanceFilters = GetCompleteAdvanceFilters(idReport);
            var report = GetReport(idReport);

            if (report == null) return null;


            SpartaneObject obj = GetObject(report.Object.Value);
            if (report.Object.HasValue)
            {
                ViewBag.Object = obj;
                ViewBag.ObjectId = report.Object.Value;
            }
            var response = GetDataReport(obj, report.Query, quickFilters, advanceFilters, idReport, iSortCol, sSortDir);
            string json = response.Resource;


            var datatable = GetJsonWithTotalColumns(json);

   
            var data = new PrintReport() { Data = datatable, Report_Name = report.Report_Name };

            return data;
        
        }
        private string GetJsonWithTotalRows(string json, int countData)
        {
            string jsonFinal = "";
            string newColumnJson = "";
            var objects = JArray.Parse(json);
            Dictionary<string, float?> dataResult = new Dictionary<string, float?>();
            jsonFinal = "[";
            foreach (JObject root in objects)
            {
                float? val = null;
                newColumnJson = "{"; 
                foreach (KeyValuePair<String, JToken> app in root)
                {
                    var appName = app.Key;
                    var appValue = app.Value;
                    newColumnJson += "\"" + appName + "\":\"" + appValue + "\",";
                    try
                    {
                        if(val.HasValue)
                            val += float.Parse(appValue.ToString());
                        else
                            val = float.Parse(appValue.ToString());
                    }
                    catch (Exception ex)
                    {
                        if (val.HasValue)
                            val += 0;
                    }
                    
                }
                string valString = val.HasValue ? val.Value.ToString() : "";
                newColumnJson += "\"Total\":\"" + valString + "\"},";
                jsonFinal += newColumnJson;
            }
            jsonFinal = jsonFinal.Substring(0, jsonFinal.Length - 1);
            jsonFinal += "]";
            return jsonFinal;
        }

        private DataTable GetJsonWithTotalColumns(string json)
        {
            var DataTable = JsonConverterHelper.JsonStringToDataTable(json);

            DataRow drTotals = DataTable.NewRow();
            //How add the data from datatable to pdf table
            for (int row = 0; row < DataTable.Rows.Count; row++)
            {
                for (int column = 0; column < DataTable.Columns.Count; column++)
                {
                    DataTable.Columns[column].ColumnName = DataTable.Columns[column].ColumnName.Replace("_", " ");
                    if (isDecimal(DataTable.Rows[row][column].ToString()))
                    {
                        DataTable.Rows[row][column] = Decimal.Round(Convert.ToDecimal(DataTable.Rows[row][column]), 2);
                        drTotals[column] = (drTotals[column].ToString() != string.Empty ?  Decimal.Round(Convert.ToDecimal(drTotals[column]),2) : 0) + Decimal.Round(Convert.ToDecimal(DataTable.Rows[row][column]),2);
                    }
                    else
                    {
                        drTotals[column] = "";
                    }
                }
            }
            DataTable.Rows.Add(drTotals);
                
            return DataTable;
            
        }

        private bool  isDecimal(string valor)
        {
            decimal value;
            if (Decimal.TryParse(valor, out value))
                return true;
            else
                return false;
        }

        private string GetJsonWithTotalColumns2(string json, int countData)
        {
            var objects = JArray.Parse(json);
            Dictionary<string, float?> dataResult = new Dictionary<string, float?>();
            foreach (JObject root in objects)
            {
                foreach (KeyValuePair<String, JToken> app in root)
                {
                    var appName = app.Key;
                    var appValue = app.Value;
                    float? val = null;
                    try
                    {
                        val = float.Parse(appValue.ToString());
                    }
                    catch (Exception ex)
                    { }
                    if (dataResult.Keys.Contains(appName))
                    {
                        if (val.HasValue)
                        {
                            dataResult[appName] = dataResult[appName] + val;
                        }
                    }
                    else
                    {
                        dataResult.Add(appName, val);
                    }
                }
            }
            string newRow = "{";
            foreach (var item in dataResult)
            {
                string v = item.Value.ToString() ?? "";
                newRow += "\"" + item.Key.ToString() + "\":\"" + v + "\",";
            }
            newRow = newRow.Substring(0, newRow.Length - 1);
            newRow += "}";
            json = json.Substring(0, json.Length - 1);
            json = json + "," + newRow + "]";

            return json;
        }

        #endregion

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

        [HttpGet]
        public ActionResult ClearFilter(int id)
        {
            Session["AdvanceReportFilter"] = null;
            return RedirectToAction("Index", new { id = id });
        }

        #endregion "Controller Methods"

        #region "Custom methods"
        private GrantAccessTypes GetGrantAccessType(int reportId, int userRole, ref Core.Domain.Spartan_Report.Spartan_Report report)
        {
            if (!_tokenManager.GenerateToken())
                return GrantAccessTypes.NotFound;

            _ISpartanReportPermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);

            string sqlWhere = String.Format("User_Role = {0} AND Report = {1}", userRole, reportId);
            var reportPermissions = _ISpartanReportPermissionsApiConsumer.ListaSelAll(0, 3, sqlWhere, null);

            if (reportPermissions.Resource.RowCount == 0)
            {
                return GrantAccessTypes.Denied;
            }

            _ISpartanReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartanReportApiConsumer.GetByKey(reportId, false);

            if (response.Success == false || response.Resource == null) return GrantAccessTypes.Denied;

            if (response.Resource.Status == 2) return GrantAccessTypes.Disabled;

            report = response.Resource;

            return GrantAccessTypes.Allow;
        }

        private Core.Domain.Spartan_Report.Spartan_Report GetReport(int reportId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartanReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartanReportApiConsumer.GetByKey(reportId, false);

            if (response.Success == false || response.Resource == null) return null;

            if (response.Resource.Status == 2) return null;

            var report = response.Resource;

            return report;
        }

        private Core.Domain.SpartaneObject.SpartaneObject GetObject(int objectId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartaneObjectApiConsumer.GetByKey(objectId, false);

            if (response.Success == false || response.Resource == null) return null;

            var obj = response.Resource;

            return obj;
        }

        private WebApiConsumer.ResponseHelpers.ApiResponse<string> GetDataReport(SpartaneObject obj, string query, List<Filter> quickFilters = null, List<Filter> advanceFilters = null, int id = 0, string iSortCol = "", string sSortDir = "")
        {
            if (!_tokenManager.GenerateToken()) return null;
            _ISpartanQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            string quickwhere = "";
            string advanceWhere = "";
            string finishWhere = "";
            bool ret = false;
            if (Session["QuickReportFilter"] != null)
            {
                List<FilterResult> filters = (List<FilterResult>)Session["QuickReportFilter"];
                foreach (var filter in filters)
                {
                    if (!String.IsNullOrEmpty(filter.Valor) && filter.Valor != "Select Value..." && filter.Valor != "-1;-1;")
                    {
                        if (quickwhere != "")
                            quickwhere += " AND ";
                        int dataType = quickFilters.Where(x => x.PhysicalName == filter.PhysicalName).First().DataType;
                        int controlType = quickFilters.Where(x => x.PhysicalName == filter.PhysicalName).First().ControlType.Value;
                        switch (dataType)
                        {
                            case 1:
                                if (controlType == 1)
                                {
                                    string whereNum = "";
                                    string[] separateValues = filter.Valor.Split(';');
                                    if (separateValues[0] != "-1")
                                        whereNum += obj.URL + "." + filter.PhysicalName + " >= " + separateValues[0];
                                    if (separateValues[1] != "-1")
                                        if (whereNum == "")
                                            whereNum += obj.URL + "." + filter.PhysicalName + " <= " + separateValues[1];
                                        else
                                            whereNum += " AND " + obj.URL + "." + filter.PhysicalName + " <= " + separateValues[1];
                                    quickwhere += whereNum;
                                }
                                if (controlType == 2 || controlType == 6)
                                {
                                    quickwhere += obj.URL + "." + filter.PhysicalName + "=" + filter.Valor;
                                }
                                break;
                            case 2:
                                quickwhere += obj.URL + "." + filter.PhysicalName + " like '%" + filter.Valor + "%'";
                                break;
                            case 3:
                                quickwhere += obj.URL + "." + filter.PhysicalName + " like '" + filter.Valor + "'";
                                break;
                            case 4:
                                quickwhere += obj.URL + "." + filter.PhysicalName + "=" + filter.Valor;
                                break;
                            case 5:
                                string whereDate = "";
                                    string[] separateValuesDate = filter.Valor.Split(';');
                                    if (separateValuesDate[0] != "-1")
                                    {
                                        DateTime dateFrom = Convert.ToDateTime(separateValuesDate[0]);
                                        whereDate += obj.URL + "." + filter.PhysicalName + " >= '" + dateFrom.ToString("dd-MM-yyyy") + "'";
                                    }
                                    if (separateValuesDate[1] != "-1")
                                    {
                                        DateTime dateTo = Convert.ToDateTime(separateValuesDate[1]);
                                        if (whereDate == "")
                                            whereDate += obj.URL + "." + filter.PhysicalName + " <= '" + dateTo.ToString("dd-MM-yyyy") + "'";
                                        else
                                            whereDate += " AND " + obj.URL + "." + filter.PhysicalName + " <= '" + dateTo.ToString("dd-MM-yyyy") + "'";
                                    }
                                    quickwhere += whereDate;
                                break;
                            case 6:
                                string whereHour = "";
                                    string[] separateValuesHour = filter.Valor.Split(';');
                                    if (separateValuesHour[0] != "-1")
                                        whereHour += obj.URL + "." + filter.PhysicalName + " >= '" + separateValuesHour[0] + "'";
                                    if (separateValuesHour[1] != "-1")
                                        if (whereHour == "")
                                            whereHour += obj.URL + "." + filter.PhysicalName + " <= '" + separateValuesHour[1] + "'";
                                        else
                                            whereHour += " AND " + obj.URL + "." + filter.PhysicalName + " <= '" + separateValuesHour[1] + "'";
                                    quickwhere += whereHour;
                                break;
                            case 7:
                                quickwhere += obj.URL + "." + filter.PhysicalName + "='" + filter.Valor + "'";
                                break;
                            case 8:
                                quickwhere += obj.URL + "." + filter.PhysicalName + "='" + filter.Valor + "'";
                                break;
                            default:
                                quickwhere += obj.URL + "." + filter.PhysicalName + "=" + filter.Valor;
                                break;
                        }
                        
                    }
                }
            }
            if (Session["AdvanceReportFilter"] != null)
            {
                List<FilterResult> filters = (List<FilterResult>)Session["AdvanceReportFilter"];
                string filtersSelected = "'";
                foreach (var filter in filters)
                {
                    filtersSelected += filter.PhysicalName + ",";
                    if (!String.IsNullOrEmpty(filter.Valor) && filter.Valor != "Select Value..." && filter.Valor != "-1;-1;")
                    {
                        if (advanceWhere != "")
                            advanceWhere += " AND ";
                        int dataType = advanceFilters.Where(x => x.CampoQuery == filter.PhysicalName).First().DataType;
                        int controlType = advanceFilters.Where(x => x.CampoQuery == filter.PhysicalName).First().ControlType.Value;
                        switch (dataType)
                        {
                            case 1:
                                if (controlType == 1)
                                {
                                    string whereNum = "";
                                    string[] separateValues = filter.Valor.Split(';');
                                    if (separateValues[0] != "-1")
                                        whereNum += filter.PhysicalName + " >= " + separateValues[0];
                                    if (separateValues[1] != "-1")
                                        if (whereNum == "")
                                            whereNum += filter.PhysicalName + " <= " + separateValues[1];
                                        else
                                            whereNum += " AND " + filter.PhysicalName + " <= " + separateValues[1];
                                    advanceWhere += whereNum;
                                }
                                if (controlType == 2 || controlType == 6)
                                {
                                    advanceWhere += filter.PhysicalName + "=" + filter.Valor;
                                }
                                break;
                            case 2:
                                advanceWhere += filter.PhysicalName + " like '%" + filter.Valor + "%'";
                                break;
                            case 3:
                                advanceWhere += filter.PhysicalName + " like '" + filter.Valor + "'";
                                break;
                            case 4:
                                advanceWhere += filter.PhysicalName + "=" + filter.Valor;
                                break;
                            case 5:
                                string whereDate = "";
                                string[] separateValuesDate = filter.Valor.Split(';');
                                if (separateValuesDate[0] != "-1")
                                {
                                    DateTime dateFrom = Convert.ToDateTime(separateValuesDate[0]);
                                    whereDate += filter.PhysicalName + " >= '" + dateFrom.ToString("dd-MM-yyyy") + "'";
                                }
                                if (separateValuesDate[1] != "-1")
                                {
                                    DateTime dateTo = Convert.ToDateTime(separateValuesDate[1]);
                                    if (whereDate == "")
                                        whereDate += filter.PhysicalName + " <= '" + dateTo.ToString("dd-MM-yyyy") + "'";
                                    else
                                        whereDate += " AND " + filter.PhysicalName + " <= '" + dateTo.ToString("dd-MM-yyyy") + "'";
                                }
                                advanceWhere += whereDate;
                                break;
                            case 6:
                                string whereHour = "";
                                string[] separateValuesHour = filter.Valor.Split(';');
                                if (separateValuesHour[0] != "-1")
                                    whereHour += filter.PhysicalName + " >= '" + separateValuesHour[0] + "'";
                                if (separateValuesHour[1] != "-1")
                                    if (whereHour == "")
                                        whereHour += filter.PhysicalName + " <= '" + separateValuesHour[1] + "'";
                                    else
                                        whereHour += " AND " + filter.PhysicalName + " <= '" + separateValuesHour[1] + "'";
                                advanceWhere += whereHour;
                                break;
                            case 7:
                                advanceWhere += filter.PhysicalName + "='" + filter.Valor + "'";
                                break;
                            case 8:
                                advanceWhere += filter.PhysicalName + "='" + filter.Valor + "'";
                                break;
                            default:
                                advanceWhere += filter.PhysicalName + "=" + filter.Valor;
                                break;
                        }

                    }
                }
                filtersSelected = filtersSelected.Substring(0, filtersSelected.Length - 1);
                filtersSelected += "'";
                finishWhere = _ISpartanQueryApiConsumer.ExecuteRawQuery("EXEC spGetReportWhereDefault " + id + ", " + filtersSelected).Resource;
                finishWhere = JArray.Parse(finishWhere)[0]["Column1"].ToString();
                
            }
            string queryFirst = "";
            string querySecond = "";
            if (quickwhere != "" || advanceWhere != "")
            {
                if (String.IsNullOrEmpty(finishWhere))
                    finishWhere = "WHERE 1=1 ";
                if (quickwhere == "" && advanceWhere != "")
                    finishWhere = finishWhere + " AND " + advanceWhere;
                if (quickwhere != "" && advanceWhere == "")
                    finishWhere = finishWhere + " AND " + quickwhere;
                if (quickwhere != "" && advanceWhere != "")
                    finishWhere = finishWhere + " AND " + quickwhere + "AND" + advanceWhere;
                int indexSelect = query.ToLower().LastIndexOf("select");
                if (indexSelect != -1)
                {
                    queryFirst = query.Substring(0, indexSelect);
                    querySecond = query.Substring(indexSelect);
                }
            }
            string sort = iSortCol.Replace(" ", "_").ToString() + " " + sSortDir;
            if (sort != " ")
            {
                sort = " ORDER BY " + obj.URL + "." + sort;
            }
            string queryToSend = "";
            if (finishWhere != "")
            {
                if (!ret && querySecond.ToLower().Contains("group by"))
                {
                    querySecond = querySecond.ToLower().Replace("group by", " " + finishWhere + " group by");
                    ret = true;
                }
                else
                {
                    querySecond = querySecond + " " + finishWhere;
                    ret = true;
                }
                queryToSend = queryFirst + " " + querySecond;
            }
            else
                queryToSend = string.IsNullOrEmpty(query)?"":query;
            Regex regExp = new Regex(@"GLOBAL\[([^\]]+)\]");
            MatchCollection matches = regExp.Matches(queryToSend);
            for (int i = 0; i < matches.Count; i++)
            {
                string var = matches[i].Groups[1].ToString();
                if (Session[var] != null)
                    queryToSend = queryToSend.Replace(matches[i].ToString(), Session[var].ToString());
            }
            var resultQuery = _ISpartanQueryApiConsumer.ExecuteRawQuery(HttpUtility.UrlEncode(queryToSend));
			resultQuery.Resource = RemoveLineEndings(resultQuery.Resource);
            return resultQuery;
        }
		
		public string RemoveLineEndings(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\\r\\n", string.Empty)
                        .Replace("\\n", string.Empty)
                        .Replace("\\r", string.Empty)
                        .Replace(lineSeparator, string.Empty)
                        .Replace(paragraphSeparator, string.Empty);
        }
        #endregion "Custom methods"

        #region Advance Filters
        private List<Filter> GetCompleteAdvanceFilters(int reportId)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            IList<Spartan_Metadata> components = null;
            Spartan_Metadata metadata = null;
            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
            var filtersSaved = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll(0, 9999, "Spartan_Report_Advance_Filter.Report=" + reportId, "").Resource;
            List<Filter> result = new List<Filter>();
            bool isFilter = false;
            Spartan_Report_Advance_Filter filterSaved = null;

            foreach (var item in filtersSaved.Spartan_Report_Advance_Filters)
            {
                components = GetSpantan_Metadata(item.ObjectId.Value);
                metadata = components.Where(x => x.AttributeId == item.AttributeId).FirstOrDefault();
                if (metadata != null)
                {
                    result.Add(new Filter
                    {
                        DataType = metadata.Attribute_Type.Value,
                        ControlType = metadata.Control_Type,
                        Label = metadata.Logical_Name,
                        PhysicalName = metadata.Physical_Name,
                        RelationType = metadata.Relation_Type,
                        RelatedClassName = metadata.Related_Class_Name,
                        RelatedID = metadata.Related_Class_Identifier,
                        RelatedDescription = metadata.Related_Class_Description,
                        ClassName = metadata.Class_Name,
                        AttributeId = metadata.AttributeId.Value,
                        RelatedObjectID = metadata.Related_Object_Id,
                        ObjectID = metadata.Object_Id,
                        PathField = item.PathField,
                        CampoQuery = item.CampoQuery
                    });
                }
            }
            return result;
        }

        private string ConvertFiltersToHTML(List<Filter> filters)
        {
            string ret = "";
            string label = "<label class=\"col-sm-2 col-form-label\">[VALUE]</label>";
            string input = "<input id=\"[ID]\" name=\"[NAME]\" class=\"form-control greaterThanZero control-value\" type=\"text\" />";
            string checkbox = "<input id=\"[ID]\" name=\"[NAME]\" class=\"form-control control-value\" type=\"checkbox\" />";
            string dataCombo = "";
            foreach (var filter in filters)
            {
                ret += "<div class=\"form-group row filter-item\" data-physicalname=\"" + filter.PhysicalName + "\">";
                ret += label.Replace("[VALUE]", filter.Label);
                switch (filter.ControlType)
                {
                    case 1://TextBox
                        if (filter.DataType == 1)
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-daterange input-group\" id=\"datepicker\">";
                            ret += "<span class=\"input-group-addon\">" + Resources.Resources.From.ToString() + "</span>";
                            ret += input.Replace("[ID]", "filer_" + filter.FilterId.ToString() + "_From").Replace("[NAME]", "filer_" + filter.FilterId.ToString() + "_From");
                            ret += "<span class=\"input-group-addon\">" + Resources.Resources.To.ToString() + "</span>";
                            ret += input.Replace("[ID]", "filer_" + filter.FilterId.ToString() + "_To").Replace("[NAME]", "filer_" + filter.FilterId.ToString() + "_To");
                            ret += "</div>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 4)//Checkbox
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<select class=\"form-control control-value\" id=\"filer_" + filter.FilterId.ToString() + "\" name=\"filer_" + filter.FilterId.ToString() + "\">";
                            ret += "<option value=\"\">All</option>";
                            ret += "<option value=\"1\">" + Resources.Resources.Yes + "</option>";
                            ret += "<option value=\"0\">" + Resources.Resources.No + "</option>";
                            ret += "</select>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 5)//DatePicker
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-group date\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-calendar\"></i>From";
                            ret += "</span>";
                            ret += "<input id=\"filer_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control control-value\">";

                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-calendar\"></i>To";
                            ret += "</span>";
                            ret += "<input id=\"filer_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control control-value\">";
                            ret += "</div>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 6)//HourPicker
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-group\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-clock-o\"></i>From";
                            ret += "</span>";
                            ret += "<input data-autoclose=\"true\" id=\"filer_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control control-value\">";

                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-clock-o\"></i>To";
                            ret += "</span>";
                            ret += "<input data-autoclose=\"true\" id=\"filer_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control control-value\">";
                            ret += "</div>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 2)//TextBox
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += input.Replace("[ID]", "filer_" + filter.FilterId.ToString()).Replace("[NAME]", "filer_" + filter.FilterId.ToString());
                            ret += "</div>";
                        }
                        break;
                    case 2: //Combobox
                        dataCombo = GetDataCombo(filter.RelatedClassName, filter.RelatedID.Value, filter.RelatedDescription);
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<select class=\"form-control control-value\" id=\"filer_" + filter.FilterId.ToString() + "\" name=\"filer_" + filter.FilterId.ToString() + "\">";
                        ret += dataCombo;
                        ret += "</select>";
                        ret += "</div>";
                        break;
                    case 3: //ListBox
                        ret += "<div class=\"col-sm-6\">";
                        ret += input.Replace("[ID]", "filer_" + filter.FilterId.ToString()).Replace("[NAME]", "filer_" + filter.FilterId.ToString());
                        ret += "</div>";
                        break;
                    case 5://Checkbox
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<select class=\"form-control control-value\" id=\"filer_" + filter.FilterId.ToString() + "\" name=\"filer_" + filter.FilterId.ToString() + "\">";
                        ret += "<option value=\"\">All</option>";
                        ret += "<option value=\"1\">" + Resources.Resources.Yes + "</option>";
                        ret += "<option value=\"0\">" + Resources.Resources.No + "</option>";
                        ret += "</select>";
                        ret += "</div>";
                        break;
                    case 6://Autocomplete DropDownList
                        string dataiddesc = GetNameClaveAndDesc(filter.RelatedClassName, filter.RelatedID.Value, filter.RelatedDescription);

                        string urlData = "Frontal/" + filter.ClassName + "/Get" + filter.ClassName + "_" + filter.PhysicalName + "_" + filter.RelatedClassName;
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<select data-val=\"true\" data-idfield=\"" + dataiddesc.Split(';')[0] + "\" data-descfield=\"" + dataiddesc.Split(';')[1] + "\" data-url=\"" + urlData + "\" class=\"fullWidth AutoComplete form-control control-value select2-dropdown\" id=\"filer_" + filter.FilterId.ToString() + "\" name=\"filer_" + filter.FilterId.ToString() + "\">";
                        ret += "</select>";
                        ret += "</div>";
                        break;
                    case 8://DatePicker
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<div class=\"input-group date\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-calendar\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filer_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control\">";
                        ret += "</div>";
                        ret += "<div class=\"input-group date\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-calendar\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filer_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control\">";
                        ret += "</div>";
                        ret += "</div>";
                        break;
                    case 9://HourPicker
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<div class=\"input-group\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-clock-o\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filer_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control\">";
                        ret += "</div>";
                        ret += "<div class=\"input-group\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-clock-o\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filer_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control\">";
                        ret += "</div>";
                        ret += "</div>";
                        break;
                    default:
                        break;
                }
                ret += "</div>";
            }
            if (filters.Count > 0)
            {
                ret += "<div class=\"col\">";
                ret += "<input type=\"button\" class=\"btn btn-primary\" id=\"quickFilter\" value=\"Filtrar\" />";
                ret += "</div>";
            }
            return ret;
        }

        private string GetDataCombo(string className, int id, string description)
        {
            string result = "<option>Select Value...</option>";
            if (!_tokenManager.GenerateToken()) return null;
            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            var metadataId = _ISpartan_Metadata.GetByKey(id, false).Resource;
            var metadataDesc = _ISpartan_Metadata.GetByKey(Convert.ToInt32(description), false).Resource;
            string query = "Select " + metadataId.Physical_Name + ", " + metadataDesc.Physical_Name + " FROM " + className;
            var jsonData = _ISpartanQueryApiConsumer.ExecuteRawQuery(query).Resource;
            JArray v = JArray.Parse(jsonData);
            for (int i = 0; i < v.Count; i++)
            {
                var clave = (string)v[i][metadataId.Physical_Name];
                var desc = (string)v[i][metadataDesc.Physical_Name];
                result += "<option value=\"" + clave + "\">" + desc + "</option>";
            }
            return result;
        }

        private string GetNameClaveAndDesc(string className, int id, string description)
        {
            string result = "";
            if (!_tokenManager.GenerateToken()) return null;
            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            var metadataId = _ISpartan_Metadata.GetByKey(id, false).Resource;
            var metadataDesc = _ISpartan_Metadata.GetByKey(Convert.ToInt32(description), false).Resource;
            result = metadataId.Physical_Name + ";" + metadataDesc.Physical_Name;
            return result;
        }

        public ActionResult AdvanceFilterPopUp(int reportId, int objectId)
        {
            List<Filter> quickFilters = GetAdvanceFilters(reportId, objectId);
            string htmlFilters = ConvertFiltersToHTML(quickFilters, "popup");
            return PartialView("_AdvanceFiltersPopUp", htmlFilters);
        }

        public List<Filter> GetAdvanceFilters(int reportId, int objectId)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            IList<Spartan_Metadata> components = GetSpantan_Metadata(objectId);
            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
            var filtersSaved = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll(0, 9999, "Spartan_Report_Advance_Filter.Report=" + reportId + " AND Spartan_Report_Advance_Filter.Visible = 1", "").Resource;
            List<Filter> result = new List<Filter>();
            bool isFilter = false;
            Spartan_Report_Advance_Filter filterSaved = null;
            if (components.Count > 0)
            {
                foreach (var metadata in components)
                {
                    isFilter = false;
                    if (filtersSaved.RowCount > 0)
                    {
                        filterSaved = filtersSaved.Spartan_Report_Advance_Filters.Where(x => x.AttributeId == metadata.AttributeId || (x.AttributeId != metadata.AttributeId && x.ObjectId == metadata.Related_Object_Id)).FirstOrDefault();
                        if (filterSaved != null)
                        {
                            isFilter = true;
                        }
                    }
                    if (isFilter)
                    {
                        result.Add(new Filter
                        {
                            DataType = metadata.Attribute_Type.Value,
                            ControlType = metadata.Control_Type,
                            Label = metadata.Logical_Name,
                            PhysicalName = metadata.Physical_Name,
                            RelationType = metadata.Relation_Type,
                            RelatedClassName = metadata.Related_Class_Name,
                            RelatedID = metadata.Related_Class_Identifier,
                            RelatedDescription = metadata.Related_Class_Description,
                            ClassName = metadata.Class_Name,
                            AttributeId = metadata.AttributeId.Value,
                            RelatedObjectID = metadata.Related_Object_Id,
                            ObjectID = metadata.Object_Id,
                            PathField = filterSaved.PathField,
                            CampoQuery = filterSaved.CampoQuery
                        });
                    }
                }
            }
            return result;
        }

        private IList<Spartan_Metadata> GetSpantan_Metadata(int Object_Id)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            var whereClause = "Spartan_Metadata.Object_Id=" + Object_Id + " AND (Spartan_Metadata.Related_Object_Id IS NULL OR Spartan_Metadata.Identifier_Type IS NULL ) ";
            var orderClause = "Spartan_Metadata.ScreenOrder";
            var Spartan_Metadatas = _ISpartan_Metadata.SelAll(true, whereClause, orderClause);
            if (Spartan_Metadatas != null && Spartan_Metadatas.Resource != null)
                return Spartan_Metadatas.Resource.ToList();

            return null;
        }

        private string ConvertFiltersToHTML(List<Filter> filters, string sufijo = "")
        {
            string ret = "";
            string label = "<label class=\"col-sm-2 col-form-label\">[VALUE]</label>";
            string input = "<input id=\"[ID]\" name=\"[NAME]\" class=\"form-control greaterThanZero control-value\" type=\"text\" />";
            //string checkbox = "<input id=\"[ID]\" name=\"[NAME]\" class=\"form-control control-value\" type=\"checkbox\" />";
            string dataCombo = "";
            foreach (var filter in filters)
            {
                //if (filter.RelationType.HasValue)
                //{
                //    filter.ControlType = 10;
                //}
                ret += "<div class=\"form-group row filter-item" + sufijo + "\" data-campoquery=\"" + filter.CampoQuery + "\" data-pathfield=\"" + filter.PathField + "\" data-physicalname=\"" + filter.PhysicalName + "\" data-attributeid=\"" + filter.AttributeId + "\" data-objectid=\"" + filter.ObjectID + "\">";
                /*if (filter.ControlType != 2 || (filter.ControlType == 2 && filter.RelatedID.Value.ToString() != filter.RelatedDescription.ToString()))
                {
                    ret += "";
                }
                else
                {
                    ret += "<label class=\"col-sm-1 col-form-label\"></label>";
                }*/
                ret += label.Replace("[VALUE]", filter.Label);
                switch (filter.ControlType)
                {
                    case 1://TextBox
                        if (filter.DataType == 1)
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-daterange input-group\" id=\"datepicker\">";
                            ret += "<span class=\"input-group-addon\">" + Resources.Resources.From.ToString() + "</span>";
                            ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString() + "_From").Replace("[NAME]", "filter_" + filter.FilterId.ToString() + "_From");
                            ret += "<span class=\"input-group-addon\">" + Resources.Resources.To.ToString() + "</span>";
                            ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString() + "_To").Replace("[NAME]", "filter_" + filter.FilterId.ToString() + "_To");
                            ret += "</div>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 4)//Checkbox
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<select class=\"form-control control-value\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                            ret += "<option value=\"\">All</option>";
                            ret += "<option value=\"1\">" + Resources.Resources.Yes + "</option>";
                            ret += "<option value=\"0\">" + Resources.Resources.No + "</option>";
                            ret += "</select>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 5)//DatePicker
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-group date\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-calendar\"></i>From";
                            ret += "</span>";
                            ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control control-value\">";

                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-calendar\"></i>To";
                            ret += "</span>";
                            ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control control-value\">";
                            ret += "</div>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 6)//HourPicker
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-group\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-clock-o\"></i>From";
                            ret += "</span>";
                            ret += "<input data-autoclose=\"true\" id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control control-value\">";

                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-clock-o\"></i>To";
                            ret += "</span>";
                            ret += "<input data-autoclose=\"true\" id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control control-value\">";
                            ret += "</div>";
                            ret += "</div>";
                        }
                        if (filter.DataType == 2)//TextBox
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString()).Replace("[NAME]", "filter_" + filter.FilterId.ToString());
                            ret += "</div>";
                        }
                        break;
                    case 2: //Combobox
                        if (filter.RelatedID.Value.ToString() != filter.RelatedDescription.ToString())
                        {
                            dataCombo = GetDataCombo(filter.RelatedClassName, filter.RelatedID.Value, filter.RelatedDescription);
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<select class=\"form-control control-value\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                            ret += dataCombo;
                            ret += "</select>";
                            ret += "</div>";
                        }
                        else
                        {
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<a class=\"btn btn-default Detalles\" data-objectid=\"" + filter.RelatedObjectID + "\" data-toggle=\"modal\" data-target=\"#AdvanceFilter-form\">Detalles</a>";
                            ret += "</div>";
                        }
                        break;
                    case 3: //ListBox
                        ret += "<div class=\"col-sm-6\">";
                        ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString()).Replace("[NAME]", "filter_" + filter.FilterId.ToString());
                        ret += "</div>";
                        break;
                    case 5://Checkbox
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<select class=\"form-control control-value\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                        ret += "<option value=\"\">All</option>";
                        ret += "<option value=\"1\">" + Resources.Resources.Yes + "</option>";
                        ret += "<option value=\"0\">" + Resources.Resources.No + "</option>";
                        ret += "</select>";
                        ret += "</div>";
                        break;
                    case 6://Autocomplete DropDownList
                        string dataiddesc = GetNameClaveAndDesc(filter.RelatedClassName, filter.RelatedID.Value, filter.RelatedDescription);

                        string urlData = "Frontal/" + filter.ClassName + "/Get" + filter.ClassName + "_" + filter.PhysicalName + "_" + filter.RelatedClassName;
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<select data-val=\"true\" data-idfield=\"" + dataiddesc.Split(';')[0] + "\" data-descfield=\"" + dataiddesc.Split(';')[1] + "\" data-url=\"" + urlData + "\" class=\"fullWidth AutoComplete form-control control-value select2-dropdown\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                        ret += "</select>";
                        ret += "</div>";
                        break;
                    case 8://DatePicker
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<div class=\"input-group date\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-calendar\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control\">";
                        ret += "</div>";
                        ret += "<div class=\"input-group date\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-calendar\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control\">";
                        ret += "</div>";
                        ret += "</div>";
                        break;
                    case 9://HourPicker
                        ret += "<div class=\"col-sm-6\">";
                        ret += "<div class=\"input-group\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-clock-o\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control\">";
                        ret += "</div>";
                        ret += "<div class=\"input-group\">";
                        ret += "<span class=\"input-group-addon\">";
                        ret += "<i class=\"fa fa-clock-o\"></i>";
                        ret += "</span>";
                        ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control\">";
                        ret += "</div>";
                        ret += "</div>";
                        break;
                    default:
                        break;
                }
                ret += "</div>";
            }
            return ret;
        }

        public ActionResult GetSpartan_Report_AdvanceFilter(string ReportId, int object_id)
        {
            if (ReportId == "0" && object_id == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Report_FilterGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            string where = "Spartan_Report_Advance_Filter.Report=" + ReportId;
            where += " AND Spartan_Metadata.Object_Id=" + object_id;

            var result = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll(0, 9999, where, "").Resource;
            if (result.Spartan_Report_Advance_Filters == null)
                result.Spartan_Report_Advance_Filters = new List<Spartan_Report_Advance_Filter>();


            var jsonResult = Json(new
            {
                data = result.Spartan_Report_Advance_Filters.Select(m => new Spartan_Report_Advance_FilterGridModel
                {
                    Clave = m.Clave,
                    AttributeId = m.AttributeId,
                    Defect_Value_From = m.Defect_Value_From,
                    Defect_Value_To = m.Defect_Value_To,
                    AttributeIdPhysical_Name = m.AttributeId_Spartan_Metadata.Physical_Name,
                    ObjectId = m.ObjectId,
                    CampoQuery = m.CampoQuery
                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        #endregion

        #region Quick Filters
        public List<Filter> GetQuickFilters(int reportId, string token)
        {
            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(token);
            _ISpartan_Metadata.SetAuthHeader(token);
            List<Filter> result = new List<Filter>();
            var data = _ISpartan_Report_FilterApiConsumer.ListaSelAll(0, 9999, "Spartan_Report_Filter.Report = " + reportId + " AND Spartan_Report_Filter.QuickFilter = 1", "").Resource;
            if (data.RowCount > 0)
            {
                foreach (var filter in data.Spartan_Report_Filters)
                {
                    var metadata = _ISpartan_Metadata.GetByKey(filter.Field.Value, false).Resource;
                    if (metadata != null)
                    {
                        result.Add(new Filter
                        {
                            FilterId = filter.ReportFilterId,
                            DataType = metadata.Attribute_Type.Value,
                            ControlType = metadata.Control_Type,
                            Label = metadata.Logical_Name,
                            PhysicalName = metadata.Physical_Name,
                            RelationType = metadata.Relation_Type,
                            RelatedClassName = metadata.Related_Class_Name,
                            RelatedID = metadata.Related_Class_Identifier,
                            RelatedDescription = metadata.Related_Class_Description,
                            ClassName = metadata.Class_Name
                        });
                    }
                }
            }
            return result;
        }

        public JsonResult GetHeaderFooter(int id)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartanReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var response = _ISpartanReportApiConsumer.GetByKey(id, false);
            string header = response.Resource.Header;
            string footer = response.Resource.Footer;
            var result = new
            {
                header = ReplaceTags(header),
                footer = ReplaceTags(footer)
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string ReplaceTags(string data)
        {
            string result = data;
            data = data.Replace("@@date@@", DateTime.Now.ToShortDateString());
            data = data.Replace("@@hour@@", DateTime.Now.ToShortTimeString());
            //data = data.Replace("@@pageNumber@@", "");
            data = data.Replace("@@usuario@@", Session["UserName"].ToString());
            return result;
        }
        #endregion
        
    }

    public class Filter
    {
        public int FilterId { get; set; }
        public int DataType { get; set; }
        public int? ControlType { get; set; }
        public string Label { get; set; }
        public string PhysicalName { get; set; }
        public int? RelationType { get; set; }
        public string RelatedClassName { get; set; }
        public int? RelatedID { get; set; }
        public string RelatedDescription { get; set; }
        public string ClassName { get; set; }
        public int AttributeId { get; set; }
        public int? ObjectID { get; set; }
        public int? RelatedObjectID { get; set; }
        public string PathField { get; set; }
        public string CampoQuery { get; set; }
    }

    public class DataResult
    {
        public int id { get; set; }
        public List<FilterResult> filters { get; set; }
        public string type { get; set; }
    }

    public class FilterResult
    {
        public string PhysicalName { get; set; }
        public string Valor { get; set; }
    }
}
