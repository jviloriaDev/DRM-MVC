using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Proveedores
{
    public interface IProveedoresApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Proveedores.Proveedores>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Proveedores.Proveedores>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Proveedores.Proveedores> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Proveedores.ProveedoresPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData ProveedoresInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Proveedores.Proveedores entity, Spartane.Core.Domain.User.GlobalData ProveedoresInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Proveedores.Proveedores entity, Spartane.Core.Domain.User.GlobalData ProveedoresInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Proveedores.Proveedores>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Proveedores.Proveedores>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Proveedores.Proveedores>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Proveedores.ProveedoresPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Proveedores.Proveedores>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Proveedores.Proveedores_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Proveedores.Proveedores_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Datos_de_Contacto(Spartane.Core.Domain.Proveedores.Proveedores_Datos_de_Contacto entity);
		ApiResponse<Spartane.Core.Domain.Proveedores.Proveedores_Datos_de_Contacto> Get_Datos_de_Contacto(string Key);

		ApiResponse<int> Update_Red_de_Proveedores(Spartane.Core.Domain.Proveedores.Proveedores_Red_de_Proveedores entity);
		ApiResponse<Spartane.Core.Domain.Proveedores.Proveedores_Red_de_Proveedores> Get_Red_de_Proveedores(string Key);

		ApiResponse<int> Update_Datos_Fiscales(Spartane.Core.Domain.Proveedores.Proveedores_Datos_Fiscales entity);
		ApiResponse<Spartane.Core.Domain.Proveedores.Proveedores_Datos_Fiscales> Get_Datos_Fiscales(string Key);


    }
}

