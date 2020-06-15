using System;
using System.Reflection;

namespace Spartane.Web.Areas.WebApiConsumer.ResponseHelpers
{
    public enum ContentType
    {
        [MediaType(Value = "application/json")]
        Json,
        [MediaType(Value = "application/x-www-form-urlencoded")]
        FormData
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MediaTypeAttribute : Attribute
    {
        public MediaTypeAttribute()
        {
            Value = "text/plain";
        }

        public string Value { get; set; }
    }

    public static class ContentTypeExtensions
    {
        private static object GetMediaTypeAttribute(ContentType contentType)
        {
            var type = contentType.GetType();
            MemberInfo[] info = type.GetMember(contentType.ToString());
            if ((info.Length > 0))
            {
                object[] attrs = info[0].GetCustomAttributes(typeof(MediaTypeAttribute), false);
                if ((attrs.Length > 0))
                {
                    return attrs[0];
                }
            }
            return null;
        }

        public static string GetMediaType(this ContentType contentType)
        {
            var metadata = GetMediaTypeAttribute(contentType);
            return (metadata != null) ? ((MediaTypeAttribute)metadata).Value : contentType.ToString();
        }
    }
}

