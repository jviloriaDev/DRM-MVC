using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Dashboard_Status
{
    public interface IDashboard_StatusApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dashboard_Status.Dashboard_StatusPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Dashboard_StatusInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Dashboard_Status.Dashboard_Status entity, Spartane.Core.Domain.User.GlobalData Dashboard_StatusInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Dashboard_Status.Dashboard_Status entity, Spartane.Core.Domain.User.GlobalData Dashboard_StatusInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Dashboard_Status.Dashboard_StatusPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<short> GenerateID();
		ApiResponse<short> Update_Datos_Generales(Spartane.Core.Domain.Dashboard_Status.Dashboard_Status_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

