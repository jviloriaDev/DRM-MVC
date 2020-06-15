using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spartane.Core.Domain.Spartan_Additional_Menu;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject
{
    public class SpartaneUserRoleModuleObjectApiConsumer : BaseApiConsumer, ISpartaneUserRoleModuleObjectApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string AdditionalMenuApiControllerUrl { get; set; }
        public string baseApi;

        public SpartaneUserRoleModuleObjectApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/spartan_user_rule_module_object/";
            AdditionalMenuApiControllerUrl = "/api/SpartanAdditionalMenu/";
        }

        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAll(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(false, null);
            }
        }

        public ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject> GetByKey(int? Key, bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>(false, null);
            }
        }

        public ApiResponse<bool> Delete(int? Key, int spartanUserRole, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key + "&spartanUserRole=" + spartanUserRole,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }

        }

        public ApiResponse<int> Insert(Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.User_Rule_Module_Object_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(baseApi, ApiControllerUrl + "GetAll?" +
                    (string.IsNullOrEmpty(Where) ? "" : "Where=" + Where) +
                    "&Order=" + Order,
                     Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(true, products);


            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>>(false, null);
            }
           
        }

        public ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
             throw new NotImplementedException();
        }

        public ApiResponse<Core.Domain.SpartanUserRoleModuleObject.SpartaneUserRoleModuleObjectPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartaneUserRoleModuleObjectPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartanUserRoleModuleObject.SpartaneUserRoleModuleObjectPagingModel>(true, products);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartanUserRoleModuleObject.SpartaneUserRoleModuleObjectPagingModel>(false, new Core.Domain.SpartanUserRoleModuleObject.SpartaneUserRoleModuleObjectPagingModel() { Spartane_Module_Object = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Additional_Menu.Spartan_Additional_Menu>> GetAdditionalMenu(int user_Role_Id, int language_id)
        {
            try
            {
                var AdditionalMenus = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Additional_Menu.Spartan_Additional_Menu>>(baseApi, AdditionalMenuApiControllerUrl + "/GetMenu?user=" + user_Role_Id.ToString() + "&languageId=" + language_id,
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Additional_Menu.Spartan_Additional_Menu>>(true, AdditionalMenus);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Additional_Menu.Spartan_Additional_Menu>>(false, null);
            }
        }
    }
}