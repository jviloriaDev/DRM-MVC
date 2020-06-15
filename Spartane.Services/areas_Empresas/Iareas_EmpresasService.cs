using System;
using Spartane.Core.Domain.areas_Empresas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.areas_Empresas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface Iareas_EmpresasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.areas_Empresas.areas_Empresas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.areas_Empresas.areas_Empresas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.areas_Empresas.areas_Empresas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.areas_Empresas.areas_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
