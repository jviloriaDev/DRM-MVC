using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Interpretacion_Calorias
{
    public interface IInterpretacion_CaloriasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_CaloriasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_CaloriasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias entity, Spartane.Core.Domain.User.GlobalData Interpretacion_CaloriasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias entity, Spartane.Core.Domain.User.GlobalData Interpretacion_CaloriasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_CaloriasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

