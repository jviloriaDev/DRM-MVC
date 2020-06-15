using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Pacientes
{
    public interface IPacientesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Pacientes.Pacientes>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Pacientes.Pacientes>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Pacientes.PacientesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData PacientesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Pacientes.Pacientes entity, Spartane.Core.Domain.User.GlobalData PacientesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Pacientes.Pacientes entity, Spartane.Core.Domain.User.GlobalData PacientesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Pacientes.Pacientes>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Pacientes.Pacientes>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Pacientes.Pacientes>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Pacientes.PacientesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Pacientes.Pacientes>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Pacientes.Pacientes_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Padecimientos(Spartane.Core.Domain.Pacientes.Pacientes_Padecimientos entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Padecimientos> Get_Padecimientos(string Key);

		ApiResponse<int> Update_Antecedentes(Spartane.Core.Domain.Pacientes.Pacientes_Antecedentes entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Antecedentes> Get_Antecedentes(string Key);

		ApiResponse<int> Update_Mediciones_Iniciales(Spartane.Core.Domain.Pacientes.Pacientes_Mediciones_Iniciales entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Mediciones_Iniciales> Get_Mediciones_Iniciales(string Key);

		ApiResponse<int> Update_Datos_Ginecologicos(Spartane.Core.Domain.Pacientes.Pacientes_Datos_Ginecologicos entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Datos_Ginecologicos> Get_Datos_Ginecologicos(string Key);

		ApiResponse<int> Update_Historia_Nutricional(Spartane.Core.Domain.Pacientes.Pacientes_Historia_Nutricional entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Historia_Nutricional> Get_Historia_Nutricional(string Key);

		ApiResponse<int> Update_Estilo_de_Vida(Spartane.Core.Domain.Pacientes.Pacientes_Estilo_de_Vida entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Estilo_de_Vida> Get_Estilo_de_Vida(string Key);

		ApiResponse<int> Update_Resultados(Spartane.Core.Domain.Pacientes.Pacientes_Resultados entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Resultados> Get_Resultados(string Key);

		ApiResponse<int> Update_Suscripcion(Spartane.Core.Domain.Pacientes.Pacientes_Suscripcion entity);
		ApiResponse<Spartane.Core.Domain.Pacientes.Pacientes_Suscripcion> Get_Suscripcion(string Key);


    }
}

