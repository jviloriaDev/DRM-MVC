using System;
using Spartane.Core.Domain.Titulos_Personales;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Titulos_Personales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITitulos_PersonalesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Titulos_Personales.Titulos_Personales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Titulos_Personales.Titulos_Personales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Titulos_Personales.Titulos_Personales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Titulos_Personales.Titulos_PersonalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
