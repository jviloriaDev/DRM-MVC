using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Rango_de_Horas
{
    public interface IRango_de_HorasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Rango_de_Horas.Rango_de_HorasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Rango_de_HorasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas entity, Spartane.Core.Domain.User.GlobalData Rango_de_HorasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas entity, Spartane.Core.Domain.User.GlobalData Rango_de_HorasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Rango_de_Horas.Rango_de_HorasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

