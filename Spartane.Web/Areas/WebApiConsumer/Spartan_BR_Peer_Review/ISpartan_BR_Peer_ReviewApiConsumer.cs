using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Peer_Review
{
    public interface ISpartan_BR_Peer_ReviewApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_ReviewPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Peer_ReviewInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Peer_ReviewInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Peer_ReviewInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_ReviewPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

