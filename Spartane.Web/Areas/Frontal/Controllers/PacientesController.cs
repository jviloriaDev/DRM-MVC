using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_Registro;
using Spartane.Core.Domain.Tipo_Paciente;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estado_Civil;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Objetivos;
using Spartane.Core.Domain.Estatus_por_Suscripcion;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Detalle_de_Padecimientos;

using Spartane.Core.Domain.Padecimientos;
using Spartane.Core.Domain.Tiempo_Padecimiento;
using Spartane.Core.Domain.Respuesta_Logica;

using Spartane.Core.Domain.Estatus_Padecimiento;

using Spartane.Core.Domain.Detalle_Antecedentes_Familiares;

using Spartane.Core.Domain.Padecimientos;
using Spartane.Core.Domain.Parentesco;

using Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos;

using Spartane.Core.Domain.Sustancias;
using Spartane.Core.Domain.Frecuencia_Sustancias;


using Spartane.Core.Domain.Detalle_Examenes_Laboratorio;

using Spartane.Core.Domain.Indicadores_Laboratorio;






using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Detalle_Terapia_Hormonal;




using Spartane.Core.Domain.Tipo_de_Dieta;
using Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente;

using Spartane.Core.Domain.Ingredientes;

using Spartane.Core.Domain.Detalle_Preferencia_Bebidas;

using Spartane.Core.Domain.Bebidas;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;

using Spartane.Core.Domain.Suplementos;
using Spartane.Core.Domain.Preferencias_Sal;
using Spartane.Core.Domain.Preferencias_Grasas;
using Spartane.Core.Domain.Cantidad_Comidas;
using Spartane.Core.Domain.Preferencias_Preparacion;
using Spartane.Core.Domain.Preferencias_Entrecomidas;
using Spartane.Core.Domain.Nivel_de_Satisfaccion;
using Spartane.Core.Domain.Tipo_Modificacion_Alimentos;
using Spartane.Core.Domain.Periodo_del_dia;
using Spartane.Core.Domain.Estado_de_Animo;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Frecuencia_Ejercicio;
using Spartane.Core.Domain.Duracion_Ejercicio;
using Spartane.Core.Domain.Tipo_Ejercicio;
using Spartane.Core.Domain.Antiguedad_Ejercicios;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_corporal;
using Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Core.Domain.Interpretacion_Calorias;
using Spartane.Core.Domain.Detalle_Pagos_Paciente;

using Spartane.Core.Domain.Planes_de_Suscripcion;


using Spartane.Core.Domain.Formas_de_Pago;

using Spartane.Core.Domain.Estatus_de_Pago;

using Spartane.Core.Domain.Detalle_Suscripciones_Paciente;

using Spartane.Core.Domain.Planes_de_Suscripcion;




using Spartane.Core.Domain.Estatus_de_Suscripcion;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Pacientes;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Registro;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Empresas;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Estado_Civil;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Objetivos;
using Spartane.Web.Areas.WebApiConsumer.Estatus_por_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Padecimientos;

using Spartane.Web.Areas.WebApiConsumer.Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Tiempo_Padecimiento;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Padecimiento;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Antecedentes_Familiares;

using Spartane.Web.Areas.WebApiConsumer.Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Parentesco;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Antecedentes_No_Patologicos;

using Spartane.Web.Areas.WebApiConsumer.Sustancias;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_Sustancias;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Examenes_Laboratorio;

using Spartane.Web.Areas.WebApiConsumer.Indicadores_Laboratorio;


using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Terapia_Hormonal;


using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Dieta;
using Spartane.Web.Areas.WebApiConsumer.MS_Exclusion_Ingredientes_Paciente;

using Spartane.Web.Areas.WebApiConsumer.Ingredientes;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Preferencia_Bebidas;

using Spartane.Web.Areas.WebApiConsumer.Bebidas;
using Spartane.Web.Areas.WebApiConsumer.Rango_Consumo_Bebidas;

using Spartane.Web.Areas.WebApiConsumer.Suplementos;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Sal;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Grasas;
using Spartane.Web.Areas.WebApiConsumer.Cantidad_Comidas;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Preparacion;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Entrecomidas;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_Satisfaccion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Modificacion_Alimentos;
using Spartane.Web.Areas.WebApiConsumer.Periodo_del_dia;
using Spartane.Web.Areas.WebApiConsumer.Estado_de_Animo;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Duracion_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Antiguedad_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_IMC;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_IMC;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_corporal;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_distribucion_grasa_corporal;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_indice_cintura__cadera;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_consumo_de_agua;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Calorias;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Paciente;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;


using Spartane.Web.Areas.WebApiConsumer.Formas_de_Pago;

using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Pago;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Paciente;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;



