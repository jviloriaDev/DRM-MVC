﻿using System;
using Spartane.Core.Domain.Planes_Alimenticios;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Planes_Alimenticios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPlanes_AlimenticiosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Planes_Alimenticios.Planes_AlimenticiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
