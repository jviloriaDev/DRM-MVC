using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Caracteristicas_Ingrediente
{
    public interface IDetalle_Caracteristicas_IngredienteApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_IngredientePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Caracteristicas_IngredienteInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity, Spartane.Core.Domain.User.GlobalData Detalle_Caracteristicas_IngredienteInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity, Spartane.Core.Domain.User.GlobalData Detalle_Caracteristicas_IngredienteInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_IngredientePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

