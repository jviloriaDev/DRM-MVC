using System;
using Spartane.Core.Domain.Tipo_de_Registro;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_de_Registro
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_RegistroService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_RegistroPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
