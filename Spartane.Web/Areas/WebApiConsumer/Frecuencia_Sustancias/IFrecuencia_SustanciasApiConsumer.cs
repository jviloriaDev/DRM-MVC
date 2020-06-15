using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Frecuencia_Sustancias
{
    public interface IFrecuencia_SustanciasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_SustanciasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_SustanciasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias entity, Spartane.Core.Domain.User.GlobalData Frecuencia_SustanciasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias entity, Spartane.Core.Domain.User.GlobalData Frecuencia_SustanciasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_SustanciasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

