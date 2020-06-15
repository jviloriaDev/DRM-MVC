using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.SpartanChangePasswordAutorizationEstatus
{
    public interface ISpartanChangePasswordAutorizationEstatusApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Spartane.Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Spartane.Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

