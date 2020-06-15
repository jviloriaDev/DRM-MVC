using System;
using Spartane.Core.Domain.Spartan_Traduction_Language;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Traduction_Language
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_LanguageService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_LanguagePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
