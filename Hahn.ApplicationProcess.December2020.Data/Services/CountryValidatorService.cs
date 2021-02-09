using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Data.Services
{
    public class CountryValidatorService : ICountryValidatorService
    {
        
        private readonly IConfiguration _config;
        public CountryValidatorService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<bool> ValidateCountryByName(string name)
        {
            string baseUrl = _config.GetSection("countryValidationUrl").Value;
            var client = new RestClient(baseUrl);
            var request = new RestRequest(string.Format("name/{0}?fullText=true", name), Method.GET);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;

        }
    }
}
