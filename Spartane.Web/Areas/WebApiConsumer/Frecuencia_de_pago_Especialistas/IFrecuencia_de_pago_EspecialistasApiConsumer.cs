using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Especialistas
{
    public interface IFrecuencia_de_pago_EspecialistasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_EspecialistasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EspecialistasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EspecialistasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EspecialistasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_EspecialistasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

