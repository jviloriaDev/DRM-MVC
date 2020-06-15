using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification
{
    public interface ISpartan_BR_Action_ClassificationApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

