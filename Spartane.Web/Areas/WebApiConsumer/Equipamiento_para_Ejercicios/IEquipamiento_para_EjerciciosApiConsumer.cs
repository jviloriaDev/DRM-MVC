using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Equipamiento_para_Ejercicios
{
    public interface IEquipamiento_para_EjerciciosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Equipamiento_para_EjerciciosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity, Spartane.Core.Domain.User.GlobalData Equipamiento_para_EjerciciosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity, Spartane.Core.Domain.User.GlobalData Equipamiento_para_EjerciciosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

