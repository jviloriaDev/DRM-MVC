using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Identificaciones_Oficiales
{
    public interface IIdentificaciones_OficialesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_OficialesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Identificaciones_OficialesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales entity, Spartane.Core.Domain.User.GlobalData Identificaciones_OficialesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales entity, Spartane.Core.Domain.User.GlobalData Identificaciones_OficialesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_OficialesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

