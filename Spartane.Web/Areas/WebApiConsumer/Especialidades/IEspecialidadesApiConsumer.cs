using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Especialidades
{
    public interface IEspecialidadesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Especialidades.Especialidades>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Especialidades.Especialidades>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Especialidades.Especialidades> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Especialidades.EspecialidadesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData EspecialidadesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Especialidades.Especialidades entity, Spartane.Core.Domain.User.GlobalData EspecialidadesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Especialidades.Especialidades entity, Spartane.Core.Domain.User.GlobalData EspecialidadesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Especialidades.Especialidades>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Especialidades.Especialidades>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Especialidades.Especialidades>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Especialidades.EspecialidadesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Especialidades.Especialidades>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Especialidades.Especialidades_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Especialidades.Especialidades_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

