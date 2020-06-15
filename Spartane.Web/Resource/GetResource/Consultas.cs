using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class ConsultasResources
    {
        //private static IResourceProvider resourceProviderConsultas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\ConsultasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderConsultas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\ConsultasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderConsultas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\ConsultasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Consultas</summary>
        public static string Consultas
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Consultas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registo</summary>
        public static string Fecha_de_Registo
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Fecha_de_Registo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_Programada</summary>
        public static string Fecha_Programada
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Fecha_Programada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Paciente</summary>
        public static string Paciente
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edad</summary>
        public static string Edad
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Edad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_padre</summary>
        public static string Nombre_del_padre
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Nombre_del_padre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Objetivo</summary>
        public static string Objetivo
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Objetivo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_Cardiaca</summary>
        public static string Frecuencia_Cardiaca
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Frecuencia_Cardiaca", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presion_sistolica</summary>
        public static string Presion_sistolica
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Presion_sistolica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presion_diastolica</summary>
        public static string Presion_diastolica
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Presion_diastolica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso_actual</summary>
        public static string Peso_actual
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Peso_actual", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatura</summary>
        public static string Estatura
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Estatura", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Circunferencia_de_cintura_cm</summary>
        public static string Circunferencia_de_cintura_cm
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Circunferencia_de_cintura_cm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Circunferencia_de_cadera_cm</summary>
        public static string Circunferencia_de_cadera_cm
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Circunferencia_de_cadera_cm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edad_Metabolica</summary>
        public static string Edad_Metabolica
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Edad_Metabolica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Agua_corporal</summary>
        public static string Agua_corporal
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Agua_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasa_Visceral</summary>
        public static string Grasa_Visceral
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Grasa_Visceral", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasa_Corporal</summary>
        public static string Grasa_Corporal
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Grasa_Corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasa_Corporal_kg</summary>
        public static string Grasa_Corporal_kg
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Grasa_Corporal_kg", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Masa_Muscular_kg</summary>
        public static string Masa_Muscular_kg
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Masa_Muscular_kg", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Semana_de_gestacion</summary>
        public static string Semana_de_gestacion
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Semana_de_gestacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IMC</summary>
        public static string IMC
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("IMC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IMC_Pediatria</summary>
        public static string IMC_Pediatria
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("IMC_Pediatria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_IMC</summary>
        public static string Interpretacion_IMC
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Interpretacion_IMC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Consumo_de_agua_resultado</summary>
        public static string Consumo_de_agua_resultado
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Consumo_de_agua_resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_agua</summary>
        public static string Interpretacion_agua
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Interpretacion_agua", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_cardiaca_en_Esfuerzo</summary>
        public static string Frecuencia_cardiaca_en_Esfuerzo
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Frecuencia_cardiaca_en_Esfuerzo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_frecuencia</summary>
        public static string Interpretacion_frecuencia
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Interpretacion_frecuencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Indice_cintura_cadera</summary>
        public static string Indice_cintura_cadera
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Indice_cintura_cadera", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_indice</summary>
        public static string Interpretacion_indice
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Interpretacion_indice", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dificultad_de_Rutina_de_Ejercicios</summary>
        public static string Dificultad_de_Rutina_de_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Dificultad_de_Rutina_de_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_dificultad</summary>
        public static string Interpretacion_dificultad
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Interpretacion_dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calorias</summary>
        public static string Calorias
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Calorias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_calorias</summary>
        public static string Interpretacion_calorias
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Interpretacion_calorias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Observaciones</summary>
        public static string Observaciones
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Observaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_siguiente_Consulta</summary>
        public static string Fecha_siguiente_Consulta
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Fecha_siguiente_Consulta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resultados</summary>
        public static string Resultados
        {
            get
            {
                SetPath();
                return resourceProviderConsultas.GetResource("Resultados", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderConsultas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Mediciones</summary>	public static string TabMediciones 	{		get		{			SetPath();  			return resourceProviderConsultas.GetResource("TabMediciones", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Resultados</summary>	public static string TabResultados 	{		get		{			SetPath();  			return resourceProviderConsultas.GetResource("TabResultados", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
