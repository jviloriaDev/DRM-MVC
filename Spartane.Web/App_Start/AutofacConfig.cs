using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using System.Web.Mvc;
using Spartane.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Core.Domain;
using Spartane.Services.Security;
using Spartane.Services.Authentication;
using Spartane.Services.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFile;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Controllers;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;
using Spartane.Services.Spartan_Format;
using Spartane.Core.Domain.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Services.Spartan_Format_Type;
using Spartane.Core.Domain.Spartan_Format_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Type;
using Spartane.Services.Spartan_Metadata;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Services.Spartan_Format_Configuration;
using Spartane.Core.Domain.Spartan_Format_Configuration;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Configuration;
using Spartane.Services.Spartan_Format_Field;
using Spartane.Core.Domain.Spartan_Format_Field;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Field;
using Spartane.Services.Spartan_Format_Permission_Type;
using Spartane.Core.Domain.Spartan_Format_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permission_Type;
using Spartane.Services.Spartan_Format_Permissions;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Services.Spartan_Report;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Services.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Field_Type;
using Spartane.Services.Spartan_Report_Fields_Detail;
using Spartane.Core.Domain.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail;
using Spartane.Services.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format;
using Spartane.Services.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Function;
using Spartane.Services.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Order_Type;
using Spartane.Services.Spartan_Report_Permission_Type;
using Spartane.Core.Domain.Spartan_Report_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permission_Type;
using Spartane.Services.Spartan_Report_Permissions;
using Spartane.Core.Domain.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Services.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;
using Spartane.Services.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View;
using Spartane.Services.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Filter;

using Spartane.Services.Spartan_User;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Services.Spartan_User_Role;
using Spartane.Core.Domain.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Services.Spartan_User_Role_Status;
using Spartane.Core.Domain.Spartan_User_Role_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role_Status;
using Spartane.Services.Spartan_User_Status;
using Spartane.Core.Domain.Spartan_User_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Status;


using Spartane.Services.Spartan_Traduction_Concept_Type;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;
using Spartane.Services.Spartan_Traduction_Detail;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Services.Spartan_Traduction_Language;
using Spartane.Core.Domain.Spartan_Traduction_Language;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Language;
using Spartane.Services.Spartan_Traduction_Object;
using Spartane.Core.Domain.Spartan_Traduction_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object;
using Spartane.Services.Spartan_Traduction_Object_Type;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object_Type;
using Spartane.Services.Spartan_Traduction_Process;
using Spartane.Core.Domain.Spartan_Traduction_Process;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process;
using Spartane.Services.Spartan_Traduction_Process_Data;
using Spartane.Core.Domain.Spartan_Traduction_Process_Data;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Data;
using Spartane.Services.Spartan_Traduction_Process_Workflow;
using Spartane.Core.Domain.Spartan_Traduction_Process_Workflow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Workflow;

using Spartane.Services.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow;
using Spartane.Services.Spartan_WorkFlow_Condition;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition;
using Spartane.Services.Spartan_WorkFlow_Condition_Operator;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition_Operator;
using Spartane.Services.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Services.Spartan_WorkFlow_Information_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Information_by_State;
using Spartane.Services.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Services.Spartan_WorkFlow_Operator;
using Spartane.Core.Domain.Spartan_WorkFlow_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Operator;
using Spartane.Services.Spartan_WorkFlow_Phase_Status;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Status;
using Spartane.Services.Spartan_WorkFlow_Phase_Type;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Type;
using Spartane.Services.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Services.Spartan_WorkFlow_Roles_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State;
using Spartane.Services.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;
using Spartane.Services.Spartan_WorkFlow_Status;
using Spartane.Core.Domain.Spartan_WorkFlow_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Status;
using Spartane.Services.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Services.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Services.Spartan_Object;
using Spartane.Core.Domain.Spartan_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Object;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Advance_Filter;

using Spartane.Services.SpartanChangePasswordAutorizationEstatus;
using Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus;
using Spartane.Web.Areas.WebApiConsumer.SpartanChangePasswordAutorizationEstatus;
using Spartane.Services.Spartan_ChangePasswordAutorization;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using Spartane.Web.Areas.WebApiConsumer.Spartan_ChangePasswordAutorization;
using Spartane.Services.Spartan_User_Historical_Password;
using Spartane.Core.Domain.Spartan_User_Historical_Password;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Historical_Password;
using Spartane.Services.Spartan_Settings;
using Spartane.Core.Domain.Spartan_Settings;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Settings;

using Spartane.Services.Antiguedad_Ejercicios;
using Spartane.Core.Domain.Antiguedad_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Antiguedad_Ejercicios;
using Spartane.Services.Bebidas;
using Spartane.Core.Domain.Bebidas;
using Spartane.Web.Areas.WebApiConsumer.Bebidas;
using Spartane.Services.Calorias;
using Spartane.Core.Domain.Calorias;
using Spartane.Web.Areas.WebApiConsumer.Calorias;
using Spartane.Services.Cantidad_Comidas;
using Spartane.Core.Domain.Cantidad_Comidas;
using Spartane.Web.Areas.WebApiConsumer.Cantidad_Comidas;
using Spartane.Services.Categorias_de_platillos;
using Spartane.Core.Domain.Categorias_de_platillos;
using Spartane.Web.Areas.WebApiConsumer.Categorias_de_platillos;
using Spartane.Services.Clasificacion_Ingredientes;
using Spartane.Core.Domain.Clasificacion_Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Clasificacion_Ingredientes;
using Spartane.Services.Detalle_Antecedentes_Familiares;
using Spartane.Core.Domain.Detalle_Antecedentes_Familiares;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Antecedentes_Familiares;
using Spartane.Services.Detalle_Antecedentes_No_Patologicos;
using Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Antecedentes_No_Patologicos;
using Spartane.Services.Detalle_de_Ingredientes;
using Spartane.Core.Domain.Detalle_de_Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Ingredientes;
using Spartane.Services.Detalle_de_Padecimientos;
using Spartane.Core.Domain.Detalle_de_Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Padecimientos;
using Spartane.Services.Detalle_Examenes_Laboratorio;
using Spartane.Core.Domain.Detalle_Examenes_Laboratorio;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Examenes_Laboratorio;
using Spartane.Services.Detalle_Preferencia_Bebidas;
using Spartane.Core.Domain.Detalle_Preferencia_Bebidas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Preferencia_Bebidas;
using Spartane.Services.Detalle_Terapia_Hormonal;
using Spartane.Core.Domain.Detalle_Terapia_Hormonal;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Terapia_Hormonal;
using Spartane.Services.Dias_de_la_semana;
using Spartane.Core.Domain.Dias_de_la_semana;
using Spartane.Web.Areas.WebApiConsumer.Dias_de_la_semana;
using Spartane.Services.Dificultad_de_platillos;
using Spartane.Core.Domain.Dificultad_de_platillos;
using Spartane.Web.Areas.WebApiConsumer.Dificultad_de_platillos;
using Spartane.Services.Duracion_Ejercicio;
using Spartane.Core.Domain.Duracion_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Duracion_Ejercicio;
using Spartane.Services.Ejercicios;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Ejercicios;
using Spartane.Services.Empresas;
using Spartane.Core.Domain.Empresas;
using Spartane.Web.Areas.WebApiConsumer.Empresas;
using Spartane.Services.Enfermedades;
using Spartane.Core.Domain.Enfermedades;
using Spartane.Web.Areas.WebApiConsumer.Enfermedades;
using Spartane.Services.Estado;
using Spartane.Core.Domain.Estado;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Services.Estado_Civil;
using Spartane.Core.Domain.Estado_Civil;
using Spartane.Web.Areas.WebApiConsumer.Estado_Civil;
using Spartane.Services.Estado_de_Animo;
using Spartane.Core.Domain.Estado_de_Animo;
using Spartane.Web.Areas.WebApiConsumer.Estado_de_Animo;
using Spartane.Services.Estatus_Paciente;
using Spartane.Core.Domain.Estatus_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Paciente;
using Spartane.Services.Estatus_Padecimiento;
using Spartane.Core.Domain.Estatus_Padecimiento;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Padecimiento;
using Spartane.Services.Frecuencia_Ejercicio;
using Spartane.Core.Domain.Frecuencia_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_Ejercicio;
using Spartane.Services.Frecuencia_Sustancias;
using Spartane.Core.Domain.Frecuencia_Sustancias;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_Sustancias;
using Spartane.Services.Indicadores_Laboratorio;
using Spartane.Core.Domain.Indicadores_Laboratorio;
using Spartane.Web.Areas.WebApiConsumer.Indicadores_Laboratorio;
using Spartane.Services.Ingredientes;
using Spartane.Core.Domain.Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;
using Spartane.Services.Marca;
using Spartane.Core.Domain.Marca;
using Spartane.Web.Areas.WebApiConsumer.Marca;
using Spartane.Services.Medicos;
using Spartane.Core.Domain.Medicos;
using Spartane.Web.Areas.WebApiConsumer.Medicos;
using Spartane.Services.Nivel_de_Satisfaccion;
using Spartane.Core.Domain.Nivel_de_Satisfaccion;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_Satisfaccion;
using Spartane.Services.Objetivos;
using Spartane.Core.Domain.Objetivos;
using Spartane.Web.Areas.WebApiConsumer.Objetivos;
using Spartane.Services.Pacientes;
using Spartane.Core.Domain.Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Pacientes;
using Spartane.Services.Padecimientos;
using Spartane.Core.Domain.Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Padecimientos;
using Spartane.Services.Pais;
using Spartane.Core.Domain.Pais;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Services.Parentesco;
using Spartane.Core.Domain.Parentesco;
using Spartane.Web.Areas.WebApiConsumer.Parentesco;
using Spartane.Services.Periodo_del_dia;
using Spartane.Core.Domain.Periodo_del_dia;
using Spartane.Web.Areas.WebApiConsumer.Periodo_del_dia;
using Spartane.Services.Platillos;
using Spartane.Core.Domain.Platillos;
using Spartane.Web.Areas.WebApiConsumer.Platillos;
using Spartane.Services.Preferencias_Entrecomidas;
using Spartane.Core.Domain.Preferencias_Entrecomidas;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Entrecomidas;
using Spartane.Services.Preferencias_Grasas;
using Spartane.Core.Domain.Preferencias_Grasas;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Grasas;
using Spartane.Services.Preferencias_Preparacion;
using Spartane.Core.Domain.Preferencias_Preparacion;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Preparacion;
using Spartane.Services.Preferencias_Sal;
using Spartane.Core.Domain.Preferencias_Sal;
using Spartane.Web.Areas.WebApiConsumer.Preferencias_Sal;
using Spartane.Services.Presentacion;
using Spartane.Core.Domain.Presentacion;
using Spartane.Web.Areas.WebApiConsumer.Presentacion;
using Spartane.Services.Rango_Consumo_Bebidas;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;
using Spartane.Web.Areas.WebApiConsumer.Rango_Consumo_Bebidas;
using Spartane.Services.Rango_de_Horas;
using Spartane.Core.Domain.Rango_de_Horas;
using Spartane.Web.Areas.WebApiConsumer.Rango_de_Horas;
using Spartane.Services.Registro;
using Spartane.Core.Domain.Registro;
using Spartane.Web.Areas.WebApiConsumer.Registro;
using Spartane.Services.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Services.Resultados_IMC;
using Spartane.Core.Domain.Resultados_IMC;
using Spartane.Web.Areas.WebApiConsumer.Resultados_IMC;
using Spartane.Services.Seleccion_de_Rangos;
using Spartane.Core.Domain.Seleccion_de_Rangos;
using Spartane.Web.Areas.WebApiConsumer.Seleccion_de_Rangos;
using Spartane.Services.Sexo;
using Spartane.Core.Domain.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Services.Suplementos;
using Spartane.Core.Domain.Suplementos;
using Spartane.Web.Areas.WebApiConsumer.Suplementos;
using Spartane.Services.Sustancias;
using Spartane.Core.Domain.Sustancias;
using Spartane.Web.Areas.WebApiConsumer.Sustancias;
using Spartane.Services.Tiempo_Padecimiento;
using Spartane.Core.Domain.Tiempo_Padecimiento;
using Spartane.Web.Areas.WebApiConsumer.Tiempo_Padecimiento;
using Spartane.Services.Tiempos_de_Comida;
using Spartane.Core.Domain.Tiempos_de_Comida;
using Spartane.Web.Areas.WebApiConsumer.Tiempos_de_Comida;
using Spartane.Services.Tipo_de_Dieta;
using Spartane.Core.Domain.Tipo_de_Dieta;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Dieta;
using Spartane.Services.Tipo_de_Registro;
using Spartane.Core.Domain.Tipo_de_Registro;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Registro;
using Spartane.Services.Tipo_Ejercicio;
using Spartane.Core.Domain.Tipo_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Ejercicio;
using Spartane.Services.Tipo_Modificacion_Alimentos;
using Spartane.Core.Domain.Tipo_Modificacion_Alimentos;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Modificacion_Alimentos;
using Spartane.Services.Tipo_Paciente;
using Spartane.Core.Domain.Tipo_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Paciente;
using Spartane.Services.Unidades_de_Medida;
using Spartane.Core.Domain.Unidades_de_Medida;
using Spartane.Web.Areas.WebApiConsumer.Unidades_de_Medida;
using Spartane.Services.Consultas;
using Spartane.Core.Domain.Consultas;
using Spartane.Web.Areas.WebApiConsumer.Consultas;
using Spartane.Services.Estatus;
using Spartane.Core.Domain.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Services.Profesiones;
using Spartane.Core.Domain.Profesiones;
using Spartane.Web.Areas.WebApiConsumer.Profesiones;
using Spartane.Services.Especialidades;
using Spartane.Core.Domain.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Services.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Services.Identificaciones_Oficiales;
using Spartane.Core.Domain.Identificaciones_Oficiales;
using Spartane.Web.Areas.WebApiConsumer.Identificaciones_Oficiales;
using Spartane.Services.Regimenes_Fiscales;
using Spartane.Core.Domain.Regimenes_Fiscales;
using Spartane.Web.Areas.WebApiConsumer.Regimenes_Fiscales;
using Spartane.Services.Interpretacion_de_porcentaje_de_grasa_corporal;
using Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_de_porcentaje_de_grasa_corporal;
using Spartane.Services.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_IMC;
using Spartane.Services.Interpretacion_corporal;
using Spartane.Core.Domain.Interpretacion_corporal;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_corporal;
using Spartane.Services.Interpretacion_distribucion_grasa_corporal;
using Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_distribucion_grasa_corporal;
using Spartane.Services.Interpretacion_indice_cintura__cadera;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_indice_cintura__cadera;
using Spartane.Services.Interpretacion_consumo_de_agua;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_consumo_de_agua;
using Spartane.Services.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Services.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Services.Interpretacion_Calorias;
using Spartane.Core.Domain.Interpretacion_Calorias;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Calorias;
using Spartane.Services.Tipo_de_Plan_de_Suscripcion;
using Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Plan_de_Suscripcion;
using Spartane.Services.Duracion_de_Planes_de_Suscripcion;
using Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Duracion_de_Planes_de_Suscripcion;
using Spartane.Services.Planes_de_Suscripcion;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Services.Estatus_por_Suscripcion;
using Spartane.Core.Domain.Estatus_por_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Estatus_por_Suscripcion;
using Spartane.Services.Detalle_Suscripciones_Paciente;
using Spartane.Core.Domain.Detalle_Suscripciones_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Paciente;
using Spartane.Services.Detalle_Pagos_Paciente;
using Spartane.Core.Domain.Detalle_Pagos_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Paciente;
using Spartane.Services.Estatus_de_Suscripcion;
using Spartane.Core.Domain.Estatus_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Suscripcion;
using Spartane.Services.Estatus_de_Pago;
using Spartane.Core.Domain.Estatus_de_Pago;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Pago;
using Spartane.Services.Formas_de_Pago;
using Spartane.Core.Domain.Formas_de_Pago;
using Spartane.Web.Areas.WebApiConsumer.Formas_de_Pago;
using Spartane.Services.Frecuencia_de_pago_Pacientes;
using Spartane.Core.Domain.Frecuencia_de_pago_Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Pacientes;
using Spartane.Services.Frecuencia_de_pago_Empresas;
using Spartane.Core.Domain.Frecuencia_de_pago_Empresas;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Empresas;
using Spartane.Services.Detalle_Resultados_Consultas;
using Spartane.Core.Domain.Detalle_Resultados_Consultas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Resultados_Consultas;
using Spartane.Services.Indicadores_Consultas;
using Spartane.Core.Domain.Indicadores_Consultas;
using Spartane.Web.Areas.WebApiConsumer.Indicadores_Consultas;
using Spartane.Services.Tipos_de_Especialistas;
using Spartane.Core.Domain.Tipos_de_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Especialistas;
using Spartane.Services.Detalle_Titulos_Medicos;
using Spartane.Core.Domain.Detalle_Titulos_Medicos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Titulos_Medicos;
using Spartane.Services.areas_Empresas;
using Spartane.Core.Domain.areas_Empresas;
using Spartane.Web.Areas.WebApiConsumer.areas_Empresas;
using Spartane.Services.Detalle_Suscripciones_Empresa;
using Spartane.Core.Domain.Detalle_Suscripciones_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Empresa;
using Spartane.Services.Detalle_Pagos_Empresa;
using Spartane.Core.Domain.Detalle_Pagos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Empresa;
using Spartane.Services.Detalle_Contactos_Empresa;
using Spartane.Core.Domain.Detalle_Contactos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Contactos_Empresa;
using Spartane.Services.Detalle_Contratos_Empresa;
using Spartane.Core.Domain.Detalle_Contratos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Contratos_Empresa;
using Spartane.Services.Tipos_de_Contrato;
using Spartane.Core.Domain.Tipos_de_Contrato;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Contrato;
using Spartane.Services.Detalle_Codigos_Referidos;
using Spartane.Core.Domain.Detalle_Codigos_Referidos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Codigos_Referidos;
using Spartane.Services.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Services.Aseguradoras;
using Spartane.Core.Domain.Aseguradoras;
using Spartane.Web.Areas.WebApiConsumer.Aseguradoras;
using Spartane.Services.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Services.Datos_Bancarios_Especialistas;
using Spartane.Core.Domain.Datos_Bancarios_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Datos_Bancarios_Especialistas;
using Spartane.Services.Detalle_Pagos_Especialistas;
using Spartane.Core.Domain.Detalle_Pagos_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Especialistas;
using Spartane.Services.Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Especialistas;
using Spartane.Services.Frecuencia_de_pago_Especialistas;
using Spartane.Core.Domain.Frecuencia_de_pago_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Especialistas;
using Spartane.Services.Bancos;
using Spartane.Core.Domain.Bancos;
using Spartane.Web.Areas.WebApiConsumer.Bancos;
using Spartane.Services.Eventos;
using Spartane.Core.Domain.Eventos;
using Spartane.Web.Areas.WebApiConsumer.Eventos;
using Spartane.Services.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;
using Spartane.Services.Estatus_Actividades_Evento;
using Spartane.Core.Domain.Estatus_Actividades_Evento;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Actividades_Evento;
using Spartane.Services.Estatus_Reservaciones_Actividad;
using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Reservaciones_Actividad;
using Spartane.Services.Tipos_de_Actividades;
using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades;
using Spartane.Services.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Ubicaciones_Eventos_Empresa;
using Spartane.Services.Actividades_del_Evento;
using Spartane.Core.Domain.Actividades_del_Evento;
using Spartane.Web.Areas.WebApiConsumer.Actividades_del_Evento;
using Spartane.Services.Detalle_Horarios_Actividad;
using Spartane.Core.Domain.Detalle_Horarios_Actividad;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Horarios_Actividad;
using Spartane.Services.Parentescos_Empleados;
using Spartane.Core.Domain.Parentescos_Empleados;
using Spartane.Web.Areas.WebApiConsumer.Parentescos_Empleados;
using Spartane.Services.Registro_en_Evento;
using Spartane.Core.Domain.Registro_en_Evento;
using Spartane.Web.Areas.WebApiConsumer.Registro_en_Evento;
using Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Services.Detalle_Registro_en_Actividad_Evento;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_en_Actividad_Evento;
using Spartane.Services.Estatus_Eventos;
using Spartane.Core.Domain.Estatus_Eventos;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Eventos;
using Spartane.Services.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Web.Areas.WebApiConsumer.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Services.Detalle_Especialistas_Pacientes;
using Spartane.Core.Domain.Detalle_Especialistas_Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Especialistas_Pacientes;
using Spartane.Services.Detalle_Facturacion_Especialistas;
using Spartane.Core.Domain.Detalle_Facturacion_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Facturacion_Especialistas;
using Spartane.Services.Estatus_Facturas;
using Spartane.Core.Domain.Estatus_Facturas;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Facturas;
using Spartane.Services.Titulos_Personales;
using Spartane.Core.Domain.Titulos_Personales;
using Spartane.Web.Areas.WebApiConsumer.Titulos_Personales;
using Spartane.Services.Detalle_Redes_Sociales_Especialista;
using Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Redes_Sociales_Especialista;
using Spartane.Services.Redes_sociales;
using Spartane.Core.Domain.Redes_sociales;
using Spartane.Web.Areas.WebApiConsumer.Redes_sociales;
using Spartane.Services.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Web.Areas.WebApiConsumer.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Services.Motivos;
using Spartane.Core.Domain.Motivos;
using Spartane.Web.Areas.WebApiConsumer.Motivos;
using Spartane.Services.Solicitud_de_Cita_con_Especialista;
using Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista;
using Spartane.Web.Areas.WebApiConsumer.Solicitud_de_Cita_con_Especialista;
using Spartane.Services.Calificacion;
using Spartane.Core.Domain.Calificacion;
using Spartane.Web.Areas.WebApiConsumer.Calificacion;
using Spartane.Services.Asuntos_Asistencia_Telefonica;
using Spartane.Core.Domain.Asuntos_Asistencia_Telefonica;
using Spartane.Web.Areas.WebApiConsumer.Asuntos_Asistencia_Telefonica;
using Spartane.Services.Estatus_Llamadas;
using Spartane.Core.Domain.Estatus_Llamadas;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Llamadas;
using Spartane.Services.Registro_de_Asistencia_Telefonica;
using Spartane.Core.Domain.Registro_de_Asistencia_Telefonica;
using Spartane.Web.Areas.WebApiConsumer.Registro_de_Asistencia_Telefonica;
using Spartane.Services.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Services.Tipos_de_Empresa;
using Spartane.Core.Domain.Tipos_de_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Empresa;
using Spartane.Services.Detalle_Caracteristicas_Ingrediente;
using Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Caracteristicas_Ingrediente;
using Spartane.Services.Tipo_de_comida_platillos;
using Spartane.Core.Domain.Tipo_de_comida_platillos;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_comida_platillos;
using Spartane.Services.Caracteristicas_platillo;
using Spartane.Core.Domain.Caracteristicas_platillo;
using Spartane.Web.Areas.WebApiConsumer.Caracteristicas_platillo;
using Spartane.Services.Detalle_Platillos;
using Spartane.Core.Domain.Detalle_Platillos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Platillos;
using Spartane.Services.Cantidad_fraccion_platillos;
using Spartane.Core.Domain.Cantidad_fraccion_platillos;
using Spartane.Web.Areas.WebApiConsumer.Cantidad_fraccion_platillos;
using Spartane.Services.Pantalla_Francisco;
using Spartane.Core.Domain.Pantalla_Francisco;
using Spartane.Web.Areas.WebApiConsumer.Pantalla_Francisco;
using Spartane.Services.Detalle_pantalla_Francisco;
using Spartane.Core.Domain.Detalle_pantalla_Francisco;
using Spartane.Web.Areas.WebApiConsumer.Detalle_pantalla_Francisco;
using Spartane.Services.Tips_y_Promociones;
using Spartane.Core.Domain.Tips_y_Promociones;
using Spartane.Web.Areas.WebApiConsumer.Tips_y_Promociones;
using Spartane.Services.Planes_Alimenticios;
using Spartane.Core.Domain.Planes_Alimenticios;
using Spartane.Web.Areas.WebApiConsumer.Planes_Alimenticios;
using Spartane.Services.Detalle_Planes_Alimenticios;
using Spartane.Core.Domain.Detalle_Planes_Alimenticios;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_Alimenticios;
using Spartane.Services.Planes_de_Rutinas;
using Spartane.Core.Domain.Planes_de_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Rutinas;
using Spartane.Services.Detalle_Planes_de_Rutinas;
using Spartane.Core.Domain.Detalle_Planes_de_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Rutinas;
using Spartane.Services.Rutinas;
using Spartane.Core.Domain.Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Rutinas;
using Spartane.Services.Nivel_de_dificultad;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_dificultad;
using Spartane.Services.Nivel_de_Intensidad;
using Spartane.Core.Domain.Nivel_de_Intensidad;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_Intensidad;
using Spartane.Services.Detalle_Ejercicios_Rutinas;
using Spartane.Core.Domain.Detalle_Ejercicios_Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Ejercicios_Rutinas;
using Spartane.Services.Musculos;
using Spartane.Core.Domain.Musculos;
using Spartane.Web.Areas.WebApiConsumer.Musculos;
using Spartane.Services.Equipamiento_para_Ejercicios;
using Spartane.Core.Domain.Equipamiento_para_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Equipamiento_para_Ejercicios;
using Spartane.Services.MS_Musculos;
using Spartane.Core.Domain.MS_Musculos;
using Spartane.Web.Areas.WebApiConsumer.MS_Musculos;
using Spartane.Services.MS_Equipamiento_para_Ejercicios;
using Spartane.Core.Domain.MS_Equipamiento_para_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.MS_Equipamiento_para_Ejercicios;
using Spartane.Services.Vendedores;
using Spartane.Core.Domain.Vendedores;
using Spartane.Web.Areas.WebApiConsumer.Vendedores;
using Spartane.Services.Detalle_Codigos_de_Referencia_Vendedores;
using Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Codigos_de_Referencia_Vendedores;
using Spartane.Services.Detalle_Facturacion_Vendedores;
using Spartane.Core.Domain.Detalle_Facturacion_Vendedores;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Facturacion_Vendedores;
using Spartane.Services.Proveedores;
using Spartane.Core.Domain.Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Proveedores;
using Spartane.Services.Tipo_de_proveedor;
using Spartane.Core.Domain.Tipo_de_proveedor;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_proveedor;
using Spartane.Services.Detalle_Sucursales_Proveedores;
using Spartane.Core.Domain.Detalle_Sucursales_Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Sucursales_Proveedores;
using Spartane.Services.Tipo_de_Sucursal;
using Spartane.Core.Domain.Tipo_de_Sucursal;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Sucursal;
using Spartane.Services.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Services.Planes_de_Suscripcion_Proveedores;
using Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Proveedores;
//**@@INCLUDE_DECLARE@@**//
using Spartane.Services.Events;
using Spartane.Data.EF;
using System.Web.Http;
using System.Web;
using Autofac.Integration.WebApi;
using Spartane.Services.User.Mock;
using Spartane.Services.Security.Mock;
using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.SpartanModule;
using Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule;
using Spartane.Web.Areas.WebApiConsumer.SpartaneModuleObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject;
using Spartane.Services.TTArchivos;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
/*Business Rules*/
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Actions_False_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_False_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;
using Spartane.Core.Domain.Spartan_BR_Action_Result;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;
using Spartane.Core.Domain.Spartan_BR_Actions_True_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_True_Detail;
using Spartane.Core.Domain.Spartan_BR_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Conditions_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;
using Spartane.Core.Domain.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Presentation_Control_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Presentation_Control_Type;
using Spartane.Core.Domain.Spartan_BR_Process_Event;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;
using Spartane.Core.Domain.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Core.Domain.Spartan_BR_Scope;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope;
using Spartane.Core.Domain.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Control_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Attribute_Control_Type;
using Spartane.Services.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Business_Rule;
using Spartane.Services.Spartan_BR_Action;
using Spartane.Services.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Action_Classification;
using Spartane.Services.Spartan_BR_Action_Configuration_Detail;
using Spartane.Services.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Actions_False_Detail;
using Spartane.Services.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Action_Param_Type;
using Spartane.Services.Spartan_BR_Action_Result;
using Spartane.Services.Spartan_BR_Actions_True_Detail;
using Spartane.Services.Spartan_BR_Condition;
using Spartane.Services.Spartan_BR_Condition_Operator;
using Spartane.Services.Spartan_BR_Conditions_Detail;
using Spartane.Services.Spartan_BR_Operation;
using Spartane.Services.Spartan_BR_Operation_Detail;
using Spartane.Services.Spartan_BR_Operator_Type;
using Spartane.Services.Spartan_BR_Presentation_Control_Type;
using Spartane.Services.Spartan_BR_Process_Event;
using Spartane.Services.Spartan_BR_Process_Event_Detail;
using Spartane.Services.Spartan_BR_Scope;
using Spartane.Services.Spartan_BR_Scope_Detail;
using Spartane.Services.Spartan_BR_Status;
using Spartane.Services.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Bitacora_SQL;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Services.Business_Rule_Creation;
using Spartane.Web.Areas.WebApiConsumer.Business_Rule_Creation;
using Spartane.Services.Spartan_BR_Complexity;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Complexity;
using Spartane.Services.Spartan_BR_Peer_Review;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Peer_Review;
using Spartane.Services.Spartan_BR_Testing;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Testing;
using Spartane.Services.Spartan_BR_Rejection_Reason;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Rejection_Reason;
using Spartane.Services.Spartan_BR_History;
using Spartane.Services.Spartan_BR_Type_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Type_History;
using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Services.Template_Dashboard_Editor;
using Spartane.Core.Domain.Template_Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Editor;
using Spartane.Services.Dashboard_Status;
using Spartane.Core.Domain.Dashboard_Status;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Status;
using Spartane.Services.Dashboard_Editor;
using Spartane.Core.Domain.Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Editor;
using Spartane.Services.Template_Dashboard_Detail;
using Spartane.Core.Domain.Template_Dashboard_Detail;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Detail;
using Spartane.Services.Dashboard_Config_Detail;
using Spartane.Core.Domain.Dashboard_Config_Detail;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Config_Detail;