using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Suscripcion;


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
    public class PacientesController : Controller
    {
        #region "variable declaration"

        private IPacientesService service = null;
        private IPacientesApiConsumer _IPacientesApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITipo_de_RegistroApiConsumer _ITipo_de_RegistroApiConsumer;
        private ITipo_PacienteApiConsumer _ITipo_PacienteApiConsumer;
        private IEmpresasApiConsumer _IEmpresasApiConsumer;
        private IPaisApiConsumer _IPaisApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IEstado_CivilApiConsumer _IEstado_CivilApiConsumer;
        private IObjetivosApiConsumer _IObjetivosApiConsumer;
        private IEstatus_por_SuscripcionApiConsumer _IEstatus_por_SuscripcionApiConsumer;
        private IRespuesta_LogicaApiConsumer _IRespuesta_LogicaApiConsumer;
        private IDetalle_de_PadecimientosApiConsumer _IDetalle_de_PadecimientosApiConsumer;

        private IPadecimientosApiConsumer _IPadecimientosApiConsumer;
        private ITiempo_PadecimientoApiConsumer _ITiempo_PadecimientoApiConsumer;
        private IEstatus_PadecimientoApiConsumer _IEstatus_PadecimientoApiConsumer;

        private IDetalle_Antecedentes_FamiliaresApiConsumer _IDetalle_Antecedentes_FamiliaresApiConsumer;

        private IParentescoApiConsumer _IParentescoApiConsumer;

        private IDetalle_Antecedentes_No_PatologicosApiConsumer _IDetalle_Antecedentes_No_PatologicosApiConsumer;

        private ISustanciasApiConsumer _ISustanciasApiConsumer;
        private IFrecuencia_SustanciasApiConsumer _IFrecuencia_SustanciasApiConsumer;

        private IDetalle_Examenes_LaboratorioApiConsumer _IDetalle_Examenes_LaboratorioApiConsumer;

        private IIndicadores_LaboratorioApiConsumer _IIndicadores_LaboratorioApiConsumer;


        private IDetalle_Terapia_HormonalApiConsumer _IDetalle_Terapia_HormonalApiConsumer;


        private ITipo_de_DietaApiConsumer _ITipo_de_DietaApiConsumer;
        private IMS_Exclusion_Ingredientes_PacienteApiConsumer _IMS_Exclusion_Ingredientes_PacienteApiConsumer;

        private IIngredientesApiConsumer _IIngredientesApiConsumer;

        private IDetalle_Preferencia_BebidasApiConsumer _IDetalle_Preferencia_BebidasApiConsumer;

        private IBebidasApiConsumer _IBebidasApiConsumer;
        private IRango_Consumo_BebidasApiConsumer _IRango_Consumo_BebidasApiConsumer;

        private ISuplementosApiConsumer _ISuplementosApiConsumer;
        private IPreferencias_SalApiConsumer _IPreferencias_SalApiConsumer;
        private IPreferencias_GrasasApiConsumer _IPreferencias_GrasasApiConsumer;
        private ICantidad_ComidasApiConsumer _ICantidad_ComidasApiConsumer;
        private IPreferencias_PreparacionApiConsumer _IPreferencias_PreparacionApiConsumer;
        private IPreferencias_EntrecomidasApiConsumer _IPreferencias_EntrecomidasApiConsumer;
        private INivel_de_SatisfaccionApiConsumer _INivel_de_SatisfaccionApiConsumer;
        private ITipo_Modificacion_AlimentosApiConsumer _ITipo_Modificacion_AlimentosApiConsumer;
        private IPeriodo_del_diaApiConsumer _IPeriodo_del_diaApiConsumer;
        private IEstado_de_AnimoApiConsumer _IEstado_de_AnimoApiConsumer;
        private IFrecuencia_EjercicioApiConsumer _IFrecuencia_EjercicioApiConsumer;
        private IDuracion_EjercicioApiConsumer _IDuracion_EjercicioApiConsumer;
        private ITipo_EjercicioApiConsumer _ITipo_EjercicioApiConsumer;
        private IAntiguedad_EjerciciosApiConsumer _IAntiguedad_EjerciciosApiConsumer;
        private IInterpretacion_IMCApiConsumer _IInterpretacion_IMCApiConsumer;
        private IInterpretacion_corporalApiConsumer _IInterpretacion_corporalApiConsumer;
        private IInterpretacion_distribucion_grasa_corporalApiConsumer _IInterpretacion_distribucion_grasa_corporalApiConsumer;
        private IInterpretacion_indice_cintura__caderaApiConsumer _IInterpretacion_indice_cintura__caderaApiConsumer;
        private IInterpretacion_consumo_de_aguaApiConsumer _IInterpretacion_consumo_de_aguaApiConsumer;
        private IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer;
        private IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer;
        private IInterpretacion_CaloriasApiConsumer _IInterpretacion_CaloriasApiConsumer;
        private IDetalle_Pagos_PacienteApiConsumer _IDetalle_Pagos_PacienteApiConsumer;

        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;


        private IFormas_de_PagoApiConsumer _IFormas_de_PagoApiConsumer;

        private IEstatus_de_PagoApiConsumer _IEstatus_de_PagoApiConsumer;

        private IDetalle_Suscripciones_PacienteApiConsumer _IDetalle_Suscripciones_PacienteApiConsumer;




        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;


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

        
        public PacientesController(IPacientesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IPacientesApiConsumer PacientesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITipo_de_RegistroApiConsumer Tipo_de_RegistroApiConsumer , ITipo_PacienteApiConsumer Tipo_PacienteApiConsumer , IEmpresasApiConsumer EmpresasApiConsumer , IPaisApiConsumer PaisApiConsumer , IEstadoApiConsumer EstadoApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstado_CivilApiConsumer Estado_CivilApiConsumer , IObjetivosApiConsumer ObjetivosApiConsumer , IEstatus_por_SuscripcionApiConsumer Estatus_por_SuscripcionApiConsumer , IRespuesta_LogicaApiConsumer Respuesta_LogicaApiConsumer , IDetalle_de_PadecimientosApiConsumer Detalle_de_PadecimientosApiConsumer , IPadecimientosApiConsumer PadecimientosApiConsumer , ITiempo_PadecimientoApiConsumer Tiempo_PadecimientoApiConsumer , IEstatus_PadecimientoApiConsumer Estatus_PadecimientoApiConsumer  , IDetalle_Antecedentes_FamiliaresApiConsumer Detalle_Antecedentes_FamiliaresApiConsumer , IParentescoApiConsumer ParentescoApiConsumer  , IDetalle_Antecedentes_No_PatologicosApiConsumer Detalle_Antecedentes_No_PatologicosApiConsumer , ISustanciasApiConsumer SustanciasApiConsumer , IFrecuencia_SustanciasApiConsumer Frecuencia_SustanciasApiConsumer  , IDetalle_Examenes_LaboratorioApiConsumer Detalle_Examenes_LaboratorioApiConsumer , IIndicadores_LaboratorioApiConsumer Indicadores_LaboratorioApiConsumer  , IDetalle_Terapia_HormonalApiConsumer Detalle_Terapia_HormonalApiConsumer  , ITipo_de_DietaApiConsumer Tipo_de_DietaApiConsumer , IMS_Exclusion_Ingredientes_PacienteApiConsumer MS_Exclusion_Ingredientes_PacienteApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer  , IDetalle_Preferencia_BebidasApiConsumer Detalle_Preferencia_BebidasApiConsumer , IBebidasApiConsumer BebidasApiConsumer , IRango_Consumo_BebidasApiConsumer Rango_Consumo_BebidasApiConsumer  , ISuplementosApiConsumer SuplementosApiConsumer , IPreferencias_SalApiConsumer Preferencias_SalApiConsumer , IPreferencias_GrasasApiConsumer Preferencias_GrasasApiConsumer , ICantidad_ComidasApiConsumer Cantidad_ComidasApiConsumer , IPreferencias_PreparacionApiConsumer Preferencias_PreparacionApiConsumer , IPreferencias_EntrecomidasApiConsumer Preferencias_EntrecomidasApiConsumer , INivel_de_SatisfaccionApiConsumer Nivel_de_SatisfaccionApiConsumer , ITipo_Modificacion_AlimentosApiConsumer Tipo_Modificacion_AlimentosApiConsumer , IPeriodo_del_diaApiConsumer Periodo_del_diaApiConsumer , IEstado_de_AnimoApiConsumer Estado_de_AnimoApiConsumer , IFrecuencia_EjercicioApiConsumer Frecuencia_EjercicioApiConsumer , IDuracion_EjercicioApiConsumer Duracion_EjercicioApiConsumer , ITipo_EjercicioApiConsumer Tipo_EjercicioApiConsumer , IAntiguedad_EjerciciosApiConsumer Antiguedad_EjerciciosApiConsumer , IInterpretacion_IMCApiConsumer Interpretacion_IMCApiConsumer , IInterpretacion_corporalApiConsumer Interpretacion_corporalApiConsumer , IInterpretacion_distribucion_grasa_corporalApiConsumer Interpretacion_distribucion_grasa_corporalApiConsumer , IInterpretacion_indice_cintura__caderaApiConsumer Interpretacion_indice_cintura__caderaApiConsumer , IInterpretacion_consumo_de_aguaApiConsumer Interpretacion_consumo_de_aguaApiConsumer , IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer Interpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer , IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer Interpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer , IInterpretacion_CaloriasApiConsumer Interpretacion_CaloriasApiConsumer , IDetalle_Pagos_PacienteApiConsumer Detalle_Pagos_PacienteApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , IFormas_de_PagoApiConsumer Formas_de_PagoApiConsumer , IEstatus_de_PagoApiConsumer Estatus_de_PagoApiConsumer  , IDetalle_Suscripciones_PacienteApiConsumer Detalle_Suscripciones_PacienteApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IPacientesApiConsumer = PacientesApiConsumer;
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
            this._ITipo_de_RegistroApiConsumer = Tipo_de_RegistroApiConsumer;
            this._ITipo_PacienteApiConsumer = Tipo_PacienteApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEmpresasApiConsumer = EmpresasApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstado_CivilApiConsumer = Estado_CivilApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IObjetivosApiConsumer = ObjetivosApiConsumer;
            this._IEstatus_por_SuscripcionApiConsumer = Estatus_por_SuscripcionApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IDetalle_de_PadecimientosApiConsumer = Detalle_de_PadecimientosApiConsumer;

            this._IPadecimientosApiConsumer = PadecimientosApiConsumer;
            this._ITiempo_PadecimientoApiConsumer = Tiempo_PadecimientoApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IEstatus_PadecimientoApiConsumer = Estatus_PadecimientoApiConsumer;

            this._IDetalle_Antecedentes_FamiliaresApiConsumer = Detalle_Antecedentes_FamiliaresApiConsumer;

            this._IPadecimientosApiConsumer = PadecimientosApiConsumer;
            this._IParentescoApiConsumer = ParentescoApiConsumer;

            this._IDetalle_Antecedentes_No_PatologicosApiConsumer = Detalle_Antecedentes_No_PatologicosApiConsumer;

            this._ISustanciasApiConsumer = SustanciasApiConsumer;
            this._IFrecuencia_SustanciasApiConsumer = Frecuencia_SustanciasApiConsumer;

            this._IDetalle_Examenes_LaboratorioApiConsumer = Detalle_Examenes_LaboratorioApiConsumer;

            this._IIndicadores_LaboratorioApiConsumer = Indicadores_LaboratorioApiConsumer;


            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IDetalle_Terapia_HormonalApiConsumer = Detalle_Terapia_HormonalApiConsumer;


            this._ITipo_de_DietaApiConsumer = Tipo_de_DietaApiConsumer;
            this._IMS_Exclusion_Ingredientes_PacienteApiConsumer = MS_Exclusion_Ingredientes_PacienteApiConsumer;

            this._IIngredientesApiConsumer = IngredientesApiConsumer;

            this._IDetalle_Preferencia_BebidasApiConsumer = Detalle_Preferencia_BebidasApiConsumer;

            this._IBebidasApiConsumer = BebidasApiConsumer;
            this._IRango_Consumo_BebidasApiConsumer = Rango_Consumo_BebidasApiConsumer;

            this._ISuplementosApiConsumer = SuplementosApiConsumer;
            this._IPreferencias_SalApiConsumer = Preferencias_SalApiConsumer;
            this._IPreferencias_GrasasApiConsumer = Preferencias_GrasasApiConsumer;
            this._ICantidad_ComidasApiConsumer = Cantidad_ComidasApiConsumer;
            this._IPreferencias_PreparacionApiConsumer = Preferencias_PreparacionApiConsumer;
            this._IPreferencias_EntrecomidasApiConsumer = Preferencias_EntrecomidasApiConsumer;
            this._INivel_de_SatisfaccionApiConsumer = Nivel_de_SatisfaccionApiConsumer;
            this._ITipo_Modificacion_AlimentosApiConsumer = Tipo_Modificacion_AlimentosApiConsumer;
            this._IPeriodo_del_diaApiConsumer = Periodo_del_diaApiConsumer;
            this._IEstado_de_AnimoApiConsumer = Estado_de_AnimoApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IFrecuencia_EjercicioApiConsumer = Frecuencia_EjercicioApiConsumer;
            this._IDuracion_EjercicioApiConsumer = Duracion_EjercicioApiConsumer;
            this._ITipo_EjercicioApiConsumer = Tipo_EjercicioApiConsumer;
            this._IAntiguedad_EjerciciosApiConsumer = Antiguedad_EjerciciosApiConsumer;
            this._IInterpretacion_IMCApiConsumer = Interpretacion_IMCApiConsumer;
            this._IInterpretacion_IMCApiConsumer = Interpretacion_IMCApiConsumer;
            this._IInterpretacion_corporalApiConsumer = Interpretacion_corporalApiConsumer;
            this._IInterpretacion_distribucion_grasa_corporalApiConsumer = Interpretacion_distribucion_grasa_corporalApiConsumer;
            this._IInterpretacion_indice_cintura__caderaApiConsumer = Interpretacion_indice_cintura__caderaApiConsumer;
            this._IInterpretacion_consumo_de_aguaApiConsumer = Interpretacion_consumo_de_aguaApiConsumer;
            this._IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer = Interpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer;
            this._IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer = Interpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer;
            this._IInterpretacion_CaloriasApiConsumer = Interpretacion_CaloriasApiConsumer;
            this._IDetalle_Pagos_PacienteApiConsumer = Detalle_Pagos_PacienteApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;


            this._IFormas_de_PagoApiConsumer = Formas_de_PagoApiConsumer;

            this._IEstatus_de_PagoApiConsumer = Estatus_de_PagoApiConsumer;

            this._IDetalle_Suscripciones_PacienteApiConsumer = Detalle_Suscripciones_PacienteApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;



            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Pacientes
        [ObjectAuth(ObjectId = (ModuleObjectId)44337, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44337, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Pacientes/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44337, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44337, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varPacientes = new PacientesModel();
			varPacientes.Folio = Id;
			
            ViewBag.ObjectId = "44337";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_de_Padecimientos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44309, ModuleId);
            ViewBag.PermissionDetalle_de_Padecimientos = permissionDetalle_de_Padecimientos;
            var permissionDetalle_Antecedentes_Familiares = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44341, ModuleId);
            ViewBag.PermissionDetalle_Antecedentes_Familiares = permissionDetalle_Antecedentes_Familiares;
            var permissionDetalle_Antecedentes_No_Patologicos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44342, ModuleId);
            ViewBag.PermissionDetalle_Antecedentes_No_Patologicos = permissionDetalle_Antecedentes_No_Patologicos;
            var permissionDetalle_Examenes_Laboratorio = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44344, ModuleId);
            ViewBag.PermissionDetalle_Examenes_Laboratorio = permissionDetalle_Examenes_Laboratorio;
            var permissionDetalle_Terapia_Hormonal = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44345, ModuleId);
            ViewBag.PermissionDetalle_Terapia_Hormonal = permissionDetalle_Terapia_Hormonal;
            var permissionMS_Exclusion_Ingredientes_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44445, ModuleId);
            ViewBag.PermissionMS_Exclusion_Ingredientes_Paciente = permissionMS_Exclusion_Ingredientes_Paciente;
            var permissionDetalle_Preferencia_Bebidas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44336, ModuleId);
            ViewBag.PermissionDetalle_Preferencia_Bebidas = permissionDetalle_Preferencia_Bebidas;
            var permissionDetalle_Pagos_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44399, ModuleId);
            ViewBag.PermissionDetalle_Pagos_Paciente = permissionDetalle_Pagos_Paciente;
            var permissionDetalle_Suscripciones_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44398, ModuleId);
            ViewBag.PermissionDetalle_Suscripciones_Paciente = permissionDetalle_Suscripciones_Paciente;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var PacientessData = _IPacientesApiConsumer.ListaSelAll(0, 1000, "Pacientes.Folio=" + Id, "").Resource.Pacientess;
				
				if (PacientessData != null && PacientessData.Count > 0)
                {
					var PacientesData = PacientessData.First();
					varPacientes= new PacientesModel
					{
						Folio  = PacientesData.Folio 
	                    ,Fecha_de_Registro = (PacientesData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(PacientesData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = PacientesData.Hora_de_Registro
                    ,Usuario_que_Registra = PacientesData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Usuario_que_Registra), "Spartan_User") ??  (string)PacientesData.Usuario_que_Registra_Spartan_User.Name
                    ,Tipo_de_Registro = PacientesData.Tipo_de_Registro
                    ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_de_Registro), "Tipo_de_Registro") ??  (string)PacientesData.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                    ,Tipo_de_Paciente = PacientesData.Tipo_de_Paciente
                    ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_de_Paciente), "Tipo_Paciente") ??  (string)PacientesData.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                    ,Usuario_Registrado = PacientesData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Usuario_Registrado), "Spartan_User") ??  (string)PacientesData.Usuario_Registrado_Spartan_User.Name
                    ,Empresa = PacientesData.Empresa
                    ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Empresa), "Empresas") ??  (string)PacientesData.Empresa_Empresas.Nombre_de_la_Empresa
                    ,Numero_de_Empleado = PacientesData.Numero_de_Empleado
                    ,Nombres = PacientesData.Nombres
                    ,Apellido_Paterno = PacientesData.Apellido_Paterno
                    ,Apellido_Materno = PacientesData.Apellido_Materno
                    ,Nombre_Completo = PacientesData.Nombre_Completo
                    ,Celular = PacientesData.Celular
                    ,Email = PacientesData.Email
                    ,Fecha_de_nacimiento = (PacientesData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(PacientesData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Nombre_del_Padre_o_Tutor = PacientesData.Nombre_del_Padre_o_Tutor
                    ,Pais_de_nacimiento = PacientesData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Pais_de_nacimiento), "Pais") ??  (string)PacientesData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Lugar_de_nacimiento = PacientesData.Lugar_de_nacimiento
                    ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Lugar_de_nacimiento), "Estado") ??  (string)PacientesData.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = PacientesData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Sexo), "Sexo") ??  (string)PacientesData.Sexo_Sexo.Descripcion
                    ,Estado_Civil = PacientesData.Estado_Civil
                    ,Estado_CivilDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Estado_Civil), "Estado_Civil") ??  (string)PacientesData.Estado_Civil_Estado_Civil.Descripcion
                    ,Calle = PacientesData.Calle
                    ,Numero_exterior = PacientesData.Numero_exterior
                    ,Numero_interior = PacientesData.Numero_interior
                    ,Colonia = PacientesData.Colonia
                    ,CP = PacientesData.CP
                    ,Ciudad = PacientesData.Ciudad
                    ,Pais = PacientesData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Pais), "Pais") ??  (string)PacientesData.Pais_Pais.Nombre_del_Pais
                    ,Estado = PacientesData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Estado), "Estado") ??  (string)PacientesData.Estado_Estado.Nombre_del_Estado
                    ,Ocupacion = PacientesData.Ocupacion
                    ,Cantidad_hijos = PacientesData.Cantidad_hijos
                    ,Objetivo = PacientesData.Objetivo
                    ,ObjetivoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Objetivo), "Objetivos") ??  (string)PacientesData.Objetivo_Objetivos.Descripcion
                    ,Estatus_Paciente = PacientesData.Estatus_Paciente
                    ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Estatus_Paciente), "Estatus_por_Suscripcion") ??  (string)PacientesData.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion
                    ,Cuenta_con_padecimientos = PacientesData.Cuenta_con_padecimientos
                    ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Cuenta_con_padecimientos), "Respuesta_Logica") ??  (string)PacientesData.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion
                    ,Frecuencia_Cardiaca = PacientesData.Frecuencia_Cardiaca
                    ,Frecuencia_Respiratoria = PacientesData.Frecuencia_Respiratoria
                    ,Presion_sistolica = PacientesData.Presion_sistolica
                    ,Presion_diastolica = PacientesData.Presion_diastolica
                    ,Peso_actual = PacientesData.Peso_actual
                    ,Estatura = PacientesData.Estatura
                    ,Peso_habitual = PacientesData.Peso_habitual
                    ,Circunferencia_de_cintura_cm = PacientesData.Circunferencia_de_cintura_cm
                    ,Circunferencia_de_cadera_cm = PacientesData.Circunferencia_de_cadera_cm
                    ,Anchura_de_muneca_mm = PacientesData.Anchura_de_muneca_mm
                    ,Circunferencia_de_brazo_cm = PacientesData.Circunferencia_de_brazo_cm
                    ,Pliegue_cutaneo_tricipital_mm = PacientesData.Pliegue_cutaneo_tricipital_mm
                    ,Pliegue_cutaneo_bicipital_mm = PacientesData.Pliegue_cutaneo_bicipital_mm
                    ,Pliegue_cutaneo_subescapular_mm = PacientesData.Pliegue_cutaneo_subescapular_mm
                    ,Pliegue_cutaneo_supraespinal_mm = PacientesData.Pliegue_cutaneo_supraespinal_mm
                    ,Edad_Metabolica = PacientesData.Edad_Metabolica
                    ,Agua_corporal = PacientesData.Agua_corporal
                    ,Grasa_Visceral = PacientesData.Grasa_Visceral
                    ,Grasa_Corporal = PacientesData.Grasa_Corporal
                    ,Grasa_Corporal_kg = PacientesData.Grasa_Corporal_kg
                    ,Masa_Muscular_kg = PacientesData.Masa_Muscular_kg
                    ,Masa_Muscular_ = PacientesData.Masa_Muscular_
                    ,Esta_embarazada = PacientesData.Esta_embarazada
                    ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Esta_embarazada), "Respuesta_Logica") ??  (string)PacientesData.Esta_embarazada_Respuesta_Logica.Descripcion
                    ,Semana_de_gestacion = PacientesData.Semana_de_gestacion
                    ,Peso_pregestacional = PacientesData.Peso_pregestacional
                    ,Toma_anticonceptivos = PacientesData.Toma_anticonceptivos
                    ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Toma_anticonceptivos), "Respuesta_Logica") ??  (string)PacientesData.Toma_anticonceptivos_Respuesta_Logica.Descripcion
                    ,Nombre_del_Anticonceptivo = PacientesData.Nombre_del_Anticonceptivo
                    ,Dosis = PacientesData.Dosis
                    ,Climaterio = PacientesData.Climaterio
                    ,ClimaterioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Climaterio), "Respuesta_Logica") ??  (string)PacientesData.Climaterio_Respuesta_Logica.Descripcion
                    ,Fecha_Climaterio = (PacientesData.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(PacientesData.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                    ,Terapia_reemplazo_hormonal = PacientesData.Terapia_reemplazo_hormonal
                    ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Terapia_reemplazo_hormonal), "Respuesta_Logica") ??  (string)PacientesData.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion
                    ,Tipo_Dieta = PacientesData.Tipo_Dieta
                    ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_Dieta), "Tipo_de_Dieta") ??  (string)PacientesData.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                    ,Suplementos = PacientesData.Suplementos
                    ,SuplementosDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Suplementos), "Suplementos") ??  (string)PacientesData.Suplementos_Suplementos.Descripcion
                    ,Consumo_de_sal = PacientesData.Consumo_de_sal
                    ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Consumo_de_sal), "Preferencias_Sal") ??  (string)PacientesData.Consumo_de_sal_Preferencias_Sal.Descripcion
                    ,Grasas_Preferencias = PacientesData.Grasas_Preferencias
                    ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Grasas_Preferencias), "Preferencias_Grasas") ??  (string)PacientesData.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                    ,Comidas_cantidad = PacientesData.Comidas_cantidad
                    ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Comidas_cantidad), "Cantidad_Comidas") ??  (string)PacientesData.Comidas_cantidad_Cantidad_Comidas.Descripcion
                    ,Preparacion_Preferencias = PacientesData.Preparacion_Preferencias
                    ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Preparacion_Preferencias), "Preferencias_Preparacion") ??  (string)PacientesData.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                    ,Entre_comidas = PacientesData.Entre_comidas
                    ,Entre_comidasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Entre_comidas), "Preferencias_Entrecomidas") ??  (string)PacientesData.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                    ,Apetito = PacientesData.Apetito
                    ,ApetitoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Apetito), "Nivel_de_Satisfaccion") ??  (string)PacientesData.Apetito_Nivel_de_Satisfaccion.Descripcion
                    ,Habitos_Modificacion = PacientesData.Habitos_Modificacion
                    ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Habitos_Modificacion), "Tipo_Modificacion_Alimentos") ??  (string)PacientesData.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                    ,Horario_hambre = PacientesData.Horario_hambre
                    ,Horario_hambreDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Horario_hambre), "Periodo_del_dia") ??  (string)PacientesData.Horario_hambre_Periodo_del_dia.Descripcion
                    ,Cuando_cambia_mi_estado_de_animo = PacientesData.Cuando_cambia_mi_estado_de_animo
                    ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Cuando_cambia_mi_estado_de_animo), "Estado_de_Animo") ??  (string)PacientesData.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                    ,Medicamentos_bajar_peso = PacientesData.Medicamentos_bajar_peso
                    ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Medicamentos_bajar_peso), "Respuesta_Logica") ??  (string)PacientesData.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
                    ,Cual_medicamento = PacientesData.Cual_medicamento
                    ,Frecuencia_Ejercicio = PacientesData.Frecuencia_Ejercicio
                    ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Frecuencia_Ejercicio), "Frecuencia_Ejercicio") ??  (string)PacientesData.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                    ,Duracion_Ejercicio = PacientesData.Duracion_Ejercicio
                    ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Duracion_Ejercicio), "Duracion_Ejercicio") ??  (string)PacientesData.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                    ,Tipo_Ejercicio = PacientesData.Tipo_Ejercicio
                    ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_Ejercicio), "Tipo_Ejercicio") ??  (string)PacientesData.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                    ,Antiguedad_Ejercicio = PacientesData.Antiguedad_Ejercicio
                    ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Antiguedad_Ejercicio), "Antiguedad_Ejercicios") ??  (string)PacientesData.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion
                    ,IMC = PacientesData.IMC
                    ,Interpretacion_IMC = PacientesData.Interpretacion_IMC
                    ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_IMC), "Interpretacion_IMC") ??  (string)PacientesData.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                    ,IMC_Pediatria = PacientesData.IMC_Pediatria
                    ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.IMC_Pediatria), "Interpretacion_IMC") ??  (string)PacientesData.IMC_Pediatria_Interpretacion_IMC.Descripcion
                    ,Complexion_corporal = PacientesData.Complexion_corporal
                    ,Interpretacion_complexion_corporal = PacientesData.Interpretacion_complexion_corporal
                    ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_complexion_corporal), "Interpretacion_corporal") ??  (string)PacientesData.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
                    ,Distribucion_de_grasa_corporal = PacientesData.Distribucion_de_grasa_corporal
                    ,Interpretacion_grasa_corporal = PacientesData.Interpretacion_grasa_corporal
                    ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_grasa_corporal), "Interpretacion_distribucion_grasa_corporal") ??  (string)PacientesData.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
                    ,Indice_cintura_cadera = PacientesData.Indice_cintura_cadera
                    ,Interpretacion_indice = PacientesData.Interpretacion_indice
                    ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_indice), "Interpretacion_indice_cintura__cadera") ??  (string)PacientesData.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
                    ,Consumo_de_agua_resultado = PacientesData.Consumo_de_agua_resultado
                    ,Interpretacion_agua = PacientesData.Interpretacion_agua
                    ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_agua), "Interpretacion_consumo_de_agua") ??  (string)PacientesData.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
                    ,Frecuencia_cardiaca_en_Esfuerzo = PacientesData.Frecuencia_cardiaca_en_Esfuerzo
                    ,Interpretacion_frecuencia = PacientesData.Interpretacion_frecuencia
                    ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_frecuencia), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo") ??  (string)PacientesData.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
                    ,Dificultad_de_Rutina_de_Ejercicios = PacientesData.Dificultad_de_Rutina_de_Ejercicios
                    ,Interpretacion_dificultad = PacientesData.Interpretacion_dificultad
                    ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_dificultad), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios") ??  (string)PacientesData.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
                    ,Calorias = PacientesData.Calorias
                    ,Interpretacion_calorias = PacientesData.Interpretacion_calorias
                    ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_calorias), "Interpretacion_Calorias") ??  (string)PacientesData.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
                    ,Observaciones = PacientesData.Observaciones

					};
				}
				
				
				
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
            _ITipo_de_RegistroApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Registros_Tipo_de_Registro = _ITipo_de_RegistroApiConsumer.SelAll(true);
            if (Tipo_de_Registros_Tipo_de_Registro != null && Tipo_de_Registros_Tipo_de_Registro.Resource != null)
                ViewBag.Tipo_de_Registros_Tipo_de_Registro = Tipo_de_Registros_Tipo_de_Registro.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Registro", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Tipo_de_Paciente = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Tipo_de_Paciente != null && Tipo_Pacientes_Tipo_de_Paciente.Resource != null)
                ViewBag.Tipo_Pacientes_Tipo_de_Paciente = Tipo_Pacientes_Tipo_de_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Lugar_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Lugar_de_nacimiento != null && Estados_Lugar_de_nacimiento.Resource != null)
                ViewBag.Estados_Lugar_de_nacimiento = Estados_Lugar_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
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
            _IEstado_CivilApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_Civils_Estado_Civil = _IEstado_CivilApiConsumer.SelAll(true);
            if (Estado_Civils_Estado_Civil != null && Estado_Civils_Estado_Civil.Resource != null)
                ViewBag.Estado_Civils_Estado_Civil = Estado_Civils_Estado_Civil.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_Civil", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_por_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_por_Suscripcions_Estatus_Paciente = _IEstatus_por_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_por_Suscripcions_Estatus_Paciente != null && Estatus_por_Suscripcions_Estatus_Paciente.Resource != null)
                ViewBag.Estatus_por_Suscripcions_Estatus_Paciente = Estatus_por_Suscripcions_Estatus_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_por_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Cuenta_con_padecimientos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Cuenta_con_padecimientos != null && Respuesta_Logicas_Cuenta_con_padecimientos.Resource != null)
                ViewBag.Respuesta_Logicas_Cuenta_con_padecimientos = Respuesta_Logicas_Cuenta_con_padecimientos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Esta_embarazada = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Esta_embarazada != null && Respuesta_Logicas_Esta_embarazada.Resource != null)
                ViewBag.Respuesta_Logicas_Esta_embarazada = Respuesta_Logicas_Esta_embarazada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Toma_anticonceptivos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Toma_anticonceptivos != null && Respuesta_Logicas_Toma_anticonceptivos.Resource != null)
                ViewBag.Respuesta_Logicas_Toma_anticonceptivos = Respuesta_Logicas_Toma_anticonceptivos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Climaterio = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Climaterio != null && Respuesta_Logicas_Climaterio.Resource != null)
                ViewBag.Respuesta_Logicas_Climaterio = Respuesta_Logicas_Climaterio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Terapia_reemplazo_hormonal = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Terapia_reemplazo_hormonal != null && Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource != null)
                ViewBag.Respuesta_Logicas_Terapia_reemplazo_hormonal = Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_DietaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Dietas_Tipo_Dieta = _ITipo_de_DietaApiConsumer.SelAll(true);
            if (Tipo_de_Dietas_Tipo_Dieta != null && Tipo_de_Dietas_Tipo_Dieta.Resource != null)
                ViewBag.Tipo_de_Dietas_Tipo_Dieta = Tipo_de_Dietas_Tipo_Dieta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Dieta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISuplementosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Suplementoss_Suplementos = _ISuplementosApiConsumer.SelAll(true);
            if (Suplementoss_Suplementos != null && Suplementoss_Suplementos.Resource != null)
                ViewBag.Suplementoss_Suplementos = Suplementoss_Suplementos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Suplementos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_SalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Sals_Consumo_de_sal = _IPreferencias_SalApiConsumer.SelAll(true);
            if (Preferencias_Sals_Consumo_de_sal != null && Preferencias_Sals_Consumo_de_sal.Resource != null)
                ViewBag.Preferencias_Sals_Consumo_de_sal = Preferencias_Sals_Consumo_de_sal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Sal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_GrasasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Grasass_Grasas_Preferencias = _IPreferencias_GrasasApiConsumer.SelAll(true);
            if (Preferencias_Grasass_Grasas_Preferencias != null && Preferencias_Grasass_Grasas_Preferencias.Resource != null)
                ViewBag.Preferencias_Grasass_Grasas_Preferencias = Preferencias_Grasass_Grasas_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Grasas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICantidad_ComidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Cantidad_Comidass_Comidas_cantidad = _ICantidad_ComidasApiConsumer.SelAll(true);
            if (Cantidad_Comidass_Comidas_cantidad != null && Cantidad_Comidass_Comidas_cantidad.Resource != null)
                ViewBag.Cantidad_Comidass_Comidas_cantidad = Cantidad_Comidass_Comidas_cantidad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cantidad_Comidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_PreparacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Preparacions_Preparacion_Preferencias = _IPreferencias_PreparacionApiConsumer.SelAll(true);
            if (Preferencias_Preparacions_Preparacion_Preferencias != null && Preferencias_Preparacions_Preparacion_Preferencias.Resource != null)
                ViewBag.Preferencias_Preparacions_Preparacion_Preferencias = Preferencias_Preparacions_Preparacion_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Preparacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_EntrecomidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Entrecomidass_Entre_comidas = _IPreferencias_EntrecomidasApiConsumer.SelAll(true);
            if (Preferencias_Entrecomidass_Entre_comidas != null && Preferencias_Entrecomidass_Entre_comidas.Resource != null)
                ViewBag.Preferencias_Entrecomidass_Entre_comidas = Preferencias_Entrecomidass_Entre_comidas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Entrecomidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_SatisfaccionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Satisfaccions_Apetito = _INivel_de_SatisfaccionApiConsumer.SelAll(true);
            if (Nivel_de_Satisfaccions_Apetito != null && Nivel_de_Satisfaccions_Apetito.Resource != null)
                ViewBag.Nivel_de_Satisfaccions_Apetito = Nivel_de_Satisfaccions_Apetito.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nivel_de_Satisfaccion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_Modificacion_AlimentosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Modificacion_Alimentoss_Habitos_Modificacion = _ITipo_Modificacion_AlimentosApiConsumer.SelAll(true);
            if (Tipo_Modificacion_Alimentoss_Habitos_Modificacion != null && Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource != null)
                ViewBag.Tipo_Modificacion_Alimentoss_Habitos_Modificacion = Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Modificacion_Alimentos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPeriodo_del_diaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Periodo_del_dias_Horario_hambre = _IPeriodo_del_diaApiConsumer.SelAll(true);
            if (Periodo_del_dias_Horario_hambre != null && Periodo_del_dias_Horario_hambre.Resource != null)
                ViewBag.Periodo_del_dias_Horario_hambre = Periodo_del_dias_Horario_hambre.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Periodo_del_dia", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstado_de_AnimoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = _IEstado_de_AnimoApiConsumer.SelAll(true);
            if (Estado_de_Animos_Cuando_cambia_mi_estado_de_animo != null && Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource != null)
                ViewBag.Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_de_Animo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Medicamentos_bajar_peso = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Medicamentos_bajar_peso != null && Respuesta_Logicas_Medicamentos_bajar_peso.Resource != null)
                ViewBag.Respuesta_Logicas_Medicamentos_bajar_peso = Respuesta_Logicas_Medicamentos_bajar_peso.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IFrecuencia_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_Ejercicios_Frecuencia_Ejercicio = _IFrecuencia_EjercicioApiConsumer.SelAll(true);
            if (Frecuencia_Ejercicios_Frecuencia_Ejercicio != null && Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource != null)
                ViewBag.Frecuencia_Ejercicios_Frecuencia_Ejercicio = Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDuracion_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Duracion_Ejercicios_Duracion_Ejercicio = _IDuracion_EjercicioApiConsumer.SelAll(true);
            if (Duracion_Ejercicios_Duracion_Ejercicio != null && Duracion_Ejercicios_Duracion_Ejercicio.Resource != null)
                ViewBag.Duracion_Ejercicios_Duracion_Ejercicio = Duracion_Ejercicios_Duracion_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Duracion_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_Ejercicio != null && Tipo_Ejercicios_Tipo_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_Ejercicio = Tipo_Ejercicios_Tipo_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IAntiguedad_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Antiguedad_Ejercicioss_Antiguedad_Ejercicio = _IAntiguedad_EjerciciosApiConsumer.SelAll(true);
            if (Antiguedad_Ejercicioss_Antiguedad_Ejercicio != null && Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource != null)
                ViewBag.Antiguedad_Ejercicioss_Antiguedad_Ejercicio = Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Antiguedad_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_corporals_Interpretacion_complexion_corporal = _IInterpretacion_corporalApiConsumer.SelAll(true);
            if (Interpretacion_corporals_Interpretacion_complexion_corporal != null && Interpretacion_corporals_Interpretacion_complexion_corporal.Resource != null)
                ViewBag.Interpretacion_corporals_Interpretacion_complexion_corporal = Interpretacion_corporals_Interpretacion_complexion_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_distribucion_grasa_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = _IInterpretacion_distribucion_grasa_corporalApiConsumer.SelAll(true);
            if (Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal != null && Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource != null)
                ViewBag.Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_distribucion_grasa_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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

				
            return View(varPacientes);
        }
		
	[HttpGet]
        public ActionResult AddPacientes(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44337);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
			PacientesModel varPacientes= new PacientesModel();
            var permissionDetalle_de_Padecimientos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44309, ModuleId);
            ViewBag.PermissionDetalle_de_Padecimientos = permissionDetalle_de_Padecimientos;
            var permissionDetalle_Antecedentes_Familiares = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44341, ModuleId);
            ViewBag.PermissionDetalle_Antecedentes_Familiares = permissionDetalle_Antecedentes_Familiares;
            var permissionDetalle_Antecedentes_No_Patologicos = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44342, ModuleId);
            ViewBag.PermissionDetalle_Antecedentes_No_Patologicos = permissionDetalle_Antecedentes_No_Patologicos;
            var permissionDetalle_Examenes_Laboratorio = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44344, ModuleId);
            ViewBag.PermissionDetalle_Examenes_Laboratorio = permissionDetalle_Examenes_Laboratorio;
            var permissionDetalle_Terapia_Hormonal = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44345, ModuleId);
            ViewBag.PermissionDetalle_Terapia_Hormonal = permissionDetalle_Terapia_Hormonal;
            var permissionMS_Exclusion_Ingredientes_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44445, ModuleId);
            ViewBag.PermissionMS_Exclusion_Ingredientes_Paciente = permissionMS_Exclusion_Ingredientes_Paciente;
            var permissionDetalle_Preferencia_Bebidas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44336, ModuleId);
            ViewBag.PermissionDetalle_Preferencia_Bebidas = permissionDetalle_Preferencia_Bebidas;
            var permissionDetalle_Pagos_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44399, ModuleId);
            ViewBag.PermissionDetalle_Pagos_Paciente = permissionDetalle_Pagos_Paciente;
            var permissionDetalle_Suscripciones_Paciente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44398, ModuleId);
            ViewBag.PermissionDetalle_Suscripciones_Paciente = permissionDetalle_Suscripciones_Paciente;


            if (id.ToString() != "0")
            {
                var PacientessData = _IPacientesApiConsumer.ListaSelAll(0, 1000, "Pacientes.Folio=" + id, "").Resource.Pacientess;
				
				if (PacientessData != null && PacientessData.Count > 0)
                {
					var PacientesData = PacientessData.First();
					varPacientes= new PacientesModel
					{
						Folio  = PacientesData.Folio 
	                    ,Fecha_de_Registro = (PacientesData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(PacientesData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = PacientesData.Hora_de_Registro
                    ,Usuario_que_Registra = PacientesData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Usuario_que_Registra), "Spartan_User") ??  (string)PacientesData.Usuario_que_Registra_Spartan_User.Name
                    ,Tipo_de_Registro = PacientesData.Tipo_de_Registro
                    ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_de_Registro), "Tipo_de_Registro") ??  (string)PacientesData.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                    ,Tipo_de_Paciente = PacientesData.Tipo_de_Paciente
                    ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_de_Paciente), "Tipo_Paciente") ??  (string)PacientesData.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                    ,Usuario_Registrado = PacientesData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Usuario_Registrado), "Spartan_User") ??  (string)PacientesData.Usuario_Registrado_Spartan_User.Name
                    ,Empresa = PacientesData.Empresa
                    ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Empresa), "Empresas") ??  (string)PacientesData.Empresa_Empresas.Nombre_de_la_Empresa
                    ,Numero_de_Empleado = PacientesData.Numero_de_Empleado
                    ,Nombres = PacientesData.Nombres
                    ,Apellido_Paterno = PacientesData.Apellido_Paterno
                    ,Apellido_Materno = PacientesData.Apellido_Materno
                    ,Nombre_Completo = PacientesData.Nombre_Completo
                    ,Celular = PacientesData.Celular
                    ,Email = PacientesData.Email
                    ,Fecha_de_nacimiento = (PacientesData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(PacientesData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Nombre_del_Padre_o_Tutor = PacientesData.Nombre_del_Padre_o_Tutor
                    ,Pais_de_nacimiento = PacientesData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Pais_de_nacimiento), "Pais") ??  (string)PacientesData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Lugar_de_nacimiento = PacientesData.Lugar_de_nacimiento
                    ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Lugar_de_nacimiento), "Estado") ??  (string)PacientesData.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = PacientesData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Sexo), "Sexo") ??  (string)PacientesData.Sexo_Sexo.Descripcion
                    ,Estado_Civil = PacientesData.Estado_Civil
                    ,Estado_CivilDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Estado_Civil), "Estado_Civil") ??  (string)PacientesData.Estado_Civil_Estado_Civil.Descripcion
                    ,Calle = PacientesData.Calle
                    ,Numero_exterior = PacientesData.Numero_exterior
                    ,Numero_interior = PacientesData.Numero_interior
                    ,Colonia = PacientesData.Colonia
                    ,CP = PacientesData.CP
                    ,Ciudad = PacientesData.Ciudad
                    ,Pais = PacientesData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Pais), "Pais") ??  (string)PacientesData.Pais_Pais.Nombre_del_Pais
                    ,Estado = PacientesData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Estado), "Estado") ??  (string)PacientesData.Estado_Estado.Nombre_del_Estado
                    ,Ocupacion = PacientesData.Ocupacion
                    ,Cantidad_hijos = PacientesData.Cantidad_hijos
                    ,Objetivo = PacientesData.Objetivo
                    ,ObjetivoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Objetivo), "Objetivos") ??  (string)PacientesData.Objetivo_Objetivos.Descripcion
                    ,Estatus_Paciente = PacientesData.Estatus_Paciente
                    ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Estatus_Paciente), "Estatus_por_Suscripcion") ??  (string)PacientesData.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion
                    ,Cuenta_con_padecimientos = PacientesData.Cuenta_con_padecimientos
                    ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Cuenta_con_padecimientos), "Respuesta_Logica") ??  (string)PacientesData.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion
                    ,Frecuencia_Cardiaca = PacientesData.Frecuencia_Cardiaca
                    ,Frecuencia_Respiratoria = PacientesData.Frecuencia_Respiratoria
                    ,Presion_sistolica = PacientesData.Presion_sistolica
                    ,Presion_diastolica = PacientesData.Presion_diastolica
                    ,Peso_actual = PacientesData.Peso_actual
                    ,Estatura = PacientesData.Estatura
                    ,Peso_habitual = PacientesData.Peso_habitual
                    ,Circunferencia_de_cintura_cm = PacientesData.Circunferencia_de_cintura_cm
                    ,Circunferencia_de_cadera_cm = PacientesData.Circunferencia_de_cadera_cm
                    ,Anchura_de_muneca_mm = PacientesData.Anchura_de_muneca_mm
                    ,Circunferencia_de_brazo_cm = PacientesData.Circunferencia_de_brazo_cm
                    ,Pliegue_cutaneo_tricipital_mm = PacientesData.Pliegue_cutaneo_tricipital_mm
                    ,Pliegue_cutaneo_bicipital_mm = PacientesData.Pliegue_cutaneo_bicipital_mm
                    ,Pliegue_cutaneo_subescapular_mm = PacientesData.Pliegue_cutaneo_subescapular_mm
                    ,Pliegue_cutaneo_supraespinal_mm = PacientesData.Pliegue_cutaneo_supraespinal_mm
                    ,Edad_Metabolica = PacientesData.Edad_Metabolica
                    ,Agua_corporal = PacientesData.Agua_corporal
                    ,Grasa_Visceral = PacientesData.Grasa_Visceral
                    ,Grasa_Corporal = PacientesData.Grasa_Corporal
                    ,Grasa_Corporal_kg = PacientesData.Grasa_Corporal_kg
                    ,Masa_Muscular_kg = PacientesData.Masa_Muscular_kg
                    ,Masa_Muscular_ = PacientesData.Masa_Muscular_
                    ,Esta_embarazada = PacientesData.Esta_embarazada
                    ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Esta_embarazada), "Respuesta_Logica") ??  (string)PacientesData.Esta_embarazada_Respuesta_Logica.Descripcion
                    ,Semana_de_gestacion = PacientesData.Semana_de_gestacion
                    ,Peso_pregestacional = PacientesData.Peso_pregestacional
                    ,Toma_anticonceptivos = PacientesData.Toma_anticonceptivos
                    ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Toma_anticonceptivos), "Respuesta_Logica") ??  (string)PacientesData.Toma_anticonceptivos_Respuesta_Logica.Descripcion
                    ,Nombre_del_Anticonceptivo = PacientesData.Nombre_del_Anticonceptivo
                    ,Dosis = PacientesData.Dosis
                    ,Climaterio = PacientesData.Climaterio
                    ,ClimaterioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Climaterio), "Respuesta_Logica") ??  (string)PacientesData.Climaterio_Respuesta_Logica.Descripcion
                    ,Fecha_Climaterio = (PacientesData.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(PacientesData.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                    ,Terapia_reemplazo_hormonal = PacientesData.Terapia_reemplazo_hormonal
                    ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Terapia_reemplazo_hormonal), "Respuesta_Logica") ??  (string)PacientesData.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion
                    ,Tipo_Dieta = PacientesData.Tipo_Dieta
                    ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_Dieta), "Tipo_de_Dieta") ??  (string)PacientesData.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                    ,Suplementos = PacientesData.Suplementos
                    ,SuplementosDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Suplementos), "Suplementos") ??  (string)PacientesData.Suplementos_Suplementos.Descripcion
                    ,Consumo_de_sal = PacientesData.Consumo_de_sal
                    ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Consumo_de_sal), "Preferencias_Sal") ??  (string)PacientesData.Consumo_de_sal_Preferencias_Sal.Descripcion
                    ,Grasas_Preferencias = PacientesData.Grasas_Preferencias
                    ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Grasas_Preferencias), "Preferencias_Grasas") ??  (string)PacientesData.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                    ,Comidas_cantidad = PacientesData.Comidas_cantidad
                    ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Comidas_cantidad), "Cantidad_Comidas") ??  (string)PacientesData.Comidas_cantidad_Cantidad_Comidas.Descripcion
                    ,Preparacion_Preferencias = PacientesData.Preparacion_Preferencias
                    ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Preparacion_Preferencias), "Preferencias_Preparacion") ??  (string)PacientesData.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                    ,Entre_comidas = PacientesData.Entre_comidas
                    ,Entre_comidasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Entre_comidas), "Preferencias_Entrecomidas") ??  (string)PacientesData.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                    ,Apetito = PacientesData.Apetito
                    ,ApetitoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Apetito), "Nivel_de_Satisfaccion") ??  (string)PacientesData.Apetito_Nivel_de_Satisfaccion.Descripcion
                    ,Habitos_Modificacion = PacientesData.Habitos_Modificacion
                    ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Habitos_Modificacion), "Tipo_Modificacion_Alimentos") ??  (string)PacientesData.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                    ,Horario_hambre = PacientesData.Horario_hambre
                    ,Horario_hambreDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Horario_hambre), "Periodo_del_dia") ??  (string)PacientesData.Horario_hambre_Periodo_del_dia.Descripcion
                    ,Cuando_cambia_mi_estado_de_animo = PacientesData.Cuando_cambia_mi_estado_de_animo
                    ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Cuando_cambia_mi_estado_de_animo), "Estado_de_Animo") ??  (string)PacientesData.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                    ,Medicamentos_bajar_peso = PacientesData.Medicamentos_bajar_peso
                    ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Medicamentos_bajar_peso), "Respuesta_Logica") ??  (string)PacientesData.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
                    ,Cual_medicamento = PacientesData.Cual_medicamento
                    ,Frecuencia_Ejercicio = PacientesData.Frecuencia_Ejercicio
                    ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Frecuencia_Ejercicio), "Frecuencia_Ejercicio") ??  (string)PacientesData.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                    ,Duracion_Ejercicio = PacientesData.Duracion_Ejercicio
                    ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Duracion_Ejercicio), "Duracion_Ejercicio") ??  (string)PacientesData.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                    ,Tipo_Ejercicio = PacientesData.Tipo_Ejercicio
                    ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Tipo_Ejercicio), "Tipo_Ejercicio") ??  (string)PacientesData.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                    ,Antiguedad_Ejercicio = PacientesData.Antiguedad_Ejercicio
                    ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Antiguedad_Ejercicio), "Antiguedad_Ejercicios") ??  (string)PacientesData.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion
                    ,IMC = PacientesData.IMC
                    ,Interpretacion_IMC = PacientesData.Interpretacion_IMC
                    ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_IMC), "Interpretacion_IMC") ??  (string)PacientesData.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                    ,IMC_Pediatria = PacientesData.IMC_Pediatria
                    ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.IMC_Pediatria), "Interpretacion_IMC") ??  (string)PacientesData.IMC_Pediatria_Interpretacion_IMC.Descripcion
                    ,Complexion_corporal = PacientesData.Complexion_corporal
                    ,Interpretacion_complexion_corporal = PacientesData.Interpretacion_complexion_corporal
                    ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_complexion_corporal), "Interpretacion_corporal") ??  (string)PacientesData.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
                    ,Distribucion_de_grasa_corporal = PacientesData.Distribucion_de_grasa_corporal
                    ,Interpretacion_grasa_corporal = PacientesData.Interpretacion_grasa_corporal
                    ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_grasa_corporal), "Interpretacion_distribucion_grasa_corporal") ??  (string)PacientesData.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
                    ,Indice_cintura_cadera = PacientesData.Indice_cintura_cadera
                    ,Interpretacion_indice = PacientesData.Interpretacion_indice
                    ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_indice), "Interpretacion_indice_cintura__cadera") ??  (string)PacientesData.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
                    ,Consumo_de_agua_resultado = PacientesData.Consumo_de_agua_resultado
                    ,Interpretacion_agua = PacientesData.Interpretacion_agua
                    ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_agua), "Interpretacion_consumo_de_agua") ??  (string)PacientesData.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
                    ,Frecuencia_cardiaca_en_Esfuerzo = PacientesData.Frecuencia_cardiaca_en_Esfuerzo
                    ,Interpretacion_frecuencia = PacientesData.Interpretacion_frecuencia
                    ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_frecuencia), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo") ??  (string)PacientesData.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
                    ,Dificultad_de_Rutina_de_Ejercicios = PacientesData.Dificultad_de_Rutina_de_Ejercicios
                    ,Interpretacion_dificultad = PacientesData.Interpretacion_dificultad
                    ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_dificultad), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios") ??  (string)PacientesData.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
                    ,Calorias = PacientesData.Calorias
                    ,Interpretacion_calorias = PacientesData.Interpretacion_calorias
                    ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(Convert.ToString(PacientesData.Interpretacion_calorias), "Interpretacion_Calorias") ??  (string)PacientesData.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
                    ,Observaciones = PacientesData.Observaciones

					};
				}

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
            _ITipo_de_RegistroApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Registros_Tipo_de_Registro = _ITipo_de_RegistroApiConsumer.SelAll(true);
            if (Tipo_de_Registros_Tipo_de_Registro != null && Tipo_de_Registros_Tipo_de_Registro.Resource != null)
                ViewBag.Tipo_de_Registros_Tipo_de_Registro = Tipo_de_Registros_Tipo_de_Registro.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Registro", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Tipo_de_Paciente = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Tipo_de_Paciente != null && Tipo_Pacientes_Tipo_de_Paciente.Resource != null)
                ViewBag.Tipo_Pacientes_Tipo_de_Paciente = Tipo_Pacientes_Tipo_de_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Lugar_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Lugar_de_nacimiento != null && Estados_Lugar_de_nacimiento.Resource != null)
                ViewBag.Estados_Lugar_de_nacimiento = Estados_Lugar_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
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
            _IEstado_CivilApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_Civils_Estado_Civil = _IEstado_CivilApiConsumer.SelAll(true);
            if (Estado_Civils_Estado_Civil != null && Estado_Civils_Estado_Civil.Resource != null)
                ViewBag.Estado_Civils_Estado_Civil = Estado_Civils_Estado_Civil.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_Civil", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_por_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_por_Suscripcions_Estatus_Paciente = _IEstatus_por_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_por_Suscripcions_Estatus_Paciente != null && Estatus_por_Suscripcions_Estatus_Paciente.Resource != null)
                ViewBag.Estatus_por_Suscripcions_Estatus_Paciente = Estatus_por_Suscripcions_Estatus_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_por_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Cuenta_con_padecimientos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Cuenta_con_padecimientos != null && Respuesta_Logicas_Cuenta_con_padecimientos.Resource != null)
                ViewBag.Respuesta_Logicas_Cuenta_con_padecimientos = Respuesta_Logicas_Cuenta_con_padecimientos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Esta_embarazada = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Esta_embarazada != null && Respuesta_Logicas_Esta_embarazada.Resource != null)
                ViewBag.Respuesta_Logicas_Esta_embarazada = Respuesta_Logicas_Esta_embarazada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Toma_anticonceptivos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Toma_anticonceptivos != null && Respuesta_Logicas_Toma_anticonceptivos.Resource != null)
                ViewBag.Respuesta_Logicas_Toma_anticonceptivos = Respuesta_Logicas_Toma_anticonceptivos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Climaterio = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Climaterio != null && Respuesta_Logicas_Climaterio.Resource != null)
                ViewBag.Respuesta_Logicas_Climaterio = Respuesta_Logicas_Climaterio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Terapia_reemplazo_hormonal = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Terapia_reemplazo_hormonal != null && Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource != null)
                ViewBag.Respuesta_Logicas_Terapia_reemplazo_hormonal = Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_DietaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Dietas_Tipo_Dieta = _ITipo_de_DietaApiConsumer.SelAll(true);
            if (Tipo_de_Dietas_Tipo_Dieta != null && Tipo_de_Dietas_Tipo_Dieta.Resource != null)
                ViewBag.Tipo_de_Dietas_Tipo_Dieta = Tipo_de_Dietas_Tipo_Dieta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Dieta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISuplementosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Suplementoss_Suplementos = _ISuplementosApiConsumer.SelAll(true);
            if (Suplementoss_Suplementos != null && Suplementoss_Suplementos.Resource != null)
                ViewBag.Suplementoss_Suplementos = Suplementoss_Suplementos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Suplementos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_SalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Sals_Consumo_de_sal = _IPreferencias_SalApiConsumer.SelAll(true);
            if (Preferencias_Sals_Consumo_de_sal != null && Preferencias_Sals_Consumo_de_sal.Resource != null)
                ViewBag.Preferencias_Sals_Consumo_de_sal = Preferencias_Sals_Consumo_de_sal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Sal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_GrasasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Grasass_Grasas_Preferencias = _IPreferencias_GrasasApiConsumer.SelAll(true);
            if (Preferencias_Grasass_Grasas_Preferencias != null && Preferencias_Grasass_Grasas_Preferencias.Resource != null)
                ViewBag.Preferencias_Grasass_Grasas_Preferencias = Preferencias_Grasass_Grasas_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Grasas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICantidad_ComidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Cantidad_Comidass_Comidas_cantidad = _ICantidad_ComidasApiConsumer.SelAll(true);
            if (Cantidad_Comidass_Comidas_cantidad != null && Cantidad_Comidass_Comidas_cantidad.Resource != null)
                ViewBag.Cantidad_Comidass_Comidas_cantidad = Cantidad_Comidass_Comidas_cantidad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cantidad_Comidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_PreparacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Preparacions_Preparacion_Preferencias = _IPreferencias_PreparacionApiConsumer.SelAll(true);
            if (Preferencias_Preparacions_Preparacion_Preferencias != null && Preferencias_Preparacions_Preparacion_Preferencias.Resource != null)
                ViewBag.Preferencias_Preparacions_Preparacion_Preferencias = Preferencias_Preparacions_Preparacion_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Preparacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_EntrecomidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Entrecomidass_Entre_comidas = _IPreferencias_EntrecomidasApiConsumer.SelAll(true);
            if (Preferencias_Entrecomidass_Entre_comidas != null && Preferencias_Entrecomidass_Entre_comidas.Resource != null)
                ViewBag.Preferencias_Entrecomidass_Entre_comidas = Preferencias_Entrecomidass_Entre_comidas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Entrecomidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_SatisfaccionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Satisfaccions_Apetito = _INivel_de_SatisfaccionApiConsumer.SelAll(true);
            if (Nivel_de_Satisfaccions_Apetito != null && Nivel_de_Satisfaccions_Apetito.Resource != null)
                ViewBag.Nivel_de_Satisfaccions_Apetito = Nivel_de_Satisfaccions_Apetito.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nivel_de_Satisfaccion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_Modificacion_AlimentosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Modificacion_Alimentoss_Habitos_Modificacion = _ITipo_Modificacion_AlimentosApiConsumer.SelAll(true);
            if (Tipo_Modificacion_Alimentoss_Habitos_Modificacion != null && Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource != null)
                ViewBag.Tipo_Modificacion_Alimentoss_Habitos_Modificacion = Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Modificacion_Alimentos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPeriodo_del_diaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Periodo_del_dias_Horario_hambre = _IPeriodo_del_diaApiConsumer.SelAll(true);
            if (Periodo_del_dias_Horario_hambre != null && Periodo_del_dias_Horario_hambre.Resource != null)
                ViewBag.Periodo_del_dias_Horario_hambre = Periodo_del_dias_Horario_hambre.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Periodo_del_dia", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstado_de_AnimoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = _IEstado_de_AnimoApiConsumer.SelAll(true);
            if (Estado_de_Animos_Cuando_cambia_mi_estado_de_animo != null && Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource != null)
                ViewBag.Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_de_Animo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Medicamentos_bajar_peso = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Medicamentos_bajar_peso != null && Respuesta_Logicas_Medicamentos_bajar_peso.Resource != null)
                ViewBag.Respuesta_Logicas_Medicamentos_bajar_peso = Respuesta_Logicas_Medicamentos_bajar_peso.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IFrecuencia_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_Ejercicios_Frecuencia_Ejercicio = _IFrecuencia_EjercicioApiConsumer.SelAll(true);
            if (Frecuencia_Ejercicios_Frecuencia_Ejercicio != null && Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource != null)
                ViewBag.Frecuencia_Ejercicios_Frecuencia_Ejercicio = Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDuracion_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Duracion_Ejercicios_Duracion_Ejercicio = _IDuracion_EjercicioApiConsumer.SelAll(true);
            if (Duracion_Ejercicios_Duracion_Ejercicio != null && Duracion_Ejercicios_Duracion_Ejercicio.Resource != null)
                ViewBag.Duracion_Ejercicios_Duracion_Ejercicio = Duracion_Ejercicios_Duracion_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Duracion_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_Ejercicio != null && Tipo_Ejercicios_Tipo_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_Ejercicio = Tipo_Ejercicios_Tipo_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IAntiguedad_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Antiguedad_Ejercicioss_Antiguedad_Ejercicio = _IAntiguedad_EjerciciosApiConsumer.SelAll(true);
            if (Antiguedad_Ejercicioss_Antiguedad_Ejercicio != null && Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource != null)
                ViewBag.Antiguedad_Ejercicioss_Antiguedad_Ejercicio = Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Antiguedad_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_corporals_Interpretacion_complexion_corporal = _IInterpretacion_corporalApiConsumer.SelAll(true);
            if (Interpretacion_corporals_Interpretacion_complexion_corporal != null && Interpretacion_corporals_Interpretacion_complexion_corporal.Resource != null)
                ViewBag.Interpretacion_corporals_Interpretacion_complexion_corporal = Interpretacion_corporals_Interpretacion_complexion_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_distribucion_grasa_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = _IInterpretacion_distribucion_grasa_corporalApiConsumer.SelAll(true);
            if (Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal != null && Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource != null)
                ViewBag.Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_distribucion_grasa_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddPacientes", varPacientes);
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
        public ActionResult GetTipo_de_RegistroAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_RegistroApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_RegistroApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Registro", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_PacienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEmpresasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa")?? m.Nombre_de_la_Empresa,
                    Value = Convert.ToString(m.Folio)
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
        public ActionResult GetEstado_CivilAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstado_CivilApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstado_CivilApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_Civil", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetObjetivosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IObjetivosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_por_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_por_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_por_SuscripcionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_por_Suscripcion", "Descripcion")?? m.Descripcion,
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
        public ActionResult GetTipo_de_DietaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_DietaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_DietaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Dieta", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSuplementosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISuplementosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISuplementosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Suplementos", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPreferencias_SalAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPreferencias_SalApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPreferencias_SalApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Sal", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPreferencias_GrasasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPreferencias_GrasasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPreferencias_GrasasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Grasas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetCantidad_ComidasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICantidad_ComidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICantidad_ComidasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cantidad_Comidas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPreferencias_PreparacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPreferencias_PreparacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPreferencias_PreparacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Preparacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPreferencias_EntrecomidasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPreferencias_EntrecomidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPreferencias_EntrecomidasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Entrecomidas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetNivel_de_SatisfaccionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INivel_de_SatisfaccionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INivel_de_SatisfaccionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nivel_de_Satisfaccion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_Modificacion_AlimentosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_Modificacion_AlimentosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_Modificacion_AlimentosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Modificacion_Alimentos", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPeriodo_del_diaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPeriodo_del_diaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPeriodo_del_diaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Periodo_del_dia", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstado_de_AnimoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstado_de_AnimoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstado_de_AnimoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_de_Animo", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetFrecuencia_EjercicioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFrecuencia_EjercicioApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Ejercicio", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDuracion_EjercicioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDuracion_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDuracion_EjercicioApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Duracion_Ejercicio", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_EjercicioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_EjercicioApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetAntiguedad_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IAntiguedad_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IAntiguedad_EjerciciosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Antiguedad_Ejercicios", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_IMCAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_IMCApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_corporalAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_corporalApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_corporal", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_distribucion_grasa_corporalAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_distribucion_grasa_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_distribucion_grasa_corporalApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_distribucion_grasa_corporal", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_indice_cintura__caderaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_consumo_de_aguaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_Frecuencia_cardiaca_en_EsfuerzoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_Dificultad_de_Rutina_de_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_CaloriasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_CaloriasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(PacientesAdvanceSearchModel model, int idFilter = -1)
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
            _ITipo_de_RegistroApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Registros_Tipo_de_Registro = _ITipo_de_RegistroApiConsumer.SelAll(true);
            if (Tipo_de_Registros_Tipo_de_Registro != null && Tipo_de_Registros_Tipo_de_Registro.Resource != null)
                ViewBag.Tipo_de_Registros_Tipo_de_Registro = Tipo_de_Registros_Tipo_de_Registro.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Registro", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Tipo_de_Paciente = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Tipo_de_Paciente != null && Tipo_Pacientes_Tipo_de_Paciente.Resource != null)
                ViewBag.Tipo_Pacientes_Tipo_de_Paciente = Tipo_Pacientes_Tipo_de_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Lugar_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Lugar_de_nacimiento != null && Estados_Lugar_de_nacimiento.Resource != null)
                ViewBag.Estados_Lugar_de_nacimiento = Estados_Lugar_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
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
            _IEstado_CivilApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_Civils_Estado_Civil = _IEstado_CivilApiConsumer.SelAll(true);
            if (Estado_Civils_Estado_Civil != null && Estado_Civils_Estado_Civil.Resource != null)
                ViewBag.Estado_Civils_Estado_Civil = Estado_Civils_Estado_Civil.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_Civil", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_por_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_por_Suscripcions_Estatus_Paciente = _IEstatus_por_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_por_Suscripcions_Estatus_Paciente != null && Estatus_por_Suscripcions_Estatus_Paciente.Resource != null)
                ViewBag.Estatus_por_Suscripcions_Estatus_Paciente = Estatus_por_Suscripcions_Estatus_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_por_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Cuenta_con_padecimientos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Cuenta_con_padecimientos != null && Respuesta_Logicas_Cuenta_con_padecimientos.Resource != null)
                ViewBag.Respuesta_Logicas_Cuenta_con_padecimientos = Respuesta_Logicas_Cuenta_con_padecimientos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Esta_embarazada = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Esta_embarazada != null && Respuesta_Logicas_Esta_embarazada.Resource != null)
                ViewBag.Respuesta_Logicas_Esta_embarazada = Respuesta_Logicas_Esta_embarazada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Toma_anticonceptivos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Toma_anticonceptivos != null && Respuesta_Logicas_Toma_anticonceptivos.Resource != null)
                ViewBag.Respuesta_Logicas_Toma_anticonceptivos = Respuesta_Logicas_Toma_anticonceptivos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Climaterio = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Climaterio != null && Respuesta_Logicas_Climaterio.Resource != null)
                ViewBag.Respuesta_Logicas_Climaterio = Respuesta_Logicas_Climaterio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Terapia_reemplazo_hormonal = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Terapia_reemplazo_hormonal != null && Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource != null)
                ViewBag.Respuesta_Logicas_Terapia_reemplazo_hormonal = Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_DietaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Dietas_Tipo_Dieta = _ITipo_de_DietaApiConsumer.SelAll(true);
            if (Tipo_de_Dietas_Tipo_Dieta != null && Tipo_de_Dietas_Tipo_Dieta.Resource != null)
                ViewBag.Tipo_de_Dietas_Tipo_Dieta = Tipo_de_Dietas_Tipo_Dieta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Dieta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISuplementosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Suplementoss_Suplementos = _ISuplementosApiConsumer.SelAll(true);
            if (Suplementoss_Suplementos != null && Suplementoss_Suplementos.Resource != null)
                ViewBag.Suplementoss_Suplementos = Suplementoss_Suplementos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Suplementos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_SalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Sals_Consumo_de_sal = _IPreferencias_SalApiConsumer.SelAll(true);
            if (Preferencias_Sals_Consumo_de_sal != null && Preferencias_Sals_Consumo_de_sal.Resource != null)
                ViewBag.Preferencias_Sals_Consumo_de_sal = Preferencias_Sals_Consumo_de_sal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Sal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_GrasasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Grasass_Grasas_Preferencias = _IPreferencias_GrasasApiConsumer.SelAll(true);
            if (Preferencias_Grasass_Grasas_Preferencias != null && Preferencias_Grasass_Grasas_Preferencias.Resource != null)
                ViewBag.Preferencias_Grasass_Grasas_Preferencias = Preferencias_Grasass_Grasas_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Grasas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICantidad_ComidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Cantidad_Comidass_Comidas_cantidad = _ICantidad_ComidasApiConsumer.SelAll(true);
            if (Cantidad_Comidass_Comidas_cantidad != null && Cantidad_Comidass_Comidas_cantidad.Resource != null)
                ViewBag.Cantidad_Comidass_Comidas_cantidad = Cantidad_Comidass_Comidas_cantidad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cantidad_Comidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_PreparacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Preparacions_Preparacion_Preferencias = _IPreferencias_PreparacionApiConsumer.SelAll(true);
            if (Preferencias_Preparacions_Preparacion_Preferencias != null && Preferencias_Preparacions_Preparacion_Preferencias.Resource != null)
                ViewBag.Preferencias_Preparacions_Preparacion_Preferencias = Preferencias_Preparacions_Preparacion_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Preparacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_EntrecomidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Entrecomidass_Entre_comidas = _IPreferencias_EntrecomidasApiConsumer.SelAll(true);
            if (Preferencias_Entrecomidass_Entre_comidas != null && Preferencias_Entrecomidass_Entre_comidas.Resource != null)
                ViewBag.Preferencias_Entrecomidass_Entre_comidas = Preferencias_Entrecomidass_Entre_comidas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Entrecomidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_SatisfaccionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Satisfaccions_Apetito = _INivel_de_SatisfaccionApiConsumer.SelAll(true);
            if (Nivel_de_Satisfaccions_Apetito != null && Nivel_de_Satisfaccions_Apetito.Resource != null)
                ViewBag.Nivel_de_Satisfaccions_Apetito = Nivel_de_Satisfaccions_Apetito.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nivel_de_Satisfaccion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_Modificacion_AlimentosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Modificacion_Alimentoss_Habitos_Modificacion = _ITipo_Modificacion_AlimentosApiConsumer.SelAll(true);
            if (Tipo_Modificacion_Alimentoss_Habitos_Modificacion != null && Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource != null)
                ViewBag.Tipo_Modificacion_Alimentoss_Habitos_Modificacion = Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Modificacion_Alimentos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPeriodo_del_diaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Periodo_del_dias_Horario_hambre = _IPeriodo_del_diaApiConsumer.SelAll(true);
            if (Periodo_del_dias_Horario_hambre != null && Periodo_del_dias_Horario_hambre.Resource != null)
                ViewBag.Periodo_del_dias_Horario_hambre = Periodo_del_dias_Horario_hambre.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Periodo_del_dia", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstado_de_AnimoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = _IEstado_de_AnimoApiConsumer.SelAll(true);
            if (Estado_de_Animos_Cuando_cambia_mi_estado_de_animo != null && Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource != null)
                ViewBag.Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_de_Animo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Medicamentos_bajar_peso = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Medicamentos_bajar_peso != null && Respuesta_Logicas_Medicamentos_bajar_peso.Resource != null)
                ViewBag.Respuesta_Logicas_Medicamentos_bajar_peso = Respuesta_Logicas_Medicamentos_bajar_peso.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IFrecuencia_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_Ejercicios_Frecuencia_Ejercicio = _IFrecuencia_EjercicioApiConsumer.SelAll(true);
            if (Frecuencia_Ejercicios_Frecuencia_Ejercicio != null && Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource != null)
                ViewBag.Frecuencia_Ejercicios_Frecuencia_Ejercicio = Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDuracion_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Duracion_Ejercicios_Duracion_Ejercicio = _IDuracion_EjercicioApiConsumer.SelAll(true);
            if (Duracion_Ejercicios_Duracion_Ejercicio != null && Duracion_Ejercicios_Duracion_Ejercicio.Resource != null)
                ViewBag.Duracion_Ejercicios_Duracion_Ejercicio = Duracion_Ejercicios_Duracion_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Duracion_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_Ejercicio != null && Tipo_Ejercicios_Tipo_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_Ejercicio = Tipo_Ejercicios_Tipo_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IAntiguedad_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Antiguedad_Ejercicioss_Antiguedad_Ejercicio = _IAntiguedad_EjerciciosApiConsumer.SelAll(true);
            if (Antiguedad_Ejercicioss_Antiguedad_Ejercicio != null && Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource != null)
                ViewBag.Antiguedad_Ejercicioss_Antiguedad_Ejercicio = Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Antiguedad_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_corporals_Interpretacion_complexion_corporal = _IInterpretacion_corporalApiConsumer.SelAll(true);
            if (Interpretacion_corporals_Interpretacion_complexion_corporal != null && Interpretacion_corporals_Interpretacion_complexion_corporal.Resource != null)
                ViewBag.Interpretacion_corporals_Interpretacion_complexion_corporal = Interpretacion_corporals_Interpretacion_complexion_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_distribucion_grasa_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = _IInterpretacion_distribucion_grasa_corporalApiConsumer.SelAll(true);
            if (Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal != null && Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource != null)
                ViewBag.Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_distribucion_grasa_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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
            _ITipo_de_RegistroApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Registros_Tipo_de_Registro = _ITipo_de_RegistroApiConsumer.SelAll(true);
            if (Tipo_de_Registros_Tipo_de_Registro != null && Tipo_de_Registros_Tipo_de_Registro.Resource != null)
                ViewBag.Tipo_de_Registros_Tipo_de_Registro = Tipo_de_Registros_Tipo_de_Registro.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Registro", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Pacientes_Tipo_de_Paciente = _ITipo_PacienteApiConsumer.SelAll(true);
            if (Tipo_Pacientes_Tipo_de_Paciente != null && Tipo_Pacientes_Tipo_de_Paciente.Resource != null)
                ViewBag.Tipo_Pacientes_Tipo_de_Paciente = Tipo_Pacientes_Tipo_de_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Paciente", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Lugar_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Lugar_de_nacimiento != null && Estados_Lugar_de_nacimiento.Resource != null)
                ViewBag.Estados_Lugar_de_nacimiento = Estados_Lugar_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
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
            _IEstado_CivilApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_Civils_Estado_Civil = _IEstado_CivilApiConsumer.SelAll(true);
            if (Estado_Civils_Estado_Civil != null && Estado_Civils_Estado_Civil.Resource != null)
                ViewBag.Estado_Civils_Estado_Civil = Estado_Civils_Estado_Civil.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_Civil", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_por_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_por_Suscripcions_Estatus_Paciente = _IEstatus_por_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_por_Suscripcions_Estatus_Paciente != null && Estatus_por_Suscripcions_Estatus_Paciente.Resource != null)
                ViewBag.Estatus_por_Suscripcions_Estatus_Paciente = Estatus_por_Suscripcions_Estatus_Paciente.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_por_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Cuenta_con_padecimientos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Cuenta_con_padecimientos != null && Respuesta_Logicas_Cuenta_con_padecimientos.Resource != null)
                ViewBag.Respuesta_Logicas_Cuenta_con_padecimientos = Respuesta_Logicas_Cuenta_con_padecimientos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Esta_embarazada = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Esta_embarazada != null && Respuesta_Logicas_Esta_embarazada.Resource != null)
                ViewBag.Respuesta_Logicas_Esta_embarazada = Respuesta_Logicas_Esta_embarazada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Toma_anticonceptivos = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Toma_anticonceptivos != null && Respuesta_Logicas_Toma_anticonceptivos.Resource != null)
                ViewBag.Respuesta_Logicas_Toma_anticonceptivos = Respuesta_Logicas_Toma_anticonceptivos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Climaterio = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Climaterio != null && Respuesta_Logicas_Climaterio.Resource != null)
                ViewBag.Respuesta_Logicas_Climaterio = Respuesta_Logicas_Climaterio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Terapia_reemplazo_hormonal = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Terapia_reemplazo_hormonal != null && Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource != null)
                ViewBag.Respuesta_Logicas_Terapia_reemplazo_hormonal = Respuesta_Logicas_Terapia_reemplazo_hormonal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_de_DietaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Dietas_Tipo_Dieta = _ITipo_de_DietaApiConsumer.SelAll(true);
            if (Tipo_de_Dietas_Tipo_Dieta != null && Tipo_de_Dietas_Tipo_Dieta.Resource != null)
                ViewBag.Tipo_de_Dietas_Tipo_Dieta = Tipo_de_Dietas_Tipo_Dieta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Dieta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISuplementosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Suplementoss_Suplementos = _ISuplementosApiConsumer.SelAll(true);
            if (Suplementoss_Suplementos != null && Suplementoss_Suplementos.Resource != null)
                ViewBag.Suplementoss_Suplementos = Suplementoss_Suplementos.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Suplementos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_SalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Sals_Consumo_de_sal = _IPreferencias_SalApiConsumer.SelAll(true);
            if (Preferencias_Sals_Consumo_de_sal != null && Preferencias_Sals_Consumo_de_sal.Resource != null)
                ViewBag.Preferencias_Sals_Consumo_de_sal = Preferencias_Sals_Consumo_de_sal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Sal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_GrasasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Grasass_Grasas_Preferencias = _IPreferencias_GrasasApiConsumer.SelAll(true);
            if (Preferencias_Grasass_Grasas_Preferencias != null && Preferencias_Grasass_Grasas_Preferencias.Resource != null)
                ViewBag.Preferencias_Grasass_Grasas_Preferencias = Preferencias_Grasass_Grasas_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Grasas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICantidad_ComidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Cantidad_Comidass_Comidas_cantidad = _ICantidad_ComidasApiConsumer.SelAll(true);
            if (Cantidad_Comidass_Comidas_cantidad != null && Cantidad_Comidass_Comidas_cantidad.Resource != null)
                ViewBag.Cantidad_Comidass_Comidas_cantidad = Cantidad_Comidass_Comidas_cantidad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cantidad_Comidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_PreparacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Preparacions_Preparacion_Preferencias = _IPreferencias_PreparacionApiConsumer.SelAll(true);
            if (Preferencias_Preparacions_Preparacion_Preferencias != null && Preferencias_Preparacions_Preparacion_Preferencias.Resource != null)
                ViewBag.Preferencias_Preparacions_Preparacion_Preferencias = Preferencias_Preparacions_Preparacion_Preferencias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Preparacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPreferencias_EntrecomidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Preferencias_Entrecomidass_Entre_comidas = _IPreferencias_EntrecomidasApiConsumer.SelAll(true);
            if (Preferencias_Entrecomidass_Entre_comidas != null && Preferencias_Entrecomidass_Entre_comidas.Resource != null)
                ViewBag.Preferencias_Entrecomidass_Entre_comidas = Preferencias_Entrecomidass_Entre_comidas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Preferencias_Entrecomidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_SatisfaccionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Satisfaccions_Apetito = _INivel_de_SatisfaccionApiConsumer.SelAll(true);
            if (Nivel_de_Satisfaccions_Apetito != null && Nivel_de_Satisfaccions_Apetito.Resource != null)
                ViewBag.Nivel_de_Satisfaccions_Apetito = Nivel_de_Satisfaccions_Apetito.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Nivel_de_Satisfaccion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_Modificacion_AlimentosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Modificacion_Alimentoss_Habitos_Modificacion = _ITipo_Modificacion_AlimentosApiConsumer.SelAll(true);
            if (Tipo_Modificacion_Alimentoss_Habitos_Modificacion != null && Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource != null)
                ViewBag.Tipo_Modificacion_Alimentoss_Habitos_Modificacion = Tipo_Modificacion_Alimentoss_Habitos_Modificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Modificacion_Alimentos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPeriodo_del_diaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Periodo_del_dias_Horario_hambre = _IPeriodo_del_diaApiConsumer.SelAll(true);
            if (Periodo_del_dias_Horario_hambre != null && Periodo_del_dias_Horario_hambre.Resource != null)
                ViewBag.Periodo_del_dias_Horario_hambre = Periodo_del_dias_Horario_hambre.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Periodo_del_dia", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstado_de_AnimoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = _IEstado_de_AnimoApiConsumer.SelAll(true);
            if (Estado_de_Animos_Cuando_cambia_mi_estado_de_animo != null && Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource != null)
                ViewBag.Estado_de_Animos_Cuando_cambia_mi_estado_de_animo = Estado_de_Animos_Cuando_cambia_mi_estado_de_animo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado_de_Animo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Medicamentos_bajar_peso = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Medicamentos_bajar_peso != null && Respuesta_Logicas_Medicamentos_bajar_peso.Resource != null)
                ViewBag.Respuesta_Logicas_Medicamentos_bajar_peso = Respuesta_Logicas_Medicamentos_bajar_peso.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IFrecuencia_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_Ejercicios_Frecuencia_Ejercicio = _IFrecuencia_EjercicioApiConsumer.SelAll(true);
            if (Frecuencia_Ejercicios_Frecuencia_Ejercicio != null && Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource != null)
                ViewBag.Frecuencia_Ejercicios_Frecuencia_Ejercicio = Frecuencia_Ejercicios_Frecuencia_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDuracion_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Duracion_Ejercicios_Duracion_Ejercicio = _IDuracion_EjercicioApiConsumer.SelAll(true);
            if (Duracion_Ejercicios_Duracion_Ejercicio != null && Duracion_Ejercicios_Duracion_Ejercicio.Resource != null)
                ViewBag.Duracion_Ejercicios_Duracion_Ejercicio = Duracion_Ejercicios_Duracion_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Duracion_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_Ejercicio != null && Tipo_Ejercicios_Tipo_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_Ejercicio = Tipo_Ejercicios_Tipo_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IAntiguedad_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Antiguedad_Ejercicioss_Antiguedad_Ejercicio = _IAntiguedad_EjerciciosApiConsumer.SelAll(true);
            if (Antiguedad_Ejercicioss_Antiguedad_Ejercicio != null && Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource != null)
                ViewBag.Antiguedad_Ejercicioss_Antiguedad_Ejercicio = Antiguedad_Ejercicioss_Antiguedad_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Antiguedad_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_corporals_Interpretacion_complexion_corporal = _IInterpretacion_corporalApiConsumer.SelAll(true);
            if (Interpretacion_corporals_Interpretacion_complexion_corporal != null && Interpretacion_corporals_Interpretacion_complexion_corporal.Resource != null)
                ViewBag.Interpretacion_corporals_Interpretacion_complexion_corporal = Interpretacion_corporals_Interpretacion_complexion_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_distribucion_grasa_corporalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = _IInterpretacion_distribucion_grasa_corporalApiConsumer.SelAll(true);
            if (Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal != null && Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource != null)
                ViewBag.Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal = Interpretacion_distribucion_grasa_corporals_Interpretacion_grasa_corporal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_distribucion_grasa_corporal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new PacientesAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (PacientesAdvanceSearchModel)(Session["AdvanceSearch"] ?? new PacientesAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new PacientesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IPacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Pacientess == null)
                result.Pacientess = new List<Pacientes>();

            return Json(new
            {
                data = result.Pacientess.Select(m => new PacientesGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Registro_Tipo_de_Registro.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                        ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Paciente_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Celular = m.Celular
			,Email = m.Email
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
			,Nombre_del_Padre_o_Tutor = m.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Lugar_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Estado_CivilDescripcion = CultureHelper.GetTraduction(m.Estado_Civil_Estado_Civil.Clave.ToString(), "Descripcion") ?? (string)m.Estado_Civil_Estado_Civil.Descripcion
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
			,Ocupacion = m.Ocupacion
			,Cantidad_hijos = m.Cantidad_hijos
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
                        ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(m.Estatus_Paciente_Estatus_por_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion
                        ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(m.Cuenta_con_padecimientos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Frecuencia_Respiratoria = m.Frecuencia_Respiratoria
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Peso_habitual = m.Peso_habitual
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Anchura_de_muneca_mm = m.Anchura_de_muneca_mm
			,Circunferencia_de_brazo_cm = m.Circunferencia_de_brazo_cm
			,Pliegue_cutaneo_tricipital_mm = m.Pliegue_cutaneo_tricipital_mm
			,Pliegue_cutaneo_bicipital_mm = m.Pliegue_cutaneo_bicipital_mm
			,Pliegue_cutaneo_subescapular_mm = m.Pliegue_cutaneo_subescapular_mm
			,Pliegue_cutaneo_supraespinal_mm = m.Pliegue_cutaneo_supraespinal_mm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Masa_Muscular_ = m.Masa_Muscular_
                        ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(m.Esta_embarazada_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Esta_embarazada_Respuesta_Logica.Descripcion
			,Semana_de_gestacion = m.Semana_de_gestacion
			,Peso_pregestacional = m.Peso_pregestacional
                        ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(m.Toma_anticonceptivos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Toma_anticonceptivos_Respuesta_Logica.Descripcion
			,Nombre_del_Anticonceptivo = m.Nombre_del_Anticonceptivo
			,Dosis = m.Dosis
                        ,ClimaterioDescripcion = CultureHelper.GetTraduction(m.Climaterio_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Climaterio_Respuesta_Logica.Descripcion
                        ,Fecha_Climaterio = (m.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(m.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                        ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(m.Terapia_reemplazo_hormonal_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion
                        ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(m.Tipo_Dieta_Tipo_de_Dieta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                        ,SuplementosDescripcion = CultureHelper.GetTraduction(m.Suplementos_Suplementos.Clave.ToString(), "Descripcion") ?? (string)m.Suplementos_Suplementos.Descripcion
                        ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(m.Consumo_de_sal_Preferencias_Sal.Clave.ToString(), "Descripcion") ?? (string)m.Consumo_de_sal_Preferencias_Sal.Descripcion
                        ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Grasas_Preferencias_Preferencias_Grasas.Clave.ToString(), "Descripcion") ?? (string)m.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                        ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(m.Comidas_cantidad_Cantidad_Comidas.Clave.ToString(), "Descripcion") ?? (string)m.Comidas_cantidad_Cantidad_Comidas.Descripcion
                        ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Preparacion_Preferencias_Preferencias_Preparacion.Clave.ToString(), "Descripcion") ?? (string)m.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                        ,Entre_comidasDescripcion = CultureHelper.GetTraduction(m.Entre_comidas_Preferencias_Entrecomidas.Clave.ToString(), "Descripcion") ?? (string)m.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                        ,ApetitoDescripcion = CultureHelper.GetTraduction(m.Apetito_Nivel_de_Satisfaccion.Clave.ToString(), "Descripcion") ?? (string)m.Apetito_Nivel_de_Satisfaccion.Descripcion
                        ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Clave.ToString(), "Descripcion") ?? (string)m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                        ,Horario_hambreDescripcion = CultureHelper.GetTraduction(m.Horario_hambre_Periodo_del_dia.Clave.ToString(), "Descripcion") ?? (string)m.Horario_hambre_Periodo_del_dia.Descripcion
                        ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Clave.ToString(), "Descripcion") ?? (string)m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                        ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(m.Medicamentos_bajar_peso_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
			,Cual_medicamento = m.Cual_medicamento
                        ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                        ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(m.Duracion_Ejercicio_Duracion_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                        ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Clave.ToString(), "Descripcion") ?? (string)m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion
			,IMC = m.IMC
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
			,Complexion_corporal = m.Complexion_corporal
                        ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_complexion_corporal_Interpretacion_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
			,Distribucion_de_grasa_corporal = m.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetPacientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPacientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Pacientes", m.),
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
        /// Get List of Pacientes from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Pacientes Entity</returns>
        public ActionResult GetPacientesList(UrlParametersModel param)
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
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new PacientesPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(PacientesAdvanceSearchModel))
                {
					var advanceFilter =
                    (PacientesAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            PacientesPropertyMapper oPacientesPropertyMapper = new PacientesPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oPacientesPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IPacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Pacientess == null)
                result.Pacientess = new List<Pacientes>();

            return Json(new
            {
                aaData = result.Pacientess.Select(m => new PacientesGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Registro_Tipo_de_Registro.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                        ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Paciente_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Celular = m.Celular
			,Email = m.Email
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
			,Nombre_del_Padre_o_Tutor = m.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Lugar_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Estado_CivilDescripcion = CultureHelper.GetTraduction(m.Estado_Civil_Estado_Civil.Clave.ToString(), "Descripcion") ?? (string)m.Estado_Civil_Estado_Civil.Descripcion
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
			,Ocupacion = m.Ocupacion
			,Cantidad_hijos = m.Cantidad_hijos
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
                        ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(m.Estatus_Paciente_Estatus_por_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion
                        ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(m.Cuenta_con_padecimientos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Frecuencia_Respiratoria = m.Frecuencia_Respiratoria
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Peso_habitual = m.Peso_habitual
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Anchura_de_muneca_mm = m.Anchura_de_muneca_mm
			,Circunferencia_de_brazo_cm = m.Circunferencia_de_brazo_cm
			,Pliegue_cutaneo_tricipital_mm = m.Pliegue_cutaneo_tricipital_mm
			,Pliegue_cutaneo_bicipital_mm = m.Pliegue_cutaneo_bicipital_mm
			,Pliegue_cutaneo_subescapular_mm = m.Pliegue_cutaneo_subescapular_mm
			,Pliegue_cutaneo_supraespinal_mm = m.Pliegue_cutaneo_supraespinal_mm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Masa_Muscular_ = m.Masa_Muscular_
                        ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(m.Esta_embarazada_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Esta_embarazada_Respuesta_Logica.Descripcion
			,Semana_de_gestacion = m.Semana_de_gestacion
			,Peso_pregestacional = m.Peso_pregestacional
                        ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(m.Toma_anticonceptivos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Toma_anticonceptivos_Respuesta_Logica.Descripcion
			,Nombre_del_Anticonceptivo = m.Nombre_del_Anticonceptivo
			,Dosis = m.Dosis
                        ,ClimaterioDescripcion = CultureHelper.GetTraduction(m.Climaterio_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Climaterio_Respuesta_Logica.Descripcion
                        ,Fecha_Climaterio = (m.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(m.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                        ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(m.Terapia_reemplazo_hormonal_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion
                        ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(m.Tipo_Dieta_Tipo_de_Dieta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                        ,SuplementosDescripcion = CultureHelper.GetTraduction(m.Suplementos_Suplementos.Clave.ToString(), "Descripcion") ?? (string)m.Suplementos_Suplementos.Descripcion
                        ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(m.Consumo_de_sal_Preferencias_Sal.Clave.ToString(), "Descripcion") ?? (string)m.Consumo_de_sal_Preferencias_Sal.Descripcion
                        ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Grasas_Preferencias_Preferencias_Grasas.Clave.ToString(), "Descripcion") ?? (string)m.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                        ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(m.Comidas_cantidad_Cantidad_Comidas.Clave.ToString(), "Descripcion") ?? (string)m.Comidas_cantidad_Cantidad_Comidas.Descripcion
                        ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Preparacion_Preferencias_Preferencias_Preparacion.Clave.ToString(), "Descripcion") ?? (string)m.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                        ,Entre_comidasDescripcion = CultureHelper.GetTraduction(m.Entre_comidas_Preferencias_Entrecomidas.Clave.ToString(), "Descripcion") ?? (string)m.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                        ,ApetitoDescripcion = CultureHelper.GetTraduction(m.Apetito_Nivel_de_Satisfaccion.Clave.ToString(), "Descripcion") ?? (string)m.Apetito_Nivel_de_Satisfaccion.Descripcion
                        ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Clave.ToString(), "Descripcion") ?? (string)m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                        ,Horario_hambreDescripcion = CultureHelper.GetTraduction(m.Horario_hambre_Periodo_del_dia.Clave.ToString(), "Descripcion") ?? (string)m.Horario_hambre_Periodo_del_dia.Descripcion
                        ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Clave.ToString(), "Descripcion") ?? (string)m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                        ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(m.Medicamentos_bajar_peso_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
			,Cual_medicamento = m.Cual_medicamento
                        ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                        ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(m.Duracion_Ejercicio_Duracion_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                        ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Clave.ToString(), "Descripcion") ?? (string)m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion
			,IMC = m.IMC
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
			,Complexion_corporal = m.Complexion_corporal
                        ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_complexion_corporal_Interpretacion_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
			,Distribucion_de_grasa_corporal = m.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(PacientesAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Pacientes.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Pacientes.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Pacientes.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Pacientes.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Pacientes.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Pacientes.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Pacientes.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Registro))
            {
                switch (filter.Tipo_de_RegistroFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Registro.Descripcion LIKE '" + filter.AdvanceTipo_de_Registro + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Registro.Descripcion LIKE '%" + filter.AdvanceTipo_de_Registro + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Registro.Descripcion = '" + filter.AdvanceTipo_de_Registro + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Registro.Descripcion LIKE '%" + filter.AdvanceTipo_de_Registro + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_RegistroMultiple != null && filter.AdvanceTipo_de_RegistroMultiple.Count() > 0)
            {
                var Tipo_de_RegistroIds = string.Join(",", filter.AdvanceTipo_de_RegistroMultiple);

                where += " AND Pacientes.Tipo_de_Registro In (" + Tipo_de_RegistroIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Paciente))
            {
                switch (filter.Tipo_de_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_Paciente.Descripcion LIKE '" + filter.AdvanceTipo_de_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_Paciente.Descripcion LIKE '%" + filter.AdvanceTipo_de_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_Paciente.Descripcion = '" + filter.AdvanceTipo_de_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_Paciente.Descripcion LIKE '%" + filter.AdvanceTipo_de_Paciente + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_PacienteMultiple != null && filter.AdvanceTipo_de_PacienteMultiple.Count() > 0)
            {
                var Tipo_de_PacienteIds = string.Join(",", filter.AdvanceTipo_de_PacienteMultiple);

                where += " AND Pacientes.Tipo_de_Paciente In (" + Tipo_de_PacienteIds + ")";
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

                where += " AND Pacientes.Usuario_Registrado In (" + Usuario_RegistradoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEmpresa))
            {
                switch (filter.EmpresaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '" + filter.AdvanceEmpresa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.AdvanceEmpresa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombre_de_la_Empresa = '" + filter.AdvanceEmpresa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.AdvanceEmpresa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEmpresaMultiple != null && filter.AdvanceEmpresaMultiple.Count() > 0)
            {
                var EmpresaIds = string.Join(",", filter.AdvanceEmpresaMultiple);

                where += " AND Pacientes.Empresa In (" + EmpresaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Numero_de_Empleado))
            {
                switch (filter.Numero_de_EmpleadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Numero_de_Empleado LIKE '" + filter.Numero_de_Empleado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Numero_de_Empleado LIKE '%" + filter.Numero_de_Empleado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Numero_de_Empleado = '" + filter.Numero_de_Empleado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Numero_de_Empleado LIKE '%" + filter.Numero_de_Empleado + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombres))
            {
                switch (filter.NombresFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombres LIKE '" + filter.Nombres + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombres LIKE '%" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombres = '" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombres LIKE '%" + filter.Nombres + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Paterno))
            {
                switch (filter.Apellido_PaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Apellido_Paterno LIKE '" + filter.Apellido_Paterno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Apellido_Paterno = '" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Materno))
            {
                switch (filter.Apellido_MaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Apellido_Materno LIKE '" + filter.Apellido_Materno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Apellido_Materno = '" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Completo))
            {
                switch (filter.Nombre_CompletoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '" + filter.Nombre_Completo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombre_Completo = '" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Celular))
            {
                switch (filter.CelularFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Celular LIKE '" + filter.Celular + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Celular LIKE '%" + filter.Celular + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Celular = '" + filter.Celular + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Celular LIKE '%" + filter.Celular + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Email LIKE '%" + filter.Email + "%'";
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
                    where += " AND Pacientes.Fecha_de_nacimiento >= '" + Fecha_de_nacimientoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_nacimiento))
                    where += " AND Pacientes.Fecha_de_nacimiento <= '" + Fecha_de_nacimientoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Padre_o_Tutor))
            {
                switch (filter.Nombre_del_Padre_o_TutorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombre_del_Padre_o_Tutor LIKE '" + filter.Nombre_del_Padre_o_Tutor + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombre_del_Padre_o_Tutor LIKE '%" + filter.Nombre_del_Padre_o_Tutor + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombre_del_Padre_o_Tutor = '" + filter.Nombre_del_Padre_o_Tutor + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombre_del_Padre_o_Tutor LIKE '%" + filter.Nombre_del_Padre_o_Tutor + "%'";
                        break;
                }
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

                where += " AND Pacientes.Pais_de_nacimiento In (" + Pais_de_nacimientoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceLugar_de_nacimiento))
            {
                switch (filter.Lugar_de_nacimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceLugar_de_nacimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceLugar_de_nacimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceLugar_de_nacimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceLugar_de_nacimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvanceLugar_de_nacimientoMultiple != null && filter.AdvanceLugar_de_nacimientoMultiple.Count() > 0)
            {
                var Lugar_de_nacimientoIds = string.Join(",", filter.AdvanceLugar_de_nacimientoMultiple);

                where += " AND Pacientes.Lugar_de_nacimiento In (" + Lugar_de_nacimientoIds + ")";
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

                where += " AND Pacientes.Sexo In (" + SexoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstado_Civil))
            {
                switch (filter.Estado_CivilFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado_Civil.Descripcion LIKE '" + filter.AdvanceEstado_Civil + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado_Civil.Descripcion LIKE '%" + filter.AdvanceEstado_Civil + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado_Civil.Descripcion = '" + filter.AdvanceEstado_Civil + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado_Civil.Descripcion LIKE '%" + filter.AdvanceEstado_Civil + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstado_CivilMultiple != null && filter.AdvanceEstado_CivilMultiple.Count() > 0)
            {
                var Estado_CivilIds = string.Join(",", filter.AdvanceEstado_CivilMultiple);

                where += " AND Pacientes.Estado_Civil In (" + Estado_CivilIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Calle))
            {
                switch (filter.CalleFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Calle LIKE '" + filter.Calle + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Calle LIKE '%" + filter.Calle + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Calle = '" + filter.Calle + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Calle LIKE '%" + filter.Calle + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_exterior))
            {
                switch (filter.Numero_exteriorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Numero_exterior LIKE '" + filter.Numero_exterior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Numero_exterior LIKE '%" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Numero_exterior = '" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Numero_exterior LIKE '%" + filter.Numero_exterior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_interior))
            {
                switch (filter.Numero_interiorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Numero_interior LIKE '" + filter.Numero_interior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Numero_interior LIKE '%" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Numero_interior = '" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Numero_interior LIKE '%" + filter.Numero_interior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Colonia))
            {
                switch (filter.ColoniaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Colonia LIKE '" + filter.Colonia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Colonia LIKE '%" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Colonia = '" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Colonia LIKE '%" + filter.Colonia + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCP) || !string.IsNullOrEmpty(filter.ToCP))
            {
                if (!string.IsNullOrEmpty(filter.FromCP))
                    where += " AND Pacientes.CP >= " + filter.FromCP;
                if (!string.IsNullOrEmpty(filter.ToCP))
                    where += " AND Pacientes.CP <= " + filter.ToCP;
            }

            if (!string.IsNullOrEmpty(filter.Ciudad))
            {
                switch (filter.CiudadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Ciudad LIKE '" + filter.Ciudad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Ciudad LIKE '%" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Ciudad = '" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Ciudad LIKE '%" + filter.Ciudad + "%'";
                        break;
                }
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

                where += " AND Pacientes.Pais In (" + PaisIds + ")";
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

                where += " AND Pacientes.Estado In (" + EstadoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Ocupacion))
            {
                switch (filter.OcupacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Ocupacion LIKE '" + filter.Ocupacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Ocupacion LIKE '%" + filter.Ocupacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Ocupacion = '" + filter.Ocupacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Ocupacion LIKE '%" + filter.Ocupacion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCantidad_hijos) || !string.IsNullOrEmpty(filter.ToCantidad_hijos))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_hijos))
                    where += " AND Pacientes.Cantidad_hijos >= " + filter.FromCantidad_hijos;
                if (!string.IsNullOrEmpty(filter.ToCantidad_hijos))
                    where += " AND Pacientes.Cantidad_hijos <= " + filter.ToCantidad_hijos;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObjetivo))
            {
                switch (filter.ObjetivoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Objetivos.Descripcion LIKE '" + filter.AdvanceObjetivo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Objetivos.Descripcion LIKE '%" + filter.AdvanceObjetivo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Objetivos.Descripcion = '" + filter.AdvanceObjetivo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Objetivos.Descripcion LIKE '%" + filter.AdvanceObjetivo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObjetivoMultiple != null && filter.AdvanceObjetivoMultiple.Count() > 0)
            {
                var ObjetivoIds = string.Join(",", filter.AdvanceObjetivoMultiple);

                where += " AND Pacientes.Objetivo In (" + ObjetivoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus_Paciente))
            {
                switch (filter.Estatus_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_por_Suscripcion.Descripcion LIKE '" + filter.AdvanceEstatus_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_por_Suscripcion.Descripcion LIKE '%" + filter.AdvanceEstatus_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_por_Suscripcion.Descripcion = '" + filter.AdvanceEstatus_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_por_Suscripcion.Descripcion LIKE '%" + filter.AdvanceEstatus_Paciente + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatus_PacienteMultiple != null && filter.AdvanceEstatus_PacienteMultiple.Count() > 0)
            {
                var Estatus_PacienteIds = string.Join(",", filter.AdvanceEstatus_PacienteMultiple);

                where += " AND Pacientes.Estatus_Paciente In (" + Estatus_PacienteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCuenta_con_padecimientos))
            {
                switch (filter.Cuenta_con_padecimientosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceCuenta_con_padecimientos + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceCuenta_con_padecimientos + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceCuenta_con_padecimientos + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceCuenta_con_padecimientos + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCuenta_con_padecimientosMultiple != null && filter.AdvanceCuenta_con_padecimientosMultiple.Count() > 0)
            {
                var Cuenta_con_padecimientosIds = string.Join(",", filter.AdvanceCuenta_con_padecimientosMultiple);

                where += " AND Pacientes.Cuenta_con_padecimientos In (" + Cuenta_con_padecimientosIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFrecuencia_Cardiaca) || !string.IsNullOrEmpty(filter.ToFrecuencia_Cardiaca))
            {
                if (!string.IsNullOrEmpty(filter.FromFrecuencia_Cardiaca))
                    where += " AND Pacientes.Frecuencia_Cardiaca >= " + filter.FromFrecuencia_Cardiaca;
                if (!string.IsNullOrEmpty(filter.ToFrecuencia_Cardiaca))
                    where += " AND Pacientes.Frecuencia_Cardiaca <= " + filter.ToFrecuencia_Cardiaca;
            }

            if (!string.IsNullOrEmpty(filter.FromFrecuencia_Respiratoria) || !string.IsNullOrEmpty(filter.ToFrecuencia_Respiratoria))
            {
                if (!string.IsNullOrEmpty(filter.FromFrecuencia_Respiratoria))
                    where += " AND Pacientes.Frecuencia_Respiratoria >= " + filter.FromFrecuencia_Respiratoria;
                if (!string.IsNullOrEmpty(filter.ToFrecuencia_Respiratoria))
                    where += " AND Pacientes.Frecuencia_Respiratoria <= " + filter.ToFrecuencia_Respiratoria;
            }

            if (!string.IsNullOrEmpty(filter.FromPresion_sistolica) || !string.IsNullOrEmpty(filter.ToPresion_sistolica))
            {
                if (!string.IsNullOrEmpty(filter.FromPresion_sistolica))
                    where += " AND Pacientes.Presion_sistolica >= " + filter.FromPresion_sistolica;
                if (!string.IsNullOrEmpty(filter.ToPresion_sistolica))
                    where += " AND Pacientes.Presion_sistolica <= " + filter.ToPresion_sistolica;
            }

            if (!string.IsNullOrEmpty(filter.FromPresion_diastolica) || !string.IsNullOrEmpty(filter.ToPresion_diastolica))
            {
                if (!string.IsNullOrEmpty(filter.FromPresion_diastolica))
                    where += " AND Pacientes.Presion_diastolica >= " + filter.FromPresion_diastolica;
                if (!string.IsNullOrEmpty(filter.ToPresion_diastolica))
                    where += " AND Pacientes.Presion_diastolica <= " + filter.ToPresion_diastolica;
            }

            if (!string.IsNullOrEmpty(filter.FromPeso_actual) || !string.IsNullOrEmpty(filter.ToPeso_actual))
            {
                if (!string.IsNullOrEmpty(filter.FromPeso_actual))
                    where += " AND Pacientes.Peso_actual >= " + filter.FromPeso_actual;
                if (!string.IsNullOrEmpty(filter.ToPeso_actual))
                    where += " AND Pacientes.Peso_actual <= " + filter.ToPeso_actual;
            }

            if (!string.IsNullOrEmpty(filter.FromEstatura) || !string.IsNullOrEmpty(filter.ToEstatura))
            {
                if (!string.IsNullOrEmpty(filter.FromEstatura))
                    where += " AND Pacientes.Estatura >= " + filter.FromEstatura;
                if (!string.IsNullOrEmpty(filter.ToEstatura))
                    where += " AND Pacientes.Estatura <= " + filter.ToEstatura;
            }

            if (!string.IsNullOrEmpty(filter.FromPeso_habitual) || !string.IsNullOrEmpty(filter.ToPeso_habitual))
            {
                if (!string.IsNullOrEmpty(filter.FromPeso_habitual))
                    where += " AND Pacientes.Peso_habitual >= " + filter.FromPeso_habitual;
                if (!string.IsNullOrEmpty(filter.ToPeso_habitual))
                    where += " AND Pacientes.Peso_habitual <= " + filter.ToPeso_habitual;
            }

            if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cintura_cm) || !string.IsNullOrEmpty(filter.ToCircunferencia_de_cintura_cm))
            {
                if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cintura_cm))
                    where += " AND Pacientes.Circunferencia_de_cintura_cm >= " + filter.FromCircunferencia_de_cintura_cm;
                if (!string.IsNullOrEmpty(filter.ToCircunferencia_de_cintura_cm))
                    where += " AND Pacientes.Circunferencia_de_cintura_cm <= " + filter.ToCircunferencia_de_cintura_cm;
            }

            if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cadera_cm) || !string.IsNullOrEmpty(filter.ToCircunferencia_de_cadera_cm))
            {
                if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cadera_cm))
                    where += " AND Pacientes.Circunferencia_de_cadera_cm >= " + filter.FromCircunferencia_de_cadera_cm;
                if (!string.IsNullOrEmpty(filter.ToCircunferencia_de_cadera_cm))
                    where += " AND Pacientes.Circunferencia_de_cadera_cm <= " + filter.ToCircunferencia_de_cadera_cm;
            }

            if (!string.IsNullOrEmpty(filter.FromAnchura_de_muneca_mm) || !string.IsNullOrEmpty(filter.ToAnchura_de_muneca_mm))
            {
                if (!string.IsNullOrEmpty(filter.FromAnchura_de_muneca_mm))
                    where += " AND Pacientes.Anchura_de_muneca_mm >= " + filter.FromAnchura_de_muneca_mm;
                if (!string.IsNullOrEmpty(filter.ToAnchura_de_muneca_mm))
                    where += " AND Pacientes.Anchura_de_muneca_mm <= " + filter.ToAnchura_de_muneca_mm;
            }

            if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_brazo_cm) || !string.IsNullOrEmpty(filter.ToCircunferencia_de_brazo_cm))
            {
                if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_brazo_cm))
                    where += " AND Pacientes.Circunferencia_de_brazo_cm >= " + filter.FromCircunferencia_de_brazo_cm;
                if (!string.IsNullOrEmpty(filter.ToCircunferencia_de_brazo_cm))
                    where += " AND Pacientes.Circunferencia_de_brazo_cm <= " + filter.ToCircunferencia_de_brazo_cm;
            }

            if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_tricipital_mm) || !string.IsNullOrEmpty(filter.ToPliegue_cutaneo_tricipital_mm))
            {
                if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_tricipital_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_tricipital_mm >= " + filter.FromPliegue_cutaneo_tricipital_mm;
                if (!string.IsNullOrEmpty(filter.ToPliegue_cutaneo_tricipital_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_tricipital_mm <= " + filter.ToPliegue_cutaneo_tricipital_mm;
            }

            if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_bicipital_mm) || !string.IsNullOrEmpty(filter.ToPliegue_cutaneo_bicipital_mm))
            {
                if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_bicipital_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_bicipital_mm >= " + filter.FromPliegue_cutaneo_bicipital_mm;
                if (!string.IsNullOrEmpty(filter.ToPliegue_cutaneo_bicipital_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_bicipital_mm <= " + filter.ToPliegue_cutaneo_bicipital_mm;
            }

            if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_subescapular_mm) || !string.IsNullOrEmpty(filter.ToPliegue_cutaneo_subescapular_mm))
            {
                if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_subescapular_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_subescapular_mm >= " + filter.FromPliegue_cutaneo_subescapular_mm;
                if (!string.IsNullOrEmpty(filter.ToPliegue_cutaneo_subescapular_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_subescapular_mm <= " + filter.ToPliegue_cutaneo_subescapular_mm;
            }

            if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_supraespinal_mm) || !string.IsNullOrEmpty(filter.ToPliegue_cutaneo_supraespinal_mm))
            {
                if (!string.IsNullOrEmpty(filter.FromPliegue_cutaneo_supraespinal_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_supraespinal_mm >= " + filter.FromPliegue_cutaneo_supraespinal_mm;
                if (!string.IsNullOrEmpty(filter.ToPliegue_cutaneo_supraespinal_mm))
                    where += " AND Pacientes.Pliegue_cutaneo_supraespinal_mm <= " + filter.ToPliegue_cutaneo_supraespinal_mm;
            }

            if (!string.IsNullOrEmpty(filter.FromEdad_Metabolica) || !string.IsNullOrEmpty(filter.ToEdad_Metabolica))
            {
                if (!string.IsNullOrEmpty(filter.FromEdad_Metabolica))
                    where += " AND Pacientes.Edad_Metabolica >= " + filter.FromEdad_Metabolica;
                if (!string.IsNullOrEmpty(filter.ToEdad_Metabolica))
                    where += " AND Pacientes.Edad_Metabolica <= " + filter.ToEdad_Metabolica;
            }

            if (!string.IsNullOrEmpty(filter.FromAgua_corporal) || !string.IsNullOrEmpty(filter.ToAgua_corporal))
            {
                if (!string.IsNullOrEmpty(filter.FromAgua_corporal))
                    where += " AND Pacientes.Agua_corporal >= " + filter.FromAgua_corporal;
                if (!string.IsNullOrEmpty(filter.ToAgua_corporal))
                    where += " AND Pacientes.Agua_corporal <= " + filter.ToAgua_corporal;
            }

            if (!string.IsNullOrEmpty(filter.FromGrasa_Visceral) || !string.IsNullOrEmpty(filter.ToGrasa_Visceral))
            {
                if (!string.IsNullOrEmpty(filter.FromGrasa_Visceral))
                    where += " AND Pacientes.Grasa_Visceral >= " + filter.FromGrasa_Visceral;
                if (!string.IsNullOrEmpty(filter.ToGrasa_Visceral))
                    where += " AND Pacientes.Grasa_Visceral <= " + filter.ToGrasa_Visceral;
            }

            if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal) || !string.IsNullOrEmpty(filter.ToGrasa_Corporal))
            {
                if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal))
                    where += " AND Pacientes.Grasa_Corporal >= " + filter.FromGrasa_Corporal;
                if (!string.IsNullOrEmpty(filter.ToGrasa_Corporal))
                    where += " AND Pacientes.Grasa_Corporal <= " + filter.ToGrasa_Corporal;
            }

            if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal_kg) || !string.IsNullOrEmpty(filter.ToGrasa_Corporal_kg))
            {
                if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal_kg))
                    where += " AND Pacientes.Grasa_Corporal_kg >= " + filter.FromGrasa_Corporal_kg;
                if (!string.IsNullOrEmpty(filter.ToGrasa_Corporal_kg))
                    where += " AND Pacientes.Grasa_Corporal_kg <= " + filter.ToGrasa_Corporal_kg;
            }

            if (!string.IsNullOrEmpty(filter.FromMasa_Muscular_kg) || !string.IsNullOrEmpty(filter.ToMasa_Muscular_kg))
            {
                if (!string.IsNullOrEmpty(filter.FromMasa_Muscular_kg))
                    where += " AND Pacientes.Masa_Muscular_kg >= " + filter.FromMasa_Muscular_kg;
                if (!string.IsNullOrEmpty(filter.ToMasa_Muscular_kg))
                    where += " AND Pacientes.Masa_Muscular_kg <= " + filter.ToMasa_Muscular_kg;
            }

            if (!string.IsNullOrEmpty(filter.FromMasa_Muscular_) || !string.IsNullOrEmpty(filter.ToMasa_Muscular_))
            {
                if (!string.IsNullOrEmpty(filter.FromMasa_Muscular_))
                    where += " AND Pacientes.Masa_Muscular_ >= " + filter.FromMasa_Muscular_;
                if (!string.IsNullOrEmpty(filter.ToMasa_Muscular_))
                    where += " AND Pacientes.Masa_Muscular_ <= " + filter.ToMasa_Muscular_;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEsta_embarazada))
            {
                switch (filter.Esta_embarazadaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceEsta_embarazada + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEsta_embarazada + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceEsta_embarazada + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceEsta_embarazada + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEsta_embarazadaMultiple != null && filter.AdvanceEsta_embarazadaMultiple.Count() > 0)
            {
                var Esta_embarazadaIds = string.Join(",", filter.AdvanceEsta_embarazadaMultiple);

                where += " AND Pacientes.Esta_embarazada In (" + Esta_embarazadaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromSemana_de_gestacion) || !string.IsNullOrEmpty(filter.ToSemana_de_gestacion))
            {
                if (!string.IsNullOrEmpty(filter.FromSemana_de_gestacion))
                    where += " AND Pacientes.Semana_de_gestacion >= " + filter.FromSemana_de_gestacion;
                if (!string.IsNullOrEmpty(filter.ToSemana_de_gestacion))
                    where += " AND Pacientes.Semana_de_gestacion <= " + filter.ToSemana_de_gestacion;
            }

            if (!string.IsNullOrEmpty(filter.FromPeso_pregestacional) || !string.IsNullOrEmpty(filter.ToPeso_pregestacional))
            {
                if (!string.IsNullOrEmpty(filter.FromPeso_pregestacional))
                    where += " AND Pacientes.Peso_pregestacional >= " + filter.FromPeso_pregestacional;
                if (!string.IsNullOrEmpty(filter.ToPeso_pregestacional))
                    where += " AND Pacientes.Peso_pregestacional <= " + filter.ToPeso_pregestacional;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceToma_anticonceptivos))
            {
                switch (filter.Toma_anticonceptivosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceToma_anticonceptivos + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceToma_anticonceptivos + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceToma_anticonceptivos + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceToma_anticonceptivos + "%'";
                        break;
                }
            }
            else if (filter.AdvanceToma_anticonceptivosMultiple != null && filter.AdvanceToma_anticonceptivosMultiple.Count() > 0)
            {
                var Toma_anticonceptivosIds = string.Join(",", filter.AdvanceToma_anticonceptivosMultiple);

                where += " AND Pacientes.Toma_anticonceptivos In (" + Toma_anticonceptivosIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Anticonceptivo))
            {
                switch (filter.Nombre_del_AnticonceptivoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombre_del_Anticonceptivo LIKE '" + filter.Nombre_del_Anticonceptivo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombre_del_Anticonceptivo LIKE '%" + filter.Nombre_del_Anticonceptivo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombre_del_Anticonceptivo = '" + filter.Nombre_del_Anticonceptivo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombre_del_Anticonceptivo LIKE '%" + filter.Nombre_del_Anticonceptivo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Dosis))
            {
                switch (filter.DosisFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Dosis LIKE '" + filter.Dosis + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Dosis LIKE '%" + filter.Dosis + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Dosis = '" + filter.Dosis + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Dosis LIKE '%" + filter.Dosis + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceClimaterio))
            {
                switch (filter.ClimaterioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceClimaterio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceClimaterio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceClimaterio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceClimaterio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceClimaterioMultiple != null && filter.AdvanceClimaterioMultiple.Count() > 0)
            {
                var ClimaterioIds = string.Join(",", filter.AdvanceClimaterioMultiple);

                where += " AND Pacientes.Climaterio In (" + ClimaterioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_Climaterio) || !string.IsNullOrEmpty(filter.ToFecha_Climaterio))
            {
                var Fecha_ClimaterioFrom = DateTime.ParseExact(filter.FromFecha_Climaterio, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_ClimaterioTo = DateTime.ParseExact(filter.ToFecha_Climaterio, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_Climaterio))
                    where += " AND Pacientes.Fecha_Climaterio >= '" + Fecha_ClimaterioFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_Climaterio))
                    where += " AND Pacientes.Fecha_Climaterio <= '" + Fecha_ClimaterioTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTerapia_reemplazo_hormonal))
            {
                switch (filter.Terapia_reemplazo_hormonalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceTerapia_reemplazo_hormonal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceTerapia_reemplazo_hormonal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceTerapia_reemplazo_hormonal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceTerapia_reemplazo_hormonal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTerapia_reemplazo_hormonalMultiple != null && filter.AdvanceTerapia_reemplazo_hormonalMultiple.Count() > 0)
            {
                var Terapia_reemplazo_hormonalIds = string.Join(",", filter.AdvanceTerapia_reemplazo_hormonalMultiple);

                where += " AND Pacientes.Terapia_reemplazo_hormonal In (" + Terapia_reemplazo_hormonalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_Dieta))
            {
                switch (filter.Tipo_DietaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Dieta.Descripcion LIKE '" + filter.AdvanceTipo_Dieta + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Dieta.Descripcion LIKE '%" + filter.AdvanceTipo_Dieta + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Dieta.Descripcion = '" + filter.AdvanceTipo_Dieta + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Dieta.Descripcion LIKE '%" + filter.AdvanceTipo_Dieta + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_DietaMultiple != null && filter.AdvanceTipo_DietaMultiple.Count() > 0)
            {
                var Tipo_DietaIds = string.Join(",", filter.AdvanceTipo_DietaMultiple);

                where += " AND Pacientes.Tipo_Dieta In (" + Tipo_DietaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSuplementos))
            {
                switch (filter.SuplementosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Suplementos.Descripcion LIKE '" + filter.AdvanceSuplementos + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Suplementos.Descripcion LIKE '%" + filter.AdvanceSuplementos + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Suplementos.Descripcion = '" + filter.AdvanceSuplementos + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Suplementos.Descripcion LIKE '%" + filter.AdvanceSuplementos + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSuplementosMultiple != null && filter.AdvanceSuplementosMultiple.Count() > 0)
            {
                var SuplementosIds = string.Join(",", filter.AdvanceSuplementosMultiple);

                where += " AND Pacientes.Suplementos In (" + SuplementosIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceConsumo_de_sal))
            {
                switch (filter.Consumo_de_salFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Preferencias_Sal.Descripcion LIKE '" + filter.AdvanceConsumo_de_sal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Preferencias_Sal.Descripcion LIKE '%" + filter.AdvanceConsumo_de_sal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Preferencias_Sal.Descripcion = '" + filter.AdvanceConsumo_de_sal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Preferencias_Sal.Descripcion LIKE '%" + filter.AdvanceConsumo_de_sal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceConsumo_de_salMultiple != null && filter.AdvanceConsumo_de_salMultiple.Count() > 0)
            {
                var Consumo_de_salIds = string.Join(",", filter.AdvanceConsumo_de_salMultiple);

                where += " AND Pacientes.Consumo_de_sal In (" + Consumo_de_salIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceGrasas_Preferencias))
            {
                switch (filter.Grasas_PreferenciasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Preferencias_Grasas.Descripcion LIKE '" + filter.AdvanceGrasas_Preferencias + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Preferencias_Grasas.Descripcion LIKE '%" + filter.AdvanceGrasas_Preferencias + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Preferencias_Grasas.Descripcion = '" + filter.AdvanceGrasas_Preferencias + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Preferencias_Grasas.Descripcion LIKE '%" + filter.AdvanceGrasas_Preferencias + "%'";
                        break;
                }
            }
            else if (filter.AdvanceGrasas_PreferenciasMultiple != null && filter.AdvanceGrasas_PreferenciasMultiple.Count() > 0)
            {
                var Grasas_PreferenciasIds = string.Join(",", filter.AdvanceGrasas_PreferenciasMultiple);

                where += " AND Pacientes.Grasas_Preferencias In (" + Grasas_PreferenciasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceComidas_cantidad))
            {
                switch (filter.Comidas_cantidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Cantidad_Comidas.Descripcion LIKE '" + filter.AdvanceComidas_cantidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Cantidad_Comidas.Descripcion LIKE '%" + filter.AdvanceComidas_cantidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Cantidad_Comidas.Descripcion = '" + filter.AdvanceComidas_cantidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Cantidad_Comidas.Descripcion LIKE '%" + filter.AdvanceComidas_cantidad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceComidas_cantidadMultiple != null && filter.AdvanceComidas_cantidadMultiple.Count() > 0)
            {
                var Comidas_cantidadIds = string.Join(",", filter.AdvanceComidas_cantidadMultiple);

                where += " AND Pacientes.Comidas_cantidad In (" + Comidas_cantidadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePreparacion_Preferencias))
            {
                switch (filter.Preparacion_PreferenciasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Preferencias_Preparacion.Descripcion LIKE '" + filter.AdvancePreparacion_Preferencias + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Preferencias_Preparacion.Descripcion LIKE '%" + filter.AdvancePreparacion_Preferencias + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Preferencias_Preparacion.Descripcion = '" + filter.AdvancePreparacion_Preferencias + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Preferencias_Preparacion.Descripcion LIKE '%" + filter.AdvancePreparacion_Preferencias + "%'";
                        break;
                }
            }
            else if (filter.AdvancePreparacion_PreferenciasMultiple != null && filter.AdvancePreparacion_PreferenciasMultiple.Count() > 0)
            {
                var Preparacion_PreferenciasIds = string.Join(",", filter.AdvancePreparacion_PreferenciasMultiple);

                where += " AND Pacientes.Preparacion_Preferencias In (" + Preparacion_PreferenciasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEntre_comidas))
            {
                switch (filter.Entre_comidasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Preferencias_Entrecomidas.Descripcion LIKE '" + filter.AdvanceEntre_comidas + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Preferencias_Entrecomidas.Descripcion LIKE '%" + filter.AdvanceEntre_comidas + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Preferencias_Entrecomidas.Descripcion = '" + filter.AdvanceEntre_comidas + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Preferencias_Entrecomidas.Descripcion LIKE '%" + filter.AdvanceEntre_comidas + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEntre_comidasMultiple != null && filter.AdvanceEntre_comidasMultiple.Count() > 0)
            {
                var Entre_comidasIds = string.Join(",", filter.AdvanceEntre_comidasMultiple);

                where += " AND Pacientes.Entre_comidas In (" + Entre_comidasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceApetito))
            {
                switch (filter.ApetitoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Nivel_de_Satisfaccion.Descripcion LIKE '" + filter.AdvanceApetito + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Nivel_de_Satisfaccion.Descripcion LIKE '%" + filter.AdvanceApetito + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Nivel_de_Satisfaccion.Descripcion = '" + filter.AdvanceApetito + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Nivel_de_Satisfaccion.Descripcion LIKE '%" + filter.AdvanceApetito + "%'";
                        break;
                }
            }
            else if (filter.AdvanceApetitoMultiple != null && filter.AdvanceApetitoMultiple.Count() > 0)
            {
                var ApetitoIds = string.Join(",", filter.AdvanceApetitoMultiple);

                where += " AND Pacientes.Apetito In (" + ApetitoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceHabitos_Modificacion))
            {
                switch (filter.Habitos_ModificacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_Modificacion_Alimentos.Descripcion LIKE '" + filter.AdvanceHabitos_Modificacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_Modificacion_Alimentos.Descripcion LIKE '%" + filter.AdvanceHabitos_Modificacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_Modificacion_Alimentos.Descripcion = '" + filter.AdvanceHabitos_Modificacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_Modificacion_Alimentos.Descripcion LIKE '%" + filter.AdvanceHabitos_Modificacion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceHabitos_ModificacionMultiple != null && filter.AdvanceHabitos_ModificacionMultiple.Count() > 0)
            {
                var Habitos_ModificacionIds = string.Join(",", filter.AdvanceHabitos_ModificacionMultiple);

                where += " AND Pacientes.Habitos_Modificacion In (" + Habitos_ModificacionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceHorario_hambre))
            {
                switch (filter.Horario_hambreFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Periodo_del_dia.Descripcion LIKE '" + filter.AdvanceHorario_hambre + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Periodo_del_dia.Descripcion LIKE '%" + filter.AdvanceHorario_hambre + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Periodo_del_dia.Descripcion = '" + filter.AdvanceHorario_hambre + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Periodo_del_dia.Descripcion LIKE '%" + filter.AdvanceHorario_hambre + "%'";
                        break;
                }
            }
            else if (filter.AdvanceHorario_hambreMultiple != null && filter.AdvanceHorario_hambreMultiple.Count() > 0)
            {
                var Horario_hambreIds = string.Join(",", filter.AdvanceHorario_hambreMultiple);

                where += " AND Pacientes.Horario_hambre In (" + Horario_hambreIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCuando_cambia_mi_estado_de_animo))
            {
                switch (filter.Cuando_cambia_mi_estado_de_animoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado_de_Animo.Descripcion LIKE '" + filter.AdvanceCuando_cambia_mi_estado_de_animo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado_de_Animo.Descripcion LIKE '%" + filter.AdvanceCuando_cambia_mi_estado_de_animo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado_de_Animo.Descripcion = '" + filter.AdvanceCuando_cambia_mi_estado_de_animo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado_de_Animo.Descripcion LIKE '%" + filter.AdvanceCuando_cambia_mi_estado_de_animo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCuando_cambia_mi_estado_de_animoMultiple != null && filter.AdvanceCuando_cambia_mi_estado_de_animoMultiple.Count() > 0)
            {
                var Cuando_cambia_mi_estado_de_animoIds = string.Join(",", filter.AdvanceCuando_cambia_mi_estado_de_animoMultiple);

                where += " AND Pacientes.Cuando_cambia_mi_estado_de_animo In (" + Cuando_cambia_mi_estado_de_animoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceMedicamentos_bajar_peso))
            {
                switch (filter.Medicamentos_bajar_pesoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceMedicamentos_bajar_peso + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceMedicamentos_bajar_peso + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceMedicamentos_bajar_peso + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceMedicamentos_bajar_peso + "%'";
                        break;
                }
            }
            else if (filter.AdvanceMedicamentos_bajar_pesoMultiple != null && filter.AdvanceMedicamentos_bajar_pesoMultiple.Count() > 0)
            {
                var Medicamentos_bajar_pesoIds = string.Join(",", filter.AdvanceMedicamentos_bajar_pesoMultiple);

                where += " AND Pacientes.Medicamentos_bajar_peso In (" + Medicamentos_bajar_pesoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Cual_medicamento))
            {
                switch (filter.Cual_medicamentoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Cual_medicamento LIKE '" + filter.Cual_medicamento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Cual_medicamento LIKE '%" + filter.Cual_medicamento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Cual_medicamento = '" + filter.Cual_medicamento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Cual_medicamento LIKE '%" + filter.Cual_medicamento + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceFrecuencia_Ejercicio))
            {
                switch (filter.Frecuencia_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Frecuencia_Ejercicio.Descripcion LIKE '" + filter.AdvanceFrecuencia_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Frecuencia_Ejercicio.Descripcion LIKE '%" + filter.AdvanceFrecuencia_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Frecuencia_Ejercicio.Descripcion = '" + filter.AdvanceFrecuencia_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Frecuencia_Ejercicio.Descripcion LIKE '%" + filter.AdvanceFrecuencia_Ejercicio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceFrecuencia_EjercicioMultiple != null && filter.AdvanceFrecuencia_EjercicioMultiple.Count() > 0)
            {
                var Frecuencia_EjercicioIds = string.Join(",", filter.AdvanceFrecuencia_EjercicioMultiple);

                where += " AND Pacientes.Frecuencia_Ejercicio In (" + Frecuencia_EjercicioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceDuracion_Ejercicio))
            {
                switch (filter.Duracion_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Duracion_Ejercicio.Descripcion LIKE '" + filter.AdvanceDuracion_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Duracion_Ejercicio.Descripcion LIKE '%" + filter.AdvanceDuracion_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Duracion_Ejercicio.Descripcion = '" + filter.AdvanceDuracion_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Duracion_Ejercicio.Descripcion LIKE '%" + filter.AdvanceDuracion_Ejercicio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceDuracion_EjercicioMultiple != null && filter.AdvanceDuracion_EjercicioMultiple.Count() > 0)
            {
                var Duracion_EjercicioIds = string.Join(",", filter.AdvanceDuracion_EjercicioMultiple);

                where += " AND Pacientes.Duracion_Ejercicio In (" + Duracion_EjercicioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_Ejercicio))
            {
                switch (filter.Tipo_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_Ejercicio.Descripcion LIKE '" + filter.AdvanceTipo_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_Ejercicio.Descripcion LIKE '%" + filter.AdvanceTipo_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_Ejercicio.Descripcion = '" + filter.AdvanceTipo_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_Ejercicio.Descripcion LIKE '%" + filter.AdvanceTipo_Ejercicio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_EjercicioMultiple != null && filter.AdvanceTipo_EjercicioMultiple.Count() > 0)
            {
                var Tipo_EjercicioIds = string.Join(",", filter.AdvanceTipo_EjercicioMultiple);

                where += " AND Pacientes.Tipo_Ejercicio In (" + Tipo_EjercicioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceAntiguedad_Ejercicio))
            {
                switch (filter.Antiguedad_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Antiguedad_Ejercicios.Descripcion LIKE '" + filter.AdvanceAntiguedad_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Antiguedad_Ejercicios.Descripcion LIKE '%" + filter.AdvanceAntiguedad_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Antiguedad_Ejercicios.Descripcion = '" + filter.AdvanceAntiguedad_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Antiguedad_Ejercicios.Descripcion LIKE '%" + filter.AdvanceAntiguedad_Ejercicio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceAntiguedad_EjercicioMultiple != null && filter.AdvanceAntiguedad_EjercicioMultiple.Count() > 0)
            {
                var Antiguedad_EjercicioIds = string.Join(",", filter.AdvanceAntiguedad_EjercicioMultiple);

                where += " AND Pacientes.Antiguedad_Ejercicio In (" + Antiguedad_EjercicioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromIMC) || !string.IsNullOrEmpty(filter.ToIMC))
            {
                if (!string.IsNullOrEmpty(filter.FromIMC))
                    where += " AND Pacientes.IMC >= " + filter.FromIMC;
                if (!string.IsNullOrEmpty(filter.ToIMC))
                    where += " AND Pacientes.IMC <= " + filter.ToIMC;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_IMC))
            {
                switch (filter.Interpretacion_IMCFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '" + filter.AdvanceInterpretacion_IMC + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceInterpretacion_IMC + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_IMC.Descripcion = '" + filter.AdvanceInterpretacion_IMC + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceInterpretacion_IMC + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_IMCMultiple != null && filter.AdvanceInterpretacion_IMCMultiple.Count() > 0)
            {
                var Interpretacion_IMCIds = string.Join(",", filter.AdvanceInterpretacion_IMCMultiple);

                where += " AND Pacientes.Interpretacion_IMC In (" + Interpretacion_IMCIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceIMC_Pediatria))
            {
                switch (filter.IMC_PediatriaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '" + filter.AdvanceIMC_Pediatria + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceIMC_Pediatria + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_IMC.Descripcion = '" + filter.AdvanceIMC_Pediatria + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceIMC_Pediatria + "%'";
                        break;
                }
            }
            else if (filter.AdvanceIMC_PediatriaMultiple != null && filter.AdvanceIMC_PediatriaMultiple.Count() > 0)
            {
                var IMC_PediatriaIds = string.Join(",", filter.AdvanceIMC_PediatriaMultiple);

                where += " AND Pacientes.IMC_Pediatria In (" + IMC_PediatriaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Complexion_corporal))
            {
                switch (filter.Complexion_corporalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Complexion_corporal LIKE '" + filter.Complexion_corporal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Complexion_corporal LIKE '%" + filter.Complexion_corporal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Complexion_corporal = '" + filter.Complexion_corporal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Complexion_corporal LIKE '%" + filter.Complexion_corporal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_complexion_corporal))
            {
                switch (filter.Interpretacion_complexion_corporalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_corporal.Descripcion LIKE '" + filter.AdvanceInterpretacion_complexion_corporal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_corporal.Descripcion LIKE '%" + filter.AdvanceInterpretacion_complexion_corporal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_corporal.Descripcion = '" + filter.AdvanceInterpretacion_complexion_corporal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_corporal.Descripcion LIKE '%" + filter.AdvanceInterpretacion_complexion_corporal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_complexion_corporalMultiple != null && filter.AdvanceInterpretacion_complexion_corporalMultiple.Count() > 0)
            {
                var Interpretacion_complexion_corporalIds = string.Join(",", filter.AdvanceInterpretacion_complexion_corporalMultiple);

                where += " AND Pacientes.Interpretacion_complexion_corporal In (" + Interpretacion_complexion_corporalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Distribucion_de_grasa_corporal))
            {
                switch (filter.Distribucion_de_grasa_corporalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Distribucion_de_grasa_corporal LIKE '" + filter.Distribucion_de_grasa_corporal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Distribucion_de_grasa_corporal LIKE '%" + filter.Distribucion_de_grasa_corporal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Distribucion_de_grasa_corporal = '" + filter.Distribucion_de_grasa_corporal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Distribucion_de_grasa_corporal LIKE '%" + filter.Distribucion_de_grasa_corporal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_grasa_corporal))
            {
                switch (filter.Interpretacion_grasa_corporalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_distribucion_grasa_corporal.Descripcion LIKE '" + filter.AdvanceInterpretacion_grasa_corporal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_distribucion_grasa_corporal.Descripcion LIKE '%" + filter.AdvanceInterpretacion_grasa_corporal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_distribucion_grasa_corporal.Descripcion = '" + filter.AdvanceInterpretacion_grasa_corporal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_distribucion_grasa_corporal.Descripcion LIKE '%" + filter.AdvanceInterpretacion_grasa_corporal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_grasa_corporalMultiple != null && filter.AdvanceInterpretacion_grasa_corporalMultiple.Count() > 0)
            {
                var Interpretacion_grasa_corporalIds = string.Join(",", filter.AdvanceInterpretacion_grasa_corporalMultiple);

                where += " AND Pacientes.Interpretacion_grasa_corporal In (" + Interpretacion_grasa_corporalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Indice_cintura_cadera))
            {
                switch (filter.Indice_cintura_caderaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Indice_cintura_cadera LIKE '" + filter.Indice_cintura_cadera + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Indice_cintura_cadera LIKE '%" + filter.Indice_cintura_cadera + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Indice_cintura_cadera = '" + filter.Indice_cintura_cadera + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Indice_cintura_cadera LIKE '%" + filter.Indice_cintura_cadera + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_indice))
            {
                switch (filter.Interpretacion_indiceFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion LIKE '" + filter.AdvanceInterpretacion_indice + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion LIKE '%" + filter.AdvanceInterpretacion_indice + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion = '" + filter.AdvanceInterpretacion_indice + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion LIKE '%" + filter.AdvanceInterpretacion_indice + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_indiceMultiple != null && filter.AdvanceInterpretacion_indiceMultiple.Count() > 0)
            {
                var Interpretacion_indiceIds = string.Join(",", filter.AdvanceInterpretacion_indiceMultiple);

                where += " AND Pacientes.Interpretacion_indice In (" + Interpretacion_indiceIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Consumo_de_agua_resultado))
            {
                switch (filter.Consumo_de_agua_resultadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Consumo_de_agua_resultado LIKE '" + filter.Consumo_de_agua_resultado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Consumo_de_agua_resultado LIKE '%" + filter.Consumo_de_agua_resultado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Consumo_de_agua_resultado = '" + filter.Consumo_de_agua_resultado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Consumo_de_agua_resultado LIKE '%" + filter.Consumo_de_agua_resultado + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_agua))
            {
                switch (filter.Interpretacion_aguaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion LIKE '" + filter.AdvanceInterpretacion_agua + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion LIKE '%" + filter.AdvanceInterpretacion_agua + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion = '" + filter.AdvanceInterpretacion_agua + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion LIKE '%" + filter.AdvanceInterpretacion_agua + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_aguaMultiple != null && filter.AdvanceInterpretacion_aguaMultiple.Count() > 0)
            {
                var Interpretacion_aguaIds = string.Join(",", filter.AdvanceInterpretacion_aguaMultiple);

                where += " AND Pacientes.Interpretacion_agua In (" + Interpretacion_aguaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFrecuencia_cardiaca_en_Esfuerzo) || !string.IsNullOrEmpty(filter.ToFrecuencia_cardiaca_en_Esfuerzo))
            {
                if (!string.IsNullOrEmpty(filter.FromFrecuencia_cardiaca_en_Esfuerzo))
                    where += " AND Pacientes.Frecuencia_cardiaca_en_Esfuerzo >= " + filter.FromFrecuencia_cardiaca_en_Esfuerzo;
                if (!string.IsNullOrEmpty(filter.ToFrecuencia_cardiaca_en_Esfuerzo))
                    where += " AND Pacientes.Frecuencia_cardiaca_en_Esfuerzo <= " + filter.ToFrecuencia_cardiaca_en_Esfuerzo;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_frecuencia))
            {
                switch (filter.Interpretacion_frecuenciaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion LIKE '" + filter.AdvanceInterpretacion_frecuencia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion LIKE '%" + filter.AdvanceInterpretacion_frecuencia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion = '" + filter.AdvanceInterpretacion_frecuencia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion LIKE '%" + filter.AdvanceInterpretacion_frecuencia + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_frecuenciaMultiple != null && filter.AdvanceInterpretacion_frecuenciaMultiple.Count() > 0)
            {
                var Interpretacion_frecuenciaIds = string.Join(",", filter.AdvanceInterpretacion_frecuenciaMultiple);

                where += " AND Pacientes.Interpretacion_frecuencia In (" + Interpretacion_frecuenciaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Dificultad_de_Rutina_de_Ejercicios))
            {
                switch (filter.Dificultad_de_Rutina_de_EjerciciosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Dificultad_de_Rutina_de_Ejercicios LIKE '" + filter.Dificultad_de_Rutina_de_Ejercicios + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Dificultad_de_Rutina_de_Ejercicios LIKE '%" + filter.Dificultad_de_Rutina_de_Ejercicios + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Dificultad_de_Rutina_de_Ejercicios = '" + filter.Dificultad_de_Rutina_de_Ejercicios + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Dificultad_de_Rutina_de_Ejercicios LIKE '%" + filter.Dificultad_de_Rutina_de_Ejercicios + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_dificultad))
            {
                switch (filter.Interpretacion_dificultadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion LIKE '" + filter.AdvanceInterpretacion_dificultad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion LIKE '%" + filter.AdvanceInterpretacion_dificultad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion = '" + filter.AdvanceInterpretacion_dificultad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion LIKE '%" + filter.AdvanceInterpretacion_dificultad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_dificultadMultiple != null && filter.AdvanceInterpretacion_dificultadMultiple.Count() > 0)
            {
                var Interpretacion_dificultadIds = string.Join(",", filter.AdvanceInterpretacion_dificultadMultiple);

                where += " AND Pacientes.Interpretacion_dificultad In (" + Interpretacion_dificultadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromCalorias) || !string.IsNullOrEmpty(filter.ToCalorias))
            {
                if (!string.IsNullOrEmpty(filter.FromCalorias))
                    where += " AND Pacientes.Calorias >= " + filter.FromCalorias;
                if (!string.IsNullOrEmpty(filter.ToCalorias))
                    where += " AND Pacientes.Calorias <= " + filter.ToCalorias;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_calorias))
            {
                switch (filter.Interpretacion_caloriasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_Calorias.Descripcion LIKE '" + filter.AdvanceInterpretacion_calorias + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_Calorias.Descripcion LIKE '%" + filter.AdvanceInterpretacion_calorias + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_Calorias.Descripcion = '" + filter.AdvanceInterpretacion_calorias + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_Calorias.Descripcion LIKE '%" + filter.AdvanceInterpretacion_calorias + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_caloriasMultiple != null && filter.AdvanceInterpretacion_caloriasMultiple.Count() > 0)
            {
                var Interpretacion_caloriasIds = string.Join(",", filter.AdvanceInterpretacion_caloriasMultiple);

                where += " AND Pacientes.Interpretacion_calorias In (" + Interpretacion_caloriasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Observaciones))
            {
                switch (filter.ObservacionesFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Observaciones LIKE '" + filter.Observaciones + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Observaciones LIKE '%" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Observaciones = '" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Observaciones LIKE '%" + filter.Observaciones + "%'";
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

        public ActionResult GetDetalle_de_Padecimientos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_de_PadecimientosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_de_Padecimientos.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_de_Padecimientos.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_de_Padecimientoss == null)
                result.Detalle_de_Padecimientoss = new List<Detalle_de_Padecimientos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_de_Padecimientoss.Select(m => new Detalle_de_PadecimientosGridModel
                {
                    Folio = m.Folio

                        ,Padecimiento = m.Padecimiento
                        ,PadecimientoDescripcion = CultureHelper.GetTraduction(m.Padecimiento_Padecimientos.Clave.ToString(), "Descripcion") ??(string)m.Padecimiento_Padecimientos.Descripcion
                        ,Tiempo_con_el_diagnostico = m.Tiempo_con_el_diagnostico
                        ,Tiempo_con_el_diagnosticoDescripcion = CultureHelper.GetTraduction(m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Clave.ToString(), "Descripcion") ??(string)m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                        ,Intervencion_quirurgica = m.Intervencion_quirurgica
                        ,Intervencion_quirurgicaDescripcion = CultureHelper.GetTraduction(m.Intervencion_quirurgica_Respuesta_Logica.Clave.ToString(), "Descripcion") ??(string)m.Intervencion_quirurgica_Respuesta_Logica.Descripcion
			,Tratamiento = m.Tratamiento
                        ,Estado_actual = m.Estado_actual
                        ,Estado_actualDescripcion = CultureHelper.GetTraduction(m.Estado_actual_Estatus_Padecimiento.Clave.ToString(), "Descripcion") ??(string)m.Estado_actual_Estatus_Padecimiento.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_de_PadecimientosGridModel> GetDetalle_de_PadecimientosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_de_PadecimientosGridModel> resultData = new List<Detalle_de_PadecimientosGridModel>();
            string where = "Detalle_de_Padecimientos.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_de_Padecimientos.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_de_Padecimientoss != null)
            {
                resultData = result.Detalle_de_Padecimientoss.Select(m => new Detalle_de_PadecimientosGridModel
                    {
                        Folio = m.Folio

                        ,Padecimiento = m.Padecimiento
                        ,PadecimientoDescripcion = CultureHelper.GetTraduction(m.Padecimiento_Padecimientos.Clave.ToString(), "Descripcion") ??(string)m.Padecimiento_Padecimientos.Descripcion
                        ,Tiempo_con_el_diagnostico = m.Tiempo_con_el_diagnostico
                        ,Tiempo_con_el_diagnosticoDescripcion = CultureHelper.GetTraduction(m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Clave.ToString(), "Descripcion") ??(string)m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                        ,Intervencion_quirurgica = m.Intervencion_quirurgica
                        ,Intervencion_quirurgicaDescripcion = CultureHelper.GetTraduction(m.Intervencion_quirurgica_Respuesta_Logica.Clave.ToString(), "Descripcion") ??(string)m.Intervencion_quirurgica_Respuesta_Logica.Descripcion
			,Tratamiento = m.Tratamiento
                        ,Estado_actual = m.Estado_actual
                        ,Estado_actualDescripcion = CultureHelper.GetTraduction(m.Estado_actual_Estatus_Padecimiento.Clave.ToString(), "Descripcion") ??(string)m.Estado_actual_Estatus_Padecimiento.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Antecedentes_Familiares(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Antecedentes_FamiliaresGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Antecedentes_Familiares.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Antecedentes_Familiares.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Antecedentes_Familiaress == null)
                result.Detalle_Antecedentes_Familiaress = new List<Detalle_Antecedentes_Familiares>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Antecedentes_Familiaress.Select(m => new Detalle_Antecedentes_FamiliaresGridModel
                {
                    Folio = m.Folio

                        ,Enfermedad = m.Enfermedad
                        ,EnfermedadDescripcion = CultureHelper.GetTraduction(m.Enfermedad_Padecimientos.Clave.ToString(), "Descripcion") ??(string)m.Enfermedad_Padecimientos.Descripcion
                        ,Parentesco = m.Parentesco
                        ,ParentescoDescripcion = CultureHelper.GetTraduction(m.Parentesco_Parentesco.Clave.ToString(), "Descripcion") ??(string)m.Parentesco_Parentesco.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Antecedentes_FamiliaresGridModel> GetDetalle_Antecedentes_FamiliaresData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Antecedentes_FamiliaresGridModel> resultData = new List<Detalle_Antecedentes_FamiliaresGridModel>();
            string where = "Detalle_Antecedentes_Familiares.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Antecedentes_Familiares.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Antecedentes_Familiaress != null)
            {
                resultData = result.Detalle_Antecedentes_Familiaress.Select(m => new Detalle_Antecedentes_FamiliaresGridModel
                    {
                        Folio = m.Folio

                        ,Enfermedad = m.Enfermedad
                        ,EnfermedadDescripcion = CultureHelper.GetTraduction(m.Enfermedad_Padecimientos.Clave.ToString(), "Descripcion") ??(string)m.Enfermedad_Padecimientos.Descripcion
                        ,Parentesco = m.Parentesco
                        ,ParentescoDescripcion = CultureHelper.GetTraduction(m.Parentesco_Parentesco.Clave.ToString(), "Descripcion") ??(string)m.Parentesco_Parentesco.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Antecedentes_No_Patologicos(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Antecedentes_No_PatologicosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Antecedentes_No_Patologicoss == null)
                result.Detalle_Antecedentes_No_Patologicoss = new List<Detalle_Antecedentes_No_Patologicos>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Antecedentes_No_Patologicoss.Select(m => new Detalle_Antecedentes_No_PatologicosGridModel
                {
                    Folio = m.Folio

                        ,Sustancia = m.Sustancia
                        ,SustanciaDescripcion = CultureHelper.GetTraduction(m.Sustancia_Sustancias.Clave.ToString(), "Descripcion") ??(string)m.Sustancia_Sustancias.Descripcion
                        ,Frecuencia = m.Frecuencia
                        ,FrecuenciaDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Frecuencia_Sustancias.Clave.ToString(), "Descripcion") ??(string)m.Frecuencia_Frecuencia_Sustancias.Descripcion
			,Cantidad = m.Cantidad

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Antecedentes_No_PatologicosGridModel> GetDetalle_Antecedentes_No_PatologicosData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Antecedentes_No_PatologicosGridModel> resultData = new List<Detalle_Antecedentes_No_PatologicosGridModel>();
            string where = "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Antecedentes_No_Patologicoss != null)
            {
                resultData = result.Detalle_Antecedentes_No_Patologicoss.Select(m => new Detalle_Antecedentes_No_PatologicosGridModel
                    {
                        Folio = m.Folio

                        ,Sustancia = m.Sustancia
                        ,SustanciaDescripcion = CultureHelper.GetTraduction(m.Sustancia_Sustancias.Clave.ToString(), "Descripcion") ??(string)m.Sustancia_Sustancias.Descripcion
                        ,Frecuencia = m.Frecuencia
                        ,FrecuenciaDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Frecuencia_Sustancias.Clave.ToString(), "Descripcion") ??(string)m.Frecuencia_Frecuencia_Sustancias.Descripcion
			,Cantidad = m.Cantidad


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Examenes_Laboratorio(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Examenes_LaboratorioGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Examenes_Laboratorio.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Examenes_Laboratorio.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Examenes_Laboratorios == null)
                result.Detalle_Examenes_Laboratorios = new List<Detalle_Examenes_Laboratorio>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Examenes_Laboratorios.Select(m => new Detalle_Examenes_LaboratorioGridModel
                {
                    Folio = m.Folio

                        ,Indicador = m.Indicador
                        ,IndicadorIndicador = CultureHelper.GetTraduction(m.Indicador_Indicadores_Laboratorio.Folio.ToString(), "Indicador") ??(string)m.Indicador_Indicadores_Laboratorio.Indicador
			,Resultado = m.Resultado
			,Unidad = m.Unidad
			,Intervalo_de_Referencia = m.Intervalo_de_Referencia
			,Fecha_de_Resultado = (m.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
			,Estatus_Indicador = m.Estatus_Indicador

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Examenes_LaboratorioGridModel> GetDetalle_Examenes_LaboratorioData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Examenes_LaboratorioGridModel> resultData = new List<Detalle_Examenes_LaboratorioGridModel>();
            string where = "Detalle_Examenes_Laboratorio.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Examenes_Laboratorio.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Examenes_Laboratorios != null)
            {
                resultData = result.Detalle_Examenes_Laboratorios.Select(m => new Detalle_Examenes_LaboratorioGridModel
                    {
                        Folio = m.Folio

                        ,Indicador = m.Indicador
                        ,IndicadorIndicador = CultureHelper.GetTraduction(m.Indicador_Indicadores_Laboratorio.Folio.ToString(), "Indicador") ??(string)m.Indicador_Indicadores_Laboratorio.Indicador
			,Resultado = m.Resultado
			,Unidad = m.Unidad
			,Intervalo_de_Referencia = m.Intervalo_de_Referencia
			,Fecha_de_Resultado = (m.Fecha_de_Resultado == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Resultado).ToString(ConfigurationProperty.DateFormat))
			,Estatus_Indicador = m.Estatus_Indicador


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Terapia_Hormonal(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Terapia_HormonalGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Terapia_HormonalApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Terapia_Hormonal.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Terapia_Hormonal.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Terapia_HormonalApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Terapia_Hormonals == null)
                result.Detalle_Terapia_Hormonals = new List<Detalle_Terapia_Hormonal>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Terapia_Hormonals.Select(m => new Detalle_Terapia_HormonalGridModel
                {
                    Folio = m.Folio

			,Nombre = m.Nombre
			,Dosis = m.Dosis

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Terapia_HormonalGridModel> GetDetalle_Terapia_HormonalData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Terapia_HormonalGridModel> resultData = new List<Detalle_Terapia_HormonalGridModel>();
            string where = "Detalle_Terapia_Hormonal.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Terapia_Hormonal.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Terapia_HormonalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Terapia_HormonalApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Terapia_Hormonals != null)
            {
                resultData = result.Detalle_Terapia_Hormonals.Select(m => new Detalle_Terapia_HormonalGridModel
                    {
                        Folio = m.Folio

			,Nombre = m.Nombre
			,Dosis = m.Dosis


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
[HttpGet]
        public ActionResult GetAlergias_MS_Exclusion_Ingredientes_PacienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Exclusion_Ingredientes_Paciente(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Exclusion_Ingredientes_PacienteGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll(start, pageSize, "MS_Exclusion_Ingredientes_Paciente.Folio_Pacientes=" + RelationId,"").Resource;

            if (result.MS_Exclusion_Ingredientes_Pacientes == null)
                result.MS_Exclusion_Ingredientes_Pacientes = new List<MS_Exclusion_Ingredientes_Paciente>();

            var jsonResult = Json(new
            {
                data = result.MS_Exclusion_Ingredientes_Pacientes.Select(m => new MS_Exclusion_Ingredientes_PacienteGridModel
                {
                    Folio = m.Folio
					
                ,Ingrediente = m.Ingrediente
		,IngredienteNombre_Ingrediente = m.Ingrediente_Ingredientes.Nombre_Ingrediente


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetDetalle_Preferencia_Bebidas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Preferencia_BebidasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Preferencia_Bebidas.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Preferencia_Bebidas.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Preferencia_Bebidass == null)
                result.Detalle_Preferencia_Bebidass = new List<Detalle_Preferencia_Bebidas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Preferencia_Bebidass.Select(m => new Detalle_Preferencia_BebidasGridModel
                {
                    Folio = m.Folio

                        ,Bebida = m.Bebida
                        ,BebidaDescripcion = CultureHelper.GetTraduction(m.Bebida_Bebidas.Clave.ToString(), "Descripcion") ??(string)m.Bebida_Bebidas.Descripcion
                        ,Cantidad = m.Cantidad
                        ,CantidadDescripcion = CultureHelper.GetTraduction(m.Cantidad_Rango_Consumo_Bebidas.Clave.ToString(), "Descripcion") ??(string)m.Cantidad_Rango_Consumo_Bebidas.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Preferencia_BebidasGridModel> GetDetalle_Preferencia_BebidasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Preferencia_BebidasGridModel> resultData = new List<Detalle_Preferencia_BebidasGridModel>();
            string where = "Detalle_Preferencia_Bebidas.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Preferencia_Bebidas.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Preferencia_Bebidass != null)
            {
                resultData = result.Detalle_Preferencia_Bebidass.Select(m => new Detalle_Preferencia_BebidasGridModel
                    {
                        Folio = m.Folio

                        ,Bebida = m.Bebida
                        ,BebidaDescripcion = CultureHelper.GetTraduction(m.Bebida_Bebidas.Clave.ToString(), "Descripcion") ??(string)m.Bebida_Bebidas.Descripcion
                        ,Cantidad = m.Cantidad
                        ,CantidadDescripcion = CultureHelper.GetTraduction(m.Cantidad_Rango_Consumo_Bebidas.Clave.ToString(), "Descripcion") ??(string)m.Cantidad_Rango_Consumo_Bebidas.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Pagos_Paciente(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Pagos_PacienteGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Pagos_Paciente.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Pagos_Paciente.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Pagos_Pacientes == null)
                result.Detalle_Pagos_Pacientes = new List<Detalle_Pagos_Paciente>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Pagos_Pacientes.Select(m => new Detalle_Pagos_PacienteGridModel
                {
                    Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
			,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Forma_de_Pago = m.Forma_de_Pago
                        ,Forma_de_PagoNombre = CultureHelper.GetTraduction(m.Forma_de_Pago_Formas_de_Pago.Clave.ToString(), "Nombre") ??(string)m.Forma_de_Pago_Formas_de_Pago.Nombre
			,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Pago.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Pago.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Pagos_PacienteGridModel> GetDetalle_Pagos_PacienteData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Pagos_PacienteGridModel> resultData = new List<Detalle_Pagos_PacienteGridModel>();
            string where = "Detalle_Pagos_Paciente.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Pagos_Paciente.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Pagos_Pacientes != null)
            {
                resultData = result.Detalle_Pagos_Pacientes.Select(m => new Detalle_Pagos_PacienteGridModel
                    {
                        Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
			,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Forma_de_Pago = m.Forma_de_Pago
                        ,Forma_de_PagoNombre = CultureHelper.GetTraduction(m.Forma_de_Pago_Formas_de_Pago.Clave.ToString(), "Nombre") ??(string)m.Forma_de_Pago_Formas_de_Pago.Nombre
			,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Pago.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Pago.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Suscripciones_Paciente(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Suscripciones_PacienteGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Suscripciones_Paciente.Folio_Pacientes=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Suscripciones_Paciente.Folio_Pacientes='" + RelationId + "'";
            }
            var result = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Suscripciones_Pacientes == null)
                result.Detalle_Suscripciones_Pacientes = new List<Detalle_Suscripciones_Paciente>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Suscripciones_Pacientes.Select(m => new Detalle_Suscripciones_PacienteGridModel
                {
                    Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
			,Costo = m.Costo
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Suscripciones_PacienteGridModel> GetDetalle_Suscripciones_PacienteData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Suscripciones_PacienteGridModel> resultData = new List<Detalle_Suscripciones_PacienteGridModel>();
            string where = "Detalle_Suscripciones_Paciente.Folio_Pacientes=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Suscripciones_Paciente.Folio_Pacientes='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Suscripciones_Pacientes != null)
            {
                resultData = result.Detalle_Suscripciones_Pacientes.Select(m => new Detalle_Suscripciones_PacienteGridModel
                    {
                        Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
			,Costo = m.Costo
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion


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
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Pacientes varPacientes = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_de_Padecimientos.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_de_Padecimientos.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_de_PadecimientosInfo =
                        _IDetalle_de_PadecimientosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_de_PadecimientosInfo.Detalle_de_Padecimientoss.Count > 0)
                    {
                        var resultDetalle_de_Padecimientos = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_de_PadecimientosItem in Detalle_de_PadecimientosInfo.Detalle_de_Padecimientoss)
                            resultDetalle_de_Padecimientos = resultDetalle_de_Padecimientos
                                              && _IDetalle_de_PadecimientosApiConsumer.Delete(Detalle_de_PadecimientosItem.Folio, null,null).Resource;

                        if (!resultDetalle_de_Padecimientos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Antecedentes_Familiares.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Antecedentes_Familiares.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Antecedentes_FamiliaresInfo =
                        _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Antecedentes_FamiliaresInfo.Detalle_Antecedentes_Familiaress.Count > 0)
                    {
                        var resultDetalle_Antecedentes_Familiares = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Antecedentes_FamiliaresItem in Detalle_Antecedentes_FamiliaresInfo.Detalle_Antecedentes_Familiaress)
                            resultDetalle_Antecedentes_Familiares = resultDetalle_Antecedentes_Familiares
                                              && _IDetalle_Antecedentes_FamiliaresApiConsumer.Delete(Detalle_Antecedentes_FamiliaresItem.Folio, null,null).Resource;

                        if (!resultDetalle_Antecedentes_Familiares)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Antecedentes_No_PatologicosInfo =
                        _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Antecedentes_No_PatologicosInfo.Detalle_Antecedentes_No_Patologicoss.Count > 0)
                    {
                        var resultDetalle_Antecedentes_No_Patologicos = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Antecedentes_No_PatologicosItem in Detalle_Antecedentes_No_PatologicosInfo.Detalle_Antecedentes_No_Patologicoss)
                            resultDetalle_Antecedentes_No_Patologicos = resultDetalle_Antecedentes_No_Patologicos
                                              && _IDetalle_Antecedentes_No_PatologicosApiConsumer.Delete(Detalle_Antecedentes_No_PatologicosItem.Folio, null,null).Resource;

                        if (!resultDetalle_Antecedentes_No_Patologicos)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Examenes_Laboratorio.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Examenes_Laboratorio.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Examenes_LaboratorioInfo =
                        _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Examenes_LaboratorioInfo.Detalle_Examenes_Laboratorios.Count > 0)
                    {
                        var resultDetalle_Examenes_Laboratorio = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Examenes_LaboratorioItem in Detalle_Examenes_LaboratorioInfo.Detalle_Examenes_Laboratorios)
                            resultDetalle_Examenes_Laboratorio = resultDetalle_Examenes_Laboratorio
                                              && _IDetalle_Examenes_LaboratorioApiConsumer.Delete(Detalle_Examenes_LaboratorioItem.Folio, null,null).Resource;

                        if (!resultDetalle_Examenes_Laboratorio)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Terapia_HormonalApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Terapia_Hormonal.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Terapia_Hormonal.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Terapia_HormonalInfo =
                        _IDetalle_Terapia_HormonalApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Terapia_HormonalInfo.Detalle_Terapia_Hormonals.Count > 0)
                    {
                        var resultDetalle_Terapia_Hormonal = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Terapia_HormonalItem in Detalle_Terapia_HormonalInfo.Detalle_Terapia_Hormonals)
                            resultDetalle_Terapia_Hormonal = resultDetalle_Terapia_Hormonal
                                              && _IDetalle_Terapia_HormonalApiConsumer.Delete(Detalle_Terapia_HormonalItem.Folio, null,null).Resource;

                        if (!resultDetalle_Terapia_Hormonal)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Exclusion_Ingredientes_Paciente.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Exclusion_Ingredientes_Paciente.Folio_Pacientes='" + id + "'";
                    }
                    var MS_Exclusion_Ingredientes_PacienteInfo =
                        _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Exclusion_Ingredientes_PacienteInfo.MS_Exclusion_Ingredientes_Pacientes.Count > 0)
                    {
                        var resultMS_Exclusion_Ingredientes_Paciente = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Exclusion_Ingredientes_PacienteItem in MS_Exclusion_Ingredientes_PacienteInfo.MS_Exclusion_Ingredientes_Pacientes)
                            resultMS_Exclusion_Ingredientes_Paciente = resultMS_Exclusion_Ingredientes_Paciente
                                              && _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Delete(MS_Exclusion_Ingredientes_PacienteItem.Folio, null,null).Resource;

                        if (!resultMS_Exclusion_Ingredientes_Paciente)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Preferencia_Bebidas.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Preferencia_Bebidas.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Preferencia_BebidasInfo =
                        _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Preferencia_BebidasInfo.Detalle_Preferencia_Bebidass.Count > 0)
                    {
                        var resultDetalle_Preferencia_Bebidas = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Preferencia_BebidasItem in Detalle_Preferencia_BebidasInfo.Detalle_Preferencia_Bebidass)
                            resultDetalle_Preferencia_Bebidas = resultDetalle_Preferencia_Bebidas
                                              && _IDetalle_Preferencia_BebidasApiConsumer.Delete(Detalle_Preferencia_BebidasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Preferencia_Bebidas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Pagos_Paciente.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Pagos_Paciente.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Pagos_PacienteInfo =
                        _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Pagos_PacienteInfo.Detalle_Pagos_Pacientes.Count > 0)
                    {
                        var resultDetalle_Pagos_Paciente = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Pagos_PacienteItem in Detalle_Pagos_PacienteInfo.Detalle_Pagos_Pacientes)
                            resultDetalle_Pagos_Paciente = resultDetalle_Pagos_Paciente
                                              && _IDetalle_Pagos_PacienteApiConsumer.Delete(Detalle_Pagos_PacienteItem.Folio, null,null).Resource;

                        if (!resultDetalle_Pagos_Paciente)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Suscripciones_Paciente.Folio_Pacientes=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Suscripciones_Paciente.Folio_Pacientes='" + id + "'";
                    }
                    var Detalle_Suscripciones_PacienteInfo =
                        _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Suscripciones_PacienteInfo.Detalle_Suscripciones_Pacientes.Count > 0)
                    {
                        var resultDetalle_Suscripciones_Paciente = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Suscripciones_PacienteItem in Detalle_Suscripciones_PacienteInfo.Detalle_Suscripciones_Pacientes)
                            resultDetalle_Suscripciones_Paciente = resultDetalle_Suscripciones_Paciente
                                              && _IDetalle_Suscripciones_PacienteApiConsumer.Delete(Detalle_Suscripciones_PacienteItem.Folio, null,null).Resource;

                        if (!resultDetalle_Suscripciones_Paciente)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IPacientesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, PacientesModel varPacientes)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var PacientesInfo = new Pacientes
                    {
                        Folio = varPacientes.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPacientes.Fecha_de_Registro)) ? DateTime.ParseExact(varPacientes.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPacientes.Hora_de_Registro
                        ,Usuario_que_Registra = varPacientes.Usuario_que_Registra
                        ,Tipo_de_Registro = varPacientes.Tipo_de_Registro
                        ,Tipo_de_Paciente = varPacientes.Tipo_de_Paciente
                        ,Usuario_Registrado = varPacientes.Usuario_Registrado
                        ,Empresa = varPacientes.Empresa
                        ,Numero_de_Empleado = varPacientes.Numero_de_Empleado
                        ,Nombres = varPacientes.Nombres
                        ,Apellido_Paterno = varPacientes.Apellido_Paterno
                        ,Apellido_Materno = varPacientes.Apellido_Materno
                        ,Nombre_Completo = varPacientes.Nombre_Completo
                        ,Celular = varPacientes.Celular
                        ,Email = varPacientes.Email
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varPacientes.Fecha_de_nacimiento)) ? DateTime.ParseExact(varPacientes.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Nombre_del_Padre_o_Tutor = varPacientes.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimiento = varPacientes.Pais_de_nacimiento
                        ,Lugar_de_nacimiento = varPacientes.Lugar_de_nacimiento
                        ,Sexo = varPacientes.Sexo
                        ,Estado_Civil = varPacientes.Estado_Civil
                        ,Calle = varPacientes.Calle
                        ,Numero_exterior = varPacientes.Numero_exterior
                        ,Numero_interior = varPacientes.Numero_interior
                        ,Colonia = varPacientes.Colonia
                        ,CP = varPacientes.CP
                        ,Ciudad = varPacientes.Ciudad
                        ,Pais = varPacientes.Pais
                        ,Estado = varPacientes.Estado
                        ,Ocupacion = varPacientes.Ocupacion
                        ,Cantidad_hijos = varPacientes.Cantidad_hijos
                        ,Objetivo = varPacientes.Objetivo
                        ,Estatus_Paciente = varPacientes.Estatus_Paciente
                        ,Cuenta_con_padecimientos = varPacientes.Cuenta_con_padecimientos
                        ,Frecuencia_Cardiaca = varPacientes.Frecuencia_Cardiaca
                        ,Frecuencia_Respiratoria = varPacientes.Frecuencia_Respiratoria
                        ,Presion_sistolica = varPacientes.Presion_sistolica
                        ,Presion_diastolica = varPacientes.Presion_diastolica
                        ,Peso_actual = varPacientes.Peso_actual
                        ,Estatura = varPacientes.Estatura
                        ,Peso_habitual = varPacientes.Peso_habitual
                        ,Circunferencia_de_cintura_cm = varPacientes.Circunferencia_de_cintura_cm
                        ,Circunferencia_de_cadera_cm = varPacientes.Circunferencia_de_cadera_cm
                        ,Anchura_de_muneca_mm = varPacientes.Anchura_de_muneca_mm
                        ,Circunferencia_de_brazo_cm = varPacientes.Circunferencia_de_brazo_cm
                        ,Pliegue_cutaneo_tricipital_mm = varPacientes.Pliegue_cutaneo_tricipital_mm
                        ,Pliegue_cutaneo_bicipital_mm = varPacientes.Pliegue_cutaneo_bicipital_mm
                        ,Pliegue_cutaneo_subescapular_mm = varPacientes.Pliegue_cutaneo_subescapular_mm
                        ,Pliegue_cutaneo_supraespinal_mm = varPacientes.Pliegue_cutaneo_supraespinal_mm
                        ,Edad_Metabolica = varPacientes.Edad_Metabolica
                        ,Agua_corporal = varPacientes.Agua_corporal
                        ,Grasa_Visceral = varPacientes.Grasa_Visceral
                        ,Grasa_Corporal = varPacientes.Grasa_Corporal
                        ,Grasa_Corporal_kg = varPacientes.Grasa_Corporal_kg
                        ,Masa_Muscular_kg = varPacientes.Masa_Muscular_kg
                        ,Masa_Muscular_ = varPacientes.Masa_Muscular_
                        ,Esta_embarazada = varPacientes.Esta_embarazada
                        ,Semana_de_gestacion = varPacientes.Semana_de_gestacion
                        ,Peso_pregestacional = varPacientes.Peso_pregestacional
                        ,Toma_anticonceptivos = varPacientes.Toma_anticonceptivos
                        ,Nombre_del_Anticonceptivo = varPacientes.Nombre_del_Anticonceptivo
                        ,Dosis = varPacientes.Dosis
                        ,Climaterio = varPacientes.Climaterio
                        ,Fecha_Climaterio = (!String.IsNullOrEmpty(varPacientes.Fecha_Climaterio)) ? DateTime.ParseExact(varPacientes.Fecha_Climaterio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Terapia_reemplazo_hormonal = varPacientes.Terapia_reemplazo_hormonal
                        ,Tipo_Dieta = varPacientes.Tipo_Dieta
                        ,Suplementos = varPacientes.Suplementos
                        ,Consumo_de_sal = varPacientes.Consumo_de_sal
                        ,Grasas_Preferencias = varPacientes.Grasas_Preferencias
                        ,Comidas_cantidad = varPacientes.Comidas_cantidad
                        ,Preparacion_Preferencias = varPacientes.Preparacion_Preferencias
                        ,Entre_comidas = varPacientes.Entre_comidas
                        ,Apetito = varPacientes.Apetito
                        ,Habitos_Modificacion = varPacientes.Habitos_Modificacion
                        ,Horario_hambre = varPacientes.Horario_hambre
                        ,Cuando_cambia_mi_estado_de_animo = varPacientes.Cuando_cambia_mi_estado_de_animo
                        ,Medicamentos_bajar_peso = varPacientes.Medicamentos_bajar_peso
                        ,Cual_medicamento = varPacientes.Cual_medicamento
                        ,Frecuencia_Ejercicio = varPacientes.Frecuencia_Ejercicio
                        ,Duracion_Ejercicio = varPacientes.Duracion_Ejercicio
                        ,Tipo_Ejercicio = varPacientes.Tipo_Ejercicio
                        ,Antiguedad_Ejercicio = varPacientes.Antiguedad_Ejercicio
                        ,IMC = varPacientes.IMC
                        ,Interpretacion_IMC = varPacientes.Interpretacion_IMC
                        ,IMC_Pediatria = varPacientes.IMC_Pediatria
                        ,Complexion_corporal = varPacientes.Complexion_corporal
                        ,Interpretacion_complexion_corporal = varPacientes.Interpretacion_complexion_corporal
                        ,Distribucion_de_grasa_corporal = varPacientes.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporal = varPacientes.Interpretacion_grasa_corporal
                        ,Indice_cintura_cadera = varPacientes.Indice_cintura_cadera
                        ,Interpretacion_indice = varPacientes.Interpretacion_indice
                        ,Consumo_de_agua_resultado = varPacientes.Consumo_de_agua_resultado
                        ,Interpretacion_agua = varPacientes.Interpretacion_agua
                        ,Frecuencia_cardiaca_en_Esfuerzo = varPacientes.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuencia = varPacientes.Interpretacion_frecuencia
                        ,Dificultad_de_Rutina_de_Ejercicios = varPacientes.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultad = varPacientes.Interpretacion_dificultad
                        ,Calorias = varPacientes.Calorias
                        ,Interpretacion_calorias = varPacientes.Interpretacion_calorias
                        ,Observaciones = varPacientes.Observaciones

                    };

                    result = !IsNew ?
                        _IPacientesApiConsumer.Update(PacientesInfo, null, null).Resource.ToString() :
                         _IPacientesApiConsumer.Insert(PacientesInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_de_Padecimientos(int MasterId, int referenceId, List<Detalle_de_PadecimientosGridModelPost> Detalle_de_PadecimientosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_de_PadecimientosData = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_de_Padecimientos.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_de_PadecimientosData == null || Detalle_de_PadecimientosData.Detalle_de_Padecimientoss.Count == 0)
                    return true;

                var result = true;

                Detalle_de_PadecimientosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_de_Padecimientos in Detalle_de_PadecimientosData.Detalle_de_Padecimientoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_de_Padecimientos Detalle_de_Padecimientos1 = varDetalle_de_Padecimientos;

                    if (Detalle_de_PadecimientosItems != null && Detalle_de_PadecimientosItems.Any(m => m.Folio == Detalle_de_Padecimientos1.Folio))
                    {
                        modelDataToChange = Detalle_de_PadecimientosItems.FirstOrDefault(m => m.Folio == Detalle_de_Padecimientos1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_de_Padecimientos.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_de_PadecimientosApiConsumer.Insert(varDetalle_de_Padecimientos,null,null).Resource;
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
        public ActionResult PostDetalle_de_Padecimientos(List<Detalle_de_PadecimientosGridModelPost> Detalle_de_PadecimientosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_de_Padecimientos(MasterId, referenceId, Detalle_de_PadecimientosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_de_PadecimientosItems != null && Detalle_de_PadecimientosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_de_PadecimientosItem in Detalle_de_PadecimientosItems)
                    {







                        //Removal Request
                        if (Detalle_de_PadecimientosItem.Removed)
                        {
                            result = result && _IDetalle_de_PadecimientosApiConsumer.Delete(Detalle_de_PadecimientosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_de_PadecimientosItem.Folio = 0;

                        var Detalle_de_PadecimientosData = new Detalle_de_Padecimientos
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_de_PadecimientosItem.Folio
                            ,Padecimiento = (Convert.ToInt32(Detalle_de_PadecimientosItem.Padecimiento) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_PadecimientosItem.Padecimiento))
                            ,Tiempo_con_el_diagnostico = (Convert.ToInt32(Detalle_de_PadecimientosItem.Tiempo_con_el_diagnostico) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_PadecimientosItem.Tiempo_con_el_diagnostico))
                            ,Intervencion_quirurgica = (Convert.ToInt32(Detalle_de_PadecimientosItem.Intervencion_quirurgica) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_PadecimientosItem.Intervencion_quirurgica))
                            ,Tratamiento = Detalle_de_PadecimientosItem.Tratamiento
                            ,Estado_actual = (Convert.ToInt32(Detalle_de_PadecimientosItem.Estado_actual) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_de_PadecimientosItem.Estado_actual))

                        };

                        var resultId = Detalle_de_PadecimientosItem.Folio > 0
                           ? _IDetalle_de_PadecimientosApiConsumer.Update(Detalle_de_PadecimientosData,null,null).Resource
                           : _IDetalle_de_PadecimientosApiConsumer.Insert(Detalle_de_PadecimientosData,null,null).Resource;

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
        public ActionResult GetDetalle_de_Padecimientos_PadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPadecimientosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Padecimientos", "Descripcion");
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
        public ActionResult GetDetalle_de_Padecimientos_Tiempo_PadecimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITiempo_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITiempo_PadecimientoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tiempo_Padecimiento", "Descripcion");
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
        public ActionResult GetDetalle_de_Padecimientos_Respuesta_LogicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRespuesta_LogicaApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Respuesta_Logica", "Descripcion");
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
        public ActionResult GetDetalle_de_Padecimientos_Estatus_PadecimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_PadecimientoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_Padecimiento", "Descripcion");
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
        public bool CopyDetalle_Antecedentes_Familiares(int MasterId, int referenceId, List<Detalle_Antecedentes_FamiliaresGridModelPost> Detalle_Antecedentes_FamiliaresItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Antecedentes_FamiliaresData = _IDetalle_Antecedentes_FamiliaresApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Antecedentes_Familiares.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Antecedentes_FamiliaresData == null || Detalle_Antecedentes_FamiliaresData.Detalle_Antecedentes_Familiaress.Count == 0)
                    return true;

                var result = true;

                Detalle_Antecedentes_FamiliaresGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Antecedentes_Familiares in Detalle_Antecedentes_FamiliaresData.Detalle_Antecedentes_Familiaress)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Antecedentes_Familiares Detalle_Antecedentes_Familiares1 = varDetalle_Antecedentes_Familiares;

                    if (Detalle_Antecedentes_FamiliaresItems != null && Detalle_Antecedentes_FamiliaresItems.Any(m => m.Folio == Detalle_Antecedentes_Familiares1.Folio))
                    {
                        modelDataToChange = Detalle_Antecedentes_FamiliaresItems.FirstOrDefault(m => m.Folio == Detalle_Antecedentes_Familiares1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Antecedentes_Familiares.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Antecedentes_FamiliaresApiConsumer.Insert(varDetalle_Antecedentes_Familiares,null,null).Resource;
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
        public ActionResult PostDetalle_Antecedentes_Familiares(List<Detalle_Antecedentes_FamiliaresGridModelPost> Detalle_Antecedentes_FamiliaresItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Antecedentes_Familiares(MasterId, referenceId, Detalle_Antecedentes_FamiliaresItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Antecedentes_FamiliaresItems != null && Detalle_Antecedentes_FamiliaresItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Antecedentes_FamiliaresApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Antecedentes_FamiliaresItem in Detalle_Antecedentes_FamiliaresItems)
                    {




                        //Removal Request
                        if (Detalle_Antecedentes_FamiliaresItem.Removed)
                        {
                            result = result && _IDetalle_Antecedentes_FamiliaresApiConsumer.Delete(Detalle_Antecedentes_FamiliaresItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Antecedentes_FamiliaresItem.Folio = 0;

                        var Detalle_Antecedentes_FamiliaresData = new Detalle_Antecedentes_Familiares
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Antecedentes_FamiliaresItem.Folio
                            ,Enfermedad = (Convert.ToInt32(Detalle_Antecedentes_FamiliaresItem.Enfermedad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Antecedentes_FamiliaresItem.Enfermedad))
                            ,Parentesco = (Convert.ToInt32(Detalle_Antecedentes_FamiliaresItem.Parentesco) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Antecedentes_FamiliaresItem.Parentesco))

                        };

                        var resultId = Detalle_Antecedentes_FamiliaresItem.Folio > 0
                           ? _IDetalle_Antecedentes_FamiliaresApiConsumer.Update(Detalle_Antecedentes_FamiliaresData,null,null).Resource
                           : _IDetalle_Antecedentes_FamiliaresApiConsumer.Insert(Detalle_Antecedentes_FamiliaresData,null,null).Resource;

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
        public ActionResult GetDetalle_Antecedentes_Familiares_PadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPadecimientosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Padecimientos", "Descripcion");
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
        public ActionResult GetDetalle_Antecedentes_Familiares_ParentescoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IParentescoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IParentescoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Parentesco", "Descripcion");
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
        public bool CopyDetalle_Antecedentes_No_Patologicos(int MasterId, int referenceId, List<Detalle_Antecedentes_No_PatologicosGridModelPost> Detalle_Antecedentes_No_PatologicosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Antecedentes_No_PatologicosData = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Antecedentes_No_Patologicos.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Antecedentes_No_PatologicosData == null || Detalle_Antecedentes_No_PatologicosData.Detalle_Antecedentes_No_Patologicoss.Count == 0)
                    return true;

                var result = true;

                Detalle_Antecedentes_No_PatologicosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Antecedentes_No_Patologicos in Detalle_Antecedentes_No_PatologicosData.Detalle_Antecedentes_No_Patologicoss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Antecedentes_No_Patologicos Detalle_Antecedentes_No_Patologicos1 = varDetalle_Antecedentes_No_Patologicos;

                    if (Detalle_Antecedentes_No_PatologicosItems != null && Detalle_Antecedentes_No_PatologicosItems.Any(m => m.Folio == Detalle_Antecedentes_No_Patologicos1.Folio))
                    {
                        modelDataToChange = Detalle_Antecedentes_No_PatologicosItems.FirstOrDefault(m => m.Folio == Detalle_Antecedentes_No_Patologicos1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Antecedentes_No_Patologicos.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Antecedentes_No_PatologicosApiConsumer.Insert(varDetalle_Antecedentes_No_Patologicos,null,null).Resource;
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
        public ActionResult PostDetalle_Antecedentes_No_Patologicos(List<Detalle_Antecedentes_No_PatologicosGridModelPost> Detalle_Antecedentes_No_PatologicosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Antecedentes_No_Patologicos(MasterId, referenceId, Detalle_Antecedentes_No_PatologicosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Antecedentes_No_PatologicosItems != null && Detalle_Antecedentes_No_PatologicosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Antecedentes_No_PatologicosItem in Detalle_Antecedentes_No_PatologicosItems)
                    {





                        //Removal Request
                        if (Detalle_Antecedentes_No_PatologicosItem.Removed)
                        {
                            result = result && _IDetalle_Antecedentes_No_PatologicosApiConsumer.Delete(Detalle_Antecedentes_No_PatologicosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Antecedentes_No_PatologicosItem.Folio = 0;

                        var Detalle_Antecedentes_No_PatologicosData = new Detalle_Antecedentes_No_Patologicos
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Antecedentes_No_PatologicosItem.Folio
                            ,Sustancia = (Convert.ToInt32(Detalle_Antecedentes_No_PatologicosItem.Sustancia) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Antecedentes_No_PatologicosItem.Sustancia))
                            ,Frecuencia = (Convert.ToInt32(Detalle_Antecedentes_No_PatologicosItem.Frecuencia) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Antecedentes_No_PatologicosItem.Frecuencia))
                            ,Cantidad = Detalle_Antecedentes_No_PatologicosItem.Cantidad

                        };

                        var resultId = Detalle_Antecedentes_No_PatologicosItem.Folio > 0
                           ? _IDetalle_Antecedentes_No_PatologicosApiConsumer.Update(Detalle_Antecedentes_No_PatologicosData,null,null).Resource
                           : _IDetalle_Antecedentes_No_PatologicosApiConsumer.Insert(Detalle_Antecedentes_No_PatologicosData,null,null).Resource;

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
        public ActionResult GetDetalle_Antecedentes_No_Patologicos_SustanciasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISustanciasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Sustancias", "Descripcion");
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
        public ActionResult GetDetalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_SustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFrecuencia_SustanciasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Frecuencia_Sustancias", "Descripcion");
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
        public bool CopyDetalle_Examenes_Laboratorio(int MasterId, int referenceId, List<Detalle_Examenes_LaboratorioGridModelPost> Detalle_Examenes_LaboratorioItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Examenes_LaboratorioData = _IDetalle_Examenes_LaboratorioApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Examenes_Laboratorio.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Examenes_LaboratorioData == null || Detalle_Examenes_LaboratorioData.Detalle_Examenes_Laboratorios.Count == 0)
                    return true;

                var result = true;

                Detalle_Examenes_LaboratorioGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Examenes_Laboratorio in Detalle_Examenes_LaboratorioData.Detalle_Examenes_Laboratorios)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Examenes_Laboratorio Detalle_Examenes_Laboratorio1 = varDetalle_Examenes_Laboratorio;

                    if (Detalle_Examenes_LaboratorioItems != null && Detalle_Examenes_LaboratorioItems.Any(m => m.Folio == Detalle_Examenes_Laboratorio1.Folio))
                    {
                        modelDataToChange = Detalle_Examenes_LaboratorioItems.FirstOrDefault(m => m.Folio == Detalle_Examenes_Laboratorio1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Examenes_Laboratorio.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Examenes_LaboratorioApiConsumer.Insert(varDetalle_Examenes_Laboratorio,null,null).Resource;
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
        public ActionResult PostDetalle_Examenes_Laboratorio(List<Detalle_Examenes_LaboratorioGridModelPost> Detalle_Examenes_LaboratorioItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Examenes_Laboratorio(MasterId, referenceId, Detalle_Examenes_LaboratorioItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Examenes_LaboratorioItems != null && Detalle_Examenes_LaboratorioItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Examenes_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Examenes_LaboratorioItem in Detalle_Examenes_LaboratorioItems)
                    {








                        //Removal Request
                        if (Detalle_Examenes_LaboratorioItem.Removed)
                        {
                            result = result && _IDetalle_Examenes_LaboratorioApiConsumer.Delete(Detalle_Examenes_LaboratorioItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Examenes_LaboratorioItem.Folio = 0;

                        var Detalle_Examenes_LaboratorioData = new Detalle_Examenes_Laboratorio
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Examenes_LaboratorioItem.Folio
                            ,Indicador = (Convert.ToInt32(Detalle_Examenes_LaboratorioItem.Indicador) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Examenes_LaboratorioItem.Indicador))
                            ,Resultado = Detalle_Examenes_LaboratorioItem.Resultado
                            ,Unidad = Detalle_Examenes_LaboratorioItem.Unidad
                            ,Intervalo_de_Referencia = Detalle_Examenes_LaboratorioItem.Intervalo_de_Referencia
                            ,Fecha_de_Resultado = (Detalle_Examenes_LaboratorioItem.Fecha_de_Resultado!= null) ? DateTime.ParseExact(Detalle_Examenes_LaboratorioItem.Fecha_de_Resultado, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Estatus_Indicador = Detalle_Examenes_LaboratorioItem.Estatus_Indicador

                        };

                        var resultId = Detalle_Examenes_LaboratorioItem.Folio > 0
                           ? _IDetalle_Examenes_LaboratorioApiConsumer.Update(Detalle_Examenes_LaboratorioData,null,null).Resource
                           : _IDetalle_Examenes_LaboratorioApiConsumer.Insert(Detalle_Examenes_LaboratorioData,null,null).Resource;

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
        public ActionResult GetDetalle_Examenes_Laboratorio_Indicadores_LaboratorioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIndicadores_LaboratorioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIndicadores_LaboratorioApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Indicadores_Laboratorio", "Indicador");
                  item.Indicador= trans??item.Indicador;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }






        [NonAction]
        public bool CopyDetalle_Terapia_Hormonal(int MasterId, int referenceId, List<Detalle_Terapia_HormonalGridModelPost> Detalle_Terapia_HormonalItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Terapia_HormonalApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Terapia_HormonalData = _IDetalle_Terapia_HormonalApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Terapia_Hormonal.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Terapia_HormonalData == null || Detalle_Terapia_HormonalData.Detalle_Terapia_Hormonals.Count == 0)
                    return true;

                var result = true;

                Detalle_Terapia_HormonalGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Terapia_Hormonal in Detalle_Terapia_HormonalData.Detalle_Terapia_Hormonals)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Terapia_Hormonal Detalle_Terapia_Hormonal1 = varDetalle_Terapia_Hormonal;

                    if (Detalle_Terapia_HormonalItems != null && Detalle_Terapia_HormonalItems.Any(m => m.Folio == Detalle_Terapia_Hormonal1.Folio))
                    {
                        modelDataToChange = Detalle_Terapia_HormonalItems.FirstOrDefault(m => m.Folio == Detalle_Terapia_Hormonal1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Terapia_Hormonal.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Terapia_HormonalApiConsumer.Insert(varDetalle_Terapia_Hormonal,null,null).Resource;
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
        public ActionResult PostDetalle_Terapia_Hormonal(List<Detalle_Terapia_HormonalGridModelPost> Detalle_Terapia_HormonalItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Terapia_Hormonal(MasterId, referenceId, Detalle_Terapia_HormonalItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Terapia_HormonalItems != null && Detalle_Terapia_HormonalItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Terapia_HormonalApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Terapia_HormonalItem in Detalle_Terapia_HormonalItems)
                    {




                        //Removal Request
                        if (Detalle_Terapia_HormonalItem.Removed)
                        {
                            result = result && _IDetalle_Terapia_HormonalApiConsumer.Delete(Detalle_Terapia_HormonalItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Terapia_HormonalItem.Folio = 0;

                        var Detalle_Terapia_HormonalData = new Detalle_Terapia_Hormonal
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Terapia_HormonalItem.Folio
                            ,Nombre = Detalle_Terapia_HormonalItem.Nombre
                            ,Dosis = Detalle_Terapia_HormonalItem.Dosis

                        };

                        var resultId = Detalle_Terapia_HormonalItem.Folio > 0
                           ? _IDetalle_Terapia_HormonalApiConsumer.Update(Detalle_Terapia_HormonalData,null,null).Resource
                           : _IDetalle_Terapia_HormonalApiConsumer.Insert(Detalle_Terapia_HormonalData,null,null).Resource;

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
        public bool CopyMS_Exclusion_Ingredientes_Paciente(int MasterId, int referenceId, List<MS_Exclusion_Ingredientes_PacienteGridModelPost> MS_Exclusion_Ingredientes_PacienteItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Exclusion_Ingredientes_PacienteData = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Exclusion_Ingredientes_Paciente.Folio_Pacientes=" + referenceId,"").Resource;
                if (MS_Exclusion_Ingredientes_PacienteData == null || MS_Exclusion_Ingredientes_PacienteData.MS_Exclusion_Ingredientes_Pacientes.Count == 0)
                    return true;

                var result = true;

                MS_Exclusion_Ingredientes_PacienteGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Exclusion_Ingredientes_Paciente in MS_Exclusion_Ingredientes_PacienteData.MS_Exclusion_Ingredientes_Pacientes)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Exclusion_Ingredientes_Paciente MS_Exclusion_Ingredientes_Paciente1 = varMS_Exclusion_Ingredientes_Paciente;

                    if (MS_Exclusion_Ingredientes_PacienteItems != null && MS_Exclusion_Ingredientes_PacienteItems.Any(m => m.Folio == MS_Exclusion_Ingredientes_Paciente1.Folio))
                    {
                        modelDataToChange = MS_Exclusion_Ingredientes_PacienteItems.FirstOrDefault(m => m.Folio == MS_Exclusion_Ingredientes_Paciente1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Exclusion_Ingredientes_Paciente.Folio_Pacientes = MasterId;
                    var insertId = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Insert(varMS_Exclusion_Ingredientes_Paciente,null,null).Resource;
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
        public ActionResult PostMS_Exclusion_Ingredientes_Paciente(List<MS_Exclusion_Ingredientes_PacienteGridModelPost> MS_Exclusion_Ingredientes_PacienteItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Exclusion_Ingredientes_Paciente(MasterId, referenceId, MS_Exclusion_Ingredientes_PacienteItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Exclusion_Ingredientes_PacienteItems != null && MS_Exclusion_Ingredientes_PacienteItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Exclusion_Ingredientes_PacienteItem in MS_Exclusion_Ingredientes_PacienteItems)
                    {



                        //Removal Request
                        if (MS_Exclusion_Ingredientes_PacienteItem.Removed)
                        {
                            result = result && _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Delete(MS_Exclusion_Ingredientes_PacienteItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Exclusion_Ingredientes_PacienteItem.Folio = 0;

                        var MS_Exclusion_Ingredientes_PacienteData = new MS_Exclusion_Ingredientes_Paciente
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = MS_Exclusion_Ingredientes_PacienteItem.Folio
                            ,Ingrediente = (Convert.ToInt32(MS_Exclusion_Ingredientes_PacienteItem.Ingrediente) == 0 ? (Int32?)null : Convert.ToInt32(MS_Exclusion_Ingredientes_PacienteItem.Ingrediente))

                        };

                        var resultId = MS_Exclusion_Ingredientes_PacienteItem.Folio > 0
                           ? _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Update(MS_Exclusion_Ingredientes_PacienteData,null,null).Resource
                           : _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Insert(MS_Exclusion_Ingredientes_PacienteData,null,null).Resource;

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
        public ActionResult GetMS_Exclusion_Ingredientes_Paciente_IngredientesAll()
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

        [NonAction]
        public bool CopyDetalle_Preferencia_Bebidas(int MasterId, int referenceId, List<Detalle_Preferencia_BebidasGridModelPost> Detalle_Preferencia_BebidasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Preferencia_BebidasData = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Preferencia_Bebidas.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Preferencia_BebidasData == null || Detalle_Preferencia_BebidasData.Detalle_Preferencia_Bebidass.Count == 0)
                    return true;

                var result = true;

                Detalle_Preferencia_BebidasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Preferencia_Bebidas in Detalle_Preferencia_BebidasData.Detalle_Preferencia_Bebidass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Preferencia_Bebidas Detalle_Preferencia_Bebidas1 = varDetalle_Preferencia_Bebidas;

                    if (Detalle_Preferencia_BebidasItems != null && Detalle_Preferencia_BebidasItems.Any(m => m.Folio == Detalle_Preferencia_Bebidas1.Folio))
                    {
                        modelDataToChange = Detalle_Preferencia_BebidasItems.FirstOrDefault(m => m.Folio == Detalle_Preferencia_Bebidas1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Preferencia_Bebidas.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Preferencia_BebidasApiConsumer.Insert(varDetalle_Preferencia_Bebidas,null,null).Resource;
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
        public ActionResult PostDetalle_Preferencia_Bebidas(List<Detalle_Preferencia_BebidasGridModelPost> Detalle_Preferencia_BebidasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Preferencia_Bebidas(MasterId, referenceId, Detalle_Preferencia_BebidasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Preferencia_BebidasItems != null && Detalle_Preferencia_BebidasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Preferencia_BebidasItem in Detalle_Preferencia_BebidasItems)
                    {




                        //Removal Request
                        if (Detalle_Preferencia_BebidasItem.Removed)
                        {
                            result = result && _IDetalle_Preferencia_BebidasApiConsumer.Delete(Detalle_Preferencia_BebidasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Preferencia_BebidasItem.Folio = 0;

                        var Detalle_Preferencia_BebidasData = new Detalle_Preferencia_Bebidas
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Preferencia_BebidasItem.Folio
                            ,Bebida = (Convert.ToInt32(Detalle_Preferencia_BebidasItem.Bebida) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Preferencia_BebidasItem.Bebida))
                            ,Cantidad = (Convert.ToInt32(Detalle_Preferencia_BebidasItem.Cantidad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Preferencia_BebidasItem.Cantidad))

                        };

                        var resultId = Detalle_Preferencia_BebidasItem.Folio > 0
                           ? _IDetalle_Preferencia_BebidasApiConsumer.Update(Detalle_Preferencia_BebidasData,null,null).Resource
                           : _IDetalle_Preferencia_BebidasApiConsumer.Insert(Detalle_Preferencia_BebidasData,null,null).Resource;

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
        public ActionResult GetDetalle_Preferencia_Bebidas_BebidasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IBebidasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Bebidas", "Descripcion");
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
        public ActionResult GetDetalle_Preferencia_Bebidas_Rango_Consumo_BebidasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRango_Consumo_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRango_Consumo_BebidasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Rango_Consumo_Bebidas", "Descripcion");
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
        public bool CopyDetalle_Pagos_Paciente(int MasterId, int referenceId, List<Detalle_Pagos_PacienteGridModelPost> Detalle_Pagos_PacienteItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Pagos_PacienteData = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Pagos_Paciente.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Pagos_PacienteData == null || Detalle_Pagos_PacienteData.Detalle_Pagos_Pacientes.Count == 0)
                    return true;

                var result = true;

                Detalle_Pagos_PacienteGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Pagos_Paciente in Detalle_Pagos_PacienteData.Detalle_Pagos_Pacientes)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Pagos_Paciente Detalle_Pagos_Paciente1 = varDetalle_Pagos_Paciente;

                    if (Detalle_Pagos_PacienteItems != null && Detalle_Pagos_PacienteItems.Any(m => m.Folio == Detalle_Pagos_Paciente1.Folio))
                    {
                        modelDataToChange = Detalle_Pagos_PacienteItems.FirstOrDefault(m => m.Folio == Detalle_Pagos_Paciente1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Pagos_Paciente.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Pagos_PacienteApiConsumer.Insert(varDetalle_Pagos_Paciente,null,null).Resource;
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
        public ActionResult PostDetalle_Pagos_Paciente(List<Detalle_Pagos_PacienteGridModelPost> Detalle_Pagos_PacienteItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Pagos_Paciente(MasterId, referenceId, Detalle_Pagos_PacienteItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Pagos_PacienteItems != null && Detalle_Pagos_PacienteItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Pagos_PacienteItem in Detalle_Pagos_PacienteItems)
                    {








                        //Removal Request
                        if (Detalle_Pagos_PacienteItem.Removed)
                        {
                            result = result && _IDetalle_Pagos_PacienteApiConsumer.Delete(Detalle_Pagos_PacienteItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Pagos_PacienteItem.Folio = 0;

                        var Detalle_Pagos_PacienteData = new Detalle_Pagos_Paciente
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Pagos_PacienteItem.Folio
                            ,Suscripcion = (Convert.ToInt32(Detalle_Pagos_PacienteItem.Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Pagos_PacienteItem.Suscripcion))
                            ,Fecha_de_Suscripcion = (Detalle_Pagos_PacienteItem.Fecha_de_Suscripcion!= null) ? DateTime.ParseExact(Detalle_Pagos_PacienteItem.Fecha_de_Suscripcion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_Limite_de_Pago = (Detalle_Pagos_PacienteItem.Fecha_Limite_de_Pago!= null) ? DateTime.ParseExact(Detalle_Pagos_PacienteItem.Fecha_Limite_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Forma_de_Pago = (Convert.ToInt32(Detalle_Pagos_PacienteItem.Forma_de_Pago) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Pagos_PacienteItem.Forma_de_Pago))
                            ,Fecha_de_Pago = (Detalle_Pagos_PacienteItem.Fecha_de_Pago!= null) ? DateTime.ParseExact(Detalle_Pagos_PacienteItem.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Estatus = (Convert.ToInt32(Detalle_Pagos_PacienteItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Pagos_PacienteItem.Estatus))

                        };

                        var resultId = Detalle_Pagos_PacienteItem.Folio > 0
                           ? _IDetalle_Pagos_PacienteApiConsumer.Update(Detalle_Pagos_PacienteData,null,null).Resource
                           : _IDetalle_Pagos_PacienteApiConsumer.Insert(Detalle_Pagos_PacienteData,null,null).Resource;

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
        public ActionResult GetDetalle_Pagos_Paciente_Planes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                  item.Nombre_del_Plan= trans??item.Nombre_del_Plan;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult GetDetalle_Pagos_Paciente_Formas_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFormas_de_PagoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Formas_de_Pago", "Nombre");
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
        public ActionResult GetDetalle_Pagos_Paciente_Estatus_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_PagoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_de_Pago", "Descripcion");
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
        public bool CopyDetalle_Suscripciones_Paciente(int MasterId, int referenceId, List<Detalle_Suscripciones_PacienteGridModelPost> Detalle_Suscripciones_PacienteItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Suscripciones_PacienteData = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Suscripciones_Paciente.Folio_Pacientes=" + referenceId,"").Resource;
                if (Detalle_Suscripciones_PacienteData == null || Detalle_Suscripciones_PacienteData.Detalle_Suscripciones_Pacientes.Count == 0)
                    return true;

                var result = true;

                Detalle_Suscripciones_PacienteGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Suscripciones_Paciente in Detalle_Suscripciones_PacienteData.Detalle_Suscripciones_Pacientes)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Suscripciones_Paciente Detalle_Suscripciones_Paciente1 = varDetalle_Suscripciones_Paciente;

                    if (Detalle_Suscripciones_PacienteItems != null && Detalle_Suscripciones_PacienteItems.Any(m => m.Folio == Detalle_Suscripciones_Paciente1.Folio))
                    {
                        modelDataToChange = Detalle_Suscripciones_PacienteItems.FirstOrDefault(m => m.Folio == Detalle_Suscripciones_Paciente1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Suscripciones_Paciente.Folio_Pacientes = MasterId;
                    var insertId = _IDetalle_Suscripciones_PacienteApiConsumer.Insert(varDetalle_Suscripciones_Paciente,null,null).Resource;
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
        public ActionResult PostDetalle_Suscripciones_Paciente(List<Detalle_Suscripciones_PacienteGridModelPost> Detalle_Suscripciones_PacienteItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Suscripciones_Paciente(MasterId, referenceId, Detalle_Suscripciones_PacienteItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Suscripciones_PacienteItems != null && Detalle_Suscripciones_PacienteItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Suscripciones_PacienteItem in Detalle_Suscripciones_PacienteItems)
                    {








                        //Removal Request
                        if (Detalle_Suscripciones_PacienteItem.Removed)
                        {
                            result = result && _IDetalle_Suscripciones_PacienteApiConsumer.Delete(Detalle_Suscripciones_PacienteItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Suscripciones_PacienteItem.Folio = 0;

                        var Detalle_Suscripciones_PacienteData = new Detalle_Suscripciones_Paciente
                        {
                            Folio_Pacientes = MasterId
                            ,Folio = Detalle_Suscripciones_PacienteItem.Folio
                            ,Suscripcion = (Convert.ToInt32(Detalle_Suscripciones_PacienteItem.Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripciones_PacienteItem.Suscripcion))
                            ,Fecha_de_inicio = (Detalle_Suscripciones_PacienteItem.Fecha_de_inicio!= null) ? DateTime.ParseExact(Detalle_Suscripciones_PacienteItem.Fecha_de_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_fin = (Detalle_Suscripciones_PacienteItem.Fecha_fin!= null) ? DateTime.ParseExact(Detalle_Suscripciones_PacienteItem.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Nombre_de_la_Suscripcion = Detalle_Suscripciones_PacienteItem.Nombre_de_la_Suscripcion
                            ,Costo = Detalle_Suscripciones_PacienteItem.Costo
                            ,Estatus = (Convert.ToInt32(Detalle_Suscripciones_PacienteItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripciones_PacienteItem.Estatus))

                        };

                        var resultId = Detalle_Suscripciones_PacienteItem.Folio > 0
                           ? _IDetalle_Suscripciones_PacienteApiConsumer.Update(Detalle_Suscripciones_PacienteData,null,null).Resource
                           : _IDetalle_Suscripciones_PacienteApiConsumer.Insert(Detalle_Suscripciones_PacienteData,null,null).Resource;

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
        public ActionResult GetDetalle_Suscripciones_Paciente_Planes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                  item.Nombre_del_Plan= trans??item.Nombre_del_Plan;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpGet]
        public ActionResult GetDetalle_Suscripciones_Paciente_Estatus_de_SuscripcionAll()
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



        /// <summary>
        /// Write Element Array of Pacientes script
        /// </summary>
        /// <param name="oPacientesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew PacientesModuleAttributeList)
        {
            for (int i = 0; i < PacientesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(PacientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    PacientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(PacientesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    PacientesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (PacientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < PacientesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < PacientesModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(PacientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							PacientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(PacientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							PacientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strPacientesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Pacientes.js")))
            {
                strPacientesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Pacientes element attributes
            string userChangeJson = jsSerialize.Serialize(PacientesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strPacientesScript.IndexOf("inpuElementArray");
            string splittedString = strPacientesScript.Substring(indexOfArray, strPacientesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(PacientesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (PacientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strPacientesScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strPacientesScript.Substring(indexOfArrayHistory, strPacientesScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strPacientesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strPacientesScript.Substring(endIndexOfMainElement + indexOfArray, strPacientesScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (PacientesModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in PacientesModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Pacientes.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Pacientes.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Pacientes.js")))
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
        public ActionResult PacientesPropertyBag()
        {
            return PartialView("PacientesPropertyBag", "Pacientes");
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
        public ActionResult AddDetalle_de_Padecimientos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_de_Padecimientos/AddDetalle_de_Padecimientos");
        }

        [HttpGet]
        public ActionResult AddDetalle_Antecedentes_Familiares(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Antecedentes_Familiares/AddDetalle_Antecedentes_Familiares");
        }

        [HttpGet]
        public ActionResult AddDetalle_Antecedentes_No_Patologicos(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Antecedentes_No_Patologicos/AddDetalle_Antecedentes_No_Patologicos");
        }

        [HttpGet]
        public ActionResult AddDetalle_Examenes_Laboratorio(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Examenes_Laboratorio/AddDetalle_Examenes_Laboratorio");
        }

        [HttpGet]
        public ActionResult AddDetalle_Terapia_Hormonal(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Terapia_Hormonal/AddDetalle_Terapia_Hormonal");
        }

        [HttpGet]
        public ActionResult AddMS_Exclusion_Ingredientes_Paciente(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Exclusion_Ingredientes_Paciente/AddMS_Exclusion_Ingredientes_Paciente");
        }

        [HttpGet]
        public ActionResult AddDetalle_Preferencia_Bebidas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Preferencia_Bebidas/AddDetalle_Preferencia_Bebidas");
        }

        [HttpGet]
        public ActionResult AddDetalle_Pagos_Paciente(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Pagos_Paciente/AddDetalle_Pagos_Paciente");
        }

        [HttpGet]
        public ActionResult AddDetalle_Suscripciones_Paciente(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Suscripciones_Paciente/AddDetalle_Suscripciones_Paciente");
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
                var whereClauseFormat = "Object = 44337 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Pacientes.Folio= " + RecordId;
                            var result = _IPacientesApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new PacientesPropertyMapper());
			
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
                    (PacientesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            PacientesPropertyMapper oPacientesPropertyMapper = new PacientesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPacientesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Pacientess == null)
                result.Pacientess = new List<Pacientes>();

            var data = result.Pacientess.Select(m => new PacientesGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Registro_Tipo_de_Registro.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                        ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Paciente_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Celular = m.Celular
			,Email = m.Email
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
			,Nombre_del_Padre_o_Tutor = m.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Lugar_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Estado_CivilDescripcion = CultureHelper.GetTraduction(m.Estado_Civil_Estado_Civil.Clave.ToString(), "Descripcion") ?? (string)m.Estado_Civil_Estado_Civil.Descripcion
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
			,Ocupacion = m.Ocupacion
			,Cantidad_hijos = m.Cantidad_hijos
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
                        ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(m.Estatus_Paciente_Estatus_por_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion
                        ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(m.Cuenta_con_padecimientos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Frecuencia_Respiratoria = m.Frecuencia_Respiratoria
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Peso_habitual = m.Peso_habitual
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Anchura_de_muneca_mm = m.Anchura_de_muneca_mm
			,Circunferencia_de_brazo_cm = m.Circunferencia_de_brazo_cm
			,Pliegue_cutaneo_tricipital_mm = m.Pliegue_cutaneo_tricipital_mm
			,Pliegue_cutaneo_bicipital_mm = m.Pliegue_cutaneo_bicipital_mm
			,Pliegue_cutaneo_subescapular_mm = m.Pliegue_cutaneo_subescapular_mm
			,Pliegue_cutaneo_supraespinal_mm = m.Pliegue_cutaneo_supraespinal_mm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Masa_Muscular_ = m.Masa_Muscular_
                        ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(m.Esta_embarazada_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Esta_embarazada_Respuesta_Logica.Descripcion
			,Semana_de_gestacion = m.Semana_de_gestacion
			,Peso_pregestacional = m.Peso_pregestacional
                        ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(m.Toma_anticonceptivos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Toma_anticonceptivos_Respuesta_Logica.Descripcion
			,Nombre_del_Anticonceptivo = m.Nombre_del_Anticonceptivo
			,Dosis = m.Dosis
                        ,ClimaterioDescripcion = CultureHelper.GetTraduction(m.Climaterio_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Climaterio_Respuesta_Logica.Descripcion
                        ,Fecha_Climaterio = (m.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(m.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                        ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(m.Terapia_reemplazo_hormonal_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion
                        ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(m.Tipo_Dieta_Tipo_de_Dieta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                        ,SuplementosDescripcion = CultureHelper.GetTraduction(m.Suplementos_Suplementos.Clave.ToString(), "Descripcion") ?? (string)m.Suplementos_Suplementos.Descripcion
                        ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(m.Consumo_de_sal_Preferencias_Sal.Clave.ToString(), "Descripcion") ?? (string)m.Consumo_de_sal_Preferencias_Sal.Descripcion
                        ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Grasas_Preferencias_Preferencias_Grasas.Clave.ToString(), "Descripcion") ?? (string)m.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                        ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(m.Comidas_cantidad_Cantidad_Comidas.Clave.ToString(), "Descripcion") ?? (string)m.Comidas_cantidad_Cantidad_Comidas.Descripcion
                        ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Preparacion_Preferencias_Preferencias_Preparacion.Clave.ToString(), "Descripcion") ?? (string)m.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                        ,Entre_comidasDescripcion = CultureHelper.GetTraduction(m.Entre_comidas_Preferencias_Entrecomidas.Clave.ToString(), "Descripcion") ?? (string)m.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                        ,ApetitoDescripcion = CultureHelper.GetTraduction(m.Apetito_Nivel_de_Satisfaccion.Clave.ToString(), "Descripcion") ?? (string)m.Apetito_Nivel_de_Satisfaccion.Descripcion
                        ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Clave.ToString(), "Descripcion") ?? (string)m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                        ,Horario_hambreDescripcion = CultureHelper.GetTraduction(m.Horario_hambre_Periodo_del_dia.Clave.ToString(), "Descripcion") ?? (string)m.Horario_hambre_Periodo_del_dia.Descripcion
                        ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Clave.ToString(), "Descripcion") ?? (string)m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                        ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(m.Medicamentos_bajar_peso_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
			,Cual_medicamento = m.Cual_medicamento
                        ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                        ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(m.Duracion_Ejercicio_Duracion_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                        ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Clave.ToString(), "Descripcion") ?? (string)m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion
			,IMC = m.IMC
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
			,Complexion_corporal = m.Complexion_corporal
                        ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_complexion_corporal_Interpretacion_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
			,Distribucion_de_grasa_corporal = m.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44337, arrayColumnsVisible), "PacientesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44337, arrayColumnsVisible), "PacientesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44337, arrayColumnsVisible), "PacientesList_" + DateTime.Now.ToString());
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

            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new PacientesPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (PacientesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            PacientesPropertyMapper oPacientesPropertyMapper = new PacientesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oPacientesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IPacientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Pacientess == null)
                result.Pacientess = new List<Pacientes>();

            var data = result.Pacientess.Select(m => new PacientesGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Registro_Tipo_de_Registro.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                        ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Paciente_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Celular = m.Celular
			,Email = m.Email
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
			,Nombre_del_Padre_o_Tutor = m.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Lugar_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Estado_CivilDescripcion = CultureHelper.GetTraduction(m.Estado_Civil_Estado_Civil.Clave.ToString(), "Descripcion") ?? (string)m.Estado_Civil_Estado_Civil.Descripcion
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
			,Ocupacion = m.Ocupacion
			,Cantidad_hijos = m.Cantidad_hijos
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
                        ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(m.Estatus_Paciente_Estatus_por_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion
                        ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(m.Cuenta_con_padecimientos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Frecuencia_Respiratoria = m.Frecuencia_Respiratoria
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Peso_habitual = m.Peso_habitual
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Anchura_de_muneca_mm = m.Anchura_de_muneca_mm
			,Circunferencia_de_brazo_cm = m.Circunferencia_de_brazo_cm
			,Pliegue_cutaneo_tricipital_mm = m.Pliegue_cutaneo_tricipital_mm
			,Pliegue_cutaneo_bicipital_mm = m.Pliegue_cutaneo_bicipital_mm
			,Pliegue_cutaneo_subescapular_mm = m.Pliegue_cutaneo_subescapular_mm
			,Pliegue_cutaneo_supraespinal_mm = m.Pliegue_cutaneo_supraespinal_mm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Masa_Muscular_ = m.Masa_Muscular_
                        ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(m.Esta_embarazada_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Esta_embarazada_Respuesta_Logica.Descripcion
			,Semana_de_gestacion = m.Semana_de_gestacion
			,Peso_pregestacional = m.Peso_pregestacional
                        ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(m.Toma_anticonceptivos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Toma_anticonceptivos_Respuesta_Logica.Descripcion
			,Nombre_del_Anticonceptivo = m.Nombre_del_Anticonceptivo
			,Dosis = m.Dosis
                        ,ClimaterioDescripcion = CultureHelper.GetTraduction(m.Climaterio_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Climaterio_Respuesta_Logica.Descripcion
                        ,Fecha_Climaterio = (m.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(m.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                        ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(m.Terapia_reemplazo_hormonal_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion
                        ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(m.Tipo_Dieta_Tipo_de_Dieta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                        ,SuplementosDescripcion = CultureHelper.GetTraduction(m.Suplementos_Suplementos.Clave.ToString(), "Descripcion") ?? (string)m.Suplementos_Suplementos.Descripcion
                        ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(m.Consumo_de_sal_Preferencias_Sal.Clave.ToString(), "Descripcion") ?? (string)m.Consumo_de_sal_Preferencias_Sal.Descripcion
                        ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Grasas_Preferencias_Preferencias_Grasas.Clave.ToString(), "Descripcion") ?? (string)m.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                        ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(m.Comidas_cantidad_Cantidad_Comidas.Clave.ToString(), "Descripcion") ?? (string)m.Comidas_cantidad_Cantidad_Comidas.Descripcion
                        ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Preparacion_Preferencias_Preferencias_Preparacion.Clave.ToString(), "Descripcion") ?? (string)m.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                        ,Entre_comidasDescripcion = CultureHelper.GetTraduction(m.Entre_comidas_Preferencias_Entrecomidas.Clave.ToString(), "Descripcion") ?? (string)m.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                        ,ApetitoDescripcion = CultureHelper.GetTraduction(m.Apetito_Nivel_de_Satisfaccion.Clave.ToString(), "Descripcion") ?? (string)m.Apetito_Nivel_de_Satisfaccion.Descripcion
                        ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Clave.ToString(), "Descripcion") ?? (string)m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                        ,Horario_hambreDescripcion = CultureHelper.GetTraduction(m.Horario_hambre_Periodo_del_dia.Clave.ToString(), "Descripcion") ?? (string)m.Horario_hambre_Periodo_del_dia.Descripcion
                        ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Clave.ToString(), "Descripcion") ?? (string)m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                        ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(m.Medicamentos_bajar_peso_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
			,Cual_medicamento = m.Cual_medicamento
                        ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                        ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(m.Duracion_Ejercicio_Duracion_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                        ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Clave.ToString(), "Descripcion") ?? (string)m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion
			,IMC = m.IMC
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
			,Complexion_corporal = m.Complexion_corporal
                        ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_complexion_corporal_Interpretacion_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
			,Distribucion_de_grasa_corporal = m.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones

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
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPacientesApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Pacientes_Datos_GeneralesModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_Datos_GeneralesInfo = new Pacientes_Datos_Generales
                {
                    Folio = varPacientes.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varPacientes.Fecha_de_Registro)) ? DateTime.ParseExact(varPacientes.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varPacientes.Hora_de_Registro
                        ,Usuario_que_Registra = varPacientes.Usuario_que_Registra
                        ,Tipo_de_Registro = varPacientes.Tipo_de_Registro
                        ,Tipo_de_Paciente = varPacientes.Tipo_de_Paciente
                        ,Usuario_Registrado = varPacientes.Usuario_Registrado
                        ,Empresa = varPacientes.Empresa
                        ,Numero_de_Empleado = varPacientes.Numero_de_Empleado
                        ,Nombres = varPacientes.Nombres
                        ,Apellido_Paterno = varPacientes.Apellido_Paterno
                        ,Apellido_Materno = varPacientes.Apellido_Materno
                        ,Nombre_Completo = varPacientes.Nombre_Completo
                        ,Celular = varPacientes.Celular
                        ,Email = varPacientes.Email
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varPacientes.Fecha_de_nacimiento)) ? DateTime.ParseExact(varPacientes.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Nombre_del_Padre_o_Tutor = varPacientes.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimiento = varPacientes.Pais_de_nacimiento
                        ,Lugar_de_nacimiento = varPacientes.Lugar_de_nacimiento
                        ,Sexo = varPacientes.Sexo
                        ,Estado_Civil = varPacientes.Estado_Civil
                        ,Calle = varPacientes.Calle
                        ,Numero_exterior = varPacientes.Numero_exterior
                        ,Numero_interior = varPacientes.Numero_interior
                        ,Colonia = varPacientes.Colonia
                        ,CP = varPacientes.CP
                        ,Ciudad = varPacientes.Ciudad
                        ,Pais = varPacientes.Pais
                        ,Estado = varPacientes.Estado
                        ,Ocupacion = varPacientes.Ocupacion
                        ,Cantidad_hijos = varPacientes.Cantidad_hijos
                        ,Objetivo = varPacientes.Objetivo
                        ,Estatus_Paciente = varPacientes.Estatus_Paciente
                    
                };

                result = _IPacientesApiConsumer.Update_Datos_Generales(Pacientes_Datos_GeneralesInfo).Resource.ToString();
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
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Tipo_de_Registro = m.Tipo_de_Registro
                        ,Tipo_de_RegistroDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Registro_Tipo_de_Registro.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Registro_Tipo_de_Registro.Descripcion
                        ,Tipo_de_Paciente = m.Tipo_de_Paciente
                        ,Tipo_de_PacienteDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Paciente_Tipo_Paciente.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Paciente_Tipo_Paciente.Descripcion
                        ,Usuario_Registrado = m.Usuario_Registrado
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
                        ,Empresa = m.Empresa
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Celular = m.Celular
			,Email = m.Email
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
			,Nombre_del_Padre_o_Tutor = m.Nombre_del_Padre_o_Tutor
                        ,Pais_de_nacimiento = m.Pais_de_nacimiento
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Lugar_de_nacimiento = m.Lugar_de_nacimiento
                        ,Lugar_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Lugar_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Lugar_de_nacimiento_Estado.Nombre_del_Estado
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Estado_Civil = m.Estado_Civil
                        ,Estado_CivilDescripcion = CultureHelper.GetTraduction(m.Estado_Civil_Estado_Civil.Clave.ToString(), "Descripcion") ?? (string)m.Estado_Civil_Estado_Civil.Descripcion
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,Pais = m.Pais
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Estado = m.Estado
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
			,Ocupacion = m.Ocupacion
			,Cantidad_hijos = m.Cantidad_hijos
                        ,Objetivo = m.Objetivo
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
                        ,Estatus_Paciente = m.Estatus_Paciente
                        ,Estatus_PacienteDescripcion = CultureHelper.GetTraduction(m.Estatus_Paciente_Estatus_por_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Paciente_Estatus_por_Suscripcion.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Padecimientos(Pacientes_PadecimientosModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_PadecimientosInfo = new Pacientes_Padecimientos
                {
                    Folio = varPacientes.Folio
                                            ,Cuenta_con_padecimientos = varPacientes.Cuenta_con_padecimientos
                    
                };

                result = _IPacientesApiConsumer.Update_Padecimientos(Pacientes_PadecimientosInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Padecimientos(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Padecimientos(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_PadecimientosModel
                {
                    Folio = m.Folio
                        ,Cuenta_con_padecimientos = m.Cuenta_con_padecimientos
                        ,Cuenta_con_padecimientosDescripcion = CultureHelper.GetTraduction(m.Cuenta_con_padecimientos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Cuenta_con_padecimientos_Respuesta_Logica.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Antecedentes(Pacientes_AntecedentesModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_AntecedentesInfo = new Pacientes_Antecedentes
                {
                    Folio = varPacientes.Folio
                                        
                };

                result = _IPacientesApiConsumer.Update_Antecedentes(Pacientes_AntecedentesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Antecedentes(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Antecedentes(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_AntecedentesModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Mediciones_Iniciales(Pacientes_Mediciones_InicialesModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_Mediciones_InicialesInfo = new Pacientes_Mediciones_Iniciales
                {
                    Folio = varPacientes.Folio
                                            ,Frecuencia_Cardiaca = varPacientes.Frecuencia_Cardiaca
                        ,Frecuencia_Respiratoria = varPacientes.Frecuencia_Respiratoria
                        ,Presion_sistolica = varPacientes.Presion_sistolica
                        ,Presion_diastolica = varPacientes.Presion_diastolica
                        ,Peso_actual = varPacientes.Peso_actual
                        ,Estatura = varPacientes.Estatura
                        ,Peso_habitual = varPacientes.Peso_habitual
                        ,Circunferencia_de_cintura_cm = varPacientes.Circunferencia_de_cintura_cm
                        ,Circunferencia_de_cadera_cm = varPacientes.Circunferencia_de_cadera_cm
                        ,Anchura_de_muneca_mm = varPacientes.Anchura_de_muneca_mm
                        ,Circunferencia_de_brazo_cm = varPacientes.Circunferencia_de_brazo_cm
                        ,Pliegue_cutaneo_tricipital_mm = varPacientes.Pliegue_cutaneo_tricipital_mm
                        ,Pliegue_cutaneo_bicipital_mm = varPacientes.Pliegue_cutaneo_bicipital_mm
                        ,Pliegue_cutaneo_subescapular_mm = varPacientes.Pliegue_cutaneo_subescapular_mm
                        ,Pliegue_cutaneo_supraespinal_mm = varPacientes.Pliegue_cutaneo_supraespinal_mm
                        ,Edad_Metabolica = varPacientes.Edad_Metabolica
                        ,Agua_corporal = varPacientes.Agua_corporal
                        ,Grasa_Visceral = varPacientes.Grasa_Visceral
                        ,Grasa_Corporal = varPacientes.Grasa_Corporal
                        ,Grasa_Corporal_kg = varPacientes.Grasa_Corporal_kg
                        ,Masa_Muscular_kg = varPacientes.Masa_Muscular_kg
                        ,Masa_Muscular_ = varPacientes.Masa_Muscular_
                    
                };

                result = _IPacientesApiConsumer.Update_Mediciones_Iniciales(Pacientes_Mediciones_InicialesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Mediciones_Iniciales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Mediciones_Iniciales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_Mediciones_InicialesModel
                {
                    Folio = m.Folio
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Frecuencia_Respiratoria = m.Frecuencia_Respiratoria
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Peso_habitual = m.Peso_habitual
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Anchura_de_muneca_mm = m.Anchura_de_muneca_mm
			,Circunferencia_de_brazo_cm = m.Circunferencia_de_brazo_cm
			,Pliegue_cutaneo_tricipital_mm = m.Pliegue_cutaneo_tricipital_mm
			,Pliegue_cutaneo_bicipital_mm = m.Pliegue_cutaneo_bicipital_mm
			,Pliegue_cutaneo_subescapular_mm = m.Pliegue_cutaneo_subescapular_mm
			,Pliegue_cutaneo_supraespinal_mm = m.Pliegue_cutaneo_supraespinal_mm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Masa_Muscular_ = m.Masa_Muscular_

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Ginecologicos(Pacientes_Datos_GinecologicosModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_Datos_GinecologicosInfo = new Pacientes_Datos_Ginecologicos
                {
                    Folio = varPacientes.Folio
                                            ,Esta_embarazada = varPacientes.Esta_embarazada
                        ,Semana_de_gestacion = varPacientes.Semana_de_gestacion
                        ,Peso_pregestacional = varPacientes.Peso_pregestacional
                        ,Toma_anticonceptivos = varPacientes.Toma_anticonceptivos
                        ,Nombre_del_Anticonceptivo = varPacientes.Nombre_del_Anticonceptivo
                        ,Dosis = varPacientes.Dosis
                        ,Climaterio = varPacientes.Climaterio
                        ,Fecha_Climaterio = (!String.IsNullOrEmpty(varPacientes.Fecha_Climaterio)) ? DateTime.ParseExact(varPacientes.Fecha_Climaterio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Terapia_reemplazo_hormonal = varPacientes.Terapia_reemplazo_hormonal
                    
                };

                result = _IPacientesApiConsumer.Update_Datos_Ginecologicos(Pacientes_Datos_GinecologicosInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Ginecologicos(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Datos_Ginecologicos(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_Datos_GinecologicosModel
                {
                    Folio = m.Folio
                        ,Esta_embarazada = m.Esta_embarazada
                        ,Esta_embarazadaDescripcion = CultureHelper.GetTraduction(m.Esta_embarazada_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Esta_embarazada_Respuesta_Logica.Descripcion
			,Semana_de_gestacion = m.Semana_de_gestacion
			,Peso_pregestacional = m.Peso_pregestacional
                        ,Toma_anticonceptivos = m.Toma_anticonceptivos
                        ,Toma_anticonceptivosDescripcion = CultureHelper.GetTraduction(m.Toma_anticonceptivos_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Toma_anticonceptivos_Respuesta_Logica.Descripcion
			,Nombre_del_Anticonceptivo = m.Nombre_del_Anticonceptivo
			,Dosis = m.Dosis
                        ,Climaterio = m.Climaterio
                        ,ClimaterioDescripcion = CultureHelper.GetTraduction(m.Climaterio_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Climaterio_Respuesta_Logica.Descripcion
                        ,Fecha_Climaterio = (m.Fecha_Climaterio == null ? string.Empty : Convert.ToDateTime(m.Fecha_Climaterio).ToString(ConfigurationProperty.DateFormat))
                        ,Terapia_reemplazo_hormonal = m.Terapia_reemplazo_hormonal
                        ,Terapia_reemplazo_hormonalDescripcion = CultureHelper.GetTraduction(m.Terapia_reemplazo_hormonal_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Terapia_reemplazo_hormonal_Respuesta_Logica.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Historia_Nutricional(Pacientes_Historia_NutricionalModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_Historia_NutricionalInfo = new Pacientes_Historia_Nutricional
                {
                    Folio = varPacientes.Folio
                                            ,Tipo_Dieta = varPacientes.Tipo_Dieta
                        ,Suplementos = varPacientes.Suplementos
                        ,Consumo_de_sal = varPacientes.Consumo_de_sal
                        ,Grasas_Preferencias = varPacientes.Grasas_Preferencias
                        ,Comidas_cantidad = varPacientes.Comidas_cantidad
                        ,Preparacion_Preferencias = varPacientes.Preparacion_Preferencias
                        ,Entre_comidas = varPacientes.Entre_comidas
                        ,Apetito = varPacientes.Apetito
                        ,Habitos_Modificacion = varPacientes.Habitos_Modificacion
                        ,Horario_hambre = varPacientes.Horario_hambre
                        ,Cuando_cambia_mi_estado_de_animo = varPacientes.Cuando_cambia_mi_estado_de_animo
                        ,Medicamentos_bajar_peso = varPacientes.Medicamentos_bajar_peso
                        ,Cual_medicamento = varPacientes.Cual_medicamento
                    
                };

                result = _IPacientesApiConsumer.Update_Historia_Nutricional(Pacientes_Historia_NutricionalInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Historia_Nutricional(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Historia_Nutricional(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_Historia_NutricionalModel
                {
                    Folio = m.Folio
                        ,Tipo_Dieta = m.Tipo_Dieta
                        ,Tipo_DietaDescripcion = CultureHelper.GetTraduction(m.Tipo_Dieta_Tipo_de_Dieta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Dieta_Tipo_de_Dieta.Descripcion
                        ,Suplementos = m.Suplementos
                        ,SuplementosDescripcion = CultureHelper.GetTraduction(m.Suplementos_Suplementos.Clave.ToString(), "Descripcion") ?? (string)m.Suplementos_Suplementos.Descripcion
                        ,Consumo_de_sal = m.Consumo_de_sal
                        ,Consumo_de_salDescripcion = CultureHelper.GetTraduction(m.Consumo_de_sal_Preferencias_Sal.Clave.ToString(), "Descripcion") ?? (string)m.Consumo_de_sal_Preferencias_Sal.Descripcion
                        ,Grasas_Preferencias = m.Grasas_Preferencias
                        ,Grasas_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Grasas_Preferencias_Preferencias_Grasas.Clave.ToString(), "Descripcion") ?? (string)m.Grasas_Preferencias_Preferencias_Grasas.Descripcion
                        ,Comidas_cantidad = m.Comidas_cantidad
                        ,Comidas_cantidadDescripcion = CultureHelper.GetTraduction(m.Comidas_cantidad_Cantidad_Comidas.Clave.ToString(), "Descripcion") ?? (string)m.Comidas_cantidad_Cantidad_Comidas.Descripcion
                        ,Preparacion_Preferencias = m.Preparacion_Preferencias
                        ,Preparacion_PreferenciasDescripcion = CultureHelper.GetTraduction(m.Preparacion_Preferencias_Preferencias_Preparacion.Clave.ToString(), "Descripcion") ?? (string)m.Preparacion_Preferencias_Preferencias_Preparacion.Descripcion
                        ,Entre_comidas = m.Entre_comidas
                        ,Entre_comidasDescripcion = CultureHelper.GetTraduction(m.Entre_comidas_Preferencias_Entrecomidas.Clave.ToString(), "Descripcion") ?? (string)m.Entre_comidas_Preferencias_Entrecomidas.Descripcion
                        ,Apetito = m.Apetito
                        ,ApetitoDescripcion = CultureHelper.GetTraduction(m.Apetito_Nivel_de_Satisfaccion.Clave.ToString(), "Descripcion") ?? (string)m.Apetito_Nivel_de_Satisfaccion.Descripcion
                        ,Habitos_Modificacion = m.Habitos_Modificacion
                        ,Habitos_ModificacionDescripcion = CultureHelper.GetTraduction(m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Clave.ToString(), "Descripcion") ?? (string)m.Habitos_Modificacion_Tipo_Modificacion_Alimentos.Descripcion
                        ,Horario_hambre = m.Horario_hambre
                        ,Horario_hambreDescripcion = CultureHelper.GetTraduction(m.Horario_hambre_Periodo_del_dia.Clave.ToString(), "Descripcion") ?? (string)m.Horario_hambre_Periodo_del_dia.Descripcion
                        ,Cuando_cambia_mi_estado_de_animo = m.Cuando_cambia_mi_estado_de_animo
                        ,Cuando_cambia_mi_estado_de_animoDescripcion = CultureHelper.GetTraduction(m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Clave.ToString(), "Descripcion") ?? (string)m.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo.Descripcion
                        ,Medicamentos_bajar_peso = m.Medicamentos_bajar_peso
                        ,Medicamentos_bajar_pesoDescripcion = CultureHelper.GetTraduction(m.Medicamentos_bajar_peso_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Medicamentos_bajar_peso_Respuesta_Logica.Descripcion
			,Cual_medicamento = m.Cual_medicamento

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Estilo_de_Vida(Pacientes_Estilo_de_VidaModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_Estilo_de_VidaInfo = new Pacientes_Estilo_de_Vida
                {
                    Folio = varPacientes.Folio
                                            ,Frecuencia_Ejercicio = varPacientes.Frecuencia_Ejercicio
                        ,Duracion_Ejercicio = varPacientes.Duracion_Ejercicio
                        ,Tipo_Ejercicio = varPacientes.Tipo_Ejercicio
                        ,Antiguedad_Ejercicio = varPacientes.Antiguedad_Ejercicio
                    
                };

                result = _IPacientesApiConsumer.Update_Estilo_de_Vida(Pacientes_Estilo_de_VidaInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Estilo_de_Vida(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Estilo_de_Vida(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_Estilo_de_VidaModel
                {
                    Folio = m.Folio
                        ,Frecuencia_Ejercicio = m.Frecuencia_Ejercicio
                        ,Frecuencia_EjercicioDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Ejercicio_Frecuencia_Ejercicio.Descripcion
                        ,Duracion_Ejercicio = m.Duracion_Ejercicio
                        ,Duracion_EjercicioDescripcion = CultureHelper.GetTraduction(m.Duracion_Ejercicio_Duracion_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Duracion_Ejercicio_Duracion_Ejercicio.Descripcion
                        ,Tipo_Ejercicio = m.Tipo_Ejercicio
                        ,Tipo_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Antiguedad_Ejercicio = m.Antiguedad_Ejercicio
                        ,Antiguedad_EjercicioDescripcion = CultureHelper.GetTraduction(m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Clave.ToString(), "Descripcion") ?? (string)m.Antiguedad_Ejercicio_Antiguedad_Ejercicios.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Resultados(Pacientes_ResultadosModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_ResultadosInfo = new Pacientes_Resultados
                {
                    Folio = varPacientes.Folio
                                            ,IMC = varPacientes.IMC
                        ,Interpretacion_IMC = varPacientes.Interpretacion_IMC
                        ,IMC_Pediatria = varPacientes.IMC_Pediatria
                        ,Complexion_corporal = varPacientes.Complexion_corporal
                        ,Interpretacion_complexion_corporal = varPacientes.Interpretacion_complexion_corporal
                        ,Distribucion_de_grasa_corporal = varPacientes.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporal = varPacientes.Interpretacion_grasa_corporal
                        ,Indice_cintura_cadera = varPacientes.Indice_cintura_cadera
                        ,Interpretacion_indice = varPacientes.Interpretacion_indice
                        ,Consumo_de_agua_resultado = varPacientes.Consumo_de_agua_resultado
                        ,Interpretacion_agua = varPacientes.Interpretacion_agua
                        ,Frecuencia_cardiaca_en_Esfuerzo = varPacientes.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuencia = varPacientes.Interpretacion_frecuencia
                        ,Dificultad_de_Rutina_de_Ejercicios = varPacientes.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultad = varPacientes.Interpretacion_dificultad
                        ,Calorias = varPacientes.Calorias
                        ,Interpretacion_calorias = varPacientes.Interpretacion_calorias
                        ,Observaciones = varPacientes.Observaciones
                    
                };

                result = _IPacientesApiConsumer.Update_Resultados(Pacientes_ResultadosInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Resultados(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Resultados(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_ResultadosModel
                {
                    Folio = m.Folio
			,IMC = m.IMC
                        ,Interpretacion_IMC = m.Interpretacion_IMC
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                        ,IMC_Pediatria = m.IMC_Pediatria
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
			,Complexion_corporal = m.Complexion_corporal
                        ,Interpretacion_complexion_corporal = m.Interpretacion_complexion_corporal
                        ,Interpretacion_complexion_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_complexion_corporal_Interpretacion_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_complexion_corporal_Interpretacion_corporal.Descripcion
			,Distribucion_de_grasa_corporal = m.Distribucion_de_grasa_corporal
                        ,Interpretacion_grasa_corporal = m.Interpretacion_grasa_corporal
                        ,Interpretacion_grasa_corporalDescripcion = CultureHelper.GetTraduction(m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indice = m.Interpretacion_indice
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_agua = m.Interpretacion_agua
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuencia = m.Interpretacion_frecuencia
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultad = m.Interpretacion_dificultad
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_calorias = m.Interpretacion_calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Suscripcion(Pacientes_SuscripcionModel varPacientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Pacientes_SuscripcionInfo = new Pacientes_Suscripcion
                {
                    Folio = varPacientes.Folio
                                        
                };

                result = _IPacientesApiConsumer.Update_Suscripcion(Pacientes_SuscripcionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Suscripcion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IPacientesApiConsumer.Get_Suscripcion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_de_Padecimientos;
                var Detalle_de_PadecimientosData = GetDetalle_de_PadecimientosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_de_Padecimientos);
                int RowCount_Detalle_Antecedentes_Familiares;
                var Detalle_Antecedentes_FamiliaresData = GetDetalle_Antecedentes_FamiliaresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_Familiares);
                int RowCount_Detalle_Antecedentes_No_Patologicos;
                var Detalle_Antecedentes_No_PatologicosData = GetDetalle_Antecedentes_No_PatologicosData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Antecedentes_No_Patologicos);
                int RowCount_Detalle_Examenes_Laboratorio;
                var Detalle_Examenes_LaboratorioData = GetDetalle_Examenes_LaboratorioData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Examenes_Laboratorio);
                int RowCount_Detalle_Terapia_Hormonal;
                var Detalle_Terapia_HormonalData = GetDetalle_Terapia_HormonalData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Terapia_Hormonal);
                int RowCount_Detalle_Preferencia_Bebidas;
                var Detalle_Preferencia_BebidasData = GetDetalle_Preferencia_BebidasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Preferencia_Bebidas);
                int RowCount_Detalle_Pagos_Paciente;
                var Detalle_Pagos_PacienteData = GetDetalle_Pagos_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Paciente);
                int RowCount_Detalle_Suscripciones_Paciente;
                var Detalle_Suscripciones_PacienteData = GetDetalle_Suscripciones_PacienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Paciente);

                var result = new Pacientes_SuscripcionModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detalle_del_padecimiento = Detalle_de_PadecimientosData
                    ,Antecedentes_Familiares = Detalle_Antecedentes_FamiliaresData
                    ,Antecedentes_personales_no_patologicos = Detalle_Antecedentes_No_PatologicosData
                    ,Examenes_de_Laboratorio = Detalle_Examenes_LaboratorioData
                    ,Detalle_de_Terapia_Hormonal = Detalle_Terapia_HormonalData
                    ,Detalle_Bebidas_Paciente = Detalle_Preferencia_BebidasData
                    ,Pagos = Detalle_Pagos_PacienteData
                    ,Suscripciones = Detalle_Suscripciones_PacienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

