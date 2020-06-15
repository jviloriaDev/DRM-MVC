using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace Spartane.Web.Areas.WebApiConsumer.ResponseHelpers
{
    public class DictionaryJsonConverter : CustomCreationConverter<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Create(Type objectType)
        {
            return new Dictionary<string, object>();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object) || base.CanConvert(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject
                || reader.TokenType == JsonToken.Null)
                return base.ReadJson(reader, objectType, existingValue, serializer);

            // if the next token is not an object
            // then fall back on standard deserializer (strings, numbers etc.)
            return serializer.Deserialize(reader);
        }

        public object GetObject(Type objType,string jsonString)
        {
            try
            {
                jsonString = jsonString.Replace("[]", "null");
                var model = JsonConvert.DeserializeObject(jsonString, objType);
                return model;
            }
            catch(Exception)
            { }
            return null;
        }
    }
}