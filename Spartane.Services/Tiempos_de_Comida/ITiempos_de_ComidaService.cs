using System;
using Spartane.Core.Domain.Tiempos_de_Comida;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tiempos_de_Comida
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITiempos_de_ComidaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_ComidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
