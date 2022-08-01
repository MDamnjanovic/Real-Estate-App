using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Realty.Entities;
using Realty.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Realty.UI.MVC.Controllers
{
    public class RealtyController : BaseMVCController
    {
        public RealtyController(HttpClient httpClient, ILogger<HttpClient> logger, IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = config;
        }
        public async Task<ActionResult> Index()
        {
            CreateRealtyViewModel model = new CreateRealtyViewModel();

            model.ResAreas = await GetAllAreasInDropDownList();
            model.Cities = await GetAllCitiesInDropDownList();
            return View("CreateRealty", model);
        }
        public async Task<string> GetRealtyInfo (int id)
        {
            string jsonString = await GetRealtyInfoAPI(id);
            return jsonString;
        }


        [HttpGet]
        public async Task<SelectList> GetAllCitiesInDropDownList()
        {
            List<CityEntities> cities = (List<CityEntities>)await GetAllCities();
            Dictionary<int, string> dictionaryCity = cities.ToDictionary(x => x.Id, x => x.CityName);
            SelectList selectListCity = new SelectList(dictionaryCity, "Key", "Value");
            return selectListCity;
        }
        [HttpGet]
        public async Task<SelectList> GetAllAreasInDropDownList()
        {
            List<ResidentialAreaEntities> areas = (List<ResidentialAreaEntities>)await GetAllResidentialAreas();
            Dictionary<int, string> dictionaryArea = areas.ToDictionary(x => x.Id, x => x.ResidentialAreaName);
            SelectList selectListAreas = new SelectList(dictionaryArea, "Key", "Value");
            return selectListAreas;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllResidentialAreasFromCity2(int cityId)
        {
            string jsonString = await GetAllResidentialAreasFromCityAPI(cityId);
            List<ResidentialAreaEntities> areas = JsonConvert.DeserializeObject<List<ResidentialAreaEntities>>(jsonString);

            var area = areas.Select(x => new
            {
                Id = x.Id,
                ResidentialAreaName = x.ResidentialAreaName
            }).ToList();
            var a = Json(area);
            return Json(area);

        }



        [HttpGet]
        public async Task<IEnumerable<CityEntities>> GetAllCities()
        {
            string jsonString = await GetAllCitiesAPI();
            IEnumerable<CityEntities> cities = JsonConvert.DeserializeObject<IEnumerable<CityEntities>>(jsonString);

            return cities;

        }
        [HttpGet]
        public async Task<IEnumerable<MunicipalityEntities>> GetAllMunicipalities()
        {
            string jsonString = await GetAllMunicipalitiesAPI();
            IEnumerable<MunicipalityEntities> municipalities = JsonConvert.DeserializeObject<IEnumerable<MunicipalityEntities>>(jsonString);

            return municipalities;

        }
        [HttpGet]
        public async Task<List<ResidentialAreaEntities>> GetAllResidentialAreas()
        {
            string jsonString = await GetAllResidentialAreasAPI();
            List<ResidentialAreaEntities> areas = JsonConvert.DeserializeObject<List<ResidentialAreaEntities>>(jsonString);

            return areas;

        }
        public void DeleteItemFromList(string itemValue, string[] imageNamesList)
        {
            foreach(string imageItems in imageNamesList)
            {
                if (itemValue.Equals(imageItems))
                {
                    imageNamesList.ToList().Remove(itemValue);
                }
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> EditAddressRealtyClient(EditRealtyViewModel m)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                RealtyEntities realtyEntities = await EditRealty(m.Realty.Id, m.Realty.SquareMeters, m.Realty.Price, m.Realty.ObjectType, m.Realty.SaleOrRent);
                RealtyAddressEntities addressEntities = await EditRealtyAddress(m.RealtyAddress.Id, m.RealtyAddress.AddressName, m.RealtyAddress.AddressNumber);
                AgentClientEntities clientEntities = await EditAgentClient(m.AgentClient.Id, m.AgentClient.FirstName, m.AgentClient.LastName, m.AgentClient.EmailAddress, m.AgentClient.ContactNumber);
                if(m.Images != null)
                {
                    string imageFilePath = _configuration.GetSection("ImageFilePath").GetSection("FilePath").Value;
                    string filePathWithName = Path.Combine(imageFilePath, m.Realty.Id.ToString());
                    string filePathWithNameOriginals = Path.Combine(imageFilePath, "original" + m.Realty.Id.ToString());
                    await UploadFile(m.Images, filePathWithName, filePathWithNameOriginals);
                }

                m.ImageNamesList = m.ImageNames;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult DeleteImageFile(string fileName)
        {
            string imageFilePath = _configuration.GetSection("ImageFilePath").GetSection("FilePath").Value;
            var realtyIdPath = fileName.Remove(0, 16);
            string filePathWithName = Path.Combine(imageFilePath, realtyIdPath);
            FileInfo file = new FileInfo(filePathWithName);
            if (file.Exists)
            {
                file.Delete();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPost]
        public async Task<ActionResult> CreateRealtyAndAddress(CreateRealtyViewModel m)
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            else
            {
                string imageFilePath = _configuration.GetSection("ImageFilePath").GetSection("FilePath").Value;


                RealtyAddressEntities realtyAddressEntities = await CreateRealtyAddress(Convert.ToInt32(m.ResAreasSelected), m.RealtyAddress.AddressName, m.RealtyAddress.AddressNumber);
                RealtyEntities realtyEntities = await CreateRealty(realtyAddressEntities.Id, m.Realty.SquareMeters, m.Realty.Price, m.Realty.ObjectType, m.Realty.SaleOrRent, imageFilePath);
                string filePathWithName = ConfiguringFilePath(realtyEntities.Id);
                string filePathWithNameOriginals = ConfiguringFilePathOriginal(realtyEntities.Id);
                await UploadFile(m.Images, filePathWithName, filePathWithNameOriginals);

                return RedirectToAction("Index", "Home");
            }
        }
        public string ConfiguringFilePath(int realtyId)
        {
            string imageFilePath = _configuration.GetSection("ImageFilePath").GetSection("FilePath").Value;

            string filePathWithName = Path.Combine(imageFilePath, realtyId.ToString());
            DirectoryInfo directory = Directory.CreateDirectory(filePathWithName);
            return filePathWithName;
        }
        public string ConfiguringFilePathOriginal(int realtyId)
        {
            string imageFilePath = _configuration.GetSection("ImageFilePath").GetSection("FilePath").Value;

            string filePathWithNameOriginals = Path.Combine(imageFilePath, "original" + realtyId.ToString());
            DirectoryInfo directory = Directory.CreateDirectory(filePathWithNameOriginals);
            return filePathWithNameOriginals;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> FormFiles, string filePath, string filePathOriginal)
        {
            long size = FormFiles.Sum(f => f.Length);

            foreach (var formFile in FormFiles)
            {
                if (formFile.Length > 0)
                {
                    string filePathCombined = Path.Combine(filePath, formFile.FileName);
                    string filePathCombinedOriginalImage = Path.Combine(filePathOriginal, formFile.FileName);
                    using (FileStream fs = new FileStream(filePathCombined, FileMode.Create, FileAccess.Write))
                    {
                        var image = Image.FromStream(formFile.OpenReadStream());
                        var resized = new Bitmap(image, new Size(256, 256));
                        using var imageStream = new MemoryStream();
                        resized.Save(imageStream, ImageFormat.Jpeg);
                        var imageBytes = imageStream.ToArray();
                        fs.Write(imageBytes, 0, imageBytes.Length);
                    }
                    using (FileStream fs = new FileStream(filePathCombinedOriginalImage, FileMode.Create, FileAccess.Write))
                    {

                        await formFile.CopyToAsync(fs);
                    }
                }
            }
            return Ok();
        }
        [HttpPost]
        public async Task<RealtyEntities> CreateRealty(int addressId, short sqMeters, decimal price, string objectType, string saleOrRent, string filePathWithName)
        {
                string jsonString = await GetUserAPI(Convert.ToInt32(TempData["userId"]));
                TempData.Keep("userId");
                AgentClientEntities agentClient = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);
                
                string jsonString2 = await CreateRealtyAPI(addressId, agentClient.Id, sqMeters, price, objectType, saleOrRent, filePathWithName);
                RealtyEntities realty = JsonConvert.DeserializeObject<RealtyEntities>(jsonString2);

                return realty;

        }
        [HttpPost]
        public async Task<RealtyEntities> EditRealty(int realtyId, short sqMeters, decimal price, string objectType, string saleOrRent)
        {

            string jsonString = await EditRealtyAPI(realtyId, sqMeters, price, objectType, saleOrRent);
            RealtyEntities realty = JsonConvert.DeserializeObject<RealtyEntities>(jsonString);

            return realty;

        }
        [HttpPost]
        public async Task<RealtyAddressEntities> EditRealtyAddress(int realtyAddressId, string addressName, string addressNumber)
        {

            string jsonString = await EditRealtyAddressAPI(realtyAddressId, addressName, addressNumber);
            RealtyAddressEntities realtyAddress = JsonConvert.DeserializeObject<RealtyAddressEntities>(jsonString);

            return realtyAddress;

        }
        [HttpPost]
        public async Task<AgentClientEntities> EditAgentClient(int id, string firstName, string lastName, string emailAddress, string contactNumber)
        {

            string jsonString = await EditAgentClientAPI(id, firstName, lastName, emailAddress, contactNumber);
            AgentClientEntities client = JsonConvert.DeserializeObject<AgentClientEntities>(jsonString);

            return client;

        }
        [HttpGet]
        public async Task<string> GetNumberOfRealties()
        {

            string jsonString = await GetNumberOfRealtiesAPI();
            string numberOfRealties = JsonConvert.DeserializeObject<string>(jsonString);

            return numberOfRealties;

        }
        [HttpPost]
        public async Task<RealtyAddressEntities> CreateRealtyAddress(int resAreaId, string addressName, string addressNumber)
        {

            string jsonString = await CreateAddressAPI(resAreaId, addressName, addressNumber);
            RealtyAddressEntities realtyAddress = JsonConvert.DeserializeObject<RealtyAddressEntities>(jsonString);

            return realtyAddress;

        }
        
        

    }
}
