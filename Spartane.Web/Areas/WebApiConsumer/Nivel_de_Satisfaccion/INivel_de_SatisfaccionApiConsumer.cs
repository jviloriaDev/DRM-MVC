﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Nivel_de_Satisfaccion
{
    public interface INivel_de_SatisfaccionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_SatisfaccionPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Nivel_de_SatisfaccionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity, Spartane.Core.Domain.User.GlobalData Nivel_de_SatisfaccionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity, Spartane.Core.Domain.User.GlobalData Nivel_de_SatisfaccionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_SatisfaccionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

