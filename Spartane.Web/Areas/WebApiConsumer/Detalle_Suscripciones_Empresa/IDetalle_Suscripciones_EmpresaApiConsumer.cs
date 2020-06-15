using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Empresa
{
    public interface IDetalle_Suscripciones_EmpresaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Suscripciones_EmpresaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity, Spartane.Core.Domain.User.GlobalData Detalle_Suscripciones_EmpresaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity, Spartane.Core.Domain.User.GlobalData Detalle_Suscripciones_EmpresaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

