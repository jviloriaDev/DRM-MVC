using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Formas_de_Pago
{
    public interface IFormas_de_PagoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Formas_de_Pago.Formas_de_PagoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Formas_de_PagoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago entity, Spartane.Core.Domain.User.GlobalData Formas_de_PagoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago entity, Spartane.Core.Domain.User.GlobalData Formas_de_PagoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Formas_de_Pago.Formas_de_PagoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

