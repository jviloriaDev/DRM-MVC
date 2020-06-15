using System;
using Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Interpretacion_distribucion_grasa_corporal
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_distribucion_grasa_corporalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
