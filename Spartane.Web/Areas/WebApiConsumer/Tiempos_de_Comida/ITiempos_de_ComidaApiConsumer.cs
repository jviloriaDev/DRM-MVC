using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tiempos_de_Comida
{
    public interface ITiempos_de_ComidaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_ComidaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tiempos_de_ComidaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida entity, Spartane.Core.Domain.User.GlobalData Tiempos_de_ComidaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida entity, Spartane.Core.Domain.User.GlobalData Tiempos_de_ComidaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_ComidaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

