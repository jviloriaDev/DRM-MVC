using System;
using Spartane.Core.Domain.Unidades_de_Medida;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Unidades_de_Medida
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IUnidades_de_MedidaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_MedidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
