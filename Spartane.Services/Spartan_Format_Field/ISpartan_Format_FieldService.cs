using System;
using Spartane.Core.Domain.Spartan_Format_Field;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Format_Field
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_FieldService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_FieldPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Format_Field.Spartan_Format_Field> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
