using System;
using Spartane.Core.Domain.Parentescos_Empleados;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Parentescos_Empleados
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IParentescos_EmpleadosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Parentescos_Empleados.Parentescos_EmpleadosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
