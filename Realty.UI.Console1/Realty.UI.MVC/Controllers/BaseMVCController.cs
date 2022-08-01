using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Realty.Entities;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Realty.UI.MVC.Controllers
{
    public abstract class BaseMVCController : Controller 
    {
        protected IConfiguration _configuration;
        protected HttpClient _httpClient;
        protected ILoggerFactory _loggerFactory;
        protected Microsoft.Extensions.Logging.ILogger _logger;
        protected HttpRequest _httpRequest;
        public async Task<string> CreateRealtyAPI(int addressId, int agentClientId, short squareMeters, decimal price, string objectType, string saleOrRent, string filePath)
        {
            string url = "https://localhost:44320/api/RealtyAPI/CreateRealty/" + $"{addressId}/{agentClientId}/{squareMeters}/{price}/{objectType}/{saleOrRent}/{filePath}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> EditRealtyAPI(int realtyId, short squareMeters, decimal price, string objectType, string saleOrRent)
        {
            string url = "https://localhost:44320/api/RealtyAPI/EditRealty/" + $"{realtyId}/{squareMeters}/{price}/{objectType}/{saleOrRent}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> EditRealtyAddressAPI(int realtyAddressId, string addressName, string addressNumber)
        {
            string url = "https://localhost:44320/api/RealtyAPI/EditRealtyAddress/" + $"{realtyAddressId}/{addressName}/{addressNumber}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> EditAgentClientAPI(int id, string firstName, string lastName, string emailAddress, string contactNumber)
        {
            string url = "https://localhost:44320/api/RealtyAPI/EditAgentClient/" + $"{id}/{firstName}/{lastName}/{emailAddress}/{contactNumber}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> CreateAddressAPI(int resAreaId, string addressName, string addressNumber)
        {
            string url = "https://localhost:44320/api/RealtyAPI/CreateRealtyAddress/" + $"{resAreaId}/{addressName}/{addressNumber}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetRealtyByIdAPI(int id)
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetRealtyById/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetRealtyInfoAPI(int id)
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetRealtyInfo/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAgentForRealtyAPI(int id)
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetAgentForRealty/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAgencyForAgentAPI(int id)
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetAgencyForAgent/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAddressFromRealtyAPI(int id)
        {
            string url = "https://localhost:44320/api/HomeAPI/GetAddressFromRealty/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAllCitiesAPI()
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetAllCities/";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAllMunicipalitiesAPI()
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetAllMunicipalities/";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetNumberOfRealtiesAPI()
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetNumberOfRealties/";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAllResidentialAreasAPI()
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetAllResidentialAreas/";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetAllResidentialAreasFromCityAPI(int cityId)
        {
            string url = "https://localhost:44320/api/RealtyAPI/GetAllResidentialAreasFromCity/" + $"{cityId}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetRealtiesFromClientAPI(int id)
        {
            string url = "https://localhost:44320/api/HomeAPI/GetRealtiesFromClient/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> CallOffersAPI()
        {
            string url = "https://localhost:44320/api/HomeAPI/GetHighlightedOffers/";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> CallSearchAPI(string objectType, string saleRent, ushort sqFrom, ushort sqTo, decimal priceFrom, decimal priceTo, string location)
        {
            string url = "https://localhost:44320/api/HomeAPI/GetSearchedRealties/" + $"{objectType}/{saleRent}/{sqFrom}/{sqTo}/{priceFrom}/{priceTo}/{location}" ;
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> CreateUserAPI(string firstName, string lastName, string cityName, string emailAddress, string contactNumber, string passCode, string typeOfUser)
        {
            string url = "https://localhost:44320/api/HomeAPI/PostAgentClient/" + $"{firstName}/{lastName}/{cityName}/{emailAddress}/{contactNumber}/{passCode}/{typeOfUser}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }

        public async Task<string> AuthenticateUserAPI(string email, string passcode)
        {
            string url = "https://localhost:44320/api/HomeAPI/AuthenticateUser/" + $"{email}/{passcode}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        public async Task<string> GetUserAPI(int id)
        {
            string url = "https://localhost:44320/api/HomeAPI/GetUser/" + $"{id}";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: url);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
        [HttpGet]
        public async Task<RealtyEntities> GetRealtyById(int id)
        {
            string jsonString = await GetRealtyByIdAPI(id);
            RealtyEntities realty = JsonConvert.DeserializeObject<RealtyEntities>(jsonString);

            return realty;

        }
        [HttpGet]
        public async Task<AgentClientEntities> GetAgentForRealty(int id)
        {
            string jsonString = await GetAgentForRealtyAPI(id);
            AgentClientEntities agent = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);

            return agent;

        }
        [HttpGet]
        public async Task<AgencyEntities> GetAgencyForAgent(int id)
        {
            string jsonString = await GetAgencyForAgentAPI(id);
            AgencyEntities agency = JsonConvert.DeserializeObject<AgencyEntities>(jsonString);

            return agency;

        }
    }
}

