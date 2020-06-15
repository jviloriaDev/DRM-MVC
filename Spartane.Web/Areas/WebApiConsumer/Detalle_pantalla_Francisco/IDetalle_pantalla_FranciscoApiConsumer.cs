using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_pantalla_Francisco
{
    public interface IDetalle_pantalla_FranciscoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_FranciscoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_pantalla_FranciscoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco entity, Spartane.Core.Domain.User.GlobalData Detalle_pantalla_FranciscoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco entity, Spartane.Core.Domain.User.GlobalData Detalle_pantalla_FranciscoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_FranciscoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

