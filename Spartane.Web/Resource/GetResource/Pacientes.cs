using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class PacientesResources
    {
        //private static IResourceProvider resourceProviderPacientes = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\PacientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPacientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\PacientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPacientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\PacientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Pacientes</summary>
        public static string Pacientes
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pacientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Registro</summary>
        public static string Tipo_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Tipo_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Paciente</summary>
        public static string Tipo_de_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Tipo_de_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_Registrado</summary>
        public static string Usuario_Registrado
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Usuario_Registrado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Empresa</summary>
        public static string Empresa
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Empleado</summary>
        public static string Numero_de_Empleado
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Numero_de_Empleado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombres</summary>
        public static string Nombres
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Nombres", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Paterno</summary>
        public static string Apellido_Paterno
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Apellido_Paterno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Materno</summary>
        public static string Apellido_Materno
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Apellido_Materno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Celular</summary>
        public static string Celular
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Celular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_nacimiento</summary>
        public static string Fecha_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Fecha_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Padre_o_Tutor</summary>
        public static string Nombre_del_Padre_o_Tutor
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Nombre_del_Padre_o_Tutor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_de_nacimiento</summary>
        public static string Pais_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pais_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Lugar_de_nacimiento</summary>
        public static string Lugar_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Lugar_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado_Civil</summary>
        public static string Estado_Civil
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Estado_Civil", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle</summary>
        public static string Calle
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Calle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior</summary>
        public static string Numero_exterior
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Numero_exterior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior</summary>
        public static string Numero_interior
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Numero_interior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia</summary>
        public static string Colonia
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Colonia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CP</summary>
        public static string CP
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("CP", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad</summary>
        public static string Ciudad
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Ciudad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado</summary>
        public static string Estado
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Estado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ocupacion</summary>
        public static string Ocupacion
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Ocupacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_hijos</summary>
        public static string Cantidad_hijos
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Cantidad_hijos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Objetivo</summary>
        public static string Objetivo
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Objetivo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_Paciente</summary>
        public static string Estatus_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Estatus_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cuenta_con_padecimientos</summary>
        public static string Cuenta_con_padecimientos
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Cuenta_con_padecimientos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle_del_padecimiento</summary>
        public static string Detalle_del_padecimiento
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Detalle_del_padecimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Antecedentes_Familiares</summary>
        public static string Antecedentes_Familiares
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Antecedentes_Familiares", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Antecedentes_personales_no_patologicos</summary>
        public static string Antecedentes_personales_no_patologicos
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Antecedentes_personales_no_patologicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_Cardiaca</summary>
        public static string Frecuencia_Cardiaca
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Frecuencia_Cardiaca", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_Respiratoria</summary>
        public static string Frecuencia_Respiratoria
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Frecuencia_Respiratoria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presion_sistolica</summary>
        public static string Presion_sistolica
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Presion_sistolica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presion_diastolica</summary>
        public static string Presion_diastolica
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Presion_diastolica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso_actual</summary>
        public static string Peso_actual
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Peso_actual", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatura</summary>
        public static string Estatura
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Estatura", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso_habitual</summary>
        public static string Peso_habitual
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Peso_habitual", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Circunferencia_de_cintura_cm</summary>
        public static string Circunferencia_de_cintura_cm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Circunferencia_de_cintura_cm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Circunferencia_de_cadera_cm</summary>
        public static string Circunferencia_de_cadera_cm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Circunferencia_de_cadera_cm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Anchura_de_muneca_mm</summary>
        public static string Anchura_de_muneca_mm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Anchura_de_muneca_mm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Circunferencia_de_brazo_cm</summary>
        public static string Circunferencia_de_brazo_cm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Circunferencia_de_brazo_cm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pliegue_cutaneo_tricipital_mm</summary>
        public static string Pliegue_cutaneo_tricipital_mm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pliegue_cutaneo_tricipital_mm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pliegue_cutaneo_bicipital_mm</summary>
        public static string Pliegue_cutaneo_bicipital_mm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pliegue_cutaneo_bicipital_mm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pliegue_cutaneo_subescapular_mm</summary>
        public static string Pliegue_cutaneo_subescapular_mm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pliegue_cutaneo_subescapular_mm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pliegue_cutaneo_supraespinal_mm</summary>
        public static string Pliegue_cutaneo_supraespinal_mm
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pliegue_cutaneo_supraespinal_mm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edad_Metabolica</summary>
        public static string Edad_Metabolica
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Edad_Metabolica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Agua_corporal</summary>
        public static string Agua_corporal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Agua_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasa_Visceral</summary>
        public static string Grasa_Visceral
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Grasa_Visceral", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasa_Corporal</summary>
        public static string Grasa_Corporal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Grasa_Corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasa_Corporal_kg</summary>
        public static string Grasa_Corporal_kg
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Grasa_Corporal_kg", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Masa_Muscular_kg</summary>
        public static string Masa_Muscular_kg
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Masa_Muscular_kg", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Masa_Muscular_</summary>
        public static string Masa_Muscular_
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Masa_Muscular_", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Examenes_de_Laboratorio</summary>
        public static string Examenes_de_Laboratorio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Examenes_de_Laboratorio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Esta_embarazada</summary>
        public static string Esta_embarazada
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Esta_embarazada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Semana_de_gestacion</summary>
        public static string Semana_de_gestacion
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Semana_de_gestacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso_pregestacional</summary>
        public static string Peso_pregestacional
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Peso_pregestacional", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Toma_anticonceptivos</summary>
        public static string Toma_anticonceptivos
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Toma_anticonceptivos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Anticonceptivo</summary>
        public static string Nombre_del_Anticonceptivo
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Nombre_del_Anticonceptivo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dosis</summary>
        public static string Dosis
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Dosis", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Climaterio</summary>
        public static string Climaterio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Climaterio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_Climaterio</summary>
        public static string Fecha_Climaterio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Fecha_Climaterio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Terapia_reemplazo_hormonal</summary>
        public static string Terapia_reemplazo_hormonal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Terapia_reemplazo_hormonal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle_de_Terapia_Hormonal</summary>
        public static string Detalle_de_Terapia_Hormonal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Detalle_de_Terapia_Hormonal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_Dieta</summary>
        public static string Tipo_Dieta
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Tipo_Dieta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Alergias</summary>
        public static string Alergias
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Alergias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle_Bebidas_Paciente</summary>
        public static string Detalle_Bebidas_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Detalle_Bebidas_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suplementos</summary>
        public static string Suplementos
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Suplementos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Consumo_de_sal</summary>
        public static string Consumo_de_sal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Consumo_de_sal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Grasas_Preferencias</summary>
        public static string Grasas_Preferencias
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Grasas_Preferencias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comidas_cantidad</summary>
        public static string Comidas_cantidad
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Comidas_cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Preparacion_Preferencias</summary>
        public static string Preparacion_Preferencias
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Preparacion_Preferencias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Entre_comidas</summary>
        public static string Entre_comidas
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Entre_comidas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apetito</summary>
        public static string Apetito
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Apetito", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Habitos_Modificacion</summary>
        public static string Habitos_Modificacion
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Habitos_Modificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Horario_hambre</summary>
        public static string Horario_hambre
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Horario_hambre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cuando_cambia_mi_estado_de_animo</summary>
        public static string Cuando_cambia_mi_estado_de_animo
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Cuando_cambia_mi_estado_de_animo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Medicamentos_bajar_peso</summary>
        public static string Medicamentos_bajar_peso
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Medicamentos_bajar_peso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cual_medicamento</summary>
        public static string Cual_medicamento
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Cual_medicamento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_Ejercicio</summary>
        public static string Frecuencia_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Frecuencia_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion_Ejercicio</summary>
        public static string Duracion_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Duracion_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_Ejercicio</summary>
        public static string Tipo_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Tipo_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Antiguedad_Ejercicio</summary>
        public static string Antiguedad_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Antiguedad_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IMC</summary>
        public static string IMC
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("IMC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_IMC</summary>
        public static string Interpretacion_IMC
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_IMC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IMC_Pediatria</summary>
        public static string IMC_Pediatria
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("IMC_Pediatria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Complexion_corporal</summary>
        public static string Complexion_corporal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Complexion_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_complexion_corporal</summary>
        public static string Interpretacion_complexion_corporal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_complexion_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Distribucion_de_grasa_corporal</summary>
        public static string Distribucion_de_grasa_corporal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Distribucion_de_grasa_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_grasa_corporal</summary>
        public static string Interpretacion_grasa_corporal
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_grasa_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Indice_cintura_cadera</summary>
        public static string Indice_cintura_cadera
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Indice_cintura_cadera", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_indice</summary>
        public static string Interpretacion_indice
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_indice", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Consumo_de_agua_resultado</summary>
        public static string Consumo_de_agua_resultado
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Consumo_de_agua_resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_agua</summary>
        public static string Interpretacion_agua
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_agua", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_cardiaca_en_Esfuerzo</summary>
        public static string Frecuencia_cardiaca_en_Esfuerzo
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Frecuencia_cardiaca_en_Esfuerzo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_frecuencia</summary>
        public static string Interpretacion_frecuencia
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_frecuencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dificultad_de_Rutina_de_Ejercicios</summary>
        public static string Dificultad_de_Rutina_de_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Dificultad_de_Rutina_de_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_dificultad</summary>
        public static string Interpretacion_dificultad
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calorias</summary>
        public static string Calorias
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Calorias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion_calorias</summary>
        public static string Interpretacion_calorias
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Interpretacion_calorias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Observaciones</summary>
        public static string Observaciones
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Observaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pagos</summary>
        public static string Pagos
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Pagos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripciones</summary>
        public static string Suscripciones
        {
            get
            {
                SetPath();
                return resourceProviderPacientes.GetResource("Suscripciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Padecimientos</summary>	public static string TabPadecimientos 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabPadecimientos", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Antecedentes</summary>	public static string TabAntecedentes 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabAntecedentes", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Mediciones Iniciales</summary>	public static string TabMediciones_Iniciales 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabMediciones_Iniciales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Ginecológicos</summary>	public static string TabDatos_Ginecologicos 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabDatos_Ginecologicos", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Historia Nutricional</summary>	public static string TabHistoria_Nutricional 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabHistoria_Nutricional", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Estilo de Vida</summary>	public static string TabEstilo_de_Vida 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabEstilo_de_Vida", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Resultados</summary>	public static string TabResultados 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabResultados", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Suscripción</summary>	public static string TabSuscripcion 	{		get		{			SetPath();  			return resourceProviderPacientes.GetResource("TabSuscripcion", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
