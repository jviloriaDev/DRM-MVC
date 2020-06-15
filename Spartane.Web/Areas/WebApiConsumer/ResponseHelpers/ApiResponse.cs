using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;


namespace Spartane.Web.Areas.WebApiConsumer.ResponseHelpers
{
    public class ApiResponse<T>
    {
        public bool Success;

        public ApiResponse(bool success, T resource, IEnumerable<ApiError> warnings = null, string resourceId = null)
        {
            Success = success;
            if (warnings != null) Warnings = warnings.ToArray();
            Resource = resource;
            ResourceId = resourceId;
        }

        public ApiResponse()
        {
        }

        public string ResourceId { get; set; }
        public T Resource { get; set; }
        public ApiError[] Warnings { get; set; }
    }



    public class ApiErrorResponse
    {
        public ApiErrorResponse(ModelStateDictionary modelState)
            : this(modelState.Where(e => e.Value.Errors.Count > 0).Select(modelStateItem => new ApiError
            {
                Code = "ValidationError",
                Field = modelStateItem.Key,
                Message = string.Join(Environment.NewLine, modelStateItem.Value.Errors.Select(e => e.ErrorMessage))
            }).ToArray())
        {
        }

        public ApiErrorResponse(string code, string message, string field = null)
        {
            Errors = new[] { new ApiError { Code = code, Message = message, Field = field } };
        }

        public ApiErrorResponse(IEnumerable<ApiError> errors, IEnumerable<ApiError> warnings = null)
        {
            Errors = errors.ToArray();
            Warnings = warnings.ToArray();
        }

        public ApiErrorResponse()
        {
        }

        public ApiError[] Errors { get; set; }
        public ApiError[] Warnings { get; set; }
    }

    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(string code, string field, string messge)
        {
            Code = code;
            Field = field;
            Message = messge;
        }

        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}