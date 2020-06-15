using System;
using Spartane.Core.Domain.Nivel_de_Intensidad;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Nivel_de_Intensidad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INivel_de_IntensidadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
