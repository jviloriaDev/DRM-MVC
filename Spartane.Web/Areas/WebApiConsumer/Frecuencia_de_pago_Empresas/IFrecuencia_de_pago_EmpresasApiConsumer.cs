using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Empresas
{
    public interface IFrecuencia_de_pago_EmpresasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_EmpresasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EmpresasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EmpresasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EmpresasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_EmpresasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

