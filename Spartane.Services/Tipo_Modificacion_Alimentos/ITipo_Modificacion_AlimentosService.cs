using System;
using Spartane.Core.Domain.Tipo_Modificacion_Alimentos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_Modificacion_Alimentos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_Modificacion_AlimentosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_AlimentosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
