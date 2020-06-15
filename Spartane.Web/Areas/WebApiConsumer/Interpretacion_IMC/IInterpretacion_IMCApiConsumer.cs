using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Interpretacion_IMC
{
    public interface IInterpretacion_IMCApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMCPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_IMCInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC entity, Spartane.Core.Domain.User.GlobalData Interpretacion_IMCInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC entity, Spartane.Core.Domain.User.GlobalData Interpretacion_IMCInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMCPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

