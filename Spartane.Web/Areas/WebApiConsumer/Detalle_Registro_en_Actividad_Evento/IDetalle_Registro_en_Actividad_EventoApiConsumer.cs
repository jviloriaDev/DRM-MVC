﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_en_Actividad_Evento
{
    public interface IDetalle_Registro_en_Actividad_EventoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_EventoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Registro_en_Actividad_EventoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity, Spartane.Core.Domain.User.GlobalData Detalle_Registro_en_Actividad_EventoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity, Spartane.Core.Domain.User.GlobalData Detalle_Registro_en_Actividad_EventoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_EventoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

