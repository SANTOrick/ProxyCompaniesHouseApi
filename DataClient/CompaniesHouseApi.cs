﻿using ProxyApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyApi.Constants;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProxyApi.Configuration;

namespace ProxyApi.DataClient
{
    public class CompaniesHouseApi : ICompaniesHouseApi
    {
        public string _companiesHouseUrl = CompaniesHouseApiSettings.Urlbase;
        private readonly HttpClient _client;
        private readonly ProxyApiConfiguration _proxyApiConfiguration;


        public CompaniesHouseApi(HttpClient client, IOptions<ProxyApiConfiguration> proxyApiConfiguration)
        {

            _client = client;
            _proxyApiConfiguration = proxyApiConfiguration.Value;
        }

        public async Task<GetOrganizationResponse> GetCompaniesApiCompanyList(string request)
        {
            HttpResponseMessage responseBody = null;
            var response = new GetOrganizationResponse();
            var requestUri = $"{_companiesHouseUrl}{request}";
            responseBody = await _client.GetAsync(requestUri);
            responseBody.EnsureSuccessStatusCode();
            var raw = await responseBody.Content.ReadAsStringAsync();
            response = JsonConvert.DeserializeObject<GetOrganizationResponse>(raw);

            return response;
        } 
    }
}
