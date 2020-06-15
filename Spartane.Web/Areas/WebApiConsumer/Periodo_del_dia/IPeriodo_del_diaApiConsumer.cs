using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Periodo_del_dia
{
    public interface IPeriodo_del_diaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_diaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Periodo_del_diaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia entity, Spartane.Core.Domain.User.GlobalData Periodo_del_diaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia entity, Spartane.Core.Domain.User.GlobalData Periodo_del_diaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_diaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