namespace Spartane.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //HTTP context and other related stuff
            builder.Register(c =>
                new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterControllers();
           
            //data layer
            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=spartaneEntities";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";
            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerLifetimeScope();
            builder.RegisterType<ModulesData>().As<BaseEntity>().InstancePerLifetimeScope();

            builder.RegisterType<Spartane.Core.Domain.User.GlobalData>();
            builder.RegisterType<DataLayerFieldsBitacora>();

            builder.RegisterType<Spartan_Module>();
            
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<MockSpartanUserService>().As<ISpartanUserService>().InstancePerLifetimeScope();
            

            //New Addons
            builder.RegisterType<AuthenticationApiConsumer>().As<IAuthenticationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
            builder.RegisterType<SpartaneFileApiConsumer>().As<ISpartaneFileApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartane_FileApiConsumer>().As<ISpartane_FileApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_FormatService>().As<ISpartan_FormatService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_FormatApiConsumer>().As<ISpartan_FormatApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_TypeService>().As<ISpartan_Format_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_TypeApiConsumer>().As<ISpartan_Format_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_MetadataService>().As<ISpartan_MetadataService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_MetadataApiConsumer>().As<ISpartan_MetadataApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_ConfigurationService>().As<ISpartan_Format_ConfigurationService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_ConfigurationApiConsumer>().As<ISpartan_Format_ConfigurationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_FieldService>().As<ISpartan_Format_FieldService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_FieldApiConsumer>().As<ISpartan_Format_FieldApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_Permission_TypeService>().As<ISpartan_Format_Permission_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_Permission_TypeApiConsumer>().As<ISpartan_Format_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_PermissionsService>().As<ISpartan_Format_PermissionsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_PermissionsApiConsumer>().As<ISpartan_Format_PermissionsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ReportApiConsumer>().As<ISpartan_ReportApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Field_TypeService>().As<ISpartan_Report_Field_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Field_TypeApiConsumer>().As<ISpartan_Report_Field_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Fields_DetailService>().As<ISpartan_Report_Fields_DetailService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Fields_DetailApiConsumer>().As<ISpartan_Report_Fields_DetailApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FormatService>().As<ISpartan_Report_FormatService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FormatApiConsumer>().As<ISpartan_Report_FormatApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FunctionService>().As<ISpartan_Report_FunctionService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FunctionApiConsumer>().As<ISpartan_Report_FunctionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Order_TypeService>().As<ISpartan_Report_Order_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Order_TypeApiConsumer>().As<ISpartan_Report_Order_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Permission_TypeApiConsumer>().As<ISpartan_Report_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_PermissionsApiConsumer>().As<ISpartan_Report_PermissionsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_TypeApiConsumer>().As<ISpartan_Report_Presentation_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_ViewApiConsumer>().As<ISpartan_Report_Presentation_ViewApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_StatusService>().As<ISpartan_Report_StatusService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_StatusApiConsumer>().As<ISpartan_Report_StatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FilterApiConsumer>().As<ISpartan_Report_FilterApiConsumer>().InstancePerLifetimeScope();

builder.RegisterType<SpartanChangePasswordAutorizationEstatusService>().As<ISpartanChangePasswordAutorizationEstatusService>().InstancePerLifetimeScope();
builder.RegisterType<SpartanChangePasswordAutorizationEstatusApiConsumer>().As<ISpartanChangePasswordAutorizationEstatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ChangePasswordAutorizationService>().As<ISpartan_ChangePasswordAutorizationService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ChangePasswordAutorizationApiConsumer>().As<ISpartan_ChangePasswordAutorizationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_User_Historical_PasswordService>().As<ISpartan_User_Historical_PasswordService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_User_Historical_PasswordApiConsumer>().As<ISpartan_User_Historical_PasswordApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_SettingsService>().As<ISpartan_SettingsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_SettingsApiConsumer>().As<ISpartan_SettingsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Business_Rule_CreationService>().As<IBusiness_Rule_CreationService>().InstancePerLifetimeScope();
builder.RegisterType<Business_Rule_CreationApiConsumer>().As<IBusiness_Rule_CreationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_ComplexityService>().As<ISpartan_BR_ComplexityService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_ComplexityApiConsumer>().As<ISpartan_BR_ComplexityApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Peer_ReviewService>().As<ISpartan_BR_Peer_ReviewService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Peer_ReviewApiConsumer>().As<ISpartan_BR_Peer_ReviewApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Rejection_ReasonService>().As<ISpartan_BR_Rejection_ReasonService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Rejection_ReasonApiConsumer>().As<ISpartan_BR_Rejection_ReasonApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_TestingService>().As<ISpartan_BR_TestingService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_TestingApiConsumer>().As<ISpartan_BR_TestingApiConsumer>().InstancePerLifetimeScope();

builder.RegisterType<Spartan_BR_HistoryService>().As<ISpartan_BR_HistoryService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Type_HistoryService>().As<ISpartan_BR_Type_HistoryService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_HistoryApiConsumer>().As<ISpartan_BR_HistoryApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Type_HistoryApiConsumer>().As<ISpartan_BR_Type_HistoryApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Bitacora_SQLService>().As<ISpartan_Bitacora_SQLService>().InstancePerLifetimeScope();
builder.RegisterType<Antiguedad_EjerciciosService>().As<IAntiguedad_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<Antiguedad_EjerciciosApiConsumer>().As<IAntiguedad_EjerciciosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<BebidasService>().As<IBebidasService>().InstancePerLifetimeScope();
builder.RegisterType<BebidasApiConsumer>().As<IBebidasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<CaloriasService>().As<ICaloriasService>().InstancePerLifetimeScope();
builder.RegisterType<CaloriasApiConsumer>().As<ICaloriasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Cantidad_ComidasService>().As<ICantidad_ComidasService>().InstancePerLifetimeScope();
builder.RegisterType<Cantidad_ComidasApiConsumer>().As<ICantidad_ComidasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Categorias_de_platillosService>().As<ICategorias_de_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Categorias_de_platillosApiConsumer>().As<ICategorias_de_platillosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Clasificacion_IngredientesService>().As<IClasificacion_IngredientesService>().InstancePerLifetimeScope();
builder.RegisterType<Clasificacion_IngredientesApiConsumer>().As<IClasificacion_IngredientesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Antecedentes_FamiliaresService>().As<IDetalle_Antecedentes_FamiliaresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Antecedentes_FamiliaresApiConsumer>().As<IDetalle_Antecedentes_FamiliaresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Antecedentes_No_PatologicosService>().As<IDetalle_Antecedentes_No_PatologicosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Antecedentes_No_PatologicosApiConsumer>().As<IDetalle_Antecedentes_No_PatologicosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_IngredientesService>().As<IDetalle_de_IngredientesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_IngredientesApiConsumer>().As<IDetalle_de_IngredientesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_PadecimientosService>().As<IDetalle_de_PadecimientosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_PadecimientosApiConsumer>().As<IDetalle_de_PadecimientosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Examenes_LaboratorioService>().As<IDetalle_Examenes_LaboratorioService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Examenes_LaboratorioApiConsumer>().As<IDetalle_Examenes_LaboratorioApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Preferencia_BebidasService>().As<IDetalle_Preferencia_BebidasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Preferencia_BebidasApiConsumer>().As<IDetalle_Preferencia_BebidasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Terapia_HormonalService>().As<IDetalle_Terapia_HormonalService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Terapia_HormonalApiConsumer>().As<IDetalle_Terapia_HormonalApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Dias_de_la_semanaService>().As<IDias_de_la_semanaService>().InstancePerLifetimeScope();
builder.RegisterType<Dias_de_la_semanaApiConsumer>().As<IDias_de_la_semanaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Dificultad_de_platillosService>().As<IDificultad_de_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Dificultad_de_platillosApiConsumer>().As<IDificultad_de_platillosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Duracion_EjercicioService>().As<IDuracion_EjercicioService>().InstancePerLifetimeScope();
builder.RegisterType<Duracion_EjercicioApiConsumer>().As<IDuracion_EjercicioApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EjerciciosService>().As<IEjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<EjerciciosApiConsumer>().As<IEjerciciosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EmpresasService>().As<IEmpresasService>().InstancePerLifetimeScope();
builder.RegisterType<EmpresasApiConsumer>().As<IEmpresasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EnfermedadesService>().As<IEnfermedadesService>().InstancePerLifetimeScope();
builder.RegisterType<EnfermedadesApiConsumer>().As<IEnfermedadesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EstadoService>().As<IEstadoService>().InstancePerLifetimeScope();
builder.RegisterType<EstadoApiConsumer>().As<IEstadoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estado_CivilService>().As<IEstado_CivilService>().InstancePerLifetimeScope();
builder.RegisterType<Estado_CivilApiConsumer>().As<IEstado_CivilApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estado_de_AnimoService>().As<IEstado_de_AnimoService>().InstancePerLifetimeScope();
builder.RegisterType<Estado_de_AnimoApiConsumer>().As<IEstado_de_AnimoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_PacienteService>().As<IEstatus_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_PacienteApiConsumer>().As<IEstatus_PacienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_PadecimientoService>().As<IEstatus_PadecimientoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_PadecimientoApiConsumer>().As<IEstatus_PadecimientoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_EjercicioService>().As<IFrecuencia_EjercicioService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_EjercicioApiConsumer>().As<IFrecuencia_EjercicioApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_SustanciasService>().As<IFrecuencia_SustanciasService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_SustanciasApiConsumer>().As<IFrecuencia_SustanciasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Indicadores_LaboratorioService>().As<IIndicadores_LaboratorioService>().InstancePerLifetimeScope();
builder.RegisterType<Indicadores_LaboratorioApiConsumer>().As<IIndicadores_LaboratorioApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<IngredientesService>().As<IIngredientesService>().InstancePerLifetimeScope();
builder.RegisterType<IngredientesApiConsumer>().As<IIngredientesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MarcaService>().As<IMarcaService>().InstancePerLifetimeScope();
builder.RegisterType<MarcaApiConsumer>().As<IMarcaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MedicosService>().As<IMedicosService>().InstancePerLifetimeScope();
builder.RegisterType<MedicosApiConsumer>().As<IMedicosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_SatisfaccionService>().As<INivel_de_SatisfaccionService>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_SatisfaccionApiConsumer>().As<INivel_de_SatisfaccionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<ObjetivosService>().As<IObjetivosService>().InstancePerLifetimeScope();
builder.RegisterType<ObjetivosApiConsumer>().As<IObjetivosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<PacientesService>().As<IPacientesService>().InstancePerLifetimeScope();
builder.RegisterType<PacientesApiConsumer>().As<IPacientesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<PadecimientosService>().As<IPadecimientosService>().InstancePerLifetimeScope();
builder.RegisterType<PadecimientosApiConsumer>().As<IPadecimientosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<PaisService>().As<IPaisService>().InstancePerLifetimeScope();
builder.RegisterType<PaisApiConsumer>().As<IPaisApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<ParentescoService>().As<IParentescoService>().InstancePerLifetimeScope();
builder.RegisterType<ParentescoApiConsumer>().As<IParentescoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Periodo_del_diaService>().As<IPeriodo_del_diaService>().InstancePerLifetimeScope();
builder.RegisterType<Periodo_del_diaApiConsumer>().As<IPeriodo_del_diaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<PlatillosService>().As<IPlatillosService>().InstancePerLifetimeScope();
builder.RegisterType<PlatillosApiConsumer>().As<IPlatillosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_EntrecomidasService>().As<IPreferencias_EntrecomidasService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_EntrecomidasApiConsumer>().As<IPreferencias_EntrecomidasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_GrasasService>().As<IPreferencias_GrasasService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_GrasasApiConsumer>().As<IPreferencias_GrasasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_PreparacionService>().As<IPreferencias_PreparacionService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_PreparacionApiConsumer>().As<IPreferencias_PreparacionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_SalService>().As<IPreferencias_SalService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_SalApiConsumer>().As<IPreferencias_SalApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<PresentacionService>().As<IPresentacionService>().InstancePerLifetimeScope();
builder.RegisterType<PresentacionApiConsumer>().As<IPresentacionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Rango_Consumo_BebidasService>().As<IRango_Consumo_BebidasService>().InstancePerLifetimeScope();
builder.RegisterType<Rango_Consumo_BebidasApiConsumer>().As<IRango_Consumo_BebidasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Rango_de_HorasService>().As<IRango_de_HorasService>().InstancePerLifetimeScope();
builder.RegisterType<Rango_de_HorasApiConsumer>().As<IRango_de_HorasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<RegistroService>().As<IRegistroService>().InstancePerLifetimeScope();
builder.RegisterType<RegistroApiConsumer>().As<IRegistroApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Respuesta_LogicaService>().As<IRespuesta_LogicaService>().InstancePerLifetimeScope();
builder.RegisterType<Respuesta_LogicaApiConsumer>().As<IRespuesta_LogicaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Resultados_IMCService>().As<IResultados_IMCService>().InstancePerLifetimeScope();
builder.RegisterType<Resultados_IMCApiConsumer>().As<IResultados_IMCApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Seleccion_de_RangosService>().As<ISeleccion_de_RangosService>().InstancePerLifetimeScope();
builder.RegisterType<Seleccion_de_RangosApiConsumer>().As<ISeleccion_de_RangosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<SexoService>().As<ISexoService>().InstancePerLifetimeScope();
builder.RegisterType<SexoApiConsumer>().As<ISexoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<SuplementosService>().As<ISuplementosService>().InstancePerLifetimeScope();
builder.RegisterType<SuplementosApiConsumer>().As<ISuplementosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<SustanciasService>().As<ISustanciasService>().InstancePerLifetimeScope();
builder.RegisterType<SustanciasApiConsumer>().As<ISustanciasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tiempo_PadecimientoService>().As<ITiempo_PadecimientoService>().InstancePerLifetimeScope();
builder.RegisterType<Tiempo_PadecimientoApiConsumer>().As<ITiempo_PadecimientoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tiempos_de_ComidaService>().As<ITiempos_de_ComidaService>().InstancePerLifetimeScope();
builder.RegisterType<Tiempos_de_ComidaApiConsumer>().As<ITiempos_de_ComidaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_DietaService>().As<ITipo_de_DietaService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_DietaApiConsumer>().As<ITipo_de_DietaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_RegistroService>().As<ITipo_de_RegistroService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_RegistroApiConsumer>().As<ITipo_de_RegistroApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_EjercicioService>().As<ITipo_EjercicioService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_EjercicioApiConsumer>().As<ITipo_EjercicioApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_Modificacion_AlimentosService>().As<ITipo_Modificacion_AlimentosService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_Modificacion_AlimentosApiConsumer>().As<ITipo_Modificacion_AlimentosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_PacienteService>().As<ITipo_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_PacienteApiConsumer>().As<ITipo_PacienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Unidades_de_MedidaService>().As<IUnidades_de_MedidaService>().InstancePerLifetimeScope();
builder.RegisterType<Unidades_de_MedidaApiConsumer>().As<IUnidades_de_MedidaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<ConsultasService>().As<IConsultasService>().InstancePerLifetimeScope();
builder.RegisterType<ConsultasApiConsumer>().As<IConsultasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EstatusService>().As<IEstatusService>().InstancePerLifetimeScope();
builder.RegisterType<EstatusApiConsumer>().As<IEstatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<ProfesionesService>().As<IProfesionesService>().InstancePerLifetimeScope();
builder.RegisterType<ProfesionesApiConsumer>().As<IProfesionesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EspecialidadesService>().As<IEspecialidadesService>().InstancePerLifetimeScope();
builder.RegisterType<EspecialidadesApiConsumer>().As<IEspecialidadesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Identificacion_Oficial_MedicosService>().As<IDetalle_Identificacion_Oficial_MedicosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Identificacion_Oficial_MedicosApiConsumer>().As<IDetalle_Identificacion_Oficial_MedicosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Identificaciones_OficialesService>().As<IIdentificaciones_OficialesService>().InstancePerLifetimeScope();
builder.RegisterType<Identificaciones_OficialesApiConsumer>().As<IIdentificaciones_OficialesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Regimenes_FiscalesService>().As<IRegimenes_FiscalesService>().InstancePerLifetimeScope();
builder.RegisterType<Regimenes_FiscalesApiConsumer>().As<IRegimenes_FiscalesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_de_porcentaje_de_grasa_corporalService>().As<IInterpretacion_de_porcentaje_de_grasa_corporalService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_de_porcentaje_de_grasa_corporalApiConsumer>().As<IInterpretacion_de_porcentaje_de_grasa_corporalApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_IMCService>().As<IInterpretacion_IMCService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_IMCApiConsumer>().As<IInterpretacion_IMCApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_corporalService>().As<IInterpretacion_corporalService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_corporalApiConsumer>().As<IInterpretacion_corporalApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_distribucion_grasa_corporalService>().As<IInterpretacion_distribucion_grasa_corporalService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_distribucion_grasa_corporalApiConsumer>().As<IInterpretacion_distribucion_grasa_corporalApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_indice_cintura__caderaService>().As<IInterpretacion_indice_cintura__caderaService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_indice_cintura__caderaApiConsumer>().As<IInterpretacion_indice_cintura__caderaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_consumo_de_aguaService>().As<IInterpretacion_consumo_de_aguaService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_consumo_de_aguaApiConsumer>().As<IInterpretacion_consumo_de_aguaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_Frecuencia_cardiaca_en_EsfuerzoService>().As<IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer>().As<IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_Dificultad_de_Rutina_de_EjerciciosService>().As<IInterpretacion_Dificultad_de_Rutina_de_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer>().As<IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_CaloriasService>().As<IInterpretacion_CaloriasService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_CaloriasApiConsumer>().As<IInterpretacion_CaloriasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_Plan_de_SuscripcionService>().As<ITipo_de_Plan_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_Plan_de_SuscripcionApiConsumer>().As<ITipo_de_Plan_de_SuscripcionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Duracion_de_Planes_de_SuscripcionService>().As<IDuracion_de_Planes_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Duracion_de_Planes_de_SuscripcionApiConsumer>().As<IDuracion_de_Planes_de_SuscripcionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_SuscripcionService>().As<IPlanes_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_SuscripcionApiConsumer>().As<IPlanes_de_SuscripcionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_por_SuscripcionService>().As<IEstatus_por_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_por_SuscripcionApiConsumer>().As<IEstatus_por_SuscripcionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripciones_PacienteService>().As<IDetalle_Suscripciones_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripciones_PacienteApiConsumer>().As<IDetalle_Suscripciones_PacienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_PacienteService>().As<IDetalle_Pagos_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_PacienteApiConsumer>().As<IDetalle_Pagos_PacienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_SuscripcionService>().As<IEstatus_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_SuscripcionApiConsumer>().As<IEstatus_de_SuscripcionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_PagoService>().As<IEstatus_de_PagoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_PagoApiConsumer>().As<IEstatus_de_PagoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Formas_de_PagoService>().As<IFormas_de_PagoService>().InstancePerLifetimeScope();
builder.RegisterType<Formas_de_PagoApiConsumer>().As<IFormas_de_PagoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_PacientesService>().As<IFrecuencia_de_pago_PacientesService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_PacientesApiConsumer>().As<IFrecuencia_de_pago_PacientesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_EmpresasService>().As<IFrecuencia_de_pago_EmpresasService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_EmpresasApiConsumer>().As<IFrecuencia_de_pago_EmpresasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Resultados_ConsultasService>().As<IDetalle_Resultados_ConsultasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Resultados_ConsultasApiConsumer>().As<IDetalle_Resultados_ConsultasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Indicadores_ConsultasService>().As<IIndicadores_ConsultasService>().InstancePerLifetimeScope();
builder.RegisterType<Indicadores_ConsultasApiConsumer>().As<IIndicadores_ConsultasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_EspecialistasService>().As<ITipos_de_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_EspecialistasApiConsumer>().As<ITipos_de_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Titulos_MedicosService>().As<IDetalle_Titulos_MedicosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Titulos_MedicosApiConsumer>().As<IDetalle_Titulos_MedicosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<areas_EmpresasService>().As<Iareas_EmpresasService>().InstancePerLifetimeScope();
builder.RegisterType<areas_EmpresasApiConsumer>().As<Iareas_EmpresasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripciones_EmpresaService>().As<IDetalle_Suscripciones_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripciones_EmpresaApiConsumer>().As<IDetalle_Suscripciones_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_EmpresaService>().As<IDetalle_Pagos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_EmpresaApiConsumer>().As<IDetalle_Pagos_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Contactos_EmpresaService>().As<IDetalle_Contactos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Contactos_EmpresaApiConsumer>().As<IDetalle_Contactos_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Contratos_EmpresaService>().As<IDetalle_Contratos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Contratos_EmpresaApiConsumer>().As<IDetalle_Contratos_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_ContratoService>().As<ITipos_de_ContratoService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_ContratoApiConsumer>().As<ITipos_de_ContratoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Codigos_ReferidosService>().As<IDetalle_Codigos_ReferidosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Codigos_ReferidosApiConsumer>().As<IDetalle_Codigos_ReferidosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Convenio_Medicos_AseguradorasService>().As<IDetalle_Convenio_Medicos_AseguradorasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Convenio_Medicos_AseguradorasApiConsumer>().As<IDetalle_Convenio_Medicos_AseguradorasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<AseguradorasService>().As<IAseguradorasService>().InstancePerLifetimeScope();
builder.RegisterType<AseguradorasApiConsumer>().As<IAseguradorasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_de_Suscripcion_EspecialistasService>().As<IDetalle_Planes_de_Suscripcion_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer>().As<IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Datos_Bancarios_EspecialistasService>().As<IDatos_Bancarios_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Datos_Bancarios_EspecialistasApiConsumer>().As<IDatos_Bancarios_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_EspecialistasService>().As<IDetalle_Pagos_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_EspecialistasApiConsumer>().As<IDetalle_Pagos_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_Suscripcion_EspecialistasService>().As<IPlanes_de_Suscripcion_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_Suscripcion_EspecialistasApiConsumer>().As<IPlanes_de_Suscripcion_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_EspecialistasService>().As<IFrecuencia_de_pago_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_EspecialistasApiConsumer>().As<IFrecuencia_de_pago_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<BancosService>().As<IBancosService>().InstancePerLifetimeScope();
builder.RegisterType<BancosApiConsumer>().As<IBancosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<EventosService>().As<IEventosService>().InstancePerLifetimeScope();
builder.RegisterType<EventosApiConsumer>().As<IEventosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Actividades_EventoService>().As<IDetalle_Actividades_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Actividades_EventoApiConsumer>().As<IDetalle_Actividades_EventoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Actividades_EventoService>().As<IEstatus_Actividades_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Actividades_EventoApiConsumer>().As<IEstatus_Actividades_EventoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Reservaciones_ActividadService>().As<IEstatus_Reservaciones_ActividadService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Reservaciones_ActividadApiConsumer>().As<IEstatus_Reservaciones_ActividadApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_ActividadesService>().As<ITipos_de_ActividadesService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_ActividadesApiConsumer>().As<ITipos_de_ActividadesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Ubicaciones_Eventos_EmpresaService>().As<IUbicaciones_Eventos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Ubicaciones_Eventos_EmpresaApiConsumer>().As<IUbicaciones_Eventos_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Actividades_del_EventoService>().As<IActividades_del_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Actividades_del_EventoApiConsumer>().As<IActividades_del_EventoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Horarios_ActividadService>().As<IDetalle_Horarios_ActividadService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Horarios_ActividadApiConsumer>().As<IDetalle_Horarios_ActividadApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Parentescos_EmpleadosService>().As<IParentescos_EmpleadosService>().InstancePerLifetimeScope();
builder.RegisterType<Parentescos_EmpleadosApiConsumer>().As<IParentescos_EmpleadosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Registro_en_EventoService>().As<IRegistro_en_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_en_EventoApiConsumer>().As<IRegistro_en_EventoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Consulta_Actividades_Registro_EventoService>().As<IDetalle_Consulta_Actividades_Registro_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Consulta_Actividades_Registro_EventoApiConsumer>().As<IDetalle_Consulta_Actividades_Registro_EventoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_en_Actividad_EventoService>().As<IDetalle_Registro_en_Actividad_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_en_Actividad_EventoApiConsumer>().As<IDetalle_Registro_en_Actividad_EventoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_EventosService>().As<IEstatus_EventosService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_EventosApiConsumer>().As<IEstatus_EventosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MS_Exclusion_Ingredientes_PacienteService>().As<IMS_Exclusion_Ingredientes_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<MS_Exclusion_Ingredientes_PacienteApiConsumer>().As<IMS_Exclusion_Ingredientes_PacienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Especialistas_PacientesService>().As<IDetalle_Especialistas_PacientesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Especialistas_PacientesApiConsumer>().As<IDetalle_Especialistas_PacientesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Facturacion_EspecialistasService>().As<IDetalle_Facturacion_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Facturacion_EspecialistasApiConsumer>().As<IDetalle_Facturacion_EspecialistasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_FacturasService>().As<IEstatus_FacturasService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_FacturasApiConsumer>().As<IEstatus_FacturasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Titulos_PersonalesService>().As<ITitulos_PersonalesService>().InstancePerLifetimeScope();
builder.RegisterType<Titulos_PersonalesApiConsumer>().As<ITitulos_PersonalesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Redes_Sociales_EspecialistaService>().As<IDetalle_Redes_Sociales_EspecialistaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Redes_Sociales_EspecialistaApiConsumer>().As<IDetalle_Redes_Sociales_EspecialistaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Redes_socialesService>().As<IRedes_socialesService>().InstancePerLifetimeScope();
builder.RegisterType<Redes_socialesApiConsumer>().As<IRedes_socialesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MS_Suscripciones_Codigos_Referidos_EspecialistaService>().As<IMS_Suscripciones_Codigos_Referidos_EspecialistaService>().InstancePerLifetimeScope();
builder.RegisterType<MS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer>().As<IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MotivosService>().As<IMotivosService>().InstancePerLifetimeScope();
builder.RegisterType<MotivosApiConsumer>().As<IMotivosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Solicitud_de_Cita_con_EspecialistaService>().As<ISolicitud_de_Cita_con_EspecialistaService>().InstancePerLifetimeScope();
builder.RegisterType<Solicitud_de_Cita_con_EspecialistaApiConsumer>().As<ISolicitud_de_Cita_con_EspecialistaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<CalificacionService>().As<ICalificacionService>().InstancePerLifetimeScope();
builder.RegisterType<CalificacionApiConsumer>().As<ICalificacionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Asuntos_Asistencia_TelefonicaService>().As<IAsuntos_Asistencia_TelefonicaService>().InstancePerLifetimeScope();
builder.RegisterType<Asuntos_Asistencia_TelefonicaApiConsumer>().As<IAsuntos_Asistencia_TelefonicaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_LlamadasService>().As<IEstatus_LlamadasService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_LlamadasApiConsumer>().As<IEstatus_LlamadasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_Asistencia_TelefonicaService>().As<IRegistro_de_Asistencia_TelefonicaService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_Asistencia_TelefonicaApiConsumer>().As<IRegistro_de_Asistencia_TelefonicaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_Beneficiarios_EmpresaService>().As<IDetalle_Registro_Beneficiarios_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_Beneficiarios_EmpresaApiConsumer>().As<IDetalle_Registro_Beneficiarios_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_EmpresaService>().As<ITipos_de_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_EmpresaApiConsumer>().As<ITipos_de_EmpresaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Caracteristicas_IngredienteService>().As<IDetalle_Caracteristicas_IngredienteService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Caracteristicas_IngredienteApiConsumer>().As<IDetalle_Caracteristicas_IngredienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_comida_platillosService>().As<ITipo_de_comida_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_comida_platillosApiConsumer>().As<ITipo_de_comida_platillosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Caracteristicas_platilloService>().As<ICaracteristicas_platilloService>().InstancePerLifetimeScope();
builder.RegisterType<Caracteristicas_platilloApiConsumer>().As<ICaracteristicas_platilloApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_PlatillosService>().As<IDetalle_PlatillosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_PlatillosApiConsumer>().As<IDetalle_PlatillosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Cantidad_fraccion_platillosService>().As<ICantidad_fraccion_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Cantidad_fraccion_platillosApiConsumer>().As<ICantidad_fraccion_platillosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Pantalla_FranciscoService>().As<IPantalla_FranciscoService>().InstancePerLifetimeScope();
builder.RegisterType<Pantalla_FranciscoApiConsumer>().As<IPantalla_FranciscoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_pantalla_FranciscoService>().As<IDetalle_pantalla_FranciscoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_pantalla_FranciscoApiConsumer>().As<IDetalle_pantalla_FranciscoApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tips_y_PromocionesService>().As<ITips_y_PromocionesService>().InstancePerLifetimeScope();
builder.RegisterType<Tips_y_PromocionesApiConsumer>().As<ITips_y_PromocionesApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Planes_AlimenticiosService>().As<IPlanes_AlimenticiosService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_AlimenticiosApiConsumer>().As<IPlanes_AlimenticiosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_AlimenticiosService>().As<IDetalle_Planes_AlimenticiosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_AlimenticiosApiConsumer>().As<IDetalle_Planes_AlimenticiosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_RutinasService>().As<IPlanes_de_RutinasService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_RutinasApiConsumer>().As<IPlanes_de_RutinasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_de_RutinasService>().As<IDetalle_Planes_de_RutinasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_de_RutinasApiConsumer>().As<IDetalle_Planes_de_RutinasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<RutinasService>().As<IRutinasService>().InstancePerLifetimeScope();
builder.RegisterType<RutinasApiConsumer>().As<IRutinasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_dificultadService>().As<INivel_de_dificultadService>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_dificultadApiConsumer>().As<INivel_de_dificultadApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_IntensidadService>().As<INivel_de_IntensidadService>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_IntensidadApiConsumer>().As<INivel_de_IntensidadApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Ejercicios_RutinasService>().As<IDetalle_Ejercicios_RutinasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Ejercicios_RutinasApiConsumer>().As<IDetalle_Ejercicios_RutinasApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MusculosService>().As<IMusculosService>().InstancePerLifetimeScope();
builder.RegisterType<MusculosApiConsumer>().As<IMusculosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Equipamiento_para_EjerciciosService>().As<IEquipamiento_para_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<Equipamiento_para_EjerciciosApiConsumer>().As<IEquipamiento_para_EjerciciosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MS_MusculosService>().As<IMS_MusculosService>().InstancePerLifetimeScope();
builder.RegisterType<MS_MusculosApiConsumer>().As<IMS_MusculosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<MS_Equipamiento_para_EjerciciosService>().As<IMS_Equipamiento_para_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<MS_Equipamiento_para_EjerciciosApiConsumer>().As<IMS_Equipamiento_para_EjerciciosApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<VendedoresService>().As<IVendedoresService>().InstancePerLifetimeScope();
builder.RegisterType<VendedoresApiConsumer>().As<IVendedoresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Codigos_de_Referencia_VendedoresService>().As<IDetalle_Codigos_de_Referencia_VendedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Codigos_de_Referencia_VendedoresApiConsumer>().As<IDetalle_Codigos_de_Referencia_VendedoresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Facturacion_VendedoresService>().As<IDetalle_Facturacion_VendedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Facturacion_VendedoresApiConsumer>().As<IDetalle_Facturacion_VendedoresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<ProveedoresService>().As<IProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<ProveedoresApiConsumer>().As<IProveedoresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_proveedorService>().As<ITipo_de_proveedorService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_proveedorApiConsumer>().As<ITipo_de_proveedorApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Sucursales_ProveedoresService>().As<IDetalle_Sucursales_ProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Sucursales_ProveedoresApiConsumer>().As<IDetalle_Sucursales_ProveedoresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_SucursalService>().As<ITipo_de_SucursalService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_SucursalApiConsumer>().As<ITipo_de_SucursalApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresService>().As<IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer>().As<IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_Suscripcion_ProveedoresService>().As<IPlanes_de_Suscripcion_ProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_Suscripcion_ProveedoresApiConsumer>().As<IPlanes_de_Suscripcion_ProveedoresApiConsumer>().InstancePerLifetimeScope();
//**@@INCLUDE_EXPOSE@@**//            

            builder.RegisterType<SpartanModuleApiConsumer>().As<ISpartanModuleApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanUserRoleModuleApiConsumer>().As<ISpartanUserRoleModuleApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneModuleObjectApiConsumer>().As<ISpartaneModuleObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleModuleObjectApiConsumer>().As<ISpartaneUserRoleModuleObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneObjectApiConsumer>().As<ISpartaneObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleObjectFunctionApiConsumer>().As<ISpartaneUserRoleObjectFunctionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<LanguageApiConsumer>().As<ILanguageApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanSecurityApiConsumer>().As<ISpartanSecurityApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<SpartanSessionApiConsumer>().As<ISpartanSessionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleObjectFunctionApiConsumer>().As<ISpartaneUserRoleObjectFunctionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneFunctionApiConsumer>().As<ISpartaneFunctionApiConsumer>().InstancePerLifetimeScope();
            //Till Here
            builder.RegisterType<TTArchivosService>().As<ITTArchivosService>().InstancePerLifetimeScope();

            //builder.RegisterType<MockSpartanDepartamentoService>().As<ISpartanDepartamentoService>().InstancePerLifetimeScope();

            builder.RegisterType<MockSpartanModuleService>().As<ISpartanModuleService>().InstancePerLifetimeScope().PreserveExistingDefaults();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<SpartaneQueryApiConsumer>().As<ISpartaneQueryApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeService>().As<ISpartan_Attribute_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeApiConsumer>().As<ISpartan_Attribute_Control_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeService>().As<ISpartan_Attribute_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeApiConsumer>().As<ISpartan_Attribute_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleService>().As<ISpartan_Business_RuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleApiConsumer>().As<ISpartan_Business_RuleApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionService>().As<ISpartan_BR_ActionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionApiConsumer>().As<ISpartan_BR_ActionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailService>().As<ISpartan_BR_Attribute_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Attribute_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationService>().As<ISpartan_BR_Action_ClassificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationApiConsumer>().As<ISpartan_BR_Action_ClassificationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailService>().As<ISpartan_BR_Action_Configuration_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailApiConsumer>().As<ISpartan_BR_Action_Configuration_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailService>().As<ISpartan_BR_Event_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Event_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailService>().As<ISpartan_BR_Actions_False_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailApiConsumer>().As<ISpartan_BR_Actions_False_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailService>().As<ISpartan_BR_Operation_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Operation_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeService>().As<ISpartan_BR_Action_Param_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeApiConsumer>().As<ISpartan_BR_Action_Param_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultService>().As<ISpartan_BR_Action_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultApiConsumer>().As<ISpartan_BR_Action_ResultApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailService>().As<ISpartan_BR_Actions_True_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailApiConsumer>().As<ISpartan_BR_Actions_True_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionService>().As<ISpartan_BR_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionApiConsumer>().As<ISpartan_BR_ConditionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorService>().As<ISpartan_BR_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorApiConsumer>().As<ISpartan_BR_Condition_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailService>().As<ISpartan_BR_Conditions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailApiConsumer>().As<ISpartan_BR_Conditions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationService>().As<ISpartan_BR_OperationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationApiConsumer>().As<ISpartan_BR_OperationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailService>().As<ISpartan_BR_Operation_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailApiConsumer>().As<ISpartan_BR_Operation_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeService>().As<ISpartan_BR_Operator_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeApiConsumer>().As<ISpartan_BR_Operator_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeService>().As<ISpartan_BR_Presentation_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeApiConsumer>().As<ISpartan_BR_Presentation_Control_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventService>().As<ISpartan_BR_Process_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventApiConsumer>().As<ISpartan_BR_Process_EventApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailService>().As<ISpartan_BR_Process_Event_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailApiConsumer>().As<ISpartan_BR_Process_Event_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeService>().As<ISpartan_BR_ScopeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeApiConsumer>().As<ISpartan_BR_ScopeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailService>().As<ISpartan_BR_Scope_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailApiConsumer>().As<ISpartan_BR_Scope_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusService>().As<ISpartan_BR_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusApiConsumer>().As<ISpartan_BR_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogService>().As<ISpartan_BR_Modifications_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogApiConsumer>().As<ISpartan_BR_Modifications_LogApiConsumer>().InstancePerLifetimeScope();


            builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ReportApiConsumer>().As<ISpartan_ReportApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_TypeApiConsumer>().As<ISpartan_Report_Presentation_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Permission_TypeApiConsumer>().As<ISpartan_Report_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_PermissionsApiConsumer>().As<ISpartan_Report_PermissionsApiConsumer>().InstancePerLifetimeScope();
			
			
			builder.RegisterType<Spartan_UserService>().As<ISpartan_UserService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_UserApiConsumer>().As<ISpartan_UserApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleService>().As<ISpartan_User_RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleApiConsumer>().As<ISpartan_User_RoleApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusService>().As<ISpartan_User_Role_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusApiConsumer>().As<ISpartan_User_Role_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusService>().As<ISpartan_User_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusApiConsumer>().As<ISpartan_User_StatusApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Concept_TypeService>().As<ISpartan_Traduction_Concept_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Concept_TypeApiConsumer>().As<ISpartan_Traduction_Concept_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailService>().As<ISpartan_Traduction_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailApiConsumer>().As<ISpartan_Traduction_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageService>().As<ISpartan_Traduction_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageApiConsumer>().As<ISpartan_Traduction_LanguageApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectService>().As<ISpartan_Traduction_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectApiConsumer>().As<ISpartan_Traduction_ObjectApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeService>().As<ISpartan_Traduction_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeApiConsumer>().As<ISpartan_Traduction_Object_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessService>().As<ISpartan_Traduction_ProcessService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessApiConsumer>().As<ISpartan_Traduction_ProcessApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Process_WorkflowService>().As<ISpartan_Traduction_Process_WorkflowService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_WorkflowApiConsumer>().As<ISpartan_Traduction_Process_WorkflowApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_DataService>().As<ISpartan_Traduction_Process_DataService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_DataApiConsumer>().As<ISpartan_Traduction_Process_DataApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_WorkFlowService>().As<ISpartan_WorkFlowService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlowApiConsumer>().As<ISpartan_WorkFlowApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_ConditionService>().As<ISpartan_WorkFlow_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_ConditionApiConsumer>().As<ISpartan_WorkFlow_ConditionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Condition_OperatorService>().As<ISpartan_WorkFlow_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Condition_OperatorApiConsumer>().As<ISpartan_WorkFlow_Condition_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Conditions_by_StateService>().As<ISpartan_WorkFlow_Conditions_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Conditions_by_StateApiConsumer>().As<ISpartan_WorkFlow_Conditions_by_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Information_by_StateService>().As<ISpartan_WorkFlow_Information_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Information_by_StateApiConsumer>().As<ISpartan_WorkFlow_Information_by_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Matrix_of_StatesService>().As<ISpartan_WorkFlow_Matrix_of_StatesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Matrix_of_StatesApiConsumer>().As<ISpartan_WorkFlow_Matrix_of_StatesApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_OperatorService>().As<ISpartan_WorkFlow_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_OperatorApiConsumer>().As<ISpartan_WorkFlow_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_StatusService>().As<ISpartan_WorkFlow_Phase_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_StatusApiConsumer>().As<ISpartan_WorkFlow_Phase_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_TypeService>().As<ISpartan_WorkFlow_Phase_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_TypeApiConsumer>().As<ISpartan_WorkFlow_Phase_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_PhasesService>().As<ISpartan_WorkFlow_PhasesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_PhasesApiConsumer>().As<ISpartan_WorkFlow_PhasesApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Roles_by_StateService>().As<ISpartan_WorkFlow_Roles_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Roles_by_StateApiConsumer>().As<ISpartan_WorkFlow_Roles_by_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StateService>().As<ISpartan_WorkFlow_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StateApiConsumer>().As<ISpartan_WorkFlow_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StatusService>().As<ISpartan_WorkFlow_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StatusApiConsumer>().As<ISpartan_WorkFlow_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Flow_ControlService>().As<ISpartan_WorkFlow_Type_Flow_ControlService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Flow_ControlApiConsumer>().As<ISpartan_WorkFlow_Type_Flow_ControlApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Work_DistributionService>().As<ISpartan_WorkFlow_Type_Work_DistributionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Work_DistributionApiConsumer>().As<ISpartan_WorkFlow_Type_Work_DistributionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ObjectService>().As<ISpartan_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ObjectApiConsumer>().As<ISpartan_ObjectApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Advance_FilterApiConsumer>().As<ISpartan_Report_Advance_FilterApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<GeneratePDFApiConsumer>().As<IGeneratePDFApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Bitacora_SQLApiConsumer>().As<ISpartan_Bitacora_SQLApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_RelatedApiConsumer>().As<ISpartan_Format_RelatedApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Template_Dashboard_EditorService>().As<ITemplate_Dashboard_EditorService>().InstancePerLifetimeScope();
            builder.RegisterType<Template_Dashboard_EditorApiConsumer>().As<ITemplate_Dashboard_EditorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_StatusService>().As<IDashboard_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_StatusApiConsumer>().As<IDashboard_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_EditorService>().As<IDashboard_EditorService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_EditorApiConsumer>().As<IDashboard_EditorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Template_Dashboard_DetailService>().As<ITemplate_Dashboard_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Template_Dashboard_DetailApiConsumer>().As<ITemplate_Dashboard_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_Config_DetailService>().As<IDashboard_Config_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_Config_DetailApiConsumer>().As<IDashboard_Config_DetailApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<HomeController>().As<Controller>();
            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = resolver; 
        }

    }
}



























































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































