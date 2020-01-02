using Newtonsoft.Json;
using ProxyApi.Dtos;
using System.Collections.Generic;

namespace ProxyApi.Messages
{
    public class GetOrganizationResponse
    {
        [JsonProperty("listOfCompanies")]
        public List<Company> ListOfCompanies { get; set; }
    }
}