using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tipos_de_Contrato
{
    public interface ITipos_de_ContratoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_ContratoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipos_de_ContratoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato entity, Spartane.Core.Domain.User.GlobalData Tipos_de_ContratoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato entity, Spartane.Core.Domain.User.GlobalData Tipos_de_ContratoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_ContratoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tipos_de_Contrato.Tipos_de_Contrato_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

