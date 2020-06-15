using System;
using Spartane.Core.Domain.Nivel_de_dificultad;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Nivel_de_dificultad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INivel_de_dificultadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
