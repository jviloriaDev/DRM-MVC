using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Platillos;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Calorias;
using Spartane.Core.Domain.Dificultad_de_platillos;
using Spartane.Core.Domain.Categorias_de_platillos;
using Spartane.Core.Domain.Tiempos_de_Comida;
using Spartane.Core.Domain.Tipo_de_comida_platillos;
using Spartane.Core.Domain.Caracteristicas_platillo;
using Spartane.Core.Domain.Detalle_de_Ingredientes;


using Spartane.Core.Domain.Unidades_de_Medida;
using Spartane.Core.Domain.Ingredientes;
using Spartane.Core.Domain.Presentacion;
using Spartane.Core.Domain.Marca;

using Spartane.Core.Domain.Detalle_Platillos;



using Spartane.Core.Domain.Cantidad_fraccion_platillos;

using Spartane.Core.Domain.Ingredientes;








using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Platillos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Platillos;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Calorias;
using Spartane.Web.Areas.WebApiConsumer.Dificultad_de_platillos;
using Spartane.Web.Areas.WebApiConsumer.Categorias_de_platillos;
using Spartane.Web.Areas.WebApiConsumer.Tiempos_de_Comida;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_comida_platillos;
using Spartane.Web.Areas.WebApiConsumer.Caracteristicas_platillo;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Ingredientes;

using Spartane.Web.Areas.WebApiConsumer.Unidades_de_Medida;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Presentacion;
using Spartane.Web.Areas.WebApiConsumer.Marca;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Platillos;


