using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object_Type
{
    public interface ISpartan_Traduction_Object_TypeApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_TypePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Object_TypeInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Object_TypeInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Object_TypeInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_TypePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

