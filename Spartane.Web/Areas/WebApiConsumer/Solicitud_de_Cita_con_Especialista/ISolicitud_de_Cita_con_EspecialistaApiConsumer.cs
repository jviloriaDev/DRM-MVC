using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Solicitud_de_Cita_con_Especialista
{
    public interface ISolicitud_de_Cita_con_EspecialistaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_EspecialistaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Solicitud_de_Cita_con_EspecialistaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity, Spartane.Core.Domain.User.GlobalData Solicitud_de_Cita_con_EspecialistaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity, Spartane.Core.Domain.User.GlobalData Solicitud_de_Cita_con_EspecialistaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_EspecialistaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Solicitud(Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista_Solicitud entity);
		ApiResponse<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista_Solicitud> Get_Solicitud(string Key);


    }
}

