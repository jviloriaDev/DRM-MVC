using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Parentesco
{
    public interface IParentescoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Parentesco.Parentesco>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Parentesco.Parentesco>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Parentesco.Parentesco> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Parentesco.ParentescoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData ParentescoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Parentesco.Parentesco entity, Spartane.Core.Domain.User.GlobalData ParentescoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Parentesco.Parentesco entity, Spartane.Core.Domain.User.GlobalData ParentescoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Parentesco.Parentesco>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Parentesco.Parentesco>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Parentesco.Parentesco>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Parentesco.ParentescoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Parentesco.Parentesco>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Parentesco.Parentesco_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Parentesco.Parentesco_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

