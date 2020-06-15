using System;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Rango_Consumo_Bebidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRango_Consumo_BebidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
