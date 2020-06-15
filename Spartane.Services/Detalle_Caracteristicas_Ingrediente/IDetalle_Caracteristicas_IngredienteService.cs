using System;
using Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Caracteristicas_Ingrediente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Caracteristicas_IngredienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_IngredientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
