using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Paciente
{
    public interface IDetalle_Suscripciones_PacienteApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_PacientePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Suscripciones_PacienteInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente entity, Spartane.Core.Domain.User.GlobalData Detalle_Suscripciones_PacienteInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente entity, Spartane.Core.Domain.User.GlobalData Detalle_Suscripciones_PacienteInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_PacientePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

