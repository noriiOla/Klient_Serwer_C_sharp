using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Services
{
    public class JsonTransformService
    {
        private readonly JsonSerializerSettings jsonSettings;

        public JsonTransformService()
        {
            this.jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public TResult DeserializeToObject<TResult>(string json) where TResult : class
        {
            return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<TResult>(json, this.jsonSettings) : default(TResult);
        }

        public string SerializeToString<TResult>(TResult objectToSerialize) where TResult : class
        {
            return objectToSerialize != null ? JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented, this.jsonSettings) : string.Empty;
        }
    }
}