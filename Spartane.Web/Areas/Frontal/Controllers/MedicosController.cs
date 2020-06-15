using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Titulos_Personales;
using Spartane.Core.Domain.Tipos_de_Especialistas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista;

using Spartane.Core.Domain.Redes_sociales;



using Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras;

using Spartane.Core.Domain.Aseguradoras;

using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Profesiones;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Detalle_Titulos_Medicos;










using Spartane.Core.Domain.Regimenes_Fiscales;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos;

using Spartane.Core.Domain.Identificaciones_Oficiales;


using Spartane.Core.Domain.Detalle_Codigos_Referidos;

using Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista;

using Spartane.Core.Domain.Planes_de_Suscripcion;







using Spartane.Core.Domain.Spartan_User;


using Spartane.Core.Domain.Estatus;

using Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas;

using Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas;





using Spartane.Core.Domain.Estatus_de_Suscripcion;

using Spartane.Core.Domain.Bancos;
using Spartane.Core.Domain.Detalle_Facturacion_Especialistas;













using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Medicos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Medicos;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Titulos_Personales;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Redes_Sociales_Especialista;

using Spartane.Web.Areas.WebApiConsumer.Redes_sociales;


using Spartane.Web.Areas.WebApiConsumer.Detalle_Convenio_Medicos_Aseguradoras;

using Spartane.Web.Areas.WebApiConsumer.Aseguradoras;

using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Profesiones;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Titulos_Medicos;







using Spartane.Web.Areas.WebApiConsumer.Regimenes_Fiscales;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Identificacion_Oficial_Medicos;

using Spartane.Web.Areas.WebApiConsumer.Identificaciones_Oficiales;


using Spartane.Web.Areas.WebApiConsumer.Detalle_Codigos_Referidos;

using Spartane.Web.Areas.WebApiConsumer.MS_Suscripciones_Codigos_Referidos_Especialista;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;




using Spartane.Web.Areas.WebApiConsumer.Spartan_User;


using Spartane.Web.Areas.WebApiConsumer.Estatus;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Suscripcion_Especialistas;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Especialistas;





using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Suscripcion;

