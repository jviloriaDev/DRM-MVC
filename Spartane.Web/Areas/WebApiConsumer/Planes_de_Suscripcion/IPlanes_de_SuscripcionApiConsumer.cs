using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion
{
    public interface IPlanes_de_SuscripcionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_SuscripcionPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Planes_de_SuscripcionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion entity, Spartane.Core.Domain.User.GlobalData Planes_de_SuscripcionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion entity, Spartane.Core.Domain.User.GlobalData Planes_de_SuscripcionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_SuscripcionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

