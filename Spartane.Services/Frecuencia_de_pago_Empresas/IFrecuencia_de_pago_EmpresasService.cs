using System;
using Spartane.Core.Domain.Frecuencia_de_pago_Empresas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Frecuencia_de_pago_Empresas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IFrecuencia_de_pago_EmpresasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
