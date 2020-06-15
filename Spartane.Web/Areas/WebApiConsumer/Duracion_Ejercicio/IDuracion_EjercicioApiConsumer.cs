using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Duracion_Ejercicio
{
    public interface IDuracion_EjercicioApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_EjercicioPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Duracion_EjercicioInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio entity, Spartane.Core.Domain.User.GlobalData Duracion_EjercicioInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio entity, Spartane.Core.Domain.User.GlobalData Duracion_EjercicioInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_EjercicioPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

