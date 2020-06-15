using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Especialistas_Pacientes
{
    public interface IDetalle_Especialistas_PacientesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_PacientesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Especialistas_PacientesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity, Spartane.Core.Domain.User.GlobalData Detalle_Especialistas_PacientesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity, Spartane.Core.Domain.User.GlobalData Detalle_Especialistas_PacientesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_PacientesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

