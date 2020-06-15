using System;
using Spartane.Core.Domain.Empresas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Empresas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEmpresasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Empresas.Empresas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Empresas.Empresas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Empresas.Empresas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Empresas.Empresas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Empresas.Empresas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Empresas.Empresas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Empresas.Empresas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Empresas.Empresas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Empresas.EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Empresas.Empresas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
