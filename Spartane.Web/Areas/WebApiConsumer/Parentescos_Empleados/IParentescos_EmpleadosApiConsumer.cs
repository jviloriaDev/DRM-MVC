using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Parentescos_Empleados
{
    public interface IParentescos_EmpleadosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_EmpleadosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Parentescos_EmpleadosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados entity, Spartane.Core.Domain.User.GlobalData Parentescos_EmpleadosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados entity, Spartane.Core.Domain.User.GlobalData Parentescos_EmpleadosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_EmpleadosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

