using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Dashboard_Editor
{
    public interface IDashboard_EditorApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dashboard_Editor.Dashboard_EditorPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Dashboard_EditorInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor entity, Spartane.Core.Domain.User.GlobalData Dashboard_EditorInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor entity, Spartane.Core.Domain.User.GlobalData Dashboard_EditorInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Dashboard_Editor.Dashboard_EditorPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Configuracion(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor_Configuracion entity);
		ApiResponse<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor_Configuracion> Get_Configuracion(string Key);


    }
}