using Spartane.Web.Areas.WebApiConsumer.Bancos;
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
    public class MedicosController : Controller
    {
        #region "variable declaration"

        private IMedicosService service = null;
        private IMedicosApiConsumer _IMedicosApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITitulos_PersonalesApiConsumer _ITitulos_PersonalesApiConsumer;
        private ITipos_de_EspecialistasApiConsumer _ITipos_de_EspecialistasApiConsumer;
        private IPaisApiConsumer _IPaisApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IRespuesta_LogicaApiConsumer _IRespuesta_LogicaApiConsumer;
        private IDetalle_Redes_Sociales_EspecialistaApiConsumer _IDetalle_Redes_Sociales_EspecialistaApiConsumer;

        private IRedes_socialesApiConsumer _IRedes_socialesApiConsumer;


        private IDetalle_Convenio_Medicos_AseguradorasApiConsumer _IDetalle_Convenio_Medicos_AseguradorasApiConsumer;

        private IAseguradorasApiConsumer _IAseguradorasApiConsumer;

        private IProfesionesApiConsumer _IProfesionesApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;
        private IDetalle_Titulos_MedicosApiConsumer _IDetalle_Titulos_MedicosApiConsumer;







        private IRegimenes_FiscalesApiConsumer _IRegimenes_FiscalesApiConsumer;
        private IDetalle_Identificacion_Oficial_MedicosApiConsumer _IDetalle_Identificacion_Oficial_MedicosApiConsumer;

        private IIdentificaciones_OficialesApiConsumer _IIdentificaciones_OficialesApiConsumer;


        private IDetalle_Codigos_ReferidosApiConsumer _IDetalle_Codigos_ReferidosApiConsumer;

        private IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer;

        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;







        private IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer;

        private IPlanes_de_Suscripcion_EspecialistasApiConsumer _IPlanes_de_Suscripcion_EspecialistasApiConsumer;





        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;

        private IBancosApiConsumer _IBancosApiConsumer;
        private IDetalle_Facturacion_EspecialistasApiConsumer _IDetalle_Facturacion_EspecialistasApiConsumer;










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

        
        public MedicosController(IMedicosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMedicosApiConsumer MedicosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITitulos_PersonalesApiConsumer Titulos_PersonalesApiConsumer , ITipos_de_EspecialistasApiConsumer Tipos_de_EspecialistasApiConsumer , IPaisApiConsumer PaisApiConsumer , IEstadoApiConsumer EstadoApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IRespuesta_LogicaApiConsumer Respuesta_LogicaApiConsumer , IDetalle_Redes_Sociales_EspecialistaApiConsumer Detalle_Redes_Sociales_EspecialistaApiConsumer , IRedes_socialesApiConsumer Redes_socialesApiConsumer  , IDetalle_Convenio_Medicos_AseguradorasApiConsumer Detalle_Convenio_Medicos_AseguradorasApiConsumer , IAseguradorasApiConsumer AseguradorasApiConsumer  , IProfesionesApiConsumer ProfesionesApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , IDetalle_Titulos_MedicosApiConsumer Detalle_Titulos_MedicosApiConsumer  , IRegimenes_FiscalesApiConsumer Regimenes_FiscalesApiConsumer , IDetalle_Identificacion_Oficial_MedicosApiConsumer Detalle_Identificacion_Oficial_MedicosApiConsumer , IIdentificaciones_OficialesApiConsumer Identificaciones_OficialesApiConsumer  , IDetalle_Codigos_ReferidosApiConsumer Detalle_Codigos_ReferidosApiConsumer , IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer MS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer   , IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer , IPlanes_de_Suscripcion_EspecialistasApiConsumer Planes_de_Suscripcion_EspecialistasApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer  , IBancosApiConsumer BancosApiConsumer , IDetalle_Facturacion_EspecialistasApiConsumer Detalle_Facturacion_EspecialistasApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMedicosApiConsumer = MedicosApiConsumer;
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
            this._ITitulos_PersonalesApiConsumer = Titulos_PersonalesApiConsumer;
            this._ITipos_de_EspecialistasApiConsumer = Tipos_de_EspecialistasApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IDetalle_Redes_Sociales_EspecialistaApiConsumer = Detalle_Redes_Sociales_EspecialistaApiConsumer;

            this._IRedes_socialesApiConsumer = Redes_socialesApiConsumer;


            this._IDetalle_Convenio_Medicos_AseguradorasApiConsumer = Detalle_Convenio_Medicos_AseguradorasApiConsumer;

            this._IAseguradorasApiConsumer = AseguradorasApiConsumer;

            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IProfesionesApiConsumer = ProfesionesApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._IDetalle_Titulos_MedicosApiConsumer = Detalle_Titulos_MedicosApiConsumer;







            this._IRegimenes_FiscalesApiConsumer = Regimenes_FiscalesApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IDetalle_Identificacion_Oficial_MedicosApiConsumer = Detalle_Identificacion_Oficial_MedicosApiConsumer;

            this._IIdentificaciones_OficialesApiConsumer = Identificaciones_OficialesApiConsumer;


            this._IDetalle_Codigos_ReferidosApiConsumer = Detalle_Codigos_ReferidosApiConsumer;

            this._IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer = MS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;




            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;


            this._IEstatusApiConsumer = EstatusApiConsumer;

            this._IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer = Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer;

            this._IPlanes_de_Suscripcion_EspecialistasApiConsumer = Planes_de_Suscripcion_EspecialistasApiConsumer;





            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;

            this._IBancosApiConsumer = BancosApiConsumer;
            this._IDetalle_Facturacion_EspecialistasApiConsumer = Detalle_Facturacion_EspecialistasApiConsumer;










        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Medicos
        [ObjectAuth(ObjectId = (ModuleObjectId)44379, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44379, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Medicos/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44379, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44379, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varMedicos = new MedicosModel();
			varMedicos.Folio = Id;
			
            ViewBag.ObjectId = "44379";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Redes_Sociales_Especialista = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44450, ModuleId);
            ViewBag.PermissionDetalle_Redes_Sociales_Especialista = permissionDetalle_Redes_Sociales_Especialista;
            var permissionDetalle_Convenio_Medicos_Aseguradoras = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44421, ModuleId);
            ViewBag.PermissionDetalle_Convenio_Medicos_Aseguradoras = permissionDetalle_Convenio_Medicos_Aseguradoras;
            var permissionDetalle_Titulos_Medicos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44408, ModuleId);
            ViewBag.PermissionDetalle_Titulos_Medicos = permissionDetalle_Titulos_Medicos;
            var permissionDetalle_Identificacion_Oficial_Medicos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44380, ModuleId);
            ViewBag.PermissionDetalle_Identificacion_Oficial_Medicos = permissionDetalle_Identificacion_Oficial_Medicos;
            var permissionDetalle_Codigos_Referidos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44420, ModuleId);
            ViewBag.PermissionDetalle_Codigos_Referidos = permissionDetalle_Codigos_Referidos;
            var permissionDetalle_Planes_de_Suscripcion_Especialistas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44423, ModuleId);
            ViewBag.PermissionDetalle_Planes_de_Suscripcion_Especialistas = permissionDetalle_Planes_de_Suscripcion_Especialistas;
            var permissionDetalle_Facturacion_Especialistas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44447, ModuleId);
            ViewBag.PermissionDetalle_Facturacion_Especialistas = permissionDetalle_Facturacion_Especialistas;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MedicossData = _IMedicosApiConsumer.ListaSelAll(0, 1000, "Medicos.Folio=" + Id, "").Resource.Medicoss;
				
				if (MedicossData != null && MedicossData.Count > 0)
                {
					var MedicosData = MedicossData.First();
					varMedicos= new MedicosModel
					{
						Folio  = MedicosData.Folio 
	                    ,Fecha_de_Registro = (MedicosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(MedicosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = MedicosData.Hora_de_Registro
                    ,Usuario_que_Registra = MedicosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Usuario_que_Registra), "Spartan_User") ??  (string)MedicosData.Usuario_que_Registra_Spartan_User.Name
                    ,Titulo_Personal = MedicosData.Titulo_Personal
                    ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Titulo_Personal), "Titulos_Personales") ??  (string)MedicosData.Titulo_Personal_Titulos_Personales.Descripcion
                    ,Nombres = MedicosData.Nombres
                    ,Apellido_Paterno = MedicosData.Apellido_Paterno
                    ,Apellido_Materno = MedicosData.Apellido_Materno
                    ,Nombre_Completo = MedicosData.Nombre_Completo
                    ,Tipo_de_Especialista = MedicosData.Tipo_de_Especialista
                    ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Tipo_de_Especialista), "Tipos_de_Especialistas") ??  (string)MedicosData.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
                    ,Foto = MedicosData.Foto
                    ,Nombre_de_usuario = MedicosData.Nombre_de_usuario
                    ,Usuario_Registrado = MedicosData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Usuario_Registrado), "Spartan_User") ??  (string)MedicosData.Usuario_Registrado_Spartan_User.Name
                    ,Email = MedicosData.Email
                    ,Celular = MedicosData.Celular
                    ,Fecha_de_nacimiento = (MedicosData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(MedicosData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Pais_de_nacimiento = MedicosData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Pais_de_nacimiento), "Pais") ??  (string)MedicosData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Entidad_de_nacimiento = MedicosData.Entidad_de_nacimiento
                    ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Entidad_de_nacimiento), "Estado") ??  (string)MedicosData.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = MedicosData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Sexo), "Sexo") ??  (string)MedicosData.Sexo_Sexo.Descripcion
                    ,Email_institucional = MedicosData.Email_institucional
                    ,Estatus = MedicosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Estatus), "Estatus") ??  (string)MedicosData.Estatus_Estatus.Descripcion
                    ,Email_ppal_publico = MedicosData.Email_ppal_publico
                    ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Email_ppal_publico), "Respuesta_Logica") ??  (string)MedicosData.Email_ppal_publico_Respuesta_Logica.Descripcion
                    ,Email_de_contacto = MedicosData.Email_de_contacto
                    ,Calle = MedicosData.Calle
                    ,Numero_exterior = MedicosData.Numero_exterior
                    ,Numero_interior = MedicosData.Numero_interior
                    ,Colonia = MedicosData.Colonia
                    ,CP = MedicosData.CP
                    ,Ciudad = MedicosData.Ciudad
                    ,Estado = MedicosData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Estado), "Estado") ??  (string)MedicosData.Estado_Estado.Nombre_del_Estado
                    ,Pais = MedicosData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Pais), "Pais") ??  (string)MedicosData.Pais_Pais.Nombre_del_Pais
                    ,Telefonos = MedicosData.Telefonos
                    ,En_Hospital = MedicosData.En_Hospital
                    ,En_HospitalDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.En_Hospital), "Respuesta_Logica") ??  (string)MedicosData.En_Hospital_Respuesta_Logica.Descripcion
                    ,Nombre_del_Hospital = MedicosData.Nombre_del_Hospital
                    ,Piso_hospital = MedicosData.Piso_hospital
                    ,Numero_de_consultorio = MedicosData.Numero_de_consultorio
                    ,Se_ajusta_tabulador = MedicosData.Se_ajusta_tabulador
                    ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Se_ajusta_tabulador), "Respuesta_Logica") ??  (string)MedicosData.Se_ajusta_tabulador_Respuesta_Logica.Descripcion
                    ,Profesion = MedicosData.Profesion
                    ,ProfesionDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Profesion), "Profesiones") ??  (string)MedicosData.Profesion_Profesiones.Descripcion
                    ,Especialidad = MedicosData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Especialidad), "Especialidades") ??  (string)MedicosData.Especialidad_Especialidades.Especialidad
                    ,Resumen_Profesional = MedicosData.Resumen_Profesional
                    ,Regimen_Fiscal = MedicosData.Regimen_Fiscal
                    ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Regimen_Fiscal), "Regimenes_Fiscales") ??  (string)MedicosData.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
                    ,Nombre_o_Razon_Social = MedicosData.Nombre_o_Razon_Social
                    ,RFC = MedicosData.RFC
                    ,Calle_Fiscal = MedicosData.Calle_Fiscal
                    ,Numero_exterior_Fiscal = MedicosData.Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = MedicosData.Numero_interior_Fiscal
                    ,Colonia_Fiscal = MedicosData.Colonia_Fiscal
                    ,CP_Fiscal = MedicosData.CP_Fiscal
                    ,Ciudad_Fiscal = MedicosData.Ciudad_Fiscal
                    ,Estado_Fiscal = MedicosData.Estado_Fiscal
                    ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Estado_Fiscal), "Estado") ??  (string)MedicosData.Estado_Fiscal_Estado.Nombre_del_Estado
                    ,Pais_Fiscal = MedicosData.Pais_Fiscal
                    ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Pais_Fiscal), "Pais") ??  (string)MedicosData.Pais_Fiscal_Pais.Nombre_del_Pais
                    ,Telefono = MedicosData.Telefono
                    ,Fax = MedicosData.Fax
                    ,Cedula_Fiscal_Documento = MedicosData.Cedula_Fiscal_Documento
                    ,Comprobante_de_Domicilio = MedicosData.Comprobante_de_Domicilio
                    ,Calificacion_Red_de_Medicos = MedicosData.Calificacion_Red_de_Medicos
                    ,Banco = MedicosData.Banco
                    ,BancoNombre = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Banco), "Bancos") ??  (string)MedicosData.Banco_Bancos.Nombre
                    ,CLABE_Interbancaria = MedicosData.CLABE_Interbancaria
                    ,Numero_de_Cuenta = MedicosData.Numero_de_Cuenta
                    ,Nombre_del_Titular = MedicosData.Nombre_del_Titular

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.FotoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varMedicos.Foto).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_Fiscal_DocumentoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varMedicos.Cedula_Fiscal_Documento).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Comprobante_de_DomicilioSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varMedicos.Comprobante_de_Domicilio).Resource;

				
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
	    _ITitulos_PersonalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Titulos_Personaless_Titulo_Personal = _ITitulos_PersonalesApiConsumer.SelAll(true);
            if (Titulos_Personaless_Titulo_Personal != null && Titulos_Personaless_Titulo_Personal.Resource != null)
                ViewBag.Titulos_Personaless_Titulo_Personal = Titulos_Personaless_Titulo_Personal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Titulos_Personales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipos_de_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Especialistass_Tipo_de_Especialista = _ITipos_de_EspecialistasApiConsumer.SelAll(true);
            if (Tipos_de_Especialistass_Tipo_de_Especialista != null && Tipos_de_Especialistass_Tipo_de_Especialista.Resource != null)
                ViewBag.Tipos_de_Especialistass_Tipo_de_Especialista = Tipos_de_Especialistass_Tipo_de_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Especialistas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Email_ppal_publico = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Email_ppal_publico != null && Respuesta_Logicas_Email_ppal_publico.Resource != null)
                ViewBag.Respuesta_Logicas_Email_ppal_publico = Respuesta_Logicas_Email_ppal_publico.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_En_Hospital = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_En_Hospital != null && Respuesta_Logicas_En_Hospital.Resource != null)
                ViewBag.Respuesta_Logicas_En_Hospital = Respuesta_Logicas_En_Hospital.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Se_ajusta_tabulador = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Se_ajusta_tabulador != null && Respuesta_Logicas_Se_ajusta_tabulador.Resource != null)
                ViewBag.Respuesta_Logicas_Se_ajusta_tabulador = Respuesta_Logicas_Se_ajusta_tabulador.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IProfesionesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Profesioness_Profesion = _IProfesionesApiConsumer.SelAll(true);
            if (Profesioness_Profesion != null && Profesioness_Profesion.Resource != null)
                ViewBag.Profesioness_Profesion = Profesioness_Profesion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Profesiones", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
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

				
            return View(varMedicos);
        }
		
	[HttpGet]
        public ActionResult AddMedicos(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44379);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
			MedicosModel varMedicos= new MedicosModel();
            var permissionDetalle_Redes_Sociales_Especialista = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44450, ModuleId);
            ViewBag.PermissionDetalle_Redes_Sociales_Especialista = permissionDetalle_Redes_Sociales_Especialista;
            var permissionDetalle_Convenio_Medicos_Aseguradoras = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44421, ModuleId);
            ViewBag.PermissionDetalle_Convenio_Medicos_Aseguradoras = permissionDetalle_Convenio_Medicos_Aseguradoras;
            var permissionDetalle_Titulos_Medicos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44408, ModuleId);
            ViewBag.PermissionDetalle_Titulos_Medicos = permissionDetalle_Titulos_Medicos;
            var permissionDetalle_Identificacion_Oficial_Medicos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44380, ModuleId);
            ViewBag.PermissionDetalle_Identificacion_Oficial_Medicos = permissionDetalle_Identificacion_Oficial_Medicos;
            var permissionDetalle_Codigos_Referidos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44420, ModuleId);
            ViewBag.PermissionDetalle_Codigos_Referidos = permissionDetalle_Codigos_Referidos;
            var permissionDetalle_Planes_de_Suscripcion_Especialistas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44423, ModuleId);
            ViewBag.PermissionDetalle_Planes_de_Suscripcion_Especialistas = permissionDetalle_Planes_de_Suscripcion_Especialistas;
            var permissionDetalle_Facturacion_Especialistas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44447, ModuleId);
            ViewBag.PermissionDetalle_Facturacion_Especialistas = permissionDetalle_Facturacion_Especialistas;


            if (id.ToString() != "0")
            {
                var MedicossData = _IMedicosApiConsumer.ListaSelAll(0, 1000, "Medicos.Folio=" + id, "").Resource.Medicoss;
				
				if (MedicossData != null && MedicossData.Count > 0)
                {
					var MedicosData = MedicossData.First();
					varMedicos= new MedicosModel
					{
						Folio  = MedicosData.Folio 
	                    ,Fecha_de_Registro = (MedicosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(MedicosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = MedicosData.Hora_de_Registro
                    ,Usuario_que_Registra = MedicosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Usuario_que_Registra), "Spartan_User") ??  (string)MedicosData.Usuario_que_Registra_Spartan_User.Name
                    ,Titulo_Personal = MedicosData.Titulo_Personal
                    ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Titulo_Personal), "Titulos_Personales") ??  (string)MedicosData.Titulo_Personal_Titulos_Personales.Descripcion
                    ,Nombres = MedicosData.Nombres
                    ,Apellido_Paterno = MedicosData.Apellido_Paterno
                    ,Apellido_Materno = MedicosData.Apellido_Materno
                    ,Nombre_Completo = MedicosData.Nombre_Completo
                    ,Tipo_de_Especialista = MedicosData.Tipo_de_Especialista
                    ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Tipo_de_Especialista), "Tipos_de_Especialistas") ??  (string)MedicosData.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
                    ,Foto = MedicosData.Foto
                    ,Nombre_de_usuario = MedicosData.Nombre_de_usuario
                    ,Usuario_Registrado = MedicosData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Usuario_Registrado), "Spartan_User") ??  (string)MedicosData.Usuario_Registrado_Spartan_User.Name
                    ,Email = MedicosData.Email
                    ,Celular = MedicosData.Celular
                    ,Fecha_de_nacimiento = (MedicosData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(MedicosData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Pais_de_nacimiento = MedicosData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Pais_de_nacimiento), "Pais") ??  (string)MedicosData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Entidad_de_nacimiento = MedicosData.Entidad_de_nacimiento
                    ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Entidad_de_nacimiento), "Estado") ??  (string)MedicosData.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = MedicosData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Sexo), "Sexo") ??  (string)MedicosData.Sexo_Sexo.Descripcion
                    ,Email_institucional = MedicosData.Email_institucional
                    ,Estatus = MedicosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Estatus), "Estatus") ??  (string)MedicosData.Estatus_Estatus.Descripcion
                    ,Email_ppal_publico = MedicosData.Email_ppal_publico
                    ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Email_ppal_publico), "Respuesta_Logica") ??  (string)MedicosData.Email_ppal_publico_Respuesta_Logica.Descripcion
                    ,Email_de_contacto = MedicosData.Email_de_contacto
                    ,Calle = MedicosData.Calle
                    ,Numero_exterior = MedicosData.Numero_exterior
                    ,Numero_interior = MedicosData.Numero_interior
                    ,Colonia = MedicosData.Colonia
                    ,CP = MedicosData.CP
                    ,Ciudad = MedicosData.Ciudad
                    ,Estado = MedicosData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Estado), "Estado") ??  (string)MedicosData.Estado_Estado.Nombre_del_Estado
                    ,Pais = MedicosData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Pais), "Pais") ??  (string)MedicosData.Pais_Pais.Nombre_del_Pais
                    ,Telefonos = MedicosData.Telefonos
                    ,En_Hospital = MedicosData.En_Hospital
                    ,En_HospitalDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.En_Hospital), "Respuesta_Logica") ??  (string)MedicosData.En_Hospital_Respuesta_Logica.Descripcion
                    ,Nombre_del_Hospital = MedicosData.Nombre_del_Hospital
                    ,Piso_hospital = MedicosData.Piso_hospital
                    ,Numero_de_consultorio = MedicosData.Numero_de_consultorio
                    ,Se_ajusta_tabulador = MedicosData.Se_ajusta_tabulador
                    ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Se_ajusta_tabulador), "Respuesta_Logica") ??  (string)MedicosData.Se_ajusta_tabulador_Respuesta_Logica.Descripcion
                    ,Profesion = MedicosData.Profesion
                    ,ProfesionDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Profesion), "Profesiones") ??  (string)MedicosData.Profesion_Profesiones.Descripcion
                    ,Especialidad = MedicosData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Especialidad), "Especialidades") ??  (string)MedicosData.Especialidad_Especialidades.Especialidad
                    ,Resumen_Profesional = MedicosData.Resumen_Profesional
                    ,Regimen_Fiscal = MedicosData.Regimen_Fiscal
                    ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Regimen_Fiscal), "Regimenes_Fiscales") ??  (string)MedicosData.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
                    ,Nombre_o_Razon_Social = MedicosData.Nombre_o_Razon_Social
                    ,RFC = MedicosData.RFC
                    ,Calle_Fiscal = MedicosData.Calle_Fiscal
                    ,Numero_exterior_Fiscal = MedicosData.Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = MedicosData.Numero_interior_Fiscal
                    ,Colonia_Fiscal = MedicosData.Colonia_Fiscal
                    ,CP_Fiscal = MedicosData.CP_Fiscal
                    ,Ciudad_Fiscal = MedicosData.Ciudad_Fiscal
                    ,Estado_Fiscal = MedicosData.Estado_Fiscal
                    ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Estado_Fiscal), "Estado") ??  (string)MedicosData.Estado_Fiscal_Estado.Nombre_del_Estado
                    ,Pais_Fiscal = MedicosData.Pais_Fiscal
                    ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Pais_Fiscal), "Pais") ??  (string)MedicosData.Pais_Fiscal_Pais.Nombre_del_Pais
                    ,Telefono = MedicosData.Telefono
                    ,Fax = MedicosData.Fax
                    ,Cedula_Fiscal_Documento = MedicosData.Cedula_Fiscal_Documento
                    ,Comprobante_de_Domicilio = MedicosData.Comprobante_de_Domicilio
                    ,Calificacion_Red_de_Medicos = MedicosData.Calificacion_Red_de_Medicos
                    ,Banco = MedicosData.Banco
                    ,BancoNombre = CultureHelper.GetTraduction(Convert.ToString(MedicosData.Banco), "Bancos") ??  (string)MedicosData.Banco_Bancos.Nombre
                    ,CLABE_Interbancaria = MedicosData.CLABE_Interbancaria
                    ,Numero_de_Cuenta = MedicosData.Numero_de_Cuenta
                    ,Nombre_del_Titular = MedicosData.Nombre_del_Titular

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.FotoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varMedicos.Foto).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_Fiscal_DocumentoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varMedicos.Cedula_Fiscal_Documento).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Comprobante_de_DomicilioSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varMedicos.Comprobante_de_Domicilio).Resource;

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
	    _ITitulos_PersonalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Titulos_Personaless_Titulo_Personal = _ITitulos_PersonalesApiConsumer.SelAll(true);
            if (Titulos_Personaless_Titulo_Personal != null && Titulos_Personaless_Titulo_Personal.Resource != null)
                ViewBag.Titulos_Personaless_Titulo_Personal = Titulos_Personaless_Titulo_Personal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Titulos_Personales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipos_de_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Especialistass_Tipo_de_Especialista = _ITipos_de_EspecialistasApiConsumer.SelAll(true);
            if (Tipos_de_Especialistass_Tipo_de_Especialista != null && Tipos_de_Especialistass_Tipo_de_Especialista.Resource != null)
                ViewBag.Tipos_de_Especialistass_Tipo_de_Especialista = Tipos_de_Especialistass_Tipo_de_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Especialistas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Email_ppal_publico = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Email_ppal_publico != null && Respuesta_Logicas_Email_ppal_publico.Resource != null)
                ViewBag.Respuesta_Logicas_Email_ppal_publico = Respuesta_Logicas_Email_ppal_publico.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_En_Hospital = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_En_Hospital != null && Respuesta_Logicas_En_Hospital.Resource != null)
                ViewBag.Respuesta_Logicas_En_Hospital = Respuesta_Logicas_En_Hospital.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Se_ajusta_tabulador = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Se_ajusta_tabulador != null && Respuesta_Logicas_Se_ajusta_tabulador.Resource != null)
                ViewBag.Respuesta_Logicas_Se_ajusta_tabulador = Respuesta_Logicas_Se_ajusta_tabulador.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IProfesionesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Profesioness_Profesion = _IProfesionesApiConsumer.SelAll(true);
            if (Profesioness_Profesion != null && Profesioness_Profesion.Resource != null)
                ViewBag.Profesioness_Profesion = Profesioness_Profesion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Profesiones", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMedicos", varMedicos);
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
        public ActionResult GetTitulos_PersonalesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITitulos_PersonalesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITitulos_PersonalesApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Titulos_Personales", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipos_de_EspecialistasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_EspecialistasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Especialistas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPaisAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPaisApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais")?? m.Nombre_del_Pais,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstadoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstadoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado")?? m.Nombre_del_Estado,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSexoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISexoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetRespuesta_LogicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRespuesta_LogicaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetProfesionesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProfesionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IProfesionesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Profesiones", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEspecialidadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEspecialidadesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad")?? m.Especialidad,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetRegimenes_FiscalesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegimenes_FiscalesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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



        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(MedicosAdvanceSearchModel model, int idFilter = -1)
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
	    _ITitulos_PersonalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Titulos_Personaless_Titulo_Personal = _ITitulos_PersonalesApiConsumer.SelAll(true);
            if (Titulos_Personaless_Titulo_Personal != null && Titulos_Personaless_Titulo_Personal.Resource != null)
                ViewBag.Titulos_Personaless_Titulo_Personal = Titulos_Personaless_Titulo_Personal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Titulos_Personales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipos_de_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Especialistass_Tipo_de_Especialista = _ITipos_de_EspecialistasApiConsumer.SelAll(true);
            if (Tipos_de_Especialistass_Tipo_de_Especialista != null && Tipos_de_Especialistass_Tipo_de_Especialista.Resource != null)
                ViewBag.Tipos_de_Especialistass_Tipo_de_Especialista = Tipos_de_Especialistass_Tipo_de_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Especialistas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Email_ppal_publico = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Email_ppal_publico != null && Respuesta_Logicas_Email_ppal_publico.Resource != null)
                ViewBag.Respuesta_Logicas_Email_ppal_publico = Respuesta_Logicas_Email_ppal_publico.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_En_Hospital = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_En_Hospital != null && Respuesta_Logicas_En_Hospital.Resource != null)
                ViewBag.Respuesta_Logicas_En_Hospital = Respuesta_Logicas_En_Hospital.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Se_ajusta_tabulador = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Se_ajusta_tabulador != null && Respuesta_Logicas_Se_ajusta_tabulador.Resource != null)
                ViewBag.Respuesta_Logicas_Se_ajusta_tabulador = Respuesta_Logicas_Se_ajusta_tabulador.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IProfesionesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Profesioness_Profesion = _IProfesionesApiConsumer.SelAll(true);
            if (Profesioness_Profesion != null && Profesioness_Profesion.Resource != null)
                ViewBag.Profesioness_Profesion = Profesioness_Profesion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Profesiones", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
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
	    _ITitulos_PersonalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Titulos_Personaless_Titulo_Personal = _ITitulos_PersonalesApiConsumer.SelAll(true);
            if (Titulos_Personaless_Titulo_Personal != null && Titulos_Personaless_Titulo_Personal.Resource != null)
                ViewBag.Titulos_Personaless_Titulo_Personal = Titulos_Personaless_Titulo_Personal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Titulos_Personales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipos_de_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Especialistass_Tipo_de_Especialista = _ITipos_de_EspecialistasApiConsumer.SelAll(true);
            if (Tipos_de_Especialistass_Tipo_de_Especialista != null && Tipos_de_Especialistass_Tipo_de_Especialista.Resource != null)
                ViewBag.Tipos_de_Especialistass_Tipo_de_Especialista = Tipos_de_Especialistass_Tipo_de_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Especialistas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Email_ppal_publico = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Email_ppal_publico != null && Respuesta_Logicas_Email_ppal_publico.Resource != null)
                ViewBag.Respuesta_Logicas_Email_ppal_publico = Respuesta_Logicas_Email_ppal_publico.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_En_Hospital = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_En_Hospital != null && Respuesta_Logicas_En_Hospital.Resource != null)
                ViewBag.Respuesta_Logicas_En_Hospital = Respuesta_Logicas_En_Hospital.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Se_ajusta_tabulador = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Se_ajusta_tabulador != null && Respuesta_Logicas_Se_ajusta_tabulador.Resource != null)
                ViewBag.Respuesta_Logicas_Se_ajusta_tabulador = Respuesta_Logicas_Se_ajusta_tabulador.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IProfesionesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Profesioness_Profesion = _IProfesionesApiConsumer.SelAll(true);
            if (Profesioness_Profesion != null && Profesioness_Profesion.Resource != null)
                ViewBag.Profesioness_Profesion = Profesioness_Profesion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Profesiones", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new MedicosAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (MedicosAdvanceSearchModel)(Session["AdvanceSearch"] ?? new MedicosAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MedicosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Medicoss == null)
                result.Medicoss = new List<Medicos>();

            return Json(new
            {
                data = result.Medicoss.Select(m => new MedicosGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(m.Titulo_Personal_Titulos_Personales.Clave.ToString(), "Titulos_Personales") ?? (string)m.Titulo_Personal_Titulos_Personales.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Especialista_Tipos_de_Especialistas.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
			,Foto = m.Foto
			,Nombre_de_usuario = m.Nombre_de_usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email_institucional = m.Email_institucional
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(m.Email_ppal_publico_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Email_ppal_publico_Respuesta_Logica.Descripcion
			,Email_de_contacto = m.Email_de_contacto
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
			,Telefonos = m.Telefonos
                        ,En_HospitalDescripcion = CultureHelper.GetTraduction(m.En_Hospital_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.En_Hospital_Respuesta_Logica.Descripcion
			,Nombre_del_Hospital = m.Nombre_del_Hospital
			,Piso_hospital = m.Piso_hospital
			,Numero_de_consultorio = m.Numero_de_consultorio
                        ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(m.Se_ajusta_tabulador_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Se_ajusta_tabulador_Respuesta_Logica.Descripcion
                        ,ProfesionDescripcion = CultureHelper.GetTraduction(m.Profesion_Profesiones.Clave.ToString(), "Descripcion") ?? (string)m.Profesion_Profesiones.Descripcion
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Resumen_Profesional = m.Resumen_Profesional
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax
			,Cedula_Fiscal_Documento = m.Cedula_Fiscal_Documento
			,Comprobante_de_Domicilio = m.Comprobante_de_Domicilio
			,Calificacion_Red_de_Medicos = m.Calificacion_Red_de_Medicos
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetMedicosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMedicosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Medicos", m.),
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
        /// Get List of Medicos from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Medicos Entity</returns>
        public ActionResult GetMedicosList(UrlParametersModel param)
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
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new MedicosPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(MedicosAdvanceSearchModel))
                {
					var advanceFilter =
                    (MedicosAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            MedicosPropertyMapper oMedicosPropertyMapper = new MedicosPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oMedicosPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IMedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Medicoss == null)
                result.Medicoss = new List<Medicos>();

            return Json(new
            {
                aaData = result.Medicoss.Select(m => new MedicosGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(m.Titulo_Personal_Titulos_Personales.Clave.ToString(), "Titulos_Personales") ?? (string)m.Titulo_Personal_Titulos_Personales.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Especialista_Tipos_de_Especialistas.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
			,Foto = m.Foto
			,Nombre_de_usuario = m.Nombre_de_usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email_institucional = m.Email_institucional
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(m.Email_ppal_publico_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Email_ppal_publico_Respuesta_Logica.Descripcion
			,Email_de_contacto = m.Email_de_contacto
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
			,Telefonos = m.Telefonos
                        ,En_HospitalDescripcion = CultureHelper.GetTraduction(m.En_Hospital_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.En_Hospital_Respuesta_Logica.Descripcion
			,Nombre_del_Hospital = m.Nombre_del_Hospital
			,Piso_hospital = m.Piso_hospital
			,Numero_de_consultorio = m.Numero_de_consultorio
                        ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(m.Se_ajusta_tabulador_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Se_ajusta_tabulador_Respuesta_Logica.Descripcion
                        ,ProfesionDescripcion = CultureHelper.GetTraduction(m.Profesion_Profesiones.Clave.ToString(), "Descripcion") ?? (string)m.Profesion_Profesiones.Descripcion
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Resumen_Profesional = m.Resumen_Profesional
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax
			,Cedula_Fiscal_Documento = m.Cedula_Fiscal_Documento
			,Comprobante_de_Domicilio = m.Comprobante_de_Domicilio
			,Calificacion_Red_de_Medicos = m.Calificacion_Red_de_Medicos
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetMedicos_Titulo_Personal_Titulos_Personales(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITitulos_PersonalesApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Titulos_Personales.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Titulos_Personales.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ITitulos_PersonalesApiConsumer.ListaSelAll(1, 20,elWhere , " Titulos_Personales.Descripcion ASC ").Resource;
               
                foreach (var item in result.Titulos_Personaless)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Titulos_Personales", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Titulos_Personaless.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(MedicosAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Medicos.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Medicos.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Medicos.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Medicos.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Medicos.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Medicos.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Medicos.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTitulo_Personal))
            {
                switch (filter.Titulo_PersonalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Titulos_Personales.Descripcion LIKE '" + filter.AdvanceTitulo_Personal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Titulos_Personales.Descripcion LIKE '%" + filter.AdvanceTitulo_Personal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Titulos_Personales.Descripcion = '" + filter.AdvanceTitulo_Personal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Titulos_Personales.Descripcion LIKE '%" + filter.AdvanceTitulo_Personal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTitulo_PersonalMultiple != null && filter.AdvanceTitulo_PersonalMultiple.Count() > 0)
            {
                var Titulo_PersonalIds = string.Join(",", filter.AdvanceTitulo_PersonalMultiple);

                where += " AND Medicos.Titulo_Personal In (" + Titulo_PersonalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombres))
            {
                switch (filter.NombresFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombres LIKE '" + filter.Nombres + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombres LIKE '%" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombres = '" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombres LIKE '%" + filter.Nombres + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Paterno))
            {
                switch (filter.Apellido_PaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Apellido_Paterno LIKE '" + filter.Apellido_Paterno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Apellido_Paterno = '" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Materno))
            {
                switch (filter.Apellido_MaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Apellido_Materno LIKE '" + filter.Apellido_Materno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Apellido_Materno = '" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Completo))
            {
                switch (filter.Nombre_CompletoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombre_Completo LIKE '" + filter.Nombre_Completo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombre_Completo = '" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Especialista))
            {
                switch (filter.Tipo_de_EspecialistaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipos_de_Especialistas.Descripcion LIKE '" + filter.AdvanceTipo_de_Especialista + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipos_de_Especialistas.Descripcion LIKE '%" + filter.AdvanceTipo_de_Especialista + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipos_de_Especialistas.Descripcion = '" + filter.AdvanceTipo_de_Especialista + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipos_de_Especialistas.Descripcion LIKE '%" + filter.AdvanceTipo_de_Especialista + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_EspecialistaMultiple != null && filter.AdvanceTipo_de_EspecialistaMultiple.Count() > 0)
            {
                var Tipo_de_EspecialistaIds = string.Join(",", filter.AdvanceTipo_de_EspecialistaMultiple);

                where += " AND Medicos.Tipo_de_Especialista In (" + Tipo_de_EspecialistaIds + ")";
            }

            if (filter.Foto != RadioOptions.NoApply)
                where += " AND Medicos.Foto " + (filter.Foto == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.Nombre_de_usuario))
            {
                switch (filter.Nombre_de_usuarioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombre_de_usuario LIKE '" + filter.Nombre_de_usuario + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombre_de_usuario LIKE '%" + filter.Nombre_de_usuario + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombre_de_usuario = '" + filter.Nombre_de_usuario + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombre_de_usuario LIKE '%" + filter.Nombre_de_usuario + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_Registrado))
            {
                switch (filter.Usuario_RegistradoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_Registrado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_Registrado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_Registrado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_Registrado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_RegistradoMultiple != null && filter.AdvanceUsuario_RegistradoMultiple.Count() > 0)
            {
                var Usuario_RegistradoIds = string.Join(",", filter.AdvanceUsuario_RegistradoMultiple);

                where += " AND Medicos.Usuario_Registrado In (" + Usuario_RegistradoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Email LIKE '%" + filter.Email + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Celular))
            {
                switch (filter.CelularFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Celular LIKE '" + filter.Celular + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Celular LIKE '%" + filter.Celular + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Celular = '" + filter.Celular + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Celular LIKE '%" + filter.Celular + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_nacimiento) || !string.IsNullOrEmpty(filter.ToFecha_de_nacimiento))
            {
                var Fecha_de_nacimientoFrom = DateTime.ParseExact(filter.FromFecha_de_nacimiento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_nacimientoTo = DateTime.ParseExact(filter.ToFecha_de_nacimiento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_nacimiento))
                    where += " AND Medicos.Fecha_de_nacimiento >= '" + Fecha_de_nacimientoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_nacimiento))
                    where += " AND Medicos.Fecha_de_nacimiento <= '" + Fecha_de_nacimientoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais_de_nacimiento))
            {
                switch (filter.Pais_de_nacimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais_de_nacimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_de_nacimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais_de_nacimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_de_nacimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvancePais_de_nacimientoMultiple != null && filter.AdvancePais_de_nacimientoMultiple.Count() > 0)
            {
                var Pais_de_nacimientoIds = string.Join(",", filter.AdvancePais_de_nacimientoMultiple);

                where += " AND Medicos.Pais_de_nacimiento In (" + Pais_de_nacimientoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEntidad_de_nacimiento))
            {
                switch (filter.Entidad_de_nacimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEntidad_de_nacimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEntidad_de_nacimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEntidad_de_nacimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEntidad_de_nacimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEntidad_de_nacimientoMultiple != null && filter.AdvanceEntidad_de_nacimientoMultiple.Count() > 0)
            {
                var Entidad_de_nacimientoIds = string.Join(",", filter.AdvanceEntidad_de_nacimientoMultiple);

                where += " AND Medicos.Entidad_de_nacimiento In (" + Entidad_de_nacimientoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSexo))
            {
                switch (filter.SexoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Sexo.Descripcion LIKE '" + filter.AdvanceSexo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceSexo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Sexo.Descripcion = '" + filter.AdvanceSexo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceSexo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSexoMultiple != null && filter.AdvanceSexoMultiple.Count() > 0)
            {
                var SexoIds = string.Join(",", filter.AdvanceSexoMultiple);

                where += " AND Medicos.Sexo In (" + SexoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email_institucional))
            {
                switch (filter.Email_institucionalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Email_institucional LIKE '" + filter.Email_institucional + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Email_institucional LIKE '%" + filter.Email_institucional + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Email_institucional = '" + filter.Email_institucional + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Email_institucional LIKE '%" + filter.Email_institucional + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Medicos.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEmail_ppal_publico))
            {
                switch (filter.Email_ppal_publicoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceEmail_ppal_publico + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEmail_ppal_publico + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceEmail_ppal_publico + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEmail_ppal_publico + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEmail_ppal_publicoMultiple != null && filter.AdvanceEmail_ppal_publicoMultiple.Count() > 0)
            {
                var Email_ppal_publicoIds = string.Join(",", filter.AdvanceEmail_ppal_publicoMultiple);

                where += " AND Medicos.Email_ppal_publico In (" + Email_ppal_publicoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email_de_contacto))
            {
                switch (filter.Email_de_contactoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Email_de_contacto LIKE '" + filter.Email_de_contacto + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Email_de_contacto LIKE '%" + filter.Email_de_contacto + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Email_de_contacto = '" + filter.Email_de_contacto + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Email_de_contacto LIKE '%" + filter.Email_de_contacto + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Calle))
            {
                switch (filter.CalleFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Calle LIKE '" + filter.Calle + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Calle LIKE '%" + filter.Calle + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Calle = '" + filter.Calle + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Calle LIKE '%" + filter.Calle + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_exterior))
            {
                switch (filter.Numero_exteriorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Numero_exterior LIKE '" + filter.Numero_exterior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Numero_exterior LIKE '%" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Numero_exterior = '" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Numero_exterior LIKE '%" + filter.Numero_exterior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_interior))
            {
                switch (filter.Numero_interiorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Numero_interior LIKE '" + filter.Numero_interior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Numero_interior LIKE '%" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Numero_interior = '" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Numero_interior LIKE '%" + filter.Numero_interior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Colonia))
            {
                switch (filter.ColoniaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Colonia LIKE '" + filter.Colonia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Colonia LIKE '%" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Colonia = '" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Colonia LIKE '%" + filter.Colonia + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCP) || !string.IsNullOrEmpty(filter.ToCP))
            {
                if (!string.IsNullOrEmpty(filter.FromCP))
                    where += " AND Medicos.CP >= " + filter.FromCP;
                if (!string.IsNullOrEmpty(filter.ToCP))
                    where += " AND Medicos.CP <= " + filter.ToCP;
            }

            if (!string.IsNullOrEmpty(filter.Ciudad))
            {
                switch (filter.CiudadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Ciudad LIKE '" + filter.Ciudad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Ciudad LIKE '%" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Ciudad = '" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Ciudad LIKE '%" + filter.Ciudad + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstado))
            {
                switch (filter.EstadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEstado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEstado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstadoMultiple != null && filter.AdvanceEstadoMultiple.Count() > 0)
            {
                var EstadoIds = string.Join(",", filter.AdvanceEstadoMultiple);

                where += " AND Medicos.Estado In (" + EstadoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais))
            {
                switch (filter.PaisFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais + "%'";
                        break;
                }
            }
            else if (filter.AdvancePaisMultiple != null && filter.AdvancePaisMultiple.Count() > 0)
            {
                var PaisIds = string.Join(",", filter.AdvancePaisMultiple);

                where += " AND Medicos.Pais In (" + PaisIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Telefonos))
            {
                switch (filter.TelefonosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Telefonos LIKE '" + filter.Telefonos + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Telefonos LIKE '%" + filter.Telefonos + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Telefonos = '" + filter.Telefonos + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Telefonos LIKE '%" + filter.Telefonos + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEn_Hospital))
            {
                switch (filter.En_HospitalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceEn_Hospital + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEn_Hospital + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceEn_Hospital + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEn_Hospital + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEn_HospitalMultiple != null && filter.AdvanceEn_HospitalMultiple.Count() > 0)
            {
                var En_HospitalIds = string.Join(",", filter.AdvanceEn_HospitalMultiple);

                where += " AND Medicos.En_Hospital In (" + En_HospitalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Hospital))
            {
                switch (filter.Nombre_del_HospitalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombre_del_Hospital LIKE '" + filter.Nombre_del_Hospital + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombre_del_Hospital LIKE '%" + filter.Nombre_del_Hospital + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombre_del_Hospital = '" + filter.Nombre_del_Hospital + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombre_del_Hospital LIKE '%" + filter.Nombre_del_Hospital + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Piso_hospital))
            {
                switch (filter.Piso_hospitalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Piso_hospital LIKE '" + filter.Piso_hospital + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Piso_hospital LIKE '%" + filter.Piso_hospital + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Piso_hospital = '" + filter.Piso_hospital + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Piso_hospital LIKE '%" + filter.Piso_hospital + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_de_consultorio))
            {
                switch (filter.Numero_de_consultorioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Numero_de_consultorio LIKE '" + filter.Numero_de_consultorio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Numero_de_consultorio LIKE '%" + filter.Numero_de_consultorio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Numero_de_consultorio = '" + filter.Numero_de_consultorio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Numero_de_consultorio LIKE '%" + filter.Numero_de_consultorio + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSe_ajusta_tabulador))
            {
                switch (filter.Se_ajusta_tabuladorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceSe_ajusta_tabulador + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceSe_ajusta_tabulador + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceSe_ajusta_tabulador + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceSe_ajusta_tabulador + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSe_ajusta_tabuladorMultiple != null && filter.AdvanceSe_ajusta_tabuladorMultiple.Count() > 0)
            {
                var Se_ajusta_tabuladorIds = string.Join(",", filter.AdvanceSe_ajusta_tabuladorMultiple);

                where += " AND Medicos.Se_ajusta_tabulador In (" + Se_ajusta_tabuladorIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceProfesion))
            {
                switch (filter.ProfesionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Profesiones.Descripcion LIKE '" + filter.AdvanceProfesion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Profesiones.Descripcion LIKE '%" + filter.AdvanceProfesion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Profesiones.Descripcion = '" + filter.AdvanceProfesion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Profesiones.Descripcion LIKE '%" + filter.AdvanceProfesion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceProfesionMultiple != null && filter.AdvanceProfesionMultiple.Count() > 0)
            {
                var ProfesionIds = string.Join(",", filter.AdvanceProfesionMultiple);

                where += " AND Medicos.Profesion In (" + ProfesionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEspecialidad))
            {
                switch (filter.EspecialidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Especialidades.Especialidad LIKE '" + filter.AdvanceEspecialidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Especialidades.Especialidad LIKE '%" + filter.AdvanceEspecialidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Especialidades.Especialidad = '" + filter.AdvanceEspecialidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Especialidades.Especialidad LIKE '%" + filter.AdvanceEspecialidad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEspecialidadMultiple != null && filter.AdvanceEspecialidadMultiple.Count() > 0)
            {
                var EspecialidadIds = string.Join(",", filter.AdvanceEspecialidadMultiple);

                where += " AND Medicos.Especialidad In (" + EspecialidadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Resumen_Profesional))
            {
                switch (filter.Resumen_ProfesionalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Resumen_Profesional LIKE '" + filter.Resumen_Profesional + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Resumen_Profesional LIKE '%" + filter.Resumen_Profesional + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Resumen_Profesional = '" + filter.Resumen_Profesional + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Resumen_Profesional LIKE '%" + filter.Resumen_Profesional + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceRegimen_Fiscal))
            {
                switch (filter.Regimen_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Regimenes_Fiscales.Descripcion LIKE '" + filter.AdvanceRegimen_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Regimenes_Fiscales.Descripcion LIKE '%" + filter.AdvanceRegimen_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Regimenes_Fiscales.Descripcion = '" + filter.AdvanceRegimen_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Regimenes_Fiscales.Descripcion LIKE '%" + filter.AdvanceRegimen_Fiscal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceRegimen_FiscalMultiple != null && filter.AdvanceRegimen_FiscalMultiple.Count() > 0)
            {
                var Regimen_FiscalIds = string.Join(",", filter.AdvanceRegimen_FiscalMultiple);

                where += " AND Medicos.Regimen_Fiscal In (" + Regimen_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_o_Razon_Social))
            {
                switch (filter.Nombre_o_Razon_SocialFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombre_o_Razon_Social LIKE '" + filter.Nombre_o_Razon_Social + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombre_o_Razon_Social LIKE '%" + filter.Nombre_o_Razon_Social + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombre_o_Razon_Social = '" + filter.Nombre_o_Razon_Social + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombre_o_Razon_Social LIKE '%" + filter.Nombre_o_Razon_Social + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.RFC))
            {
                switch (filter.RFCFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.RFC LIKE '" + filter.RFC + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.RFC LIKE '%" + filter.RFC + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.RFC = '" + filter.RFC + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.RFC LIKE '%" + filter.RFC + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Calle_Fiscal))
            {
                switch (filter.Calle_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Calle_Fiscal LIKE '" + filter.Calle_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Calle_Fiscal LIKE '%" + filter.Calle_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Calle_Fiscal = '" + filter.Calle_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Calle_Fiscal LIKE '%" + filter.Calle_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_exterior_Fiscal))
            {
                switch (filter.Numero_exterior_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Numero_exterior_Fiscal LIKE '" + filter.Numero_exterior_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Numero_exterior_Fiscal LIKE '%" + filter.Numero_exterior_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Numero_exterior_Fiscal = '" + filter.Numero_exterior_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Numero_exterior_Fiscal LIKE '%" + filter.Numero_exterior_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_interior_Fiscal))
            {
                switch (filter.Numero_interior_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Numero_interior_Fiscal LIKE '" + filter.Numero_interior_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Numero_interior_Fiscal LIKE '%" + filter.Numero_interior_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Numero_interior_Fiscal = '" + filter.Numero_interior_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Numero_interior_Fiscal LIKE '%" + filter.Numero_interior_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Colonia_Fiscal))
            {
                switch (filter.Colonia_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Colonia_Fiscal LIKE '" + filter.Colonia_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Colonia_Fiscal LIKE '%" + filter.Colonia_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Colonia_Fiscal = '" + filter.Colonia_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Colonia_Fiscal LIKE '%" + filter.Colonia_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCP_Fiscal) || !string.IsNullOrEmpty(filter.ToCP_Fiscal))
            {
                if (!string.IsNullOrEmpty(filter.FromCP_Fiscal))
                    where += " AND Medicos.CP_Fiscal >= " + filter.FromCP_Fiscal;
                if (!string.IsNullOrEmpty(filter.ToCP_Fiscal))
                    where += " AND Medicos.CP_Fiscal <= " + filter.ToCP_Fiscal;
            }

            if (!string.IsNullOrEmpty(filter.Ciudad_Fiscal))
            {
                switch (filter.Ciudad_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Ciudad_Fiscal LIKE '" + filter.Ciudad_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Ciudad_Fiscal LIKE '%" + filter.Ciudad_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Ciudad_Fiscal = '" + filter.Ciudad_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Ciudad_Fiscal LIKE '%" + filter.Ciudad_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstado_Fiscal))
            {
                switch (filter.Estado_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEstado_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEstado_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado_Fiscal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstado_FiscalMultiple != null && filter.AdvanceEstado_FiscalMultiple.Count() > 0)
            {
                var Estado_FiscalIds = string.Join(",", filter.AdvanceEstado_FiscalMultiple);

                where += " AND Medicos.Estado_Fiscal In (" + Estado_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais_Fiscal))
            {
                switch (filter.Pais_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_Fiscal + "%'";
                        break;
                }
            }
            else if (filter.AdvancePais_FiscalMultiple != null && filter.AdvancePais_FiscalMultiple.Count() > 0)
            {
                var Pais_FiscalIds = string.Join(",", filter.AdvancePais_FiscalMultiple);

                where += " AND Medicos.Pais_Fiscal In (" + Pais_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Telefono))
            {
                switch (filter.TelefonoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Telefono LIKE '" + filter.Telefono + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Telefono LIKE '%" + filter.Telefono + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Telefono = '" + filter.Telefono + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Telefono LIKE '%" + filter.Telefono + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Fax))
            {
                switch (filter.FaxFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Fax LIKE '" + filter.Fax + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Fax LIKE '%" + filter.Fax + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Fax = '" + filter.Fax + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Fax LIKE '%" + filter.Fax + "%'";
                        break;
                }
            }

            if (filter.Cedula_Fiscal_Documento != RadioOptions.NoApply)
                where += " AND Medicos.Cedula_Fiscal_Documento " + (filter.Cedula_Fiscal_Documento == RadioOptions.Yes ? ">" : "==") + " 0";

            if (filter.Comprobante_de_Domicilio != RadioOptions.NoApply)
                where += " AND Medicos.Comprobante_de_Domicilio " + (filter.Comprobante_de_Domicilio == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.FromCalificacion_Red_de_Medicos) || !string.IsNullOrEmpty(filter.ToCalificacion_Red_de_Medicos))
            {
                if (!string.IsNullOrEmpty(filter.FromCalificacion_Red_de_Medicos))
                    where += " AND Medicos.Calificacion_Red_de_Medicos >= " + filter.FromCalificacion_Red_de_Medicos;
                if (!string.IsNullOrEmpty(filter.ToCalificacion_Red_de_Medicos))
                    where += " AND Medicos.Calificacion_Red_de_Medicos <= " + filter.ToCalificacion_Red_de_Medicos;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceBanco))
            {
                switch (filter.BancoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Bancos.Nombre LIKE '" + filter.AdvanceBanco + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Bancos.Nombre LIKE '%" + filter.AdvanceBanco + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Bancos.Nombre = '" + filter.AdvanceBanco + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Bancos.Nombre LIKE '%" + filter.AdvanceBanco + "%'";
                        break;
                }
            }
            else if (filter.AdvanceBancoMultiple != null && filter.AdvanceBancoMultiple.Count() > 0)
            {
                var BancoIds = string.Join(",", filter.AdvanceBancoMultiple);

                where += " AND Medicos.Banco In (" + BancoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.CLABE_Interbancaria))
            {
                switch (filter.CLABE_InterbancariaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.CLABE_Interbancaria LIKE '" + filter.CLABE_Interbancaria + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.CLABE_Interbancaria LIKE '%" + filter.CLABE_Interbancaria + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.CLABE_Interbancaria = '" + filter.CLABE_Interbancaria + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.CLABE_Interbancaria LIKE '%" + filter.CLABE_Interbancaria + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_de_Cuenta))
            {
                switch (filter.Numero_de_CuentaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Numero_de_Cuenta LIKE '" + filter.Numero_de_Cuenta + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Numero_de_Cuenta LIKE '%" + filter.Numero_de_Cuenta + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Numero_de_Cuenta = '" + filter.Numero_de_Cuenta + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Numero_de_Cuenta LIKE '%" + filter.Numero_de_Cuenta + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Titular))
            {
                switch (filter.Nombre_del_TitularFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombre_del_Titular LIKE '" + filter.Nombre_del_Titular + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombre_del_Titular LIKE '%" + filter.Nombre_del_Titular + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombre_del_Titular = '" + filter.Nombre_del_Titular + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombre_del_Titular LIKE '%" + filter.Nombre_del_Titular + "%'";
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

        public ActionResult GetDetalle_Redes_Sociales_Especialista(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Redes_Sociales_EspecialistaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Redes_Sociales_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Redes_Sociales_Especialista.Folio_Especialistas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Redes_Sociales_Especialista.Folio_Especialistas='" + RelationId + "'";
            }
            var result = _IDetalle_Redes_Sociales_EspecialistaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Redes_Sociales_Especialistas == null)
                result.Detalle_Redes_Sociales_Especialistas = new List<Detalle_Redes_Sociales_Especialista>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Redes_Sociales_Especialistas.Select(m => new Detalle_Redes_Sociales_EspecialistaGridModel
                {
                    Folio = m.Folio

                        ,Red_Social = m.Red_Social
                        ,Red_SocialDescripcion = CultureHelper.GetTraduction(m.Red_Social_Redes_sociales.Clave.ToString(), "Descripcion") ??(string)m.Red_Social_Redes_sociales.Descripcion
			,URL = m.URL
			,Principal = m.Principal

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Redes_Sociales_EspecialistaGridModel> GetDetalle_Redes_Sociales_EspecialistaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Redes_Sociales_EspecialistaGridModel> resultData = new List<Detalle_Redes_Sociales_EspecialistaGridModel>();
            string where = "Detalle_Redes_Sociales_Especialista.Folio_Especialistas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Redes_Sociales_Especialista.Folio_Especialistas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Redes_Sociales_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Redes_Sociales_EspecialistaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Redes_Sociales_Especialistas != null)
            {
                resultData = result.Detalle_Redes_Sociales_Especialistas.Select(m => new Detalle_Redes_Sociales_EspecialistaGridModel
                    {
                        Folio = m.Folio

                        ,Red_Social = m.Red_Social
                        ,Red_SocialDescripcion = CultureHelper.GetTraduction(m.Red_Social_Redes_sociales.Clave.ToString(), "Descripcion") ??(string)m.Red_Social_Redes_sociales.Descripcion
			,URL = m.URL
			,Principal = m.Principal


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Convenio_Medicos_Aseguradoras(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Convenio_Medicos_AseguradorasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos='" + RelationId + "'";
            }
            var result = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Convenio_Medicos_Aseguradorass == null)
                result.Detalle_Convenio_Medicos_Aseguradorass = new List<Detalle_Convenio_Medicos_Aseguradoras>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Convenio_Medicos_Aseguradorass.Select(m => new Detalle_Convenio_Medicos_AseguradorasGridModel
                {
                    Folio = m.Folio

                        ,Aseguradora_medico = m.Aseguradora_medico
                        ,Aseguradora_medicoNombre = CultureHelper.GetTraduction(m.Aseguradora_medico_Aseguradoras.Folio.ToString(), "Nombre") ??(string)m.Aseguradora_medico_Aseguradoras.Nombre

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Convenio_Medicos_AseguradorasGridModel> GetDetalle_Convenio_Medicos_AseguradorasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Convenio_Medicos_AseguradorasGridModel> resultData = new List<Detalle_Convenio_Medicos_AseguradorasGridModel>();
            string where = "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Convenio_Medicos_Aseguradorass != null)
            {
                resultData = result.Detalle_Convenio_Medicos_Aseguradorass.Select(m => new Detalle_Convenio_Medicos_AseguradorasGridModel
                    {
                        Folio = m.Folio

                        ,Aseguradora_medico = m.Aseguradora_medico
                        ,Aseguradora_medicoNombre = CultureHelper.GetTraduction(m.Aseguradora_medico_Aseguradoras.Folio.ToString(), "Nombre") ??(string)m.Aseguradora_medico_Aseguradoras.Nombre


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Titulos_Medicos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Titulos_MedicosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Titulos_Medicos.Folio_Medicos=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Titulos_Medicos.Folio_Medicos='" + RelationId + "'";
            }
            var result = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Titulos_Medicoss == null)
                result.Detalle_Titulos_Medicoss = new List<Detalle_Titulos_Medicos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Titulos_Medicoss.Select(m => new Detalle_Titulos_MedicosGridModel
                {
                    Folio = m.Folio

			,Nombre_del_Titulo = m.Nombre_del_Titulo
			,Institucion_Facultad = m.Institucion_Facultad
			,Fecha_de_Titulacion = (m.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
			,TituloFileInfo = m.Titulo > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Titulo).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Numero_de_Cedula = m.Numero_de_Cedula
			,Fecha_de_Expedicion = (m.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))
			,Cedula_FrenteFileInfo = m.Cedula_Frente > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Cedula_Frente).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Cedula_ReversoFileInfo = m.Cedula_Reverso > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Cedula_Reverso).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Titulos_MedicosGridModel> GetDetalle_Titulos_MedicosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Titulos_MedicosGridModel> resultData = new List<Detalle_Titulos_MedicosGridModel>();
            string where = "Detalle_Titulos_Medicos.Folio_Medicos=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Titulos_Medicos.Folio_Medicos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Titulos_Medicoss != null)
            {
                resultData = result.Detalle_Titulos_Medicoss.Select(m => new Detalle_Titulos_MedicosGridModel
                    {
                        Folio = m.Folio

			,Nombre_del_Titulo = m.Nombre_del_Titulo
			,Institucion_Facultad = m.Institucion_Facultad
			,Fecha_de_Titulacion = (m.Fecha_de_Titulacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Titulacion).ToString(ConfigurationProperty.DateFormat))
			,TituloFileInfo = m.Titulo > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Titulo).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Numero_de_Cedula = m.Numero_de_Cedula
			,Fecha_de_Expedicion = (m.Fecha_de_Expedicion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Expedicion).ToString(ConfigurationProperty.DateFormat))
			,Cedula_FrenteFileInfo = m.Cedula_Frente > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Cedula_Frente).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Cedula_ReversoFileInfo = m.Cedula_Reverso > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Cedula_Reverso).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Identificacion_Oficial_Medicos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Identificacion_Oficial_MedicosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Identificacion_Oficial_Medicos.Folio_Medico=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Identificacion_Oficial_Medicos.Folio_Medico='" + RelationId + "'";
            }
            var result = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Identificacion_Oficial_Medicoss == null)
                result.Detalle_Identificacion_Oficial_Medicoss = new List<Detalle_Identificacion_Oficial_Medicos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Identificacion_Oficial_Medicoss.Select(m => new Detalle_Identificacion_Oficial_MedicosGridModel
                {
                    Folio = m.Folio

                        ,Tipo_de_Identificacion_Oficial = m.Tipo_de_Identificacion_Oficial
                        ,Tipo_de_Identificacion_OficialDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion
			,DocumentoFileInfo = m.Documento > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Documento).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Identificacion_Oficial_MedicosGridModel> GetDetalle_Identificacion_Oficial_MedicosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Identificacion_Oficial_MedicosGridModel> resultData = new List<Detalle_Identificacion_Oficial_MedicosGridModel>();
            string where = "Detalle_Identificacion_Oficial_Medicos.Folio_Medico=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Identificacion_Oficial_Medicos.Folio_Medico='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Identificacion_Oficial_Medicoss != null)
            {
                resultData = result.Detalle_Identificacion_Oficial_Medicoss.Select(m => new Detalle_Identificacion_Oficial_MedicosGridModel
                    {
                        Folio = m.Folio

                        ,Tipo_de_Identificacion_Oficial = m.Tipo_de_Identificacion_Oficial
                        ,Tipo_de_Identificacion_OficialDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales.Descripcion
			,DocumentoFileInfo = m.Documento > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Documento).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Codigos_Referidos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Codigos_ReferidosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Codigos_Referidos.Folio_Medicos=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Codigos_Referidos.Folio_Medicos='" + RelationId + "'";
            }
            var result = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Codigos_Referidoss == null)
                result.Detalle_Codigos_Referidoss = new List<Detalle_Codigos_Referidos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Codigos_Referidoss.Select(m => new Detalle_Codigos_ReferidosGridModel
                {
                    Folio = m.Folio


			,Porcentaje_de_descuento = m.Porcentaje_de_descuento
			,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
			,Codigo_para_Referenciados = m.Codigo_para_Referenciados
			,Autorizado = m.Autorizado
                        ,Usuario_que_autoriza = m.Usuario_que_autoriza
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Usuario_que_autoriza_Spartan_User.Name
			,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Codigos_ReferidosGridModel> GetDetalle_Codigos_ReferidosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Codigos_ReferidosGridModel> resultData = new List<Detalle_Codigos_ReferidosGridModel>();
            string where = "Detalle_Codigos_Referidos.Folio_Medicos=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Codigos_Referidos.Folio_Medicos='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Codigos_Referidoss != null)
            {
                resultData = result.Detalle_Codigos_Referidoss.Select(m => new Detalle_Codigos_ReferidosGridModel
                    {
                        Folio = m.Folio


			,Porcentaje_de_descuento = m.Porcentaje_de_descuento
			,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
			,Codigo_para_Referenciados = m.Codigo_para_Referenciados
			,Autorizado = m.Autorizado
                        ,Usuario_que_autoriza = m.Usuario_que_autoriza
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Usuario_que_autoriza_Spartan_User.Name
			,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Planes_de_Suscripcion_Especialistas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Planes_de_Suscripcion_EspecialistasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas='" + RelationId + "'";
            }
            var result = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Planes_de_Suscripcion_Especialistass == null)
                result.Detalle_Planes_de_Suscripcion_Especialistass = new List<Detalle_Planes_de_Suscripcion_Especialistas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Planes_de_Suscripcion_Especialistass.Select(m => new Detalle_Planes_de_Suscripcion_EspecialistasGridModel
                {
                    Folio = m.Folio

                        ,Plan_de_Suscripcion = m.Plan_de_Suscripcion
                        ,Plan_de_SuscripcionNombre = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Folio.ToString(), "Nombre") ??(string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
			,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Costo = m.Costo
			,ContratoFileInfo = m.Contrato > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Contrato).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Firmo_Contrato = m.Firmo_Contrato
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Planes_de_Suscripcion_EspecialistasGridModel> GetDetalle_Planes_de_Suscripcion_EspecialistasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Planes_de_Suscripcion_EspecialistasGridModel> resultData = new List<Detalle_Planes_de_Suscripcion_EspecialistasGridModel>();
            string where = "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Planes_de_Suscripcion_Especialistass != null)
            {
                resultData = result.Detalle_Planes_de_Suscripcion_Especialistass.Select(m => new Detalle_Planes_de_Suscripcion_EspecialistasGridModel
                    {
                        Folio = m.Folio

                        ,Plan_de_Suscripcion = m.Plan_de_Suscripcion
                        ,Plan_de_SuscripcionNombre = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Folio.ToString(), "Nombre") ??(string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
			,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Costo = m.Costo
			,ContratoFileInfo = m.Contrato > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Contrato).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Firmo_Contrato = m.Firmo_Contrato
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Facturacion_Especialistas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Facturacion_EspecialistasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Facturacion_Especialistas.Folio_Especialistas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Facturacion_Especialistas.Folio_Especialistas='" + RelationId + "'";
            }
            var result = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Facturacion_Especialistass == null)
                result.Detalle_Facturacion_Especialistass = new List<Detalle_Facturacion_Especialistas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Facturacion_Especialistass.Select(m => new Detalle_Facturacion_EspecialistasGridModel
                {
                    Folio = m.Folio

			,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Folio_Factura = m.Folio_Factura
			,Periodo_Facturado = m.Periodo_Facturado
			,Cantidad = m.Cantidad
			,Archivo_XMLFileInfo = m.Archivo_XML > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_XML).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Archivo_PDFFileInfo = m.Archivo_PDF > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_PDF).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Estatus = m.Estatus
			,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Pagada = m.Pagada
			,Fecha_de_pago = (m.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Facturacion_EspecialistasGridModel> GetDetalle_Facturacion_EspecialistasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Facturacion_EspecialistasGridModel> resultData = new List<Detalle_Facturacion_EspecialistasGridModel>();
            string where = "Detalle_Facturacion_Especialistas.Folio_Especialistas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Facturacion_Especialistas.Folio_Especialistas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Facturacion_Especialistass != null)
            {
                resultData = result.Detalle_Facturacion_Especialistass.Select(m => new Detalle_Facturacion_EspecialistasGridModel
                    {
                        Folio = m.Folio

			,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Folio_Factura = m.Folio_Factura
			,Periodo_Facturado = m.Periodo_Facturado
			,Cantidad = m.Cantidad
			,Archivo_XMLFileInfo = m.Archivo_XML > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_XML).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Archivo_PDFFileInfo = m.Archivo_PDF > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_PDF).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Estatus = m.Estatus
			,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Pagada = m.Pagada
			,Fecha_de_pago = (m.Fecha_de_pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_pago).ToString(ConfigurationProperty.DateFormat))


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
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Medicos varMedicos = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Redes_Sociales_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Redes_Sociales_Especialista.Folio_Especialistas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Redes_Sociales_Especialista.Folio_Especialistas='" + id + "'";
                    }
                    var Detalle_Redes_Sociales_EspecialistaInfo =
                        _IDetalle_Redes_Sociales_EspecialistaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Redes_Sociales_EspecialistaInfo.Detalle_Redes_Sociales_Especialistas.Count > 0)
                    {
                        var resultDetalle_Redes_Sociales_Especialista = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Redes_Sociales_EspecialistaItem in Detalle_Redes_Sociales_EspecialistaInfo.Detalle_Redes_Sociales_Especialistas)
                            resultDetalle_Redes_Sociales_Especialista = resultDetalle_Redes_Sociales_Especialista
                                              && _IDetalle_Redes_Sociales_EspecialistaApiConsumer.Delete(Detalle_Redes_Sociales_EspecialistaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Redes_Sociales_Especialista)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos='" + id + "'";
                    }
                    var Detalle_Convenio_Medicos_AseguradorasInfo =
                        _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Convenio_Medicos_AseguradorasInfo.Detalle_Convenio_Medicos_Aseguradorass.Count > 0)
                    {
                        var resultDetalle_Convenio_Medicos_Aseguradoras = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Convenio_Medicos_AseguradorasItem in Detalle_Convenio_Medicos_AseguradorasInfo.Detalle_Convenio_Medicos_Aseguradorass)
                            resultDetalle_Convenio_Medicos_Aseguradoras = resultDetalle_Convenio_Medicos_Aseguradoras
                                              && _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Delete(Detalle_Convenio_Medicos_AseguradorasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Convenio_Medicos_Aseguradoras)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Titulos_Medicos.Folio_Medicos=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Titulos_Medicos.Folio_Medicos='" + id + "'";
                    }
                    var Detalle_Titulos_MedicosInfo =
                        _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Titulos_MedicosInfo.Detalle_Titulos_Medicoss.Count > 0)
                    {
                        var resultDetalle_Titulos_Medicos = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Titulos_MedicosItem in Detalle_Titulos_MedicosInfo.Detalle_Titulos_Medicoss)
                            resultDetalle_Titulos_Medicos = resultDetalle_Titulos_Medicos
                                              && _IDetalle_Titulos_MedicosApiConsumer.Delete(Detalle_Titulos_MedicosItem.Folio, null,null).Resource;

                        if (!resultDetalle_Titulos_Medicos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Identificacion_Oficial_Medicos.Folio_Medico=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Identificacion_Oficial_Medicos.Folio_Medico='" + id + "'";
                    }
                    var Detalle_Identificacion_Oficial_MedicosInfo =
                        _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Identificacion_Oficial_MedicosInfo.Detalle_Identificacion_Oficial_Medicoss.Count > 0)
                    {
                        var resultDetalle_Identificacion_Oficial_Medicos = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Identificacion_Oficial_MedicosItem in Detalle_Identificacion_Oficial_MedicosInfo.Detalle_Identificacion_Oficial_Medicoss)
                            resultDetalle_Identificacion_Oficial_Medicos = resultDetalle_Identificacion_Oficial_Medicos
                                              && _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Delete(Detalle_Identificacion_Oficial_MedicosItem.Folio, null,null).Resource;

                        if (!resultDetalle_Identificacion_Oficial_Medicos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Codigos_Referidos.Folio_Medicos=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Codigos_Referidos.Folio_Medicos='" + id + "'";
                    }
                    var Detalle_Codigos_ReferidosInfo =
                        _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Codigos_ReferidosInfo.Detalle_Codigos_Referidoss.Count > 0)
                    {
                        var resultDetalle_Codigos_Referidos = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Codigos_ReferidosItem in Detalle_Codigos_ReferidosInfo.Detalle_Codigos_Referidoss)
                            resultDetalle_Codigos_Referidos = resultDetalle_Codigos_Referidos
                                              && _IDetalle_Codigos_ReferidosApiConsumer.Delete(Detalle_Codigos_ReferidosItem.Folio, null,null).Resource;

                        if (!resultDetalle_Codigos_Referidos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas='" + id + "'";
                    }
                    var Detalle_Planes_de_Suscripcion_EspecialistasInfo =
                        _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Planes_de_Suscripcion_EspecialistasInfo.Detalle_Planes_de_Suscripcion_Especialistass.Count > 0)
                    {
                        var resultDetalle_Planes_de_Suscripcion_Especialistas = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Planes_de_Suscripcion_EspecialistasItem in Detalle_Planes_de_Suscripcion_EspecialistasInfo.Detalle_Planes_de_Suscripcion_Especialistass)
                            resultDetalle_Planes_de_Suscripcion_Especialistas = resultDetalle_Planes_de_Suscripcion_Especialistas
                                              && _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Delete(Detalle_Planes_de_Suscripcion_EspecialistasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Planes_de_Suscripcion_Especialistas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Facturacion_Especialistas.Folio_Especialistas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Facturacion_Especialistas.Folio_Especialistas='" + id + "'";
                    }
                    var Detalle_Facturacion_EspecialistasInfo =
                        _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Facturacion_EspecialistasInfo.Detalle_Facturacion_Especialistass.Count > 0)
                    {
                        var resultDetalle_Facturacion_Especialistas = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Facturacion_EspecialistasItem in Detalle_Facturacion_EspecialistasInfo.Detalle_Facturacion_Especialistass)
                            resultDetalle_Facturacion_Especialistas = resultDetalle_Facturacion_Especialistas
                                              && _IDetalle_Facturacion_EspecialistasApiConsumer.Delete(Detalle_Facturacion_EspecialistasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Facturacion_Especialistas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IMedicosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MedicosModel varMedicos)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varMedicos.FotoRemoveAttachment != 0 && varMedicos.FotoFile == null)
                    {
                        varMedicos.Foto = 0;
                    }

                    if (varMedicos.FotoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varMedicos.FotoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varMedicos.Foto = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varMedicos.FotoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varMedicos.Cedula_Fiscal_DocumentoRemoveAttachment != 0 && varMedicos.Cedula_Fiscal_DocumentoFile == null)
                    {
                        varMedicos.Cedula_Fiscal_Documento = 0;
                    }

                    if (varMedicos.Cedula_Fiscal_DocumentoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varMedicos.Cedula_Fiscal_DocumentoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varMedicos.Cedula_Fiscal_Documento = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varMedicos.Cedula_Fiscal_DocumentoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varMedicos.Comprobante_de_DomicilioRemoveAttachment != 0 && varMedicos.Comprobante_de_DomicilioFile == null)
                    {
                        varMedicos.Comprobante_de_Domicilio = 0;
                    }

                    if (varMedicos.Comprobante_de_DomicilioFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varMedicos.Comprobante_de_DomicilioFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varMedicos.Comprobante_de_Domicilio = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varMedicos.Comprobante_de_DomicilioFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var MedicosInfo = new Medicos
                    {
                        Folio = varMedicos.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varMedicos.Fecha_de_Registro)) ? DateTime.ParseExact(varMedicos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varMedicos.Hora_de_Registro
                        ,Usuario_que_Registra = varMedicos.Usuario_que_Registra
                        ,Titulo_Personal = varMedicos.Titulo_Personal
                        ,Nombres = varMedicos.Nombres
                        ,Apellido_Paterno = varMedicos.Apellido_Paterno
                        ,Apellido_Materno = varMedicos.Apellido_Materno
                        ,Nombre_Completo = varMedicos.Nombre_Completo
                        ,Tipo_de_Especialista = varMedicos.Tipo_de_Especialista
                        ,Foto = (varMedicos.Foto.HasValue && varMedicos.Foto != 0) ? ((int?)Convert.ToInt32(varMedicos.Foto.Value)) : null

                        ,Nombre_de_usuario = varMedicos.Nombre_de_usuario
                        ,Usuario_Registrado = varMedicos.Usuario_Registrado
                        ,Email = varMedicos.Email
                        ,Celular = varMedicos.Celular
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varMedicos.Fecha_de_nacimiento)) ? DateTime.ParseExact(varMedicos.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pais_de_nacimiento = varMedicos.Pais_de_nacimiento
                        ,Entidad_de_nacimiento = varMedicos.Entidad_de_nacimiento
                        ,Sexo = varMedicos.Sexo
                        ,Email_institucional = varMedicos.Email_institucional
                        ,Estatus = varMedicos.Estatus
                        ,Email_ppal_publico = varMedicos.Email_ppal_publico
                        ,Email_de_contacto = varMedicos.Email_de_contacto
                        ,Calle = varMedicos.Calle
                        ,Numero_exterior = varMedicos.Numero_exterior
                        ,Numero_interior = varMedicos.Numero_interior
                        ,Colonia = varMedicos.Colonia
                        ,CP = varMedicos.CP
                        ,Ciudad = varMedicos.Ciudad
                        ,Estado = varMedicos.Estado
                        ,Pais = varMedicos.Pais
                        ,Telefonos = varMedicos.Telefonos
                        ,En_Hospital = varMedicos.En_Hospital
                        ,Nombre_del_Hospital = varMedicos.Nombre_del_Hospital
                        ,Piso_hospital = varMedicos.Piso_hospital
                        ,Numero_de_consultorio = varMedicos.Numero_de_consultorio
                        ,Se_ajusta_tabulador = varMedicos.Se_ajusta_tabulador
                        ,Profesion = varMedicos.Profesion
                        ,Especialidad = varMedicos.Especialidad
                        ,Resumen_Profesional = varMedicos.Resumen_Profesional
                        ,Regimen_Fiscal = varMedicos.Regimen_Fiscal
                        ,Nombre_o_Razon_Social = varMedicos.Nombre_o_Razon_Social
                        ,RFC = varMedicos.RFC
                        ,Calle_Fiscal = varMedicos.Calle_Fiscal
                        ,Numero_exterior_Fiscal = varMedicos.Numero_exterior_Fiscal
                        ,Numero_interior_Fiscal = varMedicos.Numero_interior_Fiscal
                        ,Colonia_Fiscal = varMedicos.Colonia_Fiscal
                        ,CP_Fiscal = varMedicos.CP_Fiscal
                        ,Ciudad_Fiscal = varMedicos.Ciudad_Fiscal
                        ,Estado_Fiscal = varMedicos.Estado_Fiscal
                        ,Pais_Fiscal = varMedicos.Pais_Fiscal
                        ,Telefono = varMedicos.Telefono
                        ,Fax = varMedicos.Fax
                        ,Cedula_Fiscal_Documento = (varMedicos.Cedula_Fiscal_Documento.HasValue && varMedicos.Cedula_Fiscal_Documento != 0) ? ((int?)Convert.ToInt32(varMedicos.Cedula_Fiscal_Documento.Value)) : null

                        ,Comprobante_de_Domicilio = (varMedicos.Comprobante_de_Domicilio.HasValue && varMedicos.Comprobante_de_Domicilio != 0) ? ((int?)Convert.ToInt32(varMedicos.Comprobante_de_Domicilio.Value)) : null

                        ,Calificacion_Red_de_Medicos = varMedicos.Calificacion_Red_de_Medicos
                        ,Banco = varMedicos.Banco
                        ,CLABE_Interbancaria = varMedicos.CLABE_Interbancaria
                        ,Numero_de_Cuenta = varMedicos.Numero_de_Cuenta
                        ,Nombre_del_Titular = varMedicos.Nombre_del_Titular

                    };

                    result = !IsNew ?
                        _IMedicosApiConsumer.Update(MedicosInfo, null, null).Resource.ToString() :
                         _IMedicosApiConsumer.Insert(MedicosInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Redes_Sociales_Especialista(int MasterId, int referenceId, List<Detalle_Redes_Sociales_EspecialistaGridModelPost> Detalle_Redes_Sociales_EspecialistaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Redes_Sociales_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Redes_Sociales_EspecialistaData = _IDetalle_Redes_Sociales_EspecialistaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Redes_Sociales_Especialista.Folio_Especialistas=" + referenceId,"").Resource;
                if (Detalle_Redes_Sociales_EspecialistaData == null || Detalle_Redes_Sociales_EspecialistaData.Detalle_Redes_Sociales_Especialistas.Count == 0)
                    return true;

                var result = true;

                Detalle_Redes_Sociales_EspecialistaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Redes_Sociales_Especialista in Detalle_Redes_Sociales_EspecialistaData.Detalle_Redes_Sociales_Especialistas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Redes_Sociales_Especialista Detalle_Redes_Sociales_Especialista1 = varDetalle_Redes_Sociales_Especialista;

                    if (Detalle_Redes_Sociales_EspecialistaItems != null && Detalle_Redes_Sociales_EspecialistaItems.Any(m => m.Folio == Detalle_Redes_Sociales_Especialista1.Folio))
                    {
                        modelDataToChange = Detalle_Redes_Sociales_EspecialistaItems.FirstOrDefault(m => m.Folio == Detalle_Redes_Sociales_Especialista1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Redes_Sociales_Especialista.Folio_Especialistas = MasterId;
                    var insertId = _IDetalle_Redes_Sociales_EspecialistaApiConsumer.Insert(varDetalle_Redes_Sociales_Especialista,null,null).Resource;
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
        public ActionResult PostDetalle_Redes_Sociales_Especialista(List<Detalle_Redes_Sociales_EspecialistaGridModelPost> Detalle_Redes_Sociales_EspecialistaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Redes_Sociales_Especialista(MasterId, referenceId, Detalle_Redes_Sociales_EspecialistaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Redes_Sociales_EspecialistaItems != null && Detalle_Redes_Sociales_EspecialistaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Redes_Sociales_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Redes_Sociales_EspecialistaItem in Detalle_Redes_Sociales_EspecialistaItems)
                    {





                        //Removal Request
                        if (Detalle_Redes_Sociales_EspecialistaItem.Removed)
                        {
                            result = result && _IDetalle_Redes_Sociales_EspecialistaApiConsumer.Delete(Detalle_Redes_Sociales_EspecialistaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Redes_Sociales_EspecialistaItem.Folio = 0;

                        var Detalle_Redes_Sociales_EspecialistaData = new Detalle_Redes_Sociales_Especialista
                        {
                            Folio_Especialistas = MasterId
                            ,Folio = Detalle_Redes_Sociales_EspecialistaItem.Folio
                            ,Red_Social = (Convert.ToInt32(Detalle_Redes_Sociales_EspecialistaItem.Red_Social) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Redes_Sociales_EspecialistaItem.Red_Social))
                            ,URL = Detalle_Redes_Sociales_EspecialistaItem.URL
                            ,Principal = Detalle_Redes_Sociales_EspecialistaItem.Principal

                        };

                        var resultId = Detalle_Redes_Sociales_EspecialistaItem.Folio > 0
                           ? _IDetalle_Redes_Sociales_EspecialistaApiConsumer.Update(Detalle_Redes_Sociales_EspecialistaData,null,null).Resource
                           : _IDetalle_Redes_Sociales_EspecialistaApiConsumer.Insert(Detalle_Redes_Sociales_EspecialistaData,null,null).Resource;

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
        public ActionResult GetDetalle_Redes_Sociales_Especialista_Redes_socialesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRedes_socialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRedes_socialesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Redes_sociales", "Descripcion");
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
        public bool CopyDetalle_Convenio_Medicos_Aseguradoras(int MasterId, int referenceId, List<Detalle_Convenio_Medicos_AseguradorasGridModelPost> Detalle_Convenio_Medicos_AseguradorasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Convenio_Medicos_AseguradorasData = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Convenio_Medicos_Aseguradoras.Folio_Medicos=" + referenceId,"").Resource;
                if (Detalle_Convenio_Medicos_AseguradorasData == null || Detalle_Convenio_Medicos_AseguradorasData.Detalle_Convenio_Medicos_Aseguradorass.Count == 0)
                    return true;

                var result = true;

                Detalle_Convenio_Medicos_AseguradorasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Convenio_Medicos_Aseguradoras in Detalle_Convenio_Medicos_AseguradorasData.Detalle_Convenio_Medicos_Aseguradorass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Convenio_Medicos_Aseguradoras Detalle_Convenio_Medicos_Aseguradoras1 = varDetalle_Convenio_Medicos_Aseguradoras;

                    if (Detalle_Convenio_Medicos_AseguradorasItems != null && Detalle_Convenio_Medicos_AseguradorasItems.Any(m => m.Folio == Detalle_Convenio_Medicos_Aseguradoras1.Folio))
                    {
                        modelDataToChange = Detalle_Convenio_Medicos_AseguradorasItems.FirstOrDefault(m => m.Folio == Detalle_Convenio_Medicos_Aseguradoras1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Convenio_Medicos_Aseguradoras.Folio_Medicos = MasterId;
                    var insertId = _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Insert(varDetalle_Convenio_Medicos_Aseguradoras,null,null).Resource;
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
        public ActionResult PostDetalle_Convenio_Medicos_Aseguradoras(List<Detalle_Convenio_Medicos_AseguradorasGridModelPost> Detalle_Convenio_Medicos_AseguradorasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Convenio_Medicos_Aseguradoras(MasterId, referenceId, Detalle_Convenio_Medicos_AseguradorasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Convenio_Medicos_AseguradorasItems != null && Detalle_Convenio_Medicos_AseguradorasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Convenio_Medicos_AseguradorasItem in Detalle_Convenio_Medicos_AseguradorasItems)
                    {



                        //Removal Request
                        if (Detalle_Convenio_Medicos_AseguradorasItem.Removed)
                        {
                            result = result && _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Delete(Detalle_Convenio_Medicos_AseguradorasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Convenio_Medicos_AseguradorasItem.Folio = 0;

                        var Detalle_Convenio_Medicos_AseguradorasData = new Detalle_Convenio_Medicos_Aseguradoras
                        {
                            Folio_Medicos = MasterId
                            ,Folio = Detalle_Convenio_Medicos_AseguradorasItem.Folio
                            ,Aseguradora_medico = (Convert.ToInt32(Detalle_Convenio_Medicos_AseguradorasItem.Aseguradora_medico) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Convenio_Medicos_AseguradorasItem.Aseguradora_medico))

                        };

                        var resultId = Detalle_Convenio_Medicos_AseguradorasItem.Folio > 0
                           ? _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Update(Detalle_Convenio_Medicos_AseguradorasData,null,null).Resource
                           : _IDetalle_Convenio_Medicos_AseguradorasApiConsumer.Insert(Detalle_Convenio_Medicos_AseguradorasData,null,null).Resource;

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
        public ActionResult GetDetalle_Convenio_Medicos_Aseguradoras_AseguradorasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IAseguradorasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IAseguradorasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Aseguradoras", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyDetalle_Titulos_Medicos(int MasterId, int referenceId, List<Detalle_Titulos_MedicosGridModelPost> Detalle_Titulos_MedicosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Titulos_MedicosData = _IDetalle_Titulos_MedicosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Titulos_Medicos.Folio_Medicos=" + referenceId,"").Resource;
                if (Detalle_Titulos_MedicosData == null || Detalle_Titulos_MedicosData.Detalle_Titulos_Medicoss.Count == 0)
                    return true;

                var result = true;

                Detalle_Titulos_MedicosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Titulos_Medicos in Detalle_Titulos_MedicosData.Detalle_Titulos_Medicoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Titulos_Medicos Detalle_Titulos_Medicos1 = varDetalle_Titulos_Medicos;

                    if (Detalle_Titulos_MedicosItems != null && Detalle_Titulos_MedicosItems.Any(m => m.Folio == Detalle_Titulos_Medicos1.Folio))
                    {
                        modelDataToChange = Detalle_Titulos_MedicosItems.FirstOrDefault(m => m.Folio == Detalle_Titulos_Medicos1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Titulos_Medicos.Folio_Medicos = MasterId;
                    var insertId = _IDetalle_Titulos_MedicosApiConsumer.Insert(varDetalle_Titulos_Medicos,null,null).Resource;
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
        public ActionResult PostDetalle_Titulos_Medicos(List<Detalle_Titulos_MedicosGridModelPost> Detalle_Titulos_MedicosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Titulos_Medicos(MasterId, referenceId, Detalle_Titulos_MedicosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Titulos_MedicosItems != null && Detalle_Titulos_MedicosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Titulos_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Titulos_MedicosItem in Detalle_Titulos_MedicosItems)
                    {




                        #region TituloInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Titulos_MedicosItem.TituloInfo.Control != null && !Detalle_Titulos_MedicosItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Titulos_MedicosItem.TituloInfo.Control);
                            Detalle_Titulos_MedicosItem.TituloInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Titulos_MedicosItem.TituloInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Titulos_MedicosItem.Removed && Detalle_Titulos_MedicosItem.TituloInfo.RemoveFile)
                        {
                            Detalle_Titulos_MedicosItem.TituloInfo.FileId = 0;
                        }
                        #endregion TituloInfo


                        #region Cedula_FrenteInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.Control != null && !Detalle_Titulos_MedicosItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.Control);
                            Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Titulos_MedicosItem.Removed && Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.RemoveFile)
                        {
                            Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.FileId = 0;
                        }
                        #endregion Cedula_FrenteInfo
                        #region Cedula_ReversoInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.Control != null && !Detalle_Titulos_MedicosItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.Control);
                            Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Titulos_MedicosItem.Removed && Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.RemoveFile)
                        {
                            Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.FileId = 0;
                        }
                        #endregion Cedula_ReversoInfo

                        //Removal Request
                        if (Detalle_Titulos_MedicosItem.Removed)
                        {
                            result = result && _IDetalle_Titulos_MedicosApiConsumer.Delete(Detalle_Titulos_MedicosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Titulos_MedicosItem.Folio = 0;

                        var Detalle_Titulos_MedicosData = new Detalle_Titulos_Medicos
                        {
                            Folio_Medicos = MasterId
                            ,Folio = Detalle_Titulos_MedicosItem.Folio
                            ,Nombre_del_Titulo = Detalle_Titulos_MedicosItem.Nombre_del_Titulo
                            ,Institucion_Facultad = Detalle_Titulos_MedicosItem.Institucion_Facultad
                            ,Fecha_de_Titulacion = (Detalle_Titulos_MedicosItem.Fecha_de_Titulacion!= null) ? DateTime.ParseExact(Detalle_Titulos_MedicosItem.Fecha_de_Titulacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Titulo = Detalle_Titulos_MedicosItem.TituloInfo.FileId
                            ,Numero_de_Cedula = Detalle_Titulos_MedicosItem.Numero_de_Cedula
                            ,Fecha_de_Expedicion = (Detalle_Titulos_MedicosItem.Fecha_de_Expedicion!= null) ? DateTime.ParseExact(Detalle_Titulos_MedicosItem.Fecha_de_Expedicion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Cedula_Frente = Detalle_Titulos_MedicosItem.Cedula_FrenteInfo.FileId
                            ,Cedula_Reverso = Detalle_Titulos_MedicosItem.Cedula_ReversoInfo.FileId

                        };

                        var resultId = Detalle_Titulos_MedicosItem.Folio > 0
                           ? _IDetalle_Titulos_MedicosApiConsumer.Update(Detalle_Titulos_MedicosData,null,null).Resource
                           : _IDetalle_Titulos_MedicosApiConsumer.Insert(Detalle_Titulos_MedicosData,null,null).Resource;

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











        [NonAction]
        public bool CopyDetalle_Identificacion_Oficial_Medicos(int MasterId, int referenceId, List<Detalle_Identificacion_Oficial_MedicosGridModelPost> Detalle_Identificacion_Oficial_MedicosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Identificacion_Oficial_MedicosData = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Identificacion_Oficial_Medicos.Folio_Medico=" + referenceId,"").Resource;
                if (Detalle_Identificacion_Oficial_MedicosData == null || Detalle_Identificacion_Oficial_MedicosData.Detalle_Identificacion_Oficial_Medicoss.Count == 0)
                    return true;

                var result = true;

                Detalle_Identificacion_Oficial_MedicosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Identificacion_Oficial_Medicos in Detalle_Identificacion_Oficial_MedicosData.Detalle_Identificacion_Oficial_Medicoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Identificacion_Oficial_Medicos Detalle_Identificacion_Oficial_Medicos1 = varDetalle_Identificacion_Oficial_Medicos;

                    if (Detalle_Identificacion_Oficial_MedicosItems != null && Detalle_Identificacion_Oficial_MedicosItems.Any(m => m.Folio == Detalle_Identificacion_Oficial_Medicos1.Folio))
                    {
                        modelDataToChange = Detalle_Identificacion_Oficial_MedicosItems.FirstOrDefault(m => m.Folio == Detalle_Identificacion_Oficial_Medicos1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Identificacion_Oficial_Medicos.Folio_Medico = MasterId;
                    var insertId = _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Insert(varDetalle_Identificacion_Oficial_Medicos,null,null).Resource;
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
        public ActionResult PostDetalle_Identificacion_Oficial_Medicos(List<Detalle_Identificacion_Oficial_MedicosGridModelPost> Detalle_Identificacion_Oficial_MedicosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Identificacion_Oficial_Medicos(MasterId, referenceId, Detalle_Identificacion_Oficial_MedicosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Identificacion_Oficial_MedicosItems != null && Detalle_Identificacion_Oficial_MedicosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Identificacion_Oficial_MedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Identificacion_Oficial_MedicosItem in Detalle_Identificacion_Oficial_MedicosItems)
                    {


                        #region DocumentoInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.Control != null && !Detalle_Identificacion_Oficial_MedicosItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.Control);
                            Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Identificacion_Oficial_MedicosItem.Removed && Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.RemoveFile)
                        {
                            Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.FileId = 0;
                        }
                        #endregion DocumentoInfo

                        //Removal Request
                        if (Detalle_Identificacion_Oficial_MedicosItem.Removed)
                        {
                            result = result && _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Delete(Detalle_Identificacion_Oficial_MedicosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Identificacion_Oficial_MedicosItem.Folio = 0;

                        var Detalle_Identificacion_Oficial_MedicosData = new Detalle_Identificacion_Oficial_Medicos
                        {
                            Folio_Medico = MasterId
                            ,Folio = Detalle_Identificacion_Oficial_MedicosItem.Folio
                            ,Tipo_de_Identificacion_Oficial = (Convert.ToInt32(Detalle_Identificacion_Oficial_MedicosItem.Tipo_de_Identificacion_Oficial) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Identificacion_Oficial_MedicosItem.Tipo_de_Identificacion_Oficial))
                            ,Documento = Detalle_Identificacion_Oficial_MedicosItem.DocumentoInfo.FileId

                        };

                        var resultId = Detalle_Identificacion_Oficial_MedicosItem.Folio > 0
                           ? _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Update(Detalle_Identificacion_Oficial_MedicosData,null,null).Resource
                           : _IDetalle_Identificacion_Oficial_MedicosApiConsumer.Insert(Detalle_Identificacion_Oficial_MedicosData,null,null).Resource;

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
        public ActionResult GetDetalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIdentificaciones_OficialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIdentificaciones_OficialesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Identificaciones_Oficiales", "Descripcion");
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
        public bool CopyDetalle_Codigos_Referidos(int MasterId, int referenceId, List<Detalle_Codigos_ReferidosGridModelPost> Detalle_Codigos_ReferidosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Codigos_ReferidosData = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Codigos_Referidos.Folio_Medicos=" + referenceId,"").Resource;
                if (Detalle_Codigos_ReferidosData == null || Detalle_Codigos_ReferidosData.Detalle_Codigos_Referidoss.Count == 0)
                    return true;

                var result = true;

                Detalle_Codigos_ReferidosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Codigos_Referidos in Detalle_Codigos_ReferidosData.Detalle_Codigos_Referidoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Codigos_Referidos Detalle_Codigos_Referidos1 = varDetalle_Codigos_Referidos;

                    if (Detalle_Codigos_ReferidosItems != null && Detalle_Codigos_ReferidosItems.Any(m => m.Folio == Detalle_Codigos_Referidos1.Folio))
                    {
                        modelDataToChange = Detalle_Codigos_ReferidosItems.FirstOrDefault(m => m.Folio == Detalle_Codigos_Referidos1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Codigos_Referidos.Folio_Medicos = MasterId;
                    var insertId = _IDetalle_Codigos_ReferidosApiConsumer.Insert(varDetalle_Codigos_Referidos,null,null).Resource;
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
        public ActionResult PostDetalle_Codigos_Referidos(List<Detalle_Codigos_ReferidosGridModelPost> Detalle_Codigos_ReferidosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Codigos_Referidos(MasterId, referenceId, Detalle_Codigos_ReferidosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Codigos_ReferidosItems != null && Detalle_Codigos_ReferidosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Codigos_ReferidosItem in Detalle_Codigos_ReferidosItems)
                    {













                        //Removal Request
                        if (Detalle_Codigos_ReferidosItem.Removed)
                        {
                            result = result && _IDetalle_Codigos_ReferidosApiConsumer.Delete(Detalle_Codigos_ReferidosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Codigos_ReferidosItem.Folio = 0;

                        var Detalle_Codigos_ReferidosData = new Detalle_Codigos_Referidos
                        {
                            Folio_Medicos = MasterId
                            ,Folio = Detalle_Codigos_ReferidosItem.Folio

                            ,Porcentaje_de_descuento = Detalle_Codigos_ReferidosItem.Porcentaje_de_descuento
                            ,Fecha_inicio_vigencia = (Detalle_Codigos_ReferidosItem.Fecha_inicio_vigencia!= null) ? DateTime.ParseExact(Detalle_Codigos_ReferidosItem.Fecha_inicio_vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_fin_vigencia = (Detalle_Codigos_ReferidosItem.Fecha_fin_vigencia!= null) ? DateTime.ParseExact(Detalle_Codigos_ReferidosItem.Fecha_fin_vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Cantidad_maxima_de_referenciados = Detalle_Codigos_ReferidosItem.Cantidad_maxima_de_referenciados
                            ,Codigo_para_Referenciados = Detalle_Codigos_ReferidosItem.Codigo_para_Referenciados
                            ,Autorizado = Detalle_Codigos_ReferidosItem.Autorizado
                            ,Usuario_que_autoriza = (Convert.ToInt32(Detalle_Codigos_ReferidosItem.Usuario_que_autoriza) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Codigos_ReferidosItem.Usuario_que_autoriza))
                            ,Fecha_de_autorizacion = (Detalle_Codigos_ReferidosItem.Fecha_de_autorizacion!= null) ? DateTime.ParseExact(Detalle_Codigos_ReferidosItem.Fecha_de_autorizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Hora_de_autorizacion = Detalle_Codigos_ReferidosItem.Hora_de_autorizacion
                            ,Estatus = (Convert.ToInt32(Detalle_Codigos_ReferidosItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Codigos_ReferidosItem.Estatus))

                        };

                        var resultId = Detalle_Codigos_ReferidosItem.Folio > 0
                           ? _IDetalle_Codigos_ReferidosApiConsumer.Update(Detalle_Codigos_ReferidosData,null,null).Resource
                           : _IDetalle_Codigos_ReferidosApiConsumer.Insert(Detalle_Codigos_ReferidosData,null,null).Resource;

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
        public ActionResult GetDetalle_Codigos_Referidos_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Id_User), "Spartan_User", "Name");
                  item.Name= trans??item.Name;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult GetDetalle_Codigos_Referidos_EstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus", "Descripcion");
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
        public bool CopyDetalle_Planes_de_Suscripcion_Especialistas(int MasterId, int referenceId, List<Detalle_Planes_de_Suscripcion_EspecialistasGridModelPost> Detalle_Planes_de_Suscripcion_EspecialistasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Planes_de_Suscripcion_EspecialistasData = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas=" + referenceId,"").Resource;
                if (Detalle_Planes_de_Suscripcion_EspecialistasData == null || Detalle_Planes_de_Suscripcion_EspecialistasData.Detalle_Planes_de_Suscripcion_Especialistass.Count == 0)
                    return true;

                var result = true;

                Detalle_Planes_de_Suscripcion_EspecialistasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Planes_de_Suscripcion_Especialistas in Detalle_Planes_de_Suscripcion_EspecialistasData.Detalle_Planes_de_Suscripcion_Especialistass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Planes_de_Suscripcion_Especialistas Detalle_Planes_de_Suscripcion_Especialistas1 = varDetalle_Planes_de_Suscripcion_Especialistas;

                    if (Detalle_Planes_de_Suscripcion_EspecialistasItems != null && Detalle_Planes_de_Suscripcion_EspecialistasItems.Any(m => m.Folio == Detalle_Planes_de_Suscripcion_Especialistas1.Folio))
                    {
                        modelDataToChange = Detalle_Planes_de_Suscripcion_EspecialistasItems.FirstOrDefault(m => m.Folio == Detalle_Planes_de_Suscripcion_Especialistas1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Planes_de_Suscripcion_Especialistas.Folio_Especialistas = MasterId;
                    var insertId = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Insert(varDetalle_Planes_de_Suscripcion_Especialistas,null,null).Resource;
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
        public ActionResult PostDetalle_Planes_de_Suscripcion_Especialistas(List<Detalle_Planes_de_Suscripcion_EspecialistasGridModelPost> Detalle_Planes_de_Suscripcion_EspecialistasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Planes_de_Suscripcion_Especialistas(MasterId, referenceId, Detalle_Planes_de_Suscripcion_EspecialistasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Planes_de_Suscripcion_EspecialistasItems != null && Detalle_Planes_de_Suscripcion_EspecialistasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Planes_de_Suscripcion_EspecialistasItem in Detalle_Planes_de_Suscripcion_EspecialistasItems)
                    {





                        #region ContratoInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.Control != null && !Detalle_Planes_de_Suscripcion_EspecialistasItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.Control);
                            Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Planes_de_Suscripcion_EspecialistasItem.Removed && Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.RemoveFile)
                        {
                            Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.FileId = 0;
                        }
                        #endregion ContratoInfo



                        //Removal Request
                        if (Detalle_Planes_de_Suscripcion_EspecialistasItem.Removed)
                        {
                            result = result && _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Delete(Detalle_Planes_de_Suscripcion_EspecialistasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Planes_de_Suscripcion_EspecialistasItem.Folio = 0;

                        var Detalle_Planes_de_Suscripcion_EspecialistasData = new Detalle_Planes_de_Suscripcion_Especialistas
                        {
                            Folio_Especialistas = MasterId
                            ,Folio = Detalle_Planes_de_Suscripcion_EspecialistasItem.Folio
                            ,Plan_de_Suscripcion = (Convert.ToInt32(Detalle_Planes_de_Suscripcion_EspecialistasItem.Plan_de_Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Planes_de_Suscripcion_EspecialistasItem.Plan_de_Suscripcion))
                            ,Fecha_de_inicio = (Detalle_Planes_de_Suscripcion_EspecialistasItem.Fecha_de_inicio!= null) ? DateTime.ParseExact(Detalle_Planes_de_Suscripcion_EspecialistasItem.Fecha_de_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_fin = (Detalle_Planes_de_Suscripcion_EspecialistasItem.Fecha_fin!= null) ? DateTime.ParseExact(Detalle_Planes_de_Suscripcion_EspecialistasItem.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Costo = Detalle_Planes_de_Suscripcion_EspecialistasItem.Costo
                            ,Contrato = Detalle_Planes_de_Suscripcion_EspecialistasItem.ContratoInfo.FileId
                            ,Firmo_Contrato = Detalle_Planes_de_Suscripcion_EspecialistasItem.Firmo_Contrato
                            ,Estatus = (Convert.ToInt32(Detalle_Planes_de_Suscripcion_EspecialistasItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Planes_de_Suscripcion_EspecialistasItem.Estatus))

                        };

                        var resultId = Detalle_Planes_de_Suscripcion_EspecialistasItem.Folio > 0
                           ? _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Update(Detalle_Planes_de_Suscripcion_EspecialistasData,null,null).Resource
                           : _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Insert(Detalle_Planes_de_Suscripcion_EspecialistasData,null,null).Resource;

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
        public ActionResult GetDetalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion_Especialistas", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





        [HttpGet]
        public ActionResult GetDetalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_de_Suscripcion", "Descripcion");
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
        public bool CopyDetalle_Facturacion_Especialistas(int MasterId, int referenceId, List<Detalle_Facturacion_EspecialistasGridModelPost> Detalle_Facturacion_EspecialistasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Facturacion_EspecialistasData = _IDetalle_Facturacion_EspecialistasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Facturacion_Especialistas.Folio_Especialistas=" + referenceId,"").Resource;
                if (Detalle_Facturacion_EspecialistasData == null || Detalle_Facturacion_EspecialistasData.Detalle_Facturacion_Especialistass.Count == 0)
                    return true;

                var result = true;

                Detalle_Facturacion_EspecialistasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Facturacion_Especialistas in Detalle_Facturacion_EspecialistasData.Detalle_Facturacion_Especialistass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Facturacion_Especialistas Detalle_Facturacion_Especialistas1 = varDetalle_Facturacion_Especialistas;

                    if (Detalle_Facturacion_EspecialistasItems != null && Detalle_Facturacion_EspecialistasItems.Any(m => m.Folio == Detalle_Facturacion_Especialistas1.Folio))
                    {
                        modelDataToChange = Detalle_Facturacion_EspecialistasItems.FirstOrDefault(m => m.Folio == Detalle_Facturacion_Especialistas1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Facturacion_Especialistas.Folio_Especialistas = MasterId;
                    var insertId = _IDetalle_Facturacion_EspecialistasApiConsumer.Insert(varDetalle_Facturacion_Especialistas,null,null).Resource;
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
        public ActionResult PostDetalle_Facturacion_Especialistas(List<Detalle_Facturacion_EspecialistasGridModelPost> Detalle_Facturacion_EspecialistasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Facturacion_Especialistas(MasterId, referenceId, Detalle_Facturacion_EspecialistasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Facturacion_EspecialistasItems != null && Detalle_Facturacion_EspecialistasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Facturacion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Facturacion_EspecialistasItem in Detalle_Facturacion_EspecialistasItems)
                    {





                        #region Archivo_XMLInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.Control != null && !Detalle_Facturacion_EspecialistasItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.Control);
                            Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Facturacion_EspecialistasItem.Removed && Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.RemoveFile)
                        {
                            Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.FileId = 0;
                        }
                        #endregion Archivo_XMLInfo
                        #region Archivo_PDFInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.Control != null && !Detalle_Facturacion_EspecialistasItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.Control);
                            Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Facturacion_EspecialistasItem.Removed && Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.RemoveFile)
                        {
                            Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.FileId = 0;
                        }
                        #endregion Archivo_PDFInfo





                        //Removal Request
                        if (Detalle_Facturacion_EspecialistasItem.Removed)
                        {
                            result = result && _IDetalle_Facturacion_EspecialistasApiConsumer.Delete(Detalle_Facturacion_EspecialistasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Facturacion_EspecialistasItem.Folio = 0;

                        var Detalle_Facturacion_EspecialistasData = new Detalle_Facturacion_Especialistas
                        {
                            Folio_Especialistas = MasterId
                            ,Folio = Detalle_Facturacion_EspecialistasItem.Folio
                            ,Fecha_de_Registro = (Detalle_Facturacion_EspecialistasItem.Fecha_de_Registro!= null) ? DateTime.ParseExact(Detalle_Facturacion_EspecialistasItem.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Folio_Factura = Detalle_Facturacion_EspecialistasItem.Folio_Factura
                            ,Periodo_Facturado = Detalle_Facturacion_EspecialistasItem.Periodo_Facturado
                            ,Cantidad = Detalle_Facturacion_EspecialistasItem.Cantidad
                            ,Archivo_XML = Detalle_Facturacion_EspecialistasItem.Archivo_XMLInfo.FileId
                            ,Archivo_PDF = Detalle_Facturacion_EspecialistasItem.Archivo_PDFInfo.FileId
                            ,Estatus = Detalle_Facturacion_EspecialistasItem.Estatus
                            ,Fecha_programada_de_Pago = (Detalle_Facturacion_EspecialistasItem.Fecha_programada_de_Pago!= null) ? DateTime.ParseExact(Detalle_Facturacion_EspecialistasItem.Fecha_programada_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Pagada = Detalle_Facturacion_EspecialistasItem.Pagada
                            ,Fecha_de_pago = (Detalle_Facturacion_EspecialistasItem.Fecha_de_pago!= null) ? DateTime.ParseExact(Detalle_Facturacion_EspecialistasItem.Fecha_de_pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                        };

                        var resultId = Detalle_Facturacion_EspecialistasItem.Folio > 0
                           ? _IDetalle_Facturacion_EspecialistasApiConsumer.Update(Detalle_Facturacion_EspecialistasData,null,null).Resource
                           : _IDetalle_Facturacion_EspecialistasApiConsumer.Insert(Detalle_Facturacion_EspecialistasData,null,null).Resource;

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















        /// <summary>
        /// Write Element Array of Medicos script
        /// </summary>
        /// <param name="oMedicosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew MedicosModuleAttributeList)
        {
            for (int i = 0; i < MedicosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MedicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MedicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MedicosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MedicosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MedicosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < MedicosModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(MedicosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							MedicosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(MedicosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							MedicosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strMedicosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Medicos.js")))
            {
                strMedicosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Medicos element attributes
            string userChangeJson = jsSerialize.Serialize(MedicosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMedicosScript.IndexOf("inpuElementArray");
            string splittedString = strMedicosScript.Substring(indexOfArray, strMedicosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MedicosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MedicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMedicosScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strMedicosScript.Substring(indexOfArrayHistory, strMedicosScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strMedicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMedicosScript.Substring(endIndexOfMainElement + indexOfArray, strMedicosScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (MedicosModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in MedicosModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Medicos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Medicos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Medicos.js")))
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
        public ActionResult MedicosPropertyBag()
        {
            return PartialView("MedicosPropertyBag", "Medicos");
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
        public ActionResult AddDetalle_Redes_Sociales_Especialista(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Redes_Sociales_Especialista/AddDetalle_Redes_Sociales_Especialista");
        }

        [HttpGet]
        public ActionResult AddDetalle_Convenio_Medicos_Aseguradoras(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Convenio_Medicos_Aseguradoras/AddDetalle_Convenio_Medicos_Aseguradoras");
        }

        [HttpGet]
        public ActionResult AddDetalle_Titulos_Medicos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Titulos_Medicos/AddDetalle_Titulos_Medicos");
        }

        [HttpGet]
        public ActionResult AddDetalle_Identificacion_Oficial_Medicos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Identificacion_Oficial_Medicos/AddDetalle_Identificacion_Oficial_Medicos");
        }

        [HttpGet]
        public ActionResult AddDetalle_Codigos_Referidos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Codigos_Referidos/AddDetalle_Codigos_Referidos");
        }

        [HttpGet]
        public ActionResult AddDetalle_Planes_de_Suscripcion_Especialistas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Planes_de_Suscripcion_Especialistas/AddDetalle_Planes_de_Suscripcion_Especialistas");
        }

        [HttpGet]
        public ActionResult AddDetalle_Facturacion_Especialistas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Facturacion_Especialistas/AddDetalle_Facturacion_Especialistas");
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
                var whereClauseFormat = "Object = 44379 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Medicos.Folio= " + RecordId;
                            var result = _IMedicosApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new MedicosPropertyMapper());
			
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
                    (MedicosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            MedicosPropertyMapper oMedicosPropertyMapper = new MedicosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oMedicosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Medicoss == null)
                result.Medicoss = new List<Medicos>();

            var data = result.Medicoss.Select(m => new MedicosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(m.Titulo_Personal_Titulos_Personales.Clave.ToString(), "Titulos_Personales") ?? (string)m.Titulo_Personal_Titulos_Personales.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Especialista_Tipos_de_Especialistas.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
			,Foto = m.Foto
			,Nombre_de_usuario = m.Nombre_de_usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email_institucional = m.Email_institucional
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(m.Email_ppal_publico_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Email_ppal_publico_Respuesta_Logica.Descripcion
			,Email_de_contacto = m.Email_de_contacto
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
			,Telefonos = m.Telefonos
                        ,En_HospitalDescripcion = CultureHelper.GetTraduction(m.En_Hospital_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.En_Hospital_Respuesta_Logica.Descripcion
			,Nombre_del_Hospital = m.Nombre_del_Hospital
			,Piso_hospital = m.Piso_hospital
			,Numero_de_consultorio = m.Numero_de_consultorio
                        ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(m.Se_ajusta_tabulador_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Se_ajusta_tabulador_Respuesta_Logica.Descripcion
                        ,ProfesionDescripcion = CultureHelper.GetTraduction(m.Profesion_Profesiones.Clave.ToString(), "Descripcion") ?? (string)m.Profesion_Profesiones.Descripcion
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Resumen_Profesional = m.Resumen_Profesional
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax
			,Cedula_Fiscal_Documento = m.Cedula_Fiscal_Documento
			,Comprobante_de_Domicilio = m.Comprobante_de_Domicilio
			,Calificacion_Red_de_Medicos = m.Calificacion_Red_de_Medicos
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44379, arrayColumnsVisible), "MedicosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44379, arrayColumnsVisible), "MedicosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44379, arrayColumnsVisible), "MedicosList_" + DateTime.Now.ToString());
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

            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new MedicosPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (MedicosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            MedicosPropertyMapper oMedicosPropertyMapper = new MedicosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oMedicosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMedicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Medicoss == null)
                result.Medicoss = new List<Medicos>();

            var data = result.Medicoss.Select(m => new MedicosGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(m.Titulo_Personal_Titulos_Personales.Clave.ToString(), "Titulos_Personales") ?? (string)m.Titulo_Personal_Titulos_Personales.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Especialista_Tipos_de_Especialistas.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
			,Foto = m.Foto
			,Nombre_de_usuario = m.Nombre_de_usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email_institucional = m.Email_institucional
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(m.Email_ppal_publico_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Email_ppal_publico_Respuesta_Logica.Descripcion
			,Email_de_contacto = m.Email_de_contacto
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
			,Telefonos = m.Telefonos
                        ,En_HospitalDescripcion = CultureHelper.GetTraduction(m.En_Hospital_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.En_Hospital_Respuesta_Logica.Descripcion
			,Nombre_del_Hospital = m.Nombre_del_Hospital
			,Piso_hospital = m.Piso_hospital
			,Numero_de_consultorio = m.Numero_de_consultorio
                        ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(m.Se_ajusta_tabulador_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Se_ajusta_tabulador_Respuesta_Logica.Descripcion
                        ,ProfesionDescripcion = CultureHelper.GetTraduction(m.Profesion_Profesiones.Clave.ToString(), "Descripcion") ?? (string)m.Profesion_Profesiones.Descripcion
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Resumen_Profesional = m.Resumen_Profesional
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax
			,Cedula_Fiscal_Documento = m.Cedula_Fiscal_Documento
			,Comprobante_de_Domicilio = m.Comprobante_de_Domicilio
			,Calificacion_Red_de_Medicos = m.Calificacion_Red_de_Medicos
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

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
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMedicosApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Medicos_Datos_GeneralesModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varMedicos.FotoRemoveAttachment != 0 && varMedicos.FotoFile == null)
                    {
                        varMedicos.Foto = 0;
                    }

                    if (varMedicos.FotoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varMedicos.FotoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varMedicos.Foto = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varMedicos.FotoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Medicos_Datos_GeneralesInfo = new Medicos_Datos_Generales
                {
                    Folio = varMedicos.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varMedicos.Fecha_de_Registro)) ? DateTime.ParseExact(varMedicos.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varMedicos.Hora_de_Registro
                        ,Usuario_que_Registra = varMedicos.Usuario_que_Registra
                        ,Titulo_Personal = varMedicos.Titulo_Personal
                        ,Nombres = varMedicos.Nombres
                        ,Apellido_Paterno = varMedicos.Apellido_Paterno
                        ,Apellido_Materno = varMedicos.Apellido_Materno
                        ,Nombre_Completo = varMedicos.Nombre_Completo
                        ,Tipo_de_Especialista = varMedicos.Tipo_de_Especialista
                        ,Foto = (varMedicos.Foto.HasValue && varMedicos.Foto != 0) ? ((int?)Convert.ToInt32(varMedicos.Foto.Value)) : null

                        ,Nombre_de_usuario = varMedicos.Nombre_de_usuario
                        ,Usuario_Registrado = varMedicos.Usuario_Registrado
                        ,Email = varMedicos.Email
                        ,Celular = varMedicos.Celular
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varMedicos.Fecha_de_nacimiento)) ? DateTime.ParseExact(varMedicos.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pais_de_nacimiento = varMedicos.Pais_de_nacimiento
                        ,Entidad_de_nacimiento = varMedicos.Entidad_de_nacimiento
                        ,Sexo = varMedicos.Sexo
                        ,Email_institucional = varMedicos.Email_institucional
                        ,Estatus = varMedicos.Estatus
                    
                };

                result = _IMedicosApiConsumer.Update_Datos_Generales(Medicos_Datos_GeneralesInfo).Resource.ToString();
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
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Titulo_Personal = m.Titulo_Personal
                        ,Titulo_PersonalDescripcion = CultureHelper.GetTraduction(m.Titulo_Personal_Titulos_Personales.Clave.ToString(), "Titulos_Personales") ?? (string)m.Titulo_Personal_Titulos_Personales.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Tipo_de_Especialista = m.Tipo_de_Especialista
                        ,Tipo_de_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Especialista_Tipos_de_Especialistas.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Especialista_Tipos_de_Especialistas.Descripcion
			,Foto = m.Foto
			,Nombre_de_usuario = m.Nombre_de_usuario
                        ,Usuario_Registrado = m.Usuario_Registrado
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimiento = m.Pais_de_nacimiento
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimiento = m.Entidad_de_nacimiento
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email_institucional = m.Email_institucional
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_de_Contacto(Medicos_Datos_de_ContactoModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_Datos_de_ContactoInfo = new Medicos_Datos_de_Contacto
                {
                    Folio = varMedicos.Folio
                                            ,Email_ppal_publico = varMedicos.Email_ppal_publico
                        ,Email_de_contacto = varMedicos.Email_de_contacto
                        ,Calle = varMedicos.Calle
                        ,Numero_exterior = varMedicos.Numero_exterior
                        ,Numero_interior = varMedicos.Numero_interior
                        ,Colonia = varMedicos.Colonia
                        ,CP = varMedicos.CP
                        ,Ciudad = varMedicos.Ciudad
                        ,Estado = varMedicos.Estado
                        ,Pais = varMedicos.Pais
                        ,Telefonos = varMedicos.Telefonos
                        ,En_Hospital = varMedicos.En_Hospital
                        ,Nombre_del_Hospital = varMedicos.Nombre_del_Hospital
                        ,Piso_hospital = varMedicos.Piso_hospital
                        ,Numero_de_consultorio = varMedicos.Numero_de_consultorio
                        ,Se_ajusta_tabulador = varMedicos.Se_ajusta_tabulador
                    
                };

                result = _IMedicosApiConsumer.Update_Datos_de_Contacto(Medicos_Datos_de_ContactoInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_de_Contacto(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Datos_de_Contacto(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Datos_de_ContactoModel
                {
                    Folio = m.Folio
                        ,Email_ppal_publico = m.Email_ppal_publico
                        ,Email_ppal_publicoDescripcion = CultureHelper.GetTraduction(m.Email_ppal_publico_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Email_ppal_publico_Respuesta_Logica.Descripcion
			,Email_de_contacto = m.Email_de_contacto
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,Estado = m.Estado
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,Pais = m.Pais
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
			,Telefonos = m.Telefonos
                        ,En_Hospital = m.En_Hospital
                        ,En_HospitalDescripcion = CultureHelper.GetTraduction(m.En_Hospital_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.En_Hospital_Respuesta_Logica.Descripcion
			,Nombre_del_Hospital = m.Nombre_del_Hospital
			,Piso_hospital = m.Piso_hospital
			,Numero_de_consultorio = m.Numero_de_consultorio
                        ,Se_ajusta_tabulador = m.Se_ajusta_tabulador
                        ,Se_ajusta_tabuladorDescripcion = CultureHelper.GetTraduction(m.Se_ajusta_tabulador_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Se_ajusta_tabulador_Respuesta_Logica.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Profesionales(Medicos_Datos_ProfesionalesModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_Datos_ProfesionalesInfo = new Medicos_Datos_Profesionales
                {
                    Folio = varMedicos.Folio
                                            ,Profesion = varMedicos.Profesion
                        ,Especialidad = varMedicos.Especialidad
                        ,Resumen_Profesional = varMedicos.Resumen_Profesional
                    
                };

                result = _IMedicosApiConsumer.Update_Datos_Profesionales(Medicos_Datos_ProfesionalesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Profesionales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Datos_Profesionales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Datos_ProfesionalesModel
                {
                    Folio = m.Folio
                        ,Profesion = m.Profesion
                        ,ProfesionDescripcion = CultureHelper.GetTraduction(m.Profesion_Profesiones.Clave.ToString(), "Descripcion") ?? (string)m.Profesion_Profesiones.Descripcion
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Resumen_Profesional = m.Resumen_Profesional

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Fiscales(Medicos_Datos_FiscalesModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_Datos_FiscalesInfo = new Medicos_Datos_Fiscales
                {
                    Folio = varMedicos.Folio
                                            ,Regimen_Fiscal = varMedicos.Regimen_Fiscal
                        ,Nombre_o_Razon_Social = varMedicos.Nombre_o_Razon_Social
                        ,RFC = varMedicos.RFC
                        ,Calle_Fiscal = varMedicos.Calle_Fiscal
                        ,Numero_exterior_Fiscal = varMedicos.Numero_exterior_Fiscal
                        ,Numero_interior_Fiscal = varMedicos.Numero_interior_Fiscal
                        ,Colonia_Fiscal = varMedicos.Colonia_Fiscal
                        ,CP_Fiscal = varMedicos.CP_Fiscal
                        ,Ciudad_Fiscal = varMedicos.Ciudad_Fiscal
                        ,Estado_Fiscal = varMedicos.Estado_Fiscal
                        ,Pais_Fiscal = varMedicos.Pais_Fiscal
                        ,Telefono = varMedicos.Telefono
                        ,Fax = varMedicos.Fax
                    
                };

                result = _IMedicosApiConsumer.Update_Datos_Fiscales(Medicos_Datos_FiscalesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Fiscales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Datos_Fiscales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Datos_FiscalesModel
                {
                    Folio = m.Folio
                        ,Regimen_Fiscal = m.Regimen_Fiscal
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_Fiscal = m.Estado_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_Fiscal = m.Pais_Fiscal
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Documentacion(Medicos_DocumentacionModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varMedicos.Cedula_Fiscal_DocumentoRemoveAttachment != 0 && varMedicos.Cedula_Fiscal_DocumentoFile == null)
                    {
                        varMedicos.Cedula_Fiscal_Documento = 0;
                    }

                    if (varMedicos.Cedula_Fiscal_DocumentoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varMedicos.Cedula_Fiscal_DocumentoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varMedicos.Cedula_Fiscal_Documento = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varMedicos.Cedula_Fiscal_DocumentoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varMedicos.Comprobante_de_DomicilioRemoveAttachment != 0 && varMedicos.Comprobante_de_DomicilioFile == null)
                    {
                        varMedicos.Comprobante_de_Domicilio = 0;
                    }

                    if (varMedicos.Comprobante_de_DomicilioFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varMedicos.Comprobante_de_DomicilioFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varMedicos.Comprobante_de_Domicilio = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varMedicos.Comprobante_de_DomicilioFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Medicos_DocumentacionInfo = new Medicos_Documentacion
                {
                    Folio = varMedicos.Folio
                                            ,Cedula_Fiscal_Documento = (varMedicos.Cedula_Fiscal_Documento.HasValue && varMedicos.Cedula_Fiscal_Documento != 0) ? ((int?)Convert.ToInt32(varMedicos.Cedula_Fiscal_Documento.Value)) : null

                        ,Comprobante_de_Domicilio = (varMedicos.Comprobante_de_Domicilio.HasValue && varMedicos.Comprobante_de_Domicilio != 0) ? ((int?)Convert.ToInt32(varMedicos.Comprobante_de_Domicilio.Value)) : null

                    
                };

                result = _IMedicosApiConsumer.Update_Documentacion(Medicos_DocumentacionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Documentacion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Documentacion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_DocumentacionModel
                {
                    Folio = m.Folio
			,Cedula_Fiscal_Documento = m.Cedula_Fiscal_Documento
			,Comprobante_de_Domicilio = m.Comprobante_de_Domicilio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Codigos_de_Referencia(Medicos_Codigos_de_ReferenciaModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_Codigos_de_ReferenciaInfo = new Medicos_Codigos_de_Referencia
                {
                    Folio = varMedicos.Folio
                                        
                };

                result = _IMedicosApiConsumer.Update_Codigos_de_Referencia(Medicos_Codigos_de_ReferenciaInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Codigos_de_Referencia(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Codigos_de_Referencia(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Codigos_de_ReferenciaModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Suscripcion_Red_de_Especialistas(Medicos_Suscripcion_Red_de_EspecialistasModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_Suscripcion_Red_de_EspecialistasInfo = new Medicos_Suscripcion_Red_de_Especialistas
                {
                    Folio = varMedicos.Folio
                                            ,Calificacion_Red_de_Medicos = varMedicos.Calificacion_Red_de_Medicos
                    
                };

                result = _IMedicosApiConsumer.Update_Suscripcion_Red_de_Especialistas(Medicos_Suscripcion_Red_de_EspecialistasInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Suscripcion_Red_de_Especialistas(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Suscripcion_Red_de_Especialistas(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Suscripcion_Red_de_EspecialistasModel
                {
                    Folio = m.Folio
			,Calificacion_Red_de_Medicos = m.Calificacion_Red_de_Medicos

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Bancarios(Medicos_Datos_BancariosModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_Datos_BancariosInfo = new Medicos_Datos_Bancarios
                {
                    Folio = varMedicos.Folio
                                            ,Banco = varMedicos.Banco
                        ,CLABE_Interbancaria = varMedicos.CLABE_Interbancaria
                        ,Numero_de_Cuenta = varMedicos.Numero_de_Cuenta
                        ,Nombre_del_Titular = varMedicos.Nombre_del_Titular
                    
                };

                result = _IMedicosApiConsumer.Update_Datos_Bancarios(Medicos_Datos_BancariosInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Bancarios(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Datos_Bancarios(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_Datos_BancariosModel
                {
                    Folio = m.Folio
                        ,Banco = m.Banco
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Facturacion(Medicos_FacturacionModel varMedicos)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Medicos_FacturacionInfo = new Medicos_Facturacion
                {
                    Folio = varMedicos.Folio
                                        
                };

                result = _IMedicosApiConsumer.Update_Facturacion(Medicos_FacturacionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Facturacion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMedicosApiConsumer.Get_Facturacion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Redes_Sociales_Especialista;
                var Detalle_Redes_Sociales_EspecialistaData = GetDetalle_Redes_Sociales_EspecialistaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Redes_Sociales_Especialista);
                int RowCount_Detalle_Convenio_Medicos_Aseguradoras;
                var Detalle_Convenio_Medicos_AseguradorasData = GetDetalle_Convenio_Medicos_AseguradorasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Convenio_Medicos_Aseguradoras);
                int RowCount_Detalle_Titulos_Medicos;
                var Detalle_Titulos_MedicosData = GetDetalle_Titulos_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Titulos_Medicos);
                int RowCount_Detalle_Identificacion_Oficial_Medicos;
                var Detalle_Identificacion_Oficial_MedicosData = GetDetalle_Identificacion_Oficial_MedicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Identificacion_Oficial_Medicos);
                int RowCount_Detalle_Codigos_Referidos;
                var Detalle_Codigos_ReferidosData = GetDetalle_Codigos_ReferidosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_Referidos);
                int RowCount_Detalle_Planes_de_Suscripcion_Especialistas;
                var Detalle_Planes_de_Suscripcion_EspecialistasData = GetDetalle_Planes_de_Suscripcion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Planes_de_Suscripcion_Especialistas);
                int RowCount_Detalle_Facturacion_Especialistas;
                var Detalle_Facturacion_EspecialistasData = GetDetalle_Facturacion_EspecialistasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Especialistas);

                var result = new Medicos_FacturacionModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Redes_sociales = Detalle_Redes_Sociales_EspecialistaData
                    ,Aseguradoras_con_convenio = Detalle_Convenio_Medicos_AseguradorasData
                    ,Titulos = Detalle_Titulos_MedicosData
                    ,Identificacion_Oficial = Detalle_Identificacion_Oficial_MedicosData
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_ReferidosData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Planes_de_Suscripcion_EspecialistasData
                    ,Facturas = Detalle_Facturacion_EspecialistasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

