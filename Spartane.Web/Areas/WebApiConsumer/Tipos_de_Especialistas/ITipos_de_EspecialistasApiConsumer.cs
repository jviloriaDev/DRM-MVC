using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tipos_de_Especialistas
{
    public interface ITipos_de_EspecialistasApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_EspecialistasPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipos_de_EspecialistasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas entity, Spartane.Core.Domain.User.GlobalData Tipos_de_EspecialistasInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas entity, Spartane.Core.Domain.User.GlobalData Tipos_de_EspecialistasInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_EspecialistasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tipos_de_Especialistas.Tipos_de_Especialistas_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

