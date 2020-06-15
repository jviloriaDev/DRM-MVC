using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Medicos
{
    public interface IMedicosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Medicos.Medicos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Medicos.Medicos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Medicos.Medicos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Medicos.MedicosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData MedicosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Medicos.Medicos entity, Spartane.Core.Domain.User.GlobalData MedicosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Medicos.Medicos entity, Spartane.Core.Domain.User.GlobalData MedicosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Medicos.Medicos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Medicos.Medicos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Medicos.Medicos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Medicos.MedicosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Medicos.Medicos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Medicos.Medicos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Datos_Generales> Get_Datos_Generales(string Key);

		ApiResponse<int> Update_Datos_de_Contacto(Spartane.Core.Domain.Medicos.Medicos_Datos_de_Contacto entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Datos_de_Contacto> Get_Datos_de_Contacto(string Key);

		ApiResponse<int> Update_Datos_Profesionales(Spartane.Core.Domain.Medicos.Medicos_Datos_Profesionales entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Datos_Profesionales> Get_Datos_Profesionales(string Key);

		ApiResponse<int> Update_Datos_Fiscales(Spartane.Core.Domain.Medicos.Medicos_Datos_Fiscales entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Datos_Fiscales> Get_Datos_Fiscales(string Key);

		ApiResponse<int> Update_Documentacion(Spartane.Core.Domain.Medicos.Medicos_Documentacion entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Documentacion> Get_Documentacion(string Key);

		ApiResponse<int> Update_Codigos_de_Referencia(Spartane.Core.Domain.Medicos.Medicos_Codigos_de_Referencia entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Codigos_de_Referencia> Get_Codigos_de_Referencia(string Key);

		ApiResponse<int> Update_Suscripcion_Red_de_Especialistas(Spartane.Core.Domain.Medicos.Medicos_Suscripcion_Red_de_Especialistas entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Suscripcion_Red_de_Especialistas> Get_Suscripcion_Red_de_Especialistas(string Key);

		ApiResponse<int> Update_Datos_Bancarios(Spartane.Core.Domain.Medicos.Medicos_Datos_Bancarios entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Datos_Bancarios> Get_Datos_Bancarios(string Key);

		ApiResponse<int> Update_Facturacion(Spartane.Core.Domain.Medicos.Medicos_Facturacion entity);
		ApiResponse<Spartane.Core.Domain.Medicos.Medicos_Facturacion> Get_Facturacion(string Key);


    }
}

