using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Vendedores
{
    public interface IVendedoresApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Vendedores.Vendedores>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Vendedores.Vendedores>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Vendedores.Vendedores> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Vendedores.VendedoresPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData VendedoresInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Vendedores.Vendedores entity, Spartane.Core.Domain.User.GlobalData VendedoresInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Vendedores.Vendedores entity, Spartane.Core.Domain.User.GlobalData VendedoresInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Vendedores.Vendedores>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Vendedores.Vendedores>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Vendedores.Vendedores>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Vendedores.VendedoresPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Vendedores.Vendedores>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Vendedores.Vendedores_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Vendedores.Vendedores_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Codigos_de_Referencia(Spartane.Core.Domain.Vendedores.Vendedores_Codigos_de_Referencia entity);
		ApiResponse<Spartane.Core.Domain.Vendedores.Vendedores_Codigos_de_Referencia> Get_Codigos_de_Referencia(string Key);

		ApiResponse<int> Update_Datos_Bancarios(Spartane.Core.Domain.Vendedores.Vendedores_Datos_Bancarios entity);
		ApiResponse<Spartane.Core.Domain.Vendedores.Vendedores_Datos_Bancarios> Get_Datos_Bancarios(string Key);

		ApiResponse<int> Update_Facturacion(Spartane.Core.Domain.Vendedores.Vendedores_Facturacion entity);
		ApiResponse<Spartane.Core.Domain.Vendedores.Vendedores_Facturacion> Get_Facturacion(string Key);


    }
}

