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
    public class HomeAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(RealtyEntities), 200)]
        public IEnumerable<RealtyEntities> GetHighlightedOffers()
        {
            RealtyBsn realty = new RealtyBsn();
            IEnumerable<RealtyEntities> realties = realty.GetHighlightedOffers();
            foreach (RealtyEntities entity in realties)
            {
                entity.Location = realty.GetCompleteLocation(entity.Id);
            }
            return realties;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RealtyAddressEntities), 200)]
        public RealtyAddressEntities GetAddressFromRealty(int id)
        {
            RealtyBsn realtyBsn = new RealtyBsn();
            RealtyAddressEntities address = realtyBsn.GetAddressFromRealty(id);

            return address;
        }
        [HttpGet("{clientId}")]
        [ProducesResponseType(typeof(RealtyEntities), 200)]
        public List<RealtyEntities> GetRealtiesFromClient(int clientId)
        {
            RealtyBsn realty = new RealtyBsn();
            List<RealtyEntities> realtiesFromClient = realty.GetAllRealtiesFromClient(clientId);

            return realtiesFromClient;
        }

        [HttpGet("{objectType}/{saleRent}/{sqFrom}/{sqTo}/{priceFrom}/{priceTo}/{location?}")]
        [ProducesResponseType(typeof(List<RealtyEntities>), 200)]
        public IEnumerable<RealtyEntities> GetSearchedRealties(string objectType, string saleRent, ushort sqFrom, ushort sqTo, decimal priceFrom, decimal priceTo, string location = null)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.GetSearchedRealties(objectType, saleRent, sqFrom, sqTo, priceFrom, priceTo, location);
        }

        [HttpPost("{firstName}/{lastName}/{cityName}/{emailAddress}/{contactNumber}/{passCode}/{typeOfUser}")]
        [ProducesResponseType(typeof(AgentClientEntities), 200)]
        public AgentClientEntities PostAgentClient (string firstName, string lastName, string cityName, string emailAddress, string contactNumber, string passCode, string typeOfUser)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.CreateUser(firstName, lastName, cityName, emailAddress, contactNumber, passCode, typeOfUser);
        }
        [HttpGet("{email}/{passcode}")]
        [ProducesResponseType(typeof(AgentClientEntities), 200)]
        public AgentClientEntities AuthenticateUser(string email, string passcode)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.AuthenticateUser(email, passcode);
        }

        [HttpGet("{id}")]
        public AgentClientEntities GetUser(int id)
        {
            RealtyBsn realty = new RealtyBsn();
            return realty.GetUser(id);
        }


    }
}
