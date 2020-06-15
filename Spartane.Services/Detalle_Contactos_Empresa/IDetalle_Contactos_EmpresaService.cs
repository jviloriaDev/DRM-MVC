using System;
using Spartane.Core.Domain.Detalle_Contactos_Empresa;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Contactos_Empresa
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Contactos_EmpresaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
