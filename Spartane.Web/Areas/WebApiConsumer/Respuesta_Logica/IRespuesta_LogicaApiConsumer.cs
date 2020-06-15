using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica
{
    public interface IRespuesta_LogicaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Respuesta_Logica.Respuesta_LogicaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Respuesta_LogicaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica entity, Spartane.Core.Domain.User.GlobalData Respuesta_LogicaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica entity, Spartane.Core.Domain.User.GlobalData Respuesta_LogicaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Respuesta_Logica.Respuesta_LogicaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

