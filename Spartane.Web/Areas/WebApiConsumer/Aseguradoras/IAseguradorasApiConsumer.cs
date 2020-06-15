using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Aseguradoras
{
    public interface IAseguradorasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Aseguradoras.Aseguradoras> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Aseguradoras.AseguradorasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData AseguradorasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Aseguradoras.Aseguradoras entity, Spartane.Core.Domain.User.GlobalData AseguradorasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Aseguradoras.Aseguradoras entity, Spartane.Core.Domain.User.GlobalData AseguradorasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Aseguradoras.AseguradorasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Aseguradoras.Aseguradoras_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Aseguradoras.Aseguradoras_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

