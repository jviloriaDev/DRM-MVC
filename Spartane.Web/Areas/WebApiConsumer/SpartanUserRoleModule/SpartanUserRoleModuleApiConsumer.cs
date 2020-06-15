using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule
{
    public class SpartanUserRoleModuleApiConsumer :BaseApiConsumer, ISpartanUserRoleModuleApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartanUserRoleModuleApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/spartan_user_rule_module/";
        }


        

        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAll(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAllComplete(bool ConRelaciones)
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule> GetByKey(int? Key, bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<bool> Delete(int? Key,int Spartan_User_Role, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key +
                    "&Spartan_User_Role=" + Spartan_User_Role,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ResponseHelpers.ApiResponse<int> Insert(Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ResponseHelpers.ApiResponse<int> Update(Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.User_Rule_Module_Id + "&varSpartan_User_Rule_Module=" + entity,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>>(baseApi, ApiControllerUrl + "GetAll?" +
                    (string.IsNullOrEmpty(Where) ? "" : "Where=" + Where) +
                    "&Order=" + Order,
                     Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>>(true, products);


            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<Core.Domain.SpartaneUserRoleModule.SpartaneUserRolePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}