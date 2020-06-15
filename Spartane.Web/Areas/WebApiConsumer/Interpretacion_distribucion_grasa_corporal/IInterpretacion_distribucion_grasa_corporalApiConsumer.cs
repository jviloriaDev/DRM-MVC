using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Interpretacion_distribucion_grasa_corporal
{
    public interface IInterpretacion_distribucion_grasa_corporalApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporalPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_distribucion_grasa_corporalInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal entity, Spartane.Core.Domain.User.GlobalData Interpretacion_distribucion_grasa_corporalInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal entity, Spartane.Core.Domain.User.GlobalData Interpretacion_distribucion_grasa_corporalInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporalPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

