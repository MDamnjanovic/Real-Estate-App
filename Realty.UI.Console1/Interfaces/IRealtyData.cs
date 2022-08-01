using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRealtyData
    {
        public RealtyAddressEntities GetRealtyAddressById(int id);
        public RealtyAddressEntities GetAddressFromRealty(RealtyEntities realty);

        public List<RealtyEntities> GetAllRealtiesFromArea(int id);
        public IEnumerable<MunicipalityEntities> GetAllMunicipalities();
        public AgentClientEntities GetAgentForRealty(int realtyId);
        public AgencyEntities GetAgencyForAgent(int id);


        public IEnumerable<RealtyEntities> GetSearchedRealties(string objectType, string rentOrSale,
            ushort squareMetersFrom, ushort squareMetersTo, decimal priceFrom, decimal priceTo, string location);
        public List<string> GetAllLocations();
        public IEnumerable<RealtyEntities> GetHighlightedOffers();
        public string GetCompleteLocation(int id);

        public AgentClientEntities CreateUser(string firstName, string lastName, string cityName, string emailAddress, string contactNumber, string passCode, string typeOfUser);
        public AgentClientEntities AuthenticateUser(string email, string passcode);
        public AgentClientEntities GetUser(int id);
        public List<RealtyEntities> GetAllRealtiesFromClient(int id);
        public List<ResidentialAreaEntities> GetAllResidentialAreas();
        public IEnumerable<CityEntities> GetAllCities();
        public List<ResidentialAreaEntities> GetAllResidentialAreasFromCity(int cityId);
        public RealtyAddressEntities CreateRealtyAddress(int resAreaId, string addressName, string addressNumber);
        public RealtyEntities GetRealtyById(int id);
        public RealtyEntities CreateRealty(RealtyAddressEntities address, AgentClientEntities agentClient, short squareMeters, decimal price, string objectType, string saleOrRent, string filePath);
        public string GetNumberOfRealties();
        public RealtyEntities EditRealty(int realtyId, short squareMeters, decimal price, string objectType, string saleOrRent);
        public RealtyAddressEntities EditRealtyAddress(int realtyAddressId, string addressName, string addressNumber);
        public AgentClientEntities EditAgentClient(int id, string firstName, string lastName, string emailAddress, string contactNumber);

        public string GetRealtyInfo(int id);
    }

}
