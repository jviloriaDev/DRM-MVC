﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format
{
    public interface ISpartan_Report_FormatApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_FormatPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_FormatInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_FormatInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_FormatInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_FormatPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

