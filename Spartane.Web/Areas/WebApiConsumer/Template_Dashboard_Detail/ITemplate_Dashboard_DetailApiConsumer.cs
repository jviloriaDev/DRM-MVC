using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Detail
{
    public interface ITemplate_Dashboard_DetailApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_DetailPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Template_Dashboard_DetailInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail entity, Spartane.Core.Domain.User.GlobalData Template_Dashboard_DetailInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail entity, Spartane.Core.Domain.User.GlobalData Template_Dashboard_DetailInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_DetailPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Template_Dashboard_Detail.Template_Dashboard_Detail_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

