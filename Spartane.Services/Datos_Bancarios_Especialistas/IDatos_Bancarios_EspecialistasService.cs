using System;
using Spartane.Core.Domain.Datos_Bancarios_Especialistas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Datos_Bancarios_Especialistas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDatos_Bancarios_EspecialistasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
