using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Estatus_Reservaciones_Actividad
{
    public interface IEstatus_Reservaciones_ActividadApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_ActividadPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_Reservaciones_ActividadInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity, Spartane.Core.Domain.User.GlobalData Estatus_Reservaciones_ActividadInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity, Spartane.Core.Domain.User.GlobalData Estatus_Reservaciones_ActividadInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_ActividadPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

