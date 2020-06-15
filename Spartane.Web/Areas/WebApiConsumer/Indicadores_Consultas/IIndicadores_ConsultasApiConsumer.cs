using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Indicadores_Consultas
{
    public interface IIndicadores_ConsultasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_ConsultasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Indicadores_ConsultasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas entity, Spartane.Core.Domain.User.GlobalData Indicadores_ConsultasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas entity, Spartane.Core.Domain.User.GlobalData Indicadores_ConsultasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_ConsultasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

