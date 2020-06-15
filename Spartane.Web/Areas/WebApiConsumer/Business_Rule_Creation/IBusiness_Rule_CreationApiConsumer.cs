using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Business_Rule_Creation
{
    public interface IBusiness_Rule_CreationApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Business_Rule_CreationInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Spartane.Core.Domain.User.GlobalData Business_Rule_CreationInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Spartane.Core.Domain.User.GlobalData Business_Rule_CreationInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

