using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Cantidad_fraccion_platillos
{
    public interface ICantidad_fraccion_platillosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Spartane.Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Spartane.Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

