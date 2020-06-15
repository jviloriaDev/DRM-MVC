using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Asuntos_Asistencia_Telefonica
{
    public interface IAsuntos_Asistencia_TelefonicaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_TelefonicaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Asuntos_Asistencia_TelefonicaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity, Spartane.Core.Domain.User.GlobalData Asuntos_Asistencia_TelefonicaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity, Spartane.Core.Domain.User.GlobalData Asuntos_Asistencia_TelefonicaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_TelefonicaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

