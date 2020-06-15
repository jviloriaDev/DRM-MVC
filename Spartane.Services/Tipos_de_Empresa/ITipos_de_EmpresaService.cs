using System;
using Spartane.Core.Domain.Tipos_de_Empresa;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipos_de_Empresa
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipos_de_EmpresaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipos_de_Empresa.Tipos_de_Empresa> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
