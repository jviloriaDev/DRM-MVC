using System;
using Spartane.Core.Domain.Dificultad_de_platillos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Dificultad_de_platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDificultad_de_platillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
