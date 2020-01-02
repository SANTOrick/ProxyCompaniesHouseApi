using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ProxyApi.Dtos
{
    public class Company
    {

        [JsonProperty("address_snippet")]
        public string Address { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
