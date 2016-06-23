using System;
using System.Net.Mime;
using Newtonsoft.Json;
using OpenMagic.ErrorTracker.Core.Infrastructure.Extensions;

namespace OpenMagic.ErrorTracker.Core.Infrastructure.Serialization
{
    public class Serializer : ISerializer
    {
        public object FromJson(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        public object FromJson(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public object FromJson(string json, string contentType)
        {
            return FromJson(json, new ContentType(contentType));
        }

        public object FromJson(string json, ContentType contentType)
        {
            var typeName = contentType.GetTypeParameter();
            var type = Type.GetType(typeName);

            return FromJson(json, type);
        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public string ToJson(object value, out string contentType)
        {
            contentType = GetContentType(value);
            return ToJson(value);
        }

        private static string GetContentType(object value)
        {
            var contentType = new ContentType("application/json");

            // ReSharper disable once PossibleNullReferenceException
            contentType.Parameters.Add("type", value.GetType().ToString());

            return contentType.ToString();
        }
    }
}