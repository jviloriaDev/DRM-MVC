using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Seleccion_de_Rangos
{
    public interface ISeleccion_de_RangosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_RangosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Seleccion_de_RangosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos entity, Spartane.Core.Domain.User.GlobalData Seleccion_de_RangosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos entity, Spartane.Core.Domain.User.GlobalData Seleccion_de_RangosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_RangosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

