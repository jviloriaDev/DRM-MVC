using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades
{
    public interface ITipos_de_ActividadesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_ActividadesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipos_de_ActividadesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades entity, Spartane.Core.Domain.User.GlobalData Tipos_de_ActividadesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades entity, Spartane.Core.Domain.User.GlobalData Tipos_de_ActividadesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_ActividadesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

