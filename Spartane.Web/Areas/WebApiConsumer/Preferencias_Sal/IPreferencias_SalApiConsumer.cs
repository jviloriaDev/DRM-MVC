using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Preferencias_Sal
{
    public interface IPreferencias_SalApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Preferencias_Sal.Preferencias_SalPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Preferencias_SalInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal entity, Spartane.Core.Domain.User.GlobalData Preferencias_SalInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal entity, Spartane.Core.Domain.User.GlobalData Preferencias_SalInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Preferencias_Sal.Preferencias_SalPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

