using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Realty.Business;
using Realty.Data.EntityFramework;
using Realty.Entities;
using Realty.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SendGrid;
using System.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Realty.UI.MVC.Controllers
{
    public class HomeController : BaseMVCController
    {
        public HomeController(HttpClient httpClient, ILogger<HttpClient> logger, IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = config;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var highlightedRealties = await GetHighlightedOffers();

            HomeViewModel model = new HomeViewModel();
            HighlightedRealtiesViewModel highlightedRealtiesViewModel = new HighlightedRealtiesViewModel();
            model.highlightedRealties = highlightedRealtiesViewModel;
            model.highlightedRealties.Realties = (List<RealtyEntities>)highlightedRealties;
            List<string> imageFilePaths = GetImageFileNameForeachRealty(model.highlightedRealties.Realties);
            model.highlightedRealties.ImageFilePaths = imageFilePaths;

            //model.RealtySearch = new RealtySearchEntities();
            if (TempData.ContainsKey("userId"))
            {
                string jsonString = await GetUserAPI(Convert.ToInt32(TempData["userId"]));
                TempData.Keep("userId");
                AgentClientEntities agentClient = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);
                model.AgentClient = agentClient;
                List<RealtyEntities> realtiesFromClient = await GetRealtiesFromClient(agentClient.Id);
                model.RealtiesFromUser = realtiesFromClient;
            }

            return View(model);
        }

        public async Task<IActionResult> DisplayRealty(int realtyId)
        {
            DisplayRealtyViewModel model = new DisplayRealtyViewModel();
            
            RealtyEntities realty = await GetRealtyById(realtyId);
            model.Realty = realty;
            model.Agent = await GetAgentForRealty(realtyId);
            int agencyId = model.Agent.AgencyId ?? 0;
            if (model.Agent.AgencyId != 0)
            {
                model.Agency = await GetAgencyForAgent(agencyId);
            }
            int length = _configuration.GetSection("Root").GetSection("RootFilePath").Value.Length;
            string[] files = Directory.GetFiles(realty.ImageFilePath);
            for (int i = 0; i<files.Length; i++)
            {
                files[i] = files[i].Remove(0, length);

            }
            model.ImageNames = files;
            model.RealtyInfo = await GetRealtyInfoAPI(realtyId);
            string jsonString = await GetUserAPI(Convert.ToInt32(TempData["userId"]));
            TempData.Keep("userId");
            if (jsonString != null)
            {
                AgentClientEntities user = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);
                model.User = user;
            }
            //model.ImageNamesList = files;
            return View("../Realty/DisplayRealty", model);
        }
        public async Task<IActionResult> DisplayEditRealtyView(int realtyId)
        {
            EditRealtyViewModel model = new EditRealtyViewModel();
            RealtyEntities realty = await GetRealtyById(realtyId);
            model.Realty = realty;
            string jsonString = await GetUserAPI(Convert.ToInt32(TempData["userId"]));
            TempData.Keep("userId");
            AgentClientEntities agentClient = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);
            model.AgentClient = agentClient;
            model.RealtyAddress = await GetAddressFromRealty(realtyId);
            int length = _configuration.GetSection("Root").GetSection("RootFilePath").Value.Length;
            string[] files = Directory.GetFiles(realty.ImageFilePath);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Remove(0, length);

            }
            model.ImageNames = files;
            model.ImageNamesList = files;
            return View("../Realty/EditRealty", model);
            //relative path i lokacije odakle se poziva akcija
        }
        public async Task<RealtyAddressEntities> GetAddressFromRealty(int id)
        {
            string jsonString = await GetAddressFromRealtyAPI(id);
            RealtyAddressEntities address = JsonConvert.DeserializeObject<RealtyAddressEntities>(jsonString);

            return address;
        }

        [HttpGet]
        public async Task<List<RealtyEntities>> GetRealtiesFromClient(int id)
        {
            string jsonString = await GetRealtiesFromClientAPI(id);
            List<RealtyEntities> realtiesFromClient = JsonConvert.DeserializeObject<List<RealtyEntities>>(jsonString);

            return realtiesFromClient;

        }
        [HttpGet]
        public async Task<IEnumerable<RealtyEntities>> GetHighlightedOffers()
        {
            string jsonString = await CallOffersAPI();
            IEnumerable<RealtyEntities> highlightedRealties = JsonConvert.DeserializeObject<IEnumerable<RealtyEntities>>(jsonString);
            
            return highlightedRealties;
            
        }
        public List<string> GetImageFileNameForeachRealty (IEnumerable<RealtyEntities> realtyEntities)
        {
            //Dictionary<int, string> realtyIdAndImageFilePath = realtyEntities.ToDictionary(x => x.Id, x => x.ImageFilePath);
            List<string> imageFilePaths = new List<string>();
            foreach (RealtyEntities realty in realtyEntities)
            {
                int length = _configuration.GetSection("Root").GetSection("RootFilePath").Value.Length;
                string[] files = Directory.GetFiles(realty.ImageFilePath);
                files[0] = files[0].Remove(0, length);
                imageFilePaths.Add(files[0]);
                
            }
            return imageFilePaths;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View("../Login/Login");
        }
        [HttpPost]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,CityName,EmailAddress,ContactNumber,PassCode,TypeOfUser")] AgentClientEntities agentClient)
        {
            if (ModelState.IsValid)
            {
                var user = await CreateUserAPI(agentClient.FirstName, agentClient.LastName, agentClient.CityName, agentClient.EmailAddress, agentClient.ContactNumber, agentClient.PassCode, agentClient.TypeOfUser);
                AgentClientEntities userClient = JsonConvert.DeserializeObject<AgentClientEntities>(user);
                TempData["userId"] = userClient.Id;
                return RedirectToAction("Index", "Home");                    
            }
            else
            {
                return View();
            }
           
        }

        private Cookie CreateUserCookie (string emailAddress, string id)
        {
            Cookie userCookie = new Cookie
            {
                Name = emailAddress,
                Value = id,
                Expires = DateTime.Now.AddHours(1)
            };
            return userCookie;
           

        }
        public string GetCookie(string id)
        {
            string cookie = Request.Cookies[id];
            return cookie;
        }

        public async Task<IActionResult> SignIn([Bind("EmailAddress,PassCode")] AgentClientEntities agentClient)
        {

            if (ModelState.IsValid)
            {

                var user =  await AuthenticateUser(agentClient.EmailAddress, agentClient.PassCode);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                string id = Convert.ToString(user.Id);
                Cookie userCookie = CreateUserCookie(user.EmailAddress, id);
                Response.Cookies.Append(key: userCookie.Name, value: userCookie.Value);
                TempData["userId"] = userCookie.Value; 
                TempData["userEmail"] = userCookie.Name;

                _logger.LogInformation($"User {user.EmailAddress} logged in at {DateTime.UtcNow}.");

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public async Task<AgentClientEntities> AuthenticateUser(string email, string passcode)
        {
            string jsonString = await AuthenticateUserAPI(email, passcode);
            AgentClientEntities user = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);

            return user;
        }

        [HttpGet]
        public IActionResult GetAndRenderHighlightedOffers()
        {
            var highlightedRealties = GetHighlightedOffers();
            return PartialView("HighlightedOffers", highlightedRealties);
        }


        [HttpGet]
        public async Task<IActionResult> Search([Bind("ObjectType,SaleOrRent,SquareMetersFrom,SquareMetersTo,PriceFrom,PriceTo,Location")] RealtySearchEntities realtySearch)
        {
            HomeViewModel model = new HomeViewModel();
            model.RealtySearch = realtySearch;
            model.highlightedRealties.Realties = new List<RealtyEntities>();
            var getSearchedRealties =  await GetSearchedRealties(realtySearch.ObjectType, realtySearch.SaleOrRent, realtySearch.SquareMetersFrom
                , realtySearch.SquareMetersTo, realtySearch.PriceFrom, realtySearch.PriceTo, realtySearch.Location);            
            
            if (ModelState.IsValid)
            {
                return View("../Realty/SearchResult", getSearchedRealties);
            }
            else
            {
                return View("Index", model);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<RealtyEntities>> GetSearchedRealties(string objectType, string saleRent, ushort sqFrom, ushort sqTo, decimal priceFrom, decimal priceTo, string location)
        {
            string jsonString = await CallSearchAPI(objectType, saleRent, sqFrom, sqTo, priceFrom, priceTo, location);
            IEnumerable<RealtyEntities> searchedRealties = JsonConvert.DeserializeObject<IEnumerable<RealtyEntities>>(jsonString);

            return searchedRealties;
        }

        [HttpGet]
        public JsonResult GetAllLocations(string prefix)
        {
            RealtyBsn realty = new RealtyBsn();
            List<string> locations = (from loc in realty.GetAllLocations()
                                      where loc.StartsWith(prefix)
                                      select loc).ToList();

            return Json(locations);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
