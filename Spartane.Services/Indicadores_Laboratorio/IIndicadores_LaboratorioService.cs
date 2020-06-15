using System;
using Spartane.Core.Domain.Indicadores_Laboratorio;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Indicadores_Laboratorio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIndicadores_LaboratorioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_LaboratorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Indicadores_Laboratorio.Indicadores_Laboratorio> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
