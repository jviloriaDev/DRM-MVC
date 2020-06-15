using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Pacientes
{
    public interface IFrecuencia_de_pago_PacientesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_PacientesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_PacientesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_PacientesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_PacientesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_PacientesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

