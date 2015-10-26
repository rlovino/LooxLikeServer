using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.JSONModel
{
    public class LowercaseJsonSerializer : JsonSerializer
    {
        private JsonSerializerSettings _settings;

        public LowercaseJsonSerializer()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public string Serialize<T>(T t)
        {
            return JsonConvert.SerializeObject(t, Formatting.Indented, _settings);
        }

        public T Deserialize<T>(string str) where T : class
        {
            throw new NotImplementedException();
        }
    }
}