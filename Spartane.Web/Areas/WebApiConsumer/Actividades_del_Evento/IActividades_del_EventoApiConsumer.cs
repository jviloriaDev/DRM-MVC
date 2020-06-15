using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Actividades_del_Evento
{
    public interface IActividades_del_EventoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Actividades_del_EventoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Spartane.Core.Domain.User.GlobalData Actividades_del_EventoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Spartane.Core.Domain.User.GlobalData Actividades_del_EventoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Agenda(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Agenda entity);
		ApiResponse<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento_Agenda> Get_Agenda(string Key);


    }
}

