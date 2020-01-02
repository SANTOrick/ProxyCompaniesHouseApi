using Newtonsoft.Json;

namespace ProxyApi.Controllers
{
    public class GetOrganizationRequest
    {
        [JsonProperty("searchTerm")]
        public string SearchTerm { get; set; }
    }
}