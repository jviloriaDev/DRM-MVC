using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Horarios_Actividad
{
    public interface IDetalle_Horarios_ActividadApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_ActividadPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Horarios_ActividadInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity, Spartane.Core.Domain.User.GlobalData Detalle_Horarios_ActividadInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity, Spartane.Core.Domain.User.GlobalData Detalle_Horarios_ActividadInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_ActividadPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

