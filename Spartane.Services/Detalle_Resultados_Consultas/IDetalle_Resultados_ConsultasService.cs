using System;
using Spartane.Core.Domain.Detalle_Resultados_Consultas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Resultados_Consultas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Resultados_ConsultasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
