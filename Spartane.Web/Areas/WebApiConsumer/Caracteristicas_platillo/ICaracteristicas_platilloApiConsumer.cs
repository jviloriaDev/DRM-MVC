using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Caracteristicas_platillo
{
    public interface ICaracteristicas_platilloApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platilloPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Caracteristicas_platilloInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo entity, Spartane.Core.Domain.User.GlobalData Caracteristicas_platilloInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo entity, Spartane.Core.Domain.User.GlobalData Caracteristicas_platilloInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platilloPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

