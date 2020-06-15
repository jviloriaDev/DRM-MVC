using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tips_y_Promociones
{
    public interface ITips_y_PromocionesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_PromocionesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tips_y_PromocionesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones entity, Spartane.Core.Domain.User.GlobalData Tips_y_PromocionesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones entity, Spartane.Core.Domain.User.GlobalData Tips_y_PromocionesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_PromocionesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