using Spartane.Web.Areas.WebApiConsumer.Cantidad_fraccion_platillos;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;


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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class PlatillosController : Controller
    {
        #region "variable declaration"

        private IPlatillosService service = null;
        private IPlatillosApiConsumer _IPlatillosApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ICaloriasApiConsumer _ICaloriasApiConsumer;
        private IDificultad_de_platillosApiConsumer _IDificultad_de_platillosApiConsumer;
        private ICategorias_de_platillosApiConsumer _ICategorias_de_platillosApiConsumer;
        private ITiempos_de_ComidaApiConsumer _ITiempos_de_ComidaApiConsumer;
        private ITipo_de_comida_platillosApiConsumer _ITipo_de_comida_platillosApiConsumer;
        private ICaracteristicas_platilloApiConsumer _ICaracteristicas_platilloApiConsumer;
        private IDetalle_de_IngredientesApiConsumer _IDetalle_de_IngredientesApiConsumer;

        private IUnidades_de_MedidaApiConsumer _IUnidades_de_MedidaApiConsumer;
        private IIngredientesApiConsumer _IIngredientesApiConsumer;
        private IPresentacionApiConsumer _IPresentacionApiConsumer;
        private IMarcaApiConsumer _IMarcaApiConsumer;

        private IDetalle_PlatillosApiConsumer _IDetalle_PlatillosApiConsumer;


        private ICantidad_fraccion_platillosApiConsumer _ICantidad_fraccion_platillosApiConsumer;


        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public PlatillosController(IPlatillosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IPlatillosApiConsumer PlatillosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ICaloriasApiConsumer CaloriasApiConsumer , IDificultad_de_platillosApiConsumer Dificultad_de_platillosApiConsumer , ICategorias_de_platillosApiConsumer Categorias_de_platillosApiConsumer , ITiempos_de_ComidaApiConsumer Tiempos_de_ComidaApiConsumer , ITipo_de_comida_platillosApiConsumer Tipo_de_comida_platillosApiConsumer , ICaracteristicas_platilloApiConsumer Caracteristicas_platilloApiConsumer , IDetalle_de_IngredientesApiConsumer Detalle_de_IngredientesApiConsumer , IUnidades_de_MedidaApiConsumer Unidades_de_MedidaApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer , IPresentacionApiConsumer PresentacionApiConsumer , IMarcaApiConsumer MarcaApiConsumer  , IDetalle_PlatillosApiConsumer Detalle_PlatillosApiConsumer , ICantidad_fraccion_platillosApiConsumer Cantidad_fraccion_platillosApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IPlatillosApiConsumer = PlatillosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ICaloriasApiConsumer = CaloriasApiConsumer;
            this._IDificultad_de_platillosApiConsumer = Dificultad_de_platillosApiConsumer;
            this._ICategorias_de_platillosApiConsumer = Categorias_de_platillosApiConsumer;
            this._ITiempos_de_ComidaApiConsumer = Tiempos_de_ComidaApiConsumer;
            this._ITipo_de_comida_platillosApiConsumer = Tipo_de_comida_platillosApiConsumer;
            this._ICaracteristicas_platilloApiConsumer = Caracteristicas_platilloApiConsumer;
            this._IDetalle_de_IngredientesApiConsumer = Detalle_de_IngredientesApiConsumer;

            this._IUnidades_de_MedidaApiConsumer = Unidades_de_MedidaApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;
            this._IPresentacionApiConsumer = PresentacionApiConsumer;
            this._IMarcaApiConsumer = MarcaApiConsumer;

            this._IDetalle_PlatillosApiConsumer = Detalle_PlatillosApiConsumer;


            this._ICantidad_fraccion_platillosApiConsumer = Cantidad_fraccion_platillosApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Platillos
        [ObjectAuth(ObjectId = (ModuleObjectId)43967, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43967, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Platillos/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)43967, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43967, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varPlatillos = new PlatillosModel();
			varPlatillos.Folio = Id;
			
            ViewBag.ObjectId = "43967";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_de_Ingredientes = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43968, ModuleId);
            ViewBag.PermissionDetalle_de_Ingredientes = permissionDetalle_de_Ingredientes;
            var permissionDetalle_Platillos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44553, ModuleId);
            ViewBag.PermissionDetalle_Platillos = permissionDetalle_Platillos;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var PlatillossData = _IPlatillosApiConsumer.ListaSelAll(0, 1000, "Platillos.Folio=" + Id, "").Resource.Platilloss;
				
				if (PlatillossData != null && PlatillossData.Count > 0)
                {
					var PlatillosData = PlatillossData.First();
					varPlatillos= new PlatillosModel
					{
						Folio  = PlatillosData.Folio 
	                    ,Fecha_de_Registro = (PlatillosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(PlatillosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = PlatillosData.Hora_de_Registro
                    ,Usuario_que_Registra = PlatillosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Usuario_que_Registra), "Spartan_User") ??  (string)PlatillosData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_Platillo = PlatillosData.Nombre_de_Platillo
                    ,Imagen = PlatillosData.Imagen
                    ,Calorias = PlatillosData.Calorias
                    ,CaloriasCantidad = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Calorias), "Calorias") ??  (string)PlatillosData.Calorias_Calorias.Cantidad
                    ,Dificultad = PlatillosData.Dificultad
                    ,DificultadCategoria = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Dificultad), "Dificultad_de_platillos") ??  (string)PlatillosData.Dificultad_Dificultad_de_platillos.Categoria
                    ,Categoria_del_Platillo = PlatillosData.Categoria_del_Platillo
                    ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Categoria_del_Platillo), "Categorias_de_platillos") ??  (string)PlatillosData.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                    ,Tiempo_de_comida = PlatillosData.Tiempo_de_comida
                    ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Tiempo_de_comida), "Tiempos_de_Comida") ??  (string)PlatillosData.Tiempo_de_comida_Tiempos_de_Comida.Comida
                    ,Tipo_de_comida = PlatillosData.Tipo_de_comida
                    ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Tipo_de_comida), "Tipo_de_comida_platillos") ??  (string)PlatillosData.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                    ,Caracteristicas = PlatillosData.Caracteristicas
                    ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Caracteristicas), "Caracteristicas_platillo") ??  (string)PlatillosData.Caracteristicas_Caracteristicas_platillo.Caracteristicas
                    ,Calificacion = PlatillosData.Calificacion
                    ,Modo_de_Preparacion = PlatillosData.Modo_de_Preparacion

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varPlatillos.Imagen).Resource;

				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caloriass_Calorias = _ICaloriasApiConsumer.SelAll(true);
            if (Caloriass_Calorias != null && Caloriass_Calorias.Resource != null)
                ViewBag.Caloriass_Calorias = Caloriass_Calorias.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dificultad_de_platilloss_Dificultad = _IDificultad_de_platillosApiConsumer.SelAll(true);
            if (Dificultad_de_platilloss_Dificultad != null && Dificultad_de_platilloss_Dificultad.Resource != null)
                ViewBag.Dificultad_de_platilloss_Dificultad = Dificultad_de_platilloss_Dificultad.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dificultad_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Categorias_de_platilloss_Categoria_del_Platillo = _ICategorias_de_platillosApiConsumer.SelAll(true);
            if (Categorias_de_platilloss_Categoria_del_Platillo != null && Categorias_de_platilloss_Categoria_del_Platillo.Resource != null)
                ViewBag.Categorias_de_platilloss_Categoria_del_Platillo = Categorias_de_platilloss_Categoria_del_Platillo.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Categorias_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempos_de_Comidas_Tiempo_de_comida = _ITiempos_de_ComidaApiConsumer.SelAll(true);
            if (Tiempos_de_Comidas_Tiempo_de_comida != null && Tiempos_de_Comidas_Tiempo_de_comida.Resource != null)
                ViewBag.Tiempos_de_Comidas_Tiempo_de_comida = Tiempos_de_Comidas_Tiempo_de_comida.Resource.Where(m => m.Comida != null).OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida") ?? m.Comida.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caracteristicas_platillos_Caracteristicas = _ICaracteristicas_platilloApiConsumer.SelAll(true);
            if (Caracteristicas_platillos_Caracteristicas != null && Caracteristicas_platillos_Caracteristicas.Resource != null)
                ViewBag.Caracteristicas_platillos_Caracteristicas = Caracteristicas_platillos_Caracteristicas.Resource.Where(m => m.Caracteristicas != null).OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas") ?? m.Caracteristicas.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;

				
            return View(varPlatillos);
        }
		
	[HttpGet]
        public ActionResult AddPlatillos(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43967);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
			PlatillosModel varPlatillos= new PlatillosModel();
            var permissionDetalle_de_Ingredientes = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43968, ModuleId);
            ViewBag.PermissionDetalle_de_Ingredientes = permissionDetalle_de_Ingredientes;
            var permissionDetalle_Platillos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44553, ModuleId);
            ViewBag.PermissionDetalle_Platillos = permissionDetalle_Platillos;


            if (id.ToString() != "0")
            {
                var PlatillossData = _IPlatillosApiConsumer.ListaSelAll(0, 1000, "Platillos.Folio=" + id, "").Resource.Platilloss;
				
				if (PlatillossData != null && PlatillossData.Count > 0)
                {
					var PlatillosData = PlatillossData.First();
					varPlatillos= new PlatillosModel
					{
						Folio  = PlatillosData.Folio 
	                    ,Fecha_de_Registro = (PlatillosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(PlatillosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = PlatillosData.Hora_de_Registro
                    ,Usuario_que_Registra = PlatillosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Usuario_que_Registra), "Spartan_User") ??  (string)PlatillosData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_Platillo = PlatillosData.Nombre_de_Platillo
                    ,Imagen = PlatillosData.Imagen
                    ,Calorias = PlatillosData.Calorias
                    ,CaloriasCantidad = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Calorias), "Calorias") ??  (string)PlatillosData.Calorias_Calorias.Cantidad
                    ,Dificultad = PlatillosData.Dificultad
                    ,DificultadCategoria = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Dificultad), "Dificultad_de_platillos") ??  (string)PlatillosData.Dificultad_Dificultad_de_platillos.Categoria
                    ,Categoria_del_Platillo = PlatillosData.Categoria_del_Platillo
                    ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Categoria_del_Platillo), "Categorias_de_platillos") ??  (string)PlatillosData.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                    ,Tiempo_de_comida = PlatillosData.Tiempo_de_comida
                    ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Tiempo_de_comida), "Tiempos_de_Comida") ??  (string)PlatillosData.Tiempo_de_comida_Tiempos_de_Comida.Comida
                    ,Tipo_de_comida = PlatillosData.Tipo_de_comida
                    ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Tipo_de_comida), "Tipo_de_comida_platillos") ??  (string)PlatillosData.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                    ,Caracteristicas = PlatillosData.Caracteristicas
                    ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(Convert.ToString(PlatillosData.Caracteristicas), "Caracteristicas_platillo") ??  (string)PlatillosData.Caracteristicas_Caracteristicas_platillo.Caracteristicas
                    ,Calificacion = PlatillosData.Calificacion
                    ,Modo_de_Preparacion = PlatillosData.Modo_de_Preparacion

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varPlatillos.Imagen).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caloriass_Calorias = _ICaloriasApiConsumer.SelAll(true);
            if (Caloriass_Calorias != null && Caloriass_Calorias.Resource != null)
                ViewBag.Caloriass_Calorias = Caloriass_Calorias.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dificultad_de_platilloss_Dificultad = _IDificultad_de_platillosApiConsumer.SelAll(true);
            if (Dificultad_de_platilloss_Dificultad != null && Dificultad_de_platilloss_Dificultad.Resource != null)
                ViewBag.Dificultad_de_platilloss_Dificultad = Dificultad_de_platilloss_Dificultad.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dificultad_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Categorias_de_platilloss_Categoria_del_Platillo = _ICategorias_de_platillosApiConsumer.SelAll(true);
            if (Categorias_de_platilloss_Categoria_del_Platillo != null && Categorias_de_platilloss_Categoria_del_Platillo.Resource != null)
                ViewBag.Categorias_de_platilloss_Categoria_del_Platillo = Categorias_de_platilloss_Categoria_del_Platillo.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Categorias_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempos_de_Comidas_Tiempo_de_comida = _ITiempos_de_ComidaApiConsumer.SelAll(true);
            if (Tiempos_de_Comidas_Tiempo_de_comida != null && Tiempos_de_Comidas_Tiempo_de_comida.Resource != null)
                ViewBag.Tiempos_de_Comidas_Tiempo_de_comida = Tiempos_de_Comidas_Tiempo_de_comida.Resource.Where(m => m.Comida != null).OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida") ?? m.Comida.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caracteristicas_platillos_Caracteristicas = _ICaracteristicas_platilloApiConsumer.SelAll(true);
            if (Caracteristicas_platillos_Caracteristicas != null && Caracteristicas_platillos_Caracteristicas.Resource != null)
                ViewBag.Caracteristicas_platillos_Caracteristicas = Caracteristicas_platillos_Caracteristicas.Resource.Where(m => m.Caracteristicas != null).OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas") ?? m.Caracteristicas.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddPlatillos", varPlatillos);
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
        public ActionResult GetCaloriasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaloriasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad")?? m.Cantidad,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDificultad_de_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDificultad_de_platillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dificultad_de_platillos", "Categoria")?? m.Categoria,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetCategorias_de_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICategorias_de_platillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Categorias_de_platillos", "Categoria")?? m.Categoria,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTiempos_de_ComidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITiempos_de_ComidaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida")?? m.Comida,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_de_comida_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_comida_platillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida")?? m.Tipo_de_comida,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetCaracteristicas_platilloAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICaracteristicas_platilloApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas")?? m.Caracteristicas,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
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
        public ActionResult ShowAdvanceFilter(PlatillosAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
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

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caloriass_Calorias = _ICaloriasApiConsumer.SelAll(true);
            if (Caloriass_Calorias != null && Caloriass_Calorias.Resource != null)
                ViewBag.Caloriass_Calorias = Caloriass_Calorias.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dificultad_de_platilloss_Dificultad = _IDificultad_de_platillosApiConsumer.SelAll(true);
            if (Dificultad_de_platilloss_Dificultad != null && Dificultad_de_platilloss_Dificultad.Resource != null)
                ViewBag.Dificultad_de_platilloss_Dificultad = Dificultad_de_platilloss_Dificultad.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dificultad_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Categorias_de_platilloss_Categoria_del_Platillo = _ICategorias_de_platillosApiConsumer.SelAll(true);
            if (Categorias_de_platilloss_Categoria_del_Platillo != null && Categorias_de_platilloss_Categoria_del_Platillo.Resource != null)
                ViewBag.Categorias_de_platilloss_Categoria_del_Platillo = Categorias_de_platilloss_Categoria_del_Platillo.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Categorias_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempos_de_Comidas_Tiempo_de_comida = _ITiempos_de_ComidaApiConsumer.SelAll(true);
            if (Tiempos_de_Comidas_Tiempo_de_comida != null && Tiempos_de_Comidas_Tiempo_de_comida.Resource != null)
                ViewBag.Tiempos_de_Comidas_Tiempo_de_comida = Tiempos_de_Comidas_Tiempo_de_comida.Resource.Where(m => m.Comida != null).OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida") ?? m.Comida.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caracteristicas_platillos_Caracteristicas = _ICaracteristicas_platilloApiConsumer.SelAll(true);
            if (Caracteristicas_platillos_Caracteristicas != null && Caracteristicas_platillos_Caracteristicas.Resource != null)
                ViewBag.Caracteristicas_platillos_Caracteristicas = Caracteristicas_platillos_Caracteristicas.Resource.Where(m => m.Caracteristicas != null).OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas") ?? m.Caracteristicas.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ICaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caloriass_Calorias = _ICaloriasApiConsumer.SelAll(true);
            if (Caloriass_Calorias != null && Caloriass_Calorias.Resource != null)
                ViewBag.Caloriass_Calorias = Caloriass_Calorias.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calorias", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDificultad_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dificultad_de_platilloss_Dificultad = _IDificultad_de_platillosApiConsumer.SelAll(true);
            if (Dificultad_de_platilloss_Dificultad != null && Dificultad_de_platilloss_Dificultad.Resource != null)
                ViewBag.Dificultad_de_platilloss_Dificultad = Dificultad_de_platilloss_Dificultad.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dificultad_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICategorias_de_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Categorias_de_platilloss_Categoria_del_Platillo = _ICategorias_de_platillosApiConsumer.SelAll(true);
            if (Categorias_de_platilloss_Categoria_del_Platillo != null && Categorias_de_platilloss_Categoria_del_Platillo.Resource != null)
                ViewBag.Categorias_de_platilloss_Categoria_del_Platillo = Categorias_de_platilloss_Categoria_del_Platillo.Resource.Where(m => m.Categoria != null).OrderBy(m => m.Categoria).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Categorias_de_platillos", "Categoria") ?? m.Categoria.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITiempos_de_ComidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempos_de_Comidas_Tiempo_de_comida = _ITiempos_de_ComidaApiConsumer.SelAll(true);
            if (Tiempos_de_Comidas_Tiempo_de_comida != null && Tiempos_de_Comidas_Tiempo_de_comida.Resource != null)
                ViewBag.Tiempos_de_Comidas_Tiempo_de_comida = Tiempos_de_Comidas_Tiempo_de_comida.Resource.Where(m => m.Comida != null).OrderBy(m => m.Comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempos_de_Comida", "Comida") ?? m.Comida.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_comida_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_comida_platilloss_Tipo_de_comida = _ITipo_de_comida_platillosApiConsumer.SelAll(true);
            if (Tipo_de_comida_platilloss_Tipo_de_comida != null && Tipo_de_comida_platilloss_Tipo_de_comida.Resource != null)
                ViewBag.Tipo_de_comida_platilloss_Tipo_de_comida = Tipo_de_comida_platilloss_Tipo_de_comida.Resource.Where(m => m.Tipo_de_comida != null).OrderBy(m => m.Tipo_de_comida).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipo_de_comida_platillos", "Tipo_de_comida") ?? m.Tipo_de_comida.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ICaracteristicas_platilloApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Caracteristicas_platillos_Caracteristicas = _ICaracteristicas_platilloApiConsumer.SelAll(true);
            if (Caracteristicas_platillos_Caracteristicas != null && Caracteristicas_platillos_Caracteristicas.Resource != null)
                ViewBag.Caracteristicas_platillos_Caracteristicas = Caracteristicas_platillos_Caracteristicas.Resource.Where(m => m.Caracteristicas != null).OrderBy(m => m.Caracteristicas).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Caracteristicas_platillo", "Caracteristicas") ?? m.Caracteristicas.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new PlatillosAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (PlatillosAdvanceSearchModel)(Session["AdvanceSearch"] ?? new PlatillosAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new PlatillosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            return Json(new
            {
                data = result.Platilloss.Select(m => new PlatillosGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,CaloriasCantidad = CultureHelper.GetTraduction(m.Calorias_Calorias.Clave.ToString(), "Cantidad") ?? (string)m.Calorias_Calorias.Cantidad
                        ,DificultadCategoria = CultureHelper.GetTraduction(m.Dificultad_Dificultad_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Dificultad_Dificultad_de_platillos.Categoria
                        ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(m.Categoria_del_Platillo_Categorias_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                        ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(m.Tiempo_de_comida_Tiempos_de_Comida.Clave.ToString(), "Comida") ?? (string)m.Tiempo_de_comida_Tiempos_de_Comida.Comida
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                        ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(m.Caracteristicas_Caracteristicas_platillo.Folio.ToString(), "Caracteristicas") ?? (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetPlatillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlatillosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Platillos", m.),
                     Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Platillos from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Platillos Entity</returns>
        public ActionResult GetPlatillosList(UrlParametersModel param)
        {
			 int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new PlatillosPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)            
            {
				if (Session["AdvanceSearch"].GetType() == typeof(PlatillosAdvanceSearchModel))
                {
					var advanceFilter =
                    (PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            PlatillosPropertyMapper oPlatillosPropertyMapper = new PlatillosPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oPlatillosPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            return Json(new
            {
                aaData = result.Platilloss.Select(m => new PlatillosGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,CaloriasCantidad = CultureHelper.GetTraduction(m.Calorias_Calorias.Clave.ToString(), "Cantidad") ?? (string)m.Calorias_Calorias.Cantidad
                        ,DificultadCategoria = CultureHelper.GetTraduction(m.Dificultad_Dificultad_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Dificultad_Dificultad_de_platillos.Categoria
                        ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(m.Categoria_del_Platillo_Categorias_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                        ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(m.Tiempo_de_comida_Tiempos_de_Comida.Clave.ToString(), "Comida") ?? (string)m.Tiempo_de_comida_Tiempos_de_Comida.Comida
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                        ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(m.Caracteristicas_Caracteristicas_platillo.Folio.ToString(), "Caracteristicas") ?? (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete
        [HttpGet]
        public JsonResult GetDetalle_Platillos_Cantidad_fraccion_Cantidad_fraccion_platillos(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICantidad_fraccion_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Cantidad_fraccion_platillos.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Cantidad_fraccion_platillos.Cantidad as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ICantidad_fraccion_platillosApiConsumer.ListaSelAll(1, 20,elWhere , " Cantidad_fraccion_platillos.Cantidad ASC ").Resource;
               
                foreach (var item in result.Cantidad_fraccion_platilloss)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Cantidad_fraccion_platillos", "Cantidad");
                    item.Cantidad =trans ??item.Cantidad;
                }
                return Json(result.Cantidad_fraccion_platilloss.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }






        [NonAction]
        public string GetAdvanceFilter(PlatillosAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Platillos.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Platillos.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Platillos.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Platillos.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Platillos.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Platillos.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_Registra))
            {
                switch (filter.Usuario_que_RegistraFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_Registra + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_Registra + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_Registra + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_Registra + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_RegistraMultiple != null && filter.AdvanceUsuario_que_RegistraMultiple.Count() > 0)
            {
                var Usuario_que_RegistraIds = string.Join(",", filter.AdvanceUsuario_que_RegistraMultiple);

                where += " AND Platillos.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_Platillo))
            {
                switch (filter.Nombre_de_PlatilloFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Platillos.Nombre_de_Platillo LIKE '" + filter.Nombre_de_Platillo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Platillos.Nombre_de_Platillo LIKE '%" + filter.Nombre_de_Platillo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Platillos.Nombre_de_Platillo = '" + filter.Nombre_de_Platillo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Platillos.Nombre_de_Platillo LIKE '%" + filter.Nombre_de_Platillo + "%'";
                        break;
                }
            }

            if (filter.Imagen != RadioOptions.NoApply)
                where += " AND Platillos.Imagen " + (filter.Imagen == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.AdvanceCalorias))
            {
                switch (filter.CaloriasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Calorias.Cantidad LIKE '" + filter.AdvanceCalorias + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Calorias.Cantidad LIKE '%" + filter.AdvanceCalorias + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Calorias.Cantidad = '" + filter.AdvanceCalorias + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Calorias.Cantidad LIKE '%" + filter.AdvanceCalorias + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCaloriasMultiple != null && filter.AdvanceCaloriasMultiple.Count() > 0)
            {
                var CaloriasIds = string.Join(",", filter.AdvanceCaloriasMultiple);

                where += " AND Platillos.Calorias In (" + CaloriasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceDificultad))
            {
                switch (filter.DificultadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Dificultad_de_platillos.Categoria LIKE '" + filter.AdvanceDificultad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Dificultad_de_platillos.Categoria LIKE '%" + filter.AdvanceDificultad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Dificultad_de_platillos.Categoria = '" + filter.AdvanceDificultad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Dificultad_de_platillos.Categoria LIKE '%" + filter.AdvanceDificultad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceDificultadMultiple != null && filter.AdvanceDificultadMultiple.Count() > 0)
            {
                var DificultadIds = string.Join(",", filter.AdvanceDificultadMultiple);

                where += " AND Platillos.Dificultad In (" + DificultadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCategoria_del_Platillo))
            {
                switch (filter.Categoria_del_PlatilloFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Categorias_de_platillos.Categoria LIKE '" + filter.AdvanceCategoria_del_Platillo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Categorias_de_platillos.Categoria LIKE '%" + filter.AdvanceCategoria_del_Platillo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Categorias_de_platillos.Categoria = '" + filter.AdvanceCategoria_del_Platillo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Categorias_de_platillos.Categoria LIKE '%" + filter.AdvanceCategoria_del_Platillo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCategoria_del_PlatilloMultiple != null && filter.AdvanceCategoria_del_PlatilloMultiple.Count() > 0)
            {
                var Categoria_del_PlatilloIds = string.Join(",", filter.AdvanceCategoria_del_PlatilloMultiple);

                where += " AND Platillos.Categoria_del_Platillo In (" + Categoria_del_PlatilloIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTiempo_de_comida))
            {
                switch (filter.Tiempo_de_comidaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tiempos_de_Comida.Comida LIKE '" + filter.AdvanceTiempo_de_comida + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tiempos_de_Comida.Comida LIKE '%" + filter.AdvanceTiempo_de_comida + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tiempos_de_Comida.Comida = '" + filter.AdvanceTiempo_de_comida + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tiempos_de_Comida.Comida LIKE '%" + filter.AdvanceTiempo_de_comida + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTiempo_de_comidaMultiple != null && filter.AdvanceTiempo_de_comidaMultiple.Count() > 0)
            {
                var Tiempo_de_comidaIds = string.Join(",", filter.AdvanceTiempo_de_comidaMultiple);

                where += " AND Platillos.Tiempo_de_comida In (" + Tiempo_de_comidaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_comida))
            {
                switch (filter.Tipo_de_comidaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida LIKE '" + filter.AdvanceTipo_de_comida + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida LIKE '%" + filter.AdvanceTipo_de_comida + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida = '" + filter.AdvanceTipo_de_comida + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_comida_platillos.Tipo_de_comida LIKE '%" + filter.AdvanceTipo_de_comida + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_comidaMultiple != null && filter.AdvanceTipo_de_comidaMultiple.Count() > 0)
            {
                var Tipo_de_comidaIds = string.Join(",", filter.AdvanceTipo_de_comidaMultiple);

                where += " AND Platillos.Tipo_de_comida In (" + Tipo_de_comidaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCaracteristicas))
            {
                switch (filter.CaracteristicasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Caracteristicas_platillo.Caracteristicas LIKE '" + filter.AdvanceCaracteristicas + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Caracteristicas_platillo.Caracteristicas LIKE '%" + filter.AdvanceCaracteristicas + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Caracteristicas_platillo.Caracteristicas = '" + filter.AdvanceCaracteristicas + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Caracteristicas_platillo.Caracteristicas LIKE '%" + filter.AdvanceCaracteristicas + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCaracteristicasMultiple != null && filter.AdvanceCaracteristicasMultiple.Count() > 0)
            {
                var CaracteristicasIds = string.Join(",", filter.AdvanceCaracteristicasMultiple);

                where += " AND Platillos.Caracteristicas In (" + CaracteristicasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Calificacion))
            {
                switch (filter.CalificacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Platillos.Calificacion LIKE '" + filter.Calificacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Platillos.Calificacion LIKE '%" + filter.Calificacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Platillos.Calificacion = '" + filter.Calificacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Platillos.Calificacion LIKE '%" + filter.Calificacion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Modo_de_Preparacion))
            {
                switch (filter.Modo_de_PreparacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Platillos.Modo_de_Preparacion LIKE '" + filter.Modo_de_Preparacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Platillos.Modo_de_Preparacion LIKE '%" + filter.Modo_de_Preparacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Platillos.Modo_de_Preparacion = '" + filter.Modo_de_Preparacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Platillos.Modo_de_Preparacion LIKE '%" + filter.Modo_de_Preparacion + "%'";
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

        public ActionResult GetDetalle_de_Ingredientes(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_de_IngredientesGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_de_Ingredientes.Platillos=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_de_Ingredientes.Platillos='" + RelationId + "'";
            }
            var result = _IDetalle_de_IngredientesApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_de_Ingredientess == null)
                result.Detalle_de_Ingredientess = new List<Detalle_de_Ingredientes>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_de_Ingredientess.Select(m => new Detalle_de_IngredientesGridModel
                {
                    Clave = m.Clave

			,Cantidad = m.Cantidad
                        ,Unidad = m.Unidad
                        ,UnidadUnidad = CultureHelper.GetTraduction(m.Unidad_Unidades_de_Medida.Clave.ToString(), "Unidad") ??(string)m.Unidad_Unidades_de_Medida.Unidad
                        ,Nombre_del_Ingrediente = m.Nombre_del_Ingrediente
                        ,Nombre_del_IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Nombre_del_Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ??(string)m.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                        ,Nombre_de_presentacion = m.Nombre_de_presentacion
                        ,Nombre_de_presentacionDescripcion = CultureHelper.GetTraduction(m.Nombre_de_presentacion_Presentacion.Clave.ToString(), "Descripcion") ??(string)m.Nombre_de_presentacion_Presentacion.Descripcion
                        ,Nombre_de_Marca = m.Nombre_de_Marca
                        ,Nombre_de_MarcaDescripcion = CultureHelper.GetTraduction(m.Nombre_de_Marca_Marca.Clave.ToString(), "Descripcion") ??(string)m.Nombre_de_Marca_Marca.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_de_IngredientesGridModel> GetDetalle_de_IngredientesData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_de_IngredientesGridModel> resultData = new List<Detalle_de_IngredientesGridModel>();
            string where = "Detalle_de_Ingredientes.Platillos=" + Id;
            if("int" == "string")
            {
                where = "Detalle_de_Ingredientes.Platillos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_de_IngredientesApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_de_Ingredientess != null)
            {
                resultData = result.Detalle_de_Ingredientess.Select(m => new Detalle_de_IngredientesGridModel
                    {
                        Clave = m.Clave

			,Cantidad = m.Cantidad
                        ,Unidad = m.Unidad
                        ,UnidadUnidad = CultureHelper.GetTraduction(m.Unidad_Unidades_de_Medida.Clave.ToString(), "Unidad") ??(string)m.Unidad_Unidades_de_Medida.Unidad
                        ,Nombre_del_Ingrediente = m.Nombre_del_Ingrediente
                        ,Nombre_del_IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Nombre_del_Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ??(string)m.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                        ,Nombre_de_presentacion = m.Nombre_de_presentacion
                        ,Nombre_de_presentacionDescripcion = CultureHelper.GetTraduction(m.Nombre_de_presentacion_Presentacion.Clave.ToString(), "Descripcion") ??(string)m.Nombre_de_presentacion_Presentacion.Descripcion
                        ,Nombre_de_Marca = m.Nombre_de_Marca
                        ,Nombre_de_MarcaDescripcion = CultureHelper.GetTraduction(m.Nombre_de_Marca_Marca.Clave.ToString(), "Descripcion") ??(string)m.Nombre_de_Marca_Marca.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Platillos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_PlatillosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Platillos.Folio_Platillos=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Platillos.Folio_Platillos='" + RelationId + "'";
            }
            var result = _IDetalle_PlatillosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Platilloss == null)
                result.Detalle_Platilloss = new List<Detalle_Platillos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Platilloss.Select(m => new Detalle_PlatillosGridModel
                {
                    Folio = m.Folio

			,Lleva_fracciones = m.Lleva_fracciones
			,Cantidad = m.Cantidad
                        ,Cantidad_fraccion = m.Cantidad_fraccion
                        ,Cantidad_fraccionCantidad = CultureHelper.GetTraduction(m.Cantidad_fraccion_Cantidad_fraccion_platillos.Folio.ToString(), "Cantidad") ??(string)m.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
			,Unidad = m.Unidad
                        ,Ingrediente = m.Ingrediente
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ??(string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
			,Caracteristica = m.Caracteristica
			,Unidad_SMAE = m.Unidad_SMAE
			,Equivalente_Unidad_SMAE = m.Equivalente_Unidad_SMAE
			,Porciones = m.Porciones
			,Detalle = m.Detalle
			,Detalle_Super = m.Detalle_Super

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_PlatillosGridModel> GetDetalle_PlatillosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_PlatillosGridModel> resultData = new List<Detalle_PlatillosGridModel>();
            string where = "Detalle_Platillos.Folio_Platillos=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Platillos.Folio_Platillos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_PlatillosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Platilloss != null)
            {
                resultData = result.Detalle_Platilloss.Select(m => new Detalle_PlatillosGridModel
                    {
                        Folio = m.Folio

			,Lleva_fracciones = m.Lleva_fracciones
			,Cantidad = m.Cantidad
                        ,Cantidad_fraccion = m.Cantidad_fraccion
                        ,Cantidad_fraccionCantidad = CultureHelper.GetTraduction(m.Cantidad_fraccion_Cantidad_fraccion_platillos.Folio.ToString(), "Cantidad") ??(string)m.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
			,Unidad = m.Unidad
                        ,Ingrediente = m.Ingrediente
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ??(string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
			,Caracteristica = m.Caracteristica
			,Unidad_SMAE = m.Unidad_SMAE
			,Equivalente_Unidad_SMAE = m.Equivalente_Unidad_SMAE
			,Porciones = m.Porciones
			,Detalle = m.Detalle
			,Detalle_Super = m.Detalle_Super


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Platillos varPlatillos = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_de_Ingredientes.Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_de_Ingredientes.Platillos='" + id + "'";
                    }
                    var Detalle_de_IngredientesInfo =
                        _IDetalle_de_IngredientesApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_de_IngredientesInfo.Detalle_de_Ingredientess.Count > 0)
                    {
                        var resultDetalle_de_Ingredientes = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_de_IngredientesItem in Detalle_de_IngredientesInfo.Detalle_de_Ingredientess)
                            resultDetalle_de_Ingredientes = resultDetalle_de_Ingredientes
                                              && _IDetalle_de_IngredientesApiConsumer.Delete(Detalle_de_IngredientesItem.Clave, null,null).Resource;

                        if (!resultDetalle_de_Ingredientes)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Platillos.Folio_Platillos=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Platillos.Folio_Platillos='" + id + "'";
                    }
                    var Detalle_PlatillosInfo =
                        _IDetalle_PlatillosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_PlatillosInfo.Detalle_Platilloss.Count > 0)
                    {
                        var resultDetalle_Platillos = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_PlatillosItem in Detalle_PlatillosInfo.Detalle_Platilloss)
                            resultDetalle_Platillos = resultDetalle_Platillos
                                              && _IDetalle_PlatillosApiConsumer.Delete(Detalle_PlatillosItem.Folio, null,null).Resource;

                        if (!resultDetalle_Platillos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IPlatillosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, PlatillosModel varPlatillos)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varPlatillos.ImagenRemoveAttachment != 0 && varPlatillos.ImagenFile == null)
                    {
                        varPlatillos.Imagen = 0;
                    }

                    if (varPlatillos.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varPlatillos.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varPlatillos.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varPlatillos.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var PlatillosInfo = new Platillos
                    {
                        Folio = varPlatillos.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlatillos.Fecha_de_Registro)) ? DateTime.ParseExact(varPlatillos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlatillos.Hora_de_Registro
                        ,Usuario_que_Registra = varPlatillos.Usuario_que_Registra
                        ,Nombre_de_Platillo = varPlatillos.Nombre_de_Platillo
                        ,Imagen = (varPlatillos.Imagen.HasValue && varPlatillos.Imagen != 0) ? ((int?)Convert.ToInt32(varPlatillos.Imagen.Value)) : null

                        ,Calorias = varPlatillos.Calorias
                        ,Dificultad = varPlatillos.Dificultad
                        ,Categoria_del_Platillo = varPlatillos.Categoria_del_Platillo
                        ,Tiempo_de_comida = varPlatillos.Tiempo_de_comida
                        ,Tipo_de_comida = varPlatillos.Tipo_de_comida
                        ,Caracteristicas = varPlatillos.Caracteristicas
                        ,Calificacion = varPlatillos.Calificacion
                        ,Modo_de_Preparacion = varPlatillos.Modo_de_Preparacion

                    };

                    result = !IsNew ?
                        _IPlatillosApiConsumer.Update(PlatillosInfo, null, null).Resource.ToString() :
                         _IPlatillosApiConsumer.Insert(PlatillosInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyDetalle_de_Ingredientes(int MasterId, int referenceId, List<Detalle_de_IngredientesGridModelPost> Detalle_de_IngredientesItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_de_IngredientesData = _IDetalle_de_IngredientesApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_de_Ingredientes.Platillos=" + referenceId,"").Resource;
                if (Detalle_de_IngredientesData == null || Detalle_de_IngredientesData.Detalle_de_Ingredientess.Count == 0)
                    return true;

                var result = true;

                Detalle_de_IngredientesGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_de_Ingredientes in Detalle_de_IngredientesData.Detalle_de_Ingredientess)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_de_Ingredientes Detalle_de_Ingredientes1 = varDetalle_de_Ingredientes;

                    if (Detalle_de_IngredientesItems != null && Detalle_de_IngredientesItems.Any(m => m.Clave == Detalle_de_Ingredientes1.Clave))
                    {
                        modelDataToChange = Detalle_de_IngredientesItems.FirstOrDefault(m => m.Clave == Detalle_de_Ingredientes1.Clave);
                    }
                    //Chaning Id Value
                    varDetalle_de_Ingredientes.Platillos = MasterId;
                    var insertId = _IDetalle_de_IngredientesApiConsumer.Insert(varDetalle_de_Ingredientes,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Clave = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostDetalle_de_Ingredientes(List<Detalle_de_IngredientesGridModelPost> Detalle_de_IngredientesItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_de_Ingredientes(MasterId, referenceId, Detalle_de_IngredientesItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_de_IngredientesItems != null && Detalle_de_IngredientesItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_de_IngredientesItem in Detalle_de_IngredientesItems)
                    {







                        //Removal Request
                        if (Detalle_de_IngredientesItem.Removed)
                        {
                            result = result && _IDetalle_de_IngredientesApiConsumer.Delete(Detalle_de_IngredientesItem.Clave, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_de_IngredientesItem.Clave = 0;

                        var Detalle_de_IngredientesData = new Detalle_de_Ingredientes
                        {
                            Platillos = MasterId
                            ,Clave = Detalle_de_IngredientesItem.Clave
                            ,Cantidad = Detalle_de_IngredientesItem.Cantidad
                            ,Unidad = (Convert.ToInt32(Detalle_de_IngredientesItem.Unidad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_IngredientesItem.Unidad))
                            ,Nombre_del_Ingrediente = (Convert.ToInt32(Detalle_de_IngredientesItem.Nombre_del_Ingrediente) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_IngredientesItem.Nombre_del_Ingrediente))
                            ,Nombre_de_presentacion = (Convert.ToInt32(Detalle_de_IngredientesItem.Nombre_de_presentacion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_IngredientesItem.Nombre_de_presentacion))
                            ,Nombre_de_Marca = (Convert.ToInt32(Detalle_de_IngredientesItem.Nombre_de_Marca) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_IngredientesItem.Nombre_de_Marca))

                        };

                        var resultId = Detalle_de_IngredientesItem.Clave > 0
                           ? _IDetalle_de_IngredientesApiConsumer.Update(Detalle_de_IngredientesData,null,null).Resource
                           : _IDetalle_de_IngredientesApiConsumer.Insert(Detalle_de_IngredientesData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public ActionResult GetDetalle_de_Ingredientes_Unidades_de_MedidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUnidades_de_MedidaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Unidades_de_Medida", "Unidad");
                  item.Unidad= trans??item.Unidad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_de_Ingredientes_IngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Ingredientes", "Nombre_Ingrediente");
                  item.Nombre_Ingrediente= trans??item.Nombre_Ingrediente;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_de_Ingredientes_PresentacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPresentacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPresentacionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Presentacion", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_de_Ingredientes_MarcaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarcaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMarcaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Marca", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyDetalle_Platillos(int MasterId, int referenceId, List<Detalle_PlatillosGridModelPost> Detalle_PlatillosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_PlatillosData = _IDetalle_PlatillosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Platillos.Folio_Platillos=" + referenceId,"").Resource;
                if (Detalle_PlatillosData == null || Detalle_PlatillosData.Detalle_Platilloss.Count == 0)
                    return true;

                var result = true;

                Detalle_PlatillosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Platillos in Detalle_PlatillosData.Detalle_Platilloss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Platillos Detalle_Platillos1 = varDetalle_Platillos;

                    if (Detalle_PlatillosItems != null && Detalle_PlatillosItems.Any(m => m.Folio == Detalle_Platillos1.Folio))
                    {
                        modelDataToChange = Detalle_PlatillosItems.FirstOrDefault(m => m.Folio == Detalle_Platillos1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Platillos.Folio_Platillos = MasterId;
                    var insertId = _IDetalle_PlatillosApiConsumer.Insert(varDetalle_Platillos,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Folio = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostDetalle_Platillos(List<Detalle_PlatillosGridModelPost> Detalle_PlatillosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Platillos(MasterId, referenceId, Detalle_PlatillosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_PlatillosItems != null && Detalle_PlatillosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_PlatillosItem in Detalle_PlatillosItems)
                    {













                        //Removal Request
                        if (Detalle_PlatillosItem.Removed)
                        {
                            result = result && _IDetalle_PlatillosApiConsumer.Delete(Detalle_PlatillosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_PlatillosItem.Folio = 0;

                        var Detalle_PlatillosData = new Detalle_Platillos
                        {
                            Folio_Platillos = MasterId
                            ,Folio = Detalle_PlatillosItem.Folio
                            ,Lleva_fracciones = Detalle_PlatillosItem.Lleva_fracciones
                            ,Cantidad = Detalle_PlatillosItem.Cantidad
                            ,Cantidad_fraccion = (Convert.ToInt32(Detalle_PlatillosItem.Cantidad_fraccion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_PlatillosItem.Cantidad_fraccion))
                            ,Unidad = Detalle_PlatillosItem.Unidad
                            ,Ingrediente = (Convert.ToInt32(Detalle_PlatillosItem.Ingrediente) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_PlatillosItem.Ingrediente))
                            ,Caracteristica = Detalle_PlatillosItem.Caracteristica
                            ,Unidad_SMAE = Detalle_PlatillosItem.Unidad_SMAE
                            ,Equivalente_Unidad_SMAE = Detalle_PlatillosItem.Equivalente_Unidad_SMAE
                            ,Porciones = Detalle_PlatillosItem.Porciones
                            ,Detalle = Detalle_PlatillosItem.Detalle
                            ,Detalle_Super = Detalle_PlatillosItem.Detalle_Super

                        };

                        var resultId = Detalle_PlatillosItem.Folio > 0
                           ? _IDetalle_PlatillosApiConsumer.Update(Detalle_PlatillosData,null,null).Resource
                           : _IDetalle_PlatillosApiConsumer.Insert(Detalle_PlatillosData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpGet]
        public ActionResult GetDetalle_Platillos_Cantidad_fraccion_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICantidad_fraccion_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICantidad_fraccion_platillosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Cantidad= CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Cantidad_fraccion_platillos", "Cantidad");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Platillos_IngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Ingredientes", "Nombre_Ingrediente");
                  item.Nombre_Ingrediente= trans??item.Nombre_Ingrediente;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }









        /// <summary>
        /// Write Element Array of Platillos script
        /// </summary>
        /// <param name="oPlatillosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew PlatillosModuleAttributeList)
        {
            for (int i = 0; i < PlatillosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < PlatillosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							PlatillosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strPlatillosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
            {
                strPlatillosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Platillos element attributes
            string userChangeJson = jsSerialize.Serialize(PlatillosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strPlatillosScript.IndexOf("inpuElementArray");
            string splittedString = strPlatillosScript.Substring(indexOfArray, strPlatillosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(PlatillosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strPlatillosScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strPlatillosScript.Substring(indexOfArrayHistory, strPlatillosScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strPlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strPlatillosScript.Substring(endIndexOfMainElement + indexOfArray, strPlatillosScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (PlatillosModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in PlatillosModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Platillos.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
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
        public ActionResult PlatillosPropertyBag()
        {
            return PartialView("PlatillosPropertyBag", "Platillos");
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
        public ActionResult AddDetalle_de_Ingredientes(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_de_Ingredientes/AddDetalle_de_Ingredientes");
        }

        [HttpGet]
        public ActionResult AddDetalle_Platillos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Platillos/AddDetalle_Platillos");
        }



        #endregion "Controller Methods"

        #region "Custom methods"
		
		[HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();
           
            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);           
            }
                
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
		
		
		
		[HttpGet]
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
           _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 43967 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Platillos.Folio= " + RecordId;
                            var result = _IPlatillosApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir, string where, string order, dynamic columnsVisible)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);
										  
			string[] arrayColumnsVisible = ((string[])columnsVisible)[0].ToString().Split(',');

			 where = HttpUtility.UrlEncode(where);
            if (!_tokenManager.GenerateToken())
                return;

            _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new PlatillosPropertyMapper());
			
			 if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            PlatillosPropertyMapper oPlatillosPropertyMapper = new PlatillosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlatillosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            var data = result.Platilloss.Select(m => new PlatillosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,CaloriasCantidad = CultureHelper.GetTraduction(m.Calorias_Calorias.Clave.ToString(), "Cantidad") ?? (string)m.Calorias_Calorias.Cantidad
                        ,DificultadCategoria = CultureHelper.GetTraduction(m.Dificultad_Dificultad_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Dificultad_Dificultad_de_platillos.Categoria
                        ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(m.Categoria_del_Platillo_Categorias_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                        ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(m.Tiempo_de_comida_Tiempos_de_Comida.Clave.ToString(), "Comida") ?? (string)m.Tiempo_de_comida_Tiempos_de_Comida.Comida
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                        ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(m.Caracteristicas_Caracteristicas_platillo.Folio.ToString(), "Caracteristicas") ?? (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(43967, arrayColumnsVisible), "PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(43967, arrayColumnsVisible), "PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(43967, arrayColumnsVisible), "PlatillosList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir,string where, string order)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

			where = HttpUtility.UrlEncode(where);
										   
            if (!_tokenManager.GenerateToken())
                return null;

            _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new PlatillosPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (PlatillosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            PlatillosPropertyMapper oPlatillosPropertyMapper = new PlatillosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPlatillosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Platilloss == null)
                result.Platilloss = new List<Platillos>();

            var data = result.Platilloss.Select(m => new PlatillosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,CaloriasCantidad = CultureHelper.GetTraduction(m.Calorias_Calorias.Clave.ToString(), "Cantidad") ?? (string)m.Calorias_Calorias.Cantidad
                        ,DificultadCategoria = CultureHelper.GetTraduction(m.Dificultad_Dificultad_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Dificultad_Dificultad_de_platillos.Categoria
                        ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(m.Categoria_del_Platillo_Categorias_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                        ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(m.Tiempo_de_comida_Tiempos_de_Comida.Clave.ToString(), "Comida") ?? (string)m.Tiempo_de_comida_Tiempos_de_Comida.Comida
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                        ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(m.Caracteristicas_Caracteristicas_platillo.Folio.ToString(), "Caracteristicas") ?? (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
		
		[HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlatillosApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Platillos_Datos_GeneralesModel varPlatillos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varPlatillos.ImagenRemoveAttachment != 0 && varPlatillos.ImagenFile == null)
                    {
                        varPlatillos.Imagen = 0;
                    }

                    if (varPlatillos.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varPlatillos.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varPlatillos.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varPlatillos.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Platillos_Datos_GeneralesInfo = new Platillos_Datos_Generales
                {
                    Folio = varPlatillos.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPlatillos.Fecha_de_Registro)) ? DateTime.ParseExact(varPlatillos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPlatillos.Hora_de_Registro
                        ,Usuario_que_Registra = varPlatillos.Usuario_que_Registra
                        ,Nombre_de_Platillo = varPlatillos.Nombre_de_Platillo
                        ,Imagen = (varPlatillos.Imagen.HasValue && varPlatillos.Imagen != 0) ? ((int?)Convert.ToInt32(varPlatillos.Imagen.Value)) : null

                        ,Calorias = varPlatillos.Calorias
                        ,Dificultad = varPlatillos.Dificultad
                        ,Categoria_del_Platillo = varPlatillos.Categoria_del_Platillo
                        ,Tiempo_de_comida = varPlatillos.Tiempo_de_comida
                        ,Tipo_de_comida = varPlatillos.Tipo_de_comida
                        ,Caracteristicas = varPlatillos.Caracteristicas
                        ,Calificacion = varPlatillos.Calificacion
                        ,Modo_de_Preparacion = varPlatillos.Modo_de_Preparacion
                    
                };

                result = _IPlatillosApiConsumer.Update_Datos_Generales(Platillos_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPlatillosApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Ingredientes;
                var Detalle_de_IngredientesData = GetDetalle_de_IngredientesData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Ingredientes);
                int RowCount_Detalle_Platillos;
                var Detalle_PlatillosData = GetDetalle_PlatillosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Platillos);

                var result = new Platillos_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_Platillo = m.Nombre_de_Platillo
			,Imagen = m.Imagen
                        ,Calorias = m.Calorias
                        ,CaloriasCantidad = CultureHelper.GetTraduction(m.Calorias_Calorias.Clave.ToString(), "Cantidad") ?? (string)m.Calorias_Calorias.Cantidad
                        ,Dificultad = m.Dificultad
                        ,DificultadCategoria = CultureHelper.GetTraduction(m.Dificultad_Dificultad_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Dificultad_Dificultad_de_platillos.Categoria
                        ,Categoria_del_Platillo = m.Categoria_del_Platillo
                        ,Categoria_del_PlatilloCategoria = CultureHelper.GetTraduction(m.Categoria_del_Platillo_Categorias_de_platillos.Clave.ToString(), "Categoria") ?? (string)m.Categoria_del_Platillo_Categorias_de_platillos.Categoria
                        ,Tiempo_de_comida = m.Tiempo_de_comida
                        ,Tiempo_de_comidaComida = CultureHelper.GetTraduction(m.Tiempo_de_comida_Tiempos_de_Comida.Clave.ToString(), "Comida") ?? (string)m.Tiempo_de_comida_Tiempos_de_Comida.Comida
                        ,Tipo_de_comida = m.Tipo_de_comida
                        ,Tipo_de_comidaTipo_de_comida = CultureHelper.GetTraduction(m.Tipo_de_comida_Tipo_de_comida_platillos.Folio.ToString(), "Tipo_de_comida") ?? (string)m.Tipo_de_comida_Tipo_de_comida_platillos.Tipo_de_comida
                        ,Caracteristicas = m.Caracteristicas
                        ,CaracteristicasCaracteristicas = CultureHelper.GetTraduction(m.Caracteristicas_Caracteristicas_platillo.Folio.ToString(), "Caracteristicas") ?? (string)m.Caracteristicas_Caracteristicas_platillo.Caracteristicas
			,Calificacion = m.Calificacion
			,Modo_de_Preparacion = m.Modo_de_Preparacion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_Platillos = Detalle_de_IngredientesData
                    ,Detalle_Platillo_MR2 = Detalle_PlatillosData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

