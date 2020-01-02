using ProxyApi.Messages;
using System.Threading.Tasks;

namespace ProxyApi.DataClient
{
    public interface ICompaniesHouseApi
    {
        Task<GetOrganizationResponse> GetCompaniesApiCompanyList(string request);
    }
}