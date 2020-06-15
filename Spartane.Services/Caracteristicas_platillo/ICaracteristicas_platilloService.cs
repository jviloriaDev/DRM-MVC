using System;
using Spartane.Core.Domain.Caracteristicas_platillo;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Caracteristicas_platillo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICaracteristicas_platilloService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
