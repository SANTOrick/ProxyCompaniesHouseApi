﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProxyApi.DataClient;
using ProxyApi.Messages;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProxyApi.Controllers
{
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly ICompaniesHouseApi _companiesHouseApi;

        public OrganizationController(ICompaniesHouseApi companiesHouseApi)
        {
            _companiesHouseApi = companiesHouseApi;
        }

        [AllowAnonymous] 
        [Route("/")]
        [HttpGet]
        public ActionResult<string> Alive()
        {
            return "Service up and running";
        }

        [AllowAnonymous]
        [Route("/search")]
        [HttpGet]
        public async Task<GetOrganizationResponse> GetOrganization([FromBody]GetOrganizationRequest request)
        {
            var response = new GetOrganizationResponse();

            try
            {
                if (string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    throw new ArgumentException($"{nameof(request)} is null.");
                }

                response = await _companiesHouseApi.GetCompaniesApiCompanyList(request.SearchTerm);

                if (response.ListOfCompanies == null)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
           catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                return response;
            }
            return response;
        }

    }
}
