using Microsoft.AspNetCore.Mvc;
using Realty.Business;
using Realty.Entities;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Realty.RESTserviceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealtyAPIController : ControllerBase
    {

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RealtyEntities), 200)]
        public RealtyEntities GetRealtyById(int id)
        {
            RealtyBsn realtyBsn = new RealtyBsn();
            RealtyEntities realty = realtyBsn.GetRealtyById(id);

            return realty;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public string GetRealtyInfo(int id)
        {
            RealtyBsn realtyBsn = new RealtyBsn();
            return realtyBsn.GetRealtyInfo(id);
        }
        [HttpGet("{realtyId}")]
        [ProducesResponseType(typeof(AgentClientEntities), 200)]
        public AgentClientEntities GetAgentForRealty(int realtyId)
        {
            RealtyBsn realtyBsn = new RealtyBsn();
            AgentClientEntities agent = realtyBsn.GetAgentForRealty(realtyId);

            return agent;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AgencyEntities), 200)]
        public AgencyEntities GetAgencyForAgent(int id)
        {
            RealtyBsn realtyBsn = new RealtyBsn();
            AgencyEntities agency = realtyBsn.GetAgencyForAgent(id);

            return agency;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CityEntities), 200)]
        public IEnumerable<CityEntities> GetAllCities()
        {
            RealtyBsn realty = new RealtyBsn();
            IEnumerable<CityEntities> cities = realty.GetAllCities();

            return cities;
        }
        [HttpGet]
        [ProducesResponseType(typeof(MunicipalityEntities), 200)]
        public IEnumerable<MunicipalityEntities> GetAllMunicipalities()
        {
            RealtyBsn realty = new RealtyBsn();
            IEnumerable<MunicipalityEntities> municipalities = realty.GetAllMunicipalities();

            return municipalities;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResidentialAreaEntities), 200)]
        public List<ResidentialAreaEntities> GetAllResidentialAreas()
        {
            RealtyBsn realty = new RealtyBsn();
            List<ResidentialAreaEntities> areas = realty.GetAllResidentialAreas();

            return areas;
        }

        [HttpGet("{cityId}")]
        [ProducesResponseType(typeof(ResidentialAreaEntities), 200)]
        public List<ResidentialAreaEntities> GetAllResidentialAreasFromCity(int cityId)
        {
            RealtyBsn realty = new RealtyBsn();
            List<ResidentialAreaEntities> areas = realty.GetAllResidentialAreasFromCity(cityId);
            return areas;
        }
        [HttpPost("{resAreaId}/{addressName}/{addressNumber}")]
        [ProducesResponseType(typeof(RealtyAddressEntities), 200)]
        public RealtyAddressEntities CreateRealtyAddress(int resAreaId, string addressName, string addressNumber)
        {
            RealtyAddressBsn realty = new RealtyAddressBsn();
            return realty.CreateRealtyAddress(resAreaId, addressName, addressNumber);
        }
        [HttpPost("{addressId}/{agentClientId}/{squareMeters}/{price}/{objectType}/{saleOrRent}/{*filePath}")]
        [ProducesResponseType(typeof(RealtyEntities), 200)]
        public RealtyEntities CreateRealty(int addressId,  int agentClientId, short squareMeters, decimal price, string objectType, string saleOrRent, string filePath)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.CreateRealty(addressId, agentClientId, squareMeters, price, objectType, saleOrRent, filePath);
        }
        [HttpPost("{realtyId}/{squareMeters}/{price}/{objectType}/{saleOrRent}")]
        [ProducesResponseType(typeof(RealtyEntities), 200)]
        public RealtyEntities EditRealty(int realtyId, short squareMeters, decimal price, string objectType, string saleOrRent)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.EditRealty(realtyId, squareMeters, price, objectType, saleOrRent);
        }
        [HttpPost("{realtyAddressId}/{addressName}/{addressNumber}")]
        [ProducesResponseType(typeof(RealtyAddressEntities), 200)]
        public RealtyAddressEntities EditRealtyAddress(int realtyAddressId, string addressName, string addressNumber)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.EditRealtyAddress(realtyAddressId, addressName, addressNumber);
        }
        [HttpPost("{id}/{firstName}/{lastName}/{emailAddress}/{contactNumber}")]
        [ProducesResponseType(typeof(AgentClientEntities), 200)]
        public AgentClientEntities EditAgentClient(int id, string firstName, string lastName, string emailAddress, string contactNumber)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.EditAgentClient(id, firstName, lastName, emailAddress, contactNumber);
        }

        [HttpGet]
        public string GetNumberOfRealties()
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.GetNumberOfRealties();
        }
    }
}
