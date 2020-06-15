using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Dias_de_la_semana
{
    public interface IDias_de_la_semanaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semanaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Dias_de_la_semanaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana entity, Spartane.Core.Domain.User.GlobalData Dias_de_la_semanaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana entity, Spartane.Core.Domain.User.GlobalData Dias_de_la_semanaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semanaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

