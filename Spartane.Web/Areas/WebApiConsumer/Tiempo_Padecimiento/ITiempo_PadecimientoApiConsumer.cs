using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tiempo_Padecimiento
{
    public interface ITiempo_PadecimientoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_PadecimientoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tiempo_PadecimientoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento entity, Spartane.Core.Domain.User.GlobalData Tiempo_PadecimientoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento entity, Spartane.Core.Domain.User.GlobalData Tiempo_PadecimientoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_PadecimientoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

