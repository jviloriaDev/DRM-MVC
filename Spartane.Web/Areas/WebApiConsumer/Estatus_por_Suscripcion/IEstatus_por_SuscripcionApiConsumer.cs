using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Estatus_por_Suscripcion
{
    public interface IEstatus_por_SuscripcionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_SuscripcionPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_por_SuscripcionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion entity, Spartane.Core.Domain.User.GlobalData Estatus_por_SuscripcionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion entity, Spartane.Core.Domain.User.GlobalData Estatus_por_SuscripcionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_SuscripcionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

