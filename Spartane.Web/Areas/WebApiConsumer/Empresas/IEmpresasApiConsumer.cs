using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Empresas
{
    public interface IEmpresasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Empresas.Empresas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Empresas.Empresas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Empresas.Empresas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Empresas.EmpresasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpresasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Empresas.Empresas entity, Spartane.Core.Domain.User.GlobalData EmpresasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Empresas.Empresas entity, Spartane.Core.Domain.User.GlobalData EmpresasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Empresas.Empresas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Empresas.Empresas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Empresas.Empresas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Empresas.EmpresasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Empresas.Empresas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Empresas.Empresas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Empresas.Empresas_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Datos_de_Contacto(Spartane.Core.Domain.Empresas.Empresas_Datos_de_Contacto entity);
		ApiResponse<Spartane.Core.Domain.Empresas.Empresas_Datos_de_Contacto> Get_Datos_de_Contacto(string Key);

		ApiResponse<int> Update_Datos_Fiscales(Spartane.Core.Domain.Empresas.Empresas_Datos_Fiscales entity);
		ApiResponse<Spartane.Core.Domain.Empresas.Empresas_Datos_Fiscales> Get_Datos_Fiscales(string Key);

		ApiResponse<int> Update_Suscripcion(Spartane.Core.Domain.Empresas.Empresas_Suscripcion entity);
		ApiResponse<Spartane.Core.Domain.Empresas.Empresas_Suscripcion> Get_Suscripcion(string Key);

		ApiResponse<int> Update_Documentacion(Spartane.Core.Domain.Empresas.Empresas_Documentacion entity);
		ApiResponse<Spartane.Core.Domain.Empresas.Empresas_Documentacion> Get_Documentacion(string Key);


    }
}

