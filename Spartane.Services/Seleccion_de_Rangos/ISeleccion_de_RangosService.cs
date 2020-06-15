using System;
using Spartane.Core.Domain.Seleccion_de_Rangos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Seleccion_de_Rangos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISeleccion_de_RangosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_RangosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
