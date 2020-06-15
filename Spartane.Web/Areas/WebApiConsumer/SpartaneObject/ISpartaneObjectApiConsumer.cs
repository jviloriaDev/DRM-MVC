using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneObject
{
   public interface ISpartaneObjectApiConsumer
    {

        void SetAuthHeader(string token);

        Int32 SelCount();

        ApiResponse<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>> SelAll(Boolean ConRelaciones);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>> SelAllComplete(Boolean ConRelaciones);

        ApiResponse<Spartane.Core.Domain.SpartaneObject.SpartaneObject> GetByKey(int? Key, Boolean ConRelaciones);

        ApiResponse<bool> Delete(int? Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<Int32> Insert(Spartane.Core.Domain.SpartaneObject.SpartaneObject entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<Int32> Update(Spartane.Core.Domain.SpartaneObject.SpartaneObject entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>> SelAll(Boolean ConRelaciones, string Where, string Order);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        
        ApiResponse<Spartane.Core.Domain.SpartaneObject.SpartaneObjectPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>> ListaSelAll(Boolean ConRelaciones, string Where);


    }


}
