using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyApi.Configuration
{
    public class ProxyApiConfiguration
    {
        [JsonProperty("baseAddress")]
        public string BaseAddress { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(BaseAddress) && !string.IsNullOrWhiteSpace(ApiKey);
        }
    }
}