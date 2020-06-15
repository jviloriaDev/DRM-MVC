using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Template_Dashboard_Editor;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Editor
{
    public class Template_Dashboard_EditorApiConsumer : BaseApiConsumer,ITemplate_Dashboard_EditorApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Template_Dashboard_EditorApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Template_Dashboard_Editor";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>(false, null);
            }
        }

        public ApiResponse<Template_Dashboard_EditorPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Template_Dashboard_Editor.Template_Id='" + Key.ToString() + "'"
                        + "&Order=Template_Dashboard_Editor.Template_Id ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel>(false, new Template_Dashboard_EditorPagingModel() { Template_Dashboard_Editors = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Template_Dashboard_EditorInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<int> Insert(Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor entity, Core.Domain.User.GlobalData Template_Dashboard_EditorInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<int> Update(Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor entity, Core.Domain.User.GlobalData Template_Dashboard_EditorInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Template_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Template_Dashboard_EditorPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_EditorPagingModel>(false, new Template_Dashboard_EditorPagingModel() { Template_Dashboard_Editors = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Template_Dashboard_EditorGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Template_Dashboard_Editor_Datos_Generales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Generales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ApiResponse<Template_Dashboard_Editor_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor_Datos_Generales>(false, null);
            }
        }


    }
}

