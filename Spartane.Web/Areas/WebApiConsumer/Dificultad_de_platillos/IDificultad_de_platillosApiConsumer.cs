using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Dificultad_de_platillos
{
    public interface IDificultad_de_platillosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Dificultad_de_platillosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos entity, Spartane.Core.Domain.User.GlobalData Dificultad_de_platillosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos entity, Spartane.Core.Domain.User.GlobalData Dificultad_de_platillosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

