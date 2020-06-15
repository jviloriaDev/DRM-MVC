using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PacientesMainModel
    {
        public PacientesModel PacientesInfo { set; get; }
        public Detalle_de_PadecimientosGridModelPost Detalle_de_PadecimientosGridInfo { set; get; }
        public Detalle_Antecedentes_FamiliaresGridModelPost Detalle_Antecedentes_FamiliaresGridInfo { set; get; }
        public Detalle_Antecedentes_No_PatologicosGridModelPost Detalle_Antecedentes_No_PatologicosGridInfo { set; get; }
        public Detalle_Examenes_LaboratorioGridModelPost Detalle_Examenes_LaboratorioGridInfo { set; get; }
        public Detalle_Terapia_HormonalGridModelPost Detalle_Terapia_HormonalGridInfo { set; get; }
        public MS_Exclusion_Ingredientes_PacienteGridModelPost MS_Exclusion_Ingredientes_PacienteGridInfo { set; get; }
        public Detalle_Preferencia_BebidasGridModelPost Detalle_Preferencia_BebidasGridInfo { set; get; }
        public Detalle_Pagos_PacienteGridModelPost Detalle_Pagos_PacienteGridInfo { set; get; }
        public Detalle_Suscripciones_PacienteGridModelPost Detalle_Suscripciones_PacienteGridInfo { set; get; }

    }

    public class Detalle_de_PadecimientosGridModelPost
    {
        public int Folio { get; set; }
        public int? Padecimiento { get; set; }
        public int? Tiempo_con_el_diagnostico { get; set; }
        public int? Intervencion_quirurgica { get; set; }
        public string Tratamiento { get; set; }
        public int? Estado_actual { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Antecedentes_FamiliaresGridModelPost
    {
        public int Folio { get; set; }
        public int? Enfermedad { get; set; }
        public int? Parentesco { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Antecedentes_No_PatologicosGridModelPost
    {
        public int Folio { get; set; }
        public int? Sustancia { get; set; }
        public int? Frecuencia { get; set; }
        public int? Cantidad { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Examenes_LaboratorioGridModelPost
    {
        public int Folio { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_Referencia { get; set; }
        public string Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Terapia_HormonalGridModelPost
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public string Dosis { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Exclusion_Ingredientes_PacienteGridModelPost
    {
        public int Folio { get; set; }
        public int? Ingrediente { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Preferencia_BebidasGridModelPost
    {
        public int Folio { get; set; }
        public int? Bebida { get; set; }
        public int? Cantidad { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Pagos_PacienteGridModelPost
    {
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string Fecha_de_Suscripcion { get; set; }
        public string Fecha_Limite_de_Pago { get; set; }
        public int? Forma_de_Pago { get; set; }
        public string Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Suscripciones_PacienteGridModelPost
    {
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }



}

