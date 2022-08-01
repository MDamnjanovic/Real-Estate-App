using Interfaces;
using Realty.Data.EntityFramework;
using Realty.Entities;
using Realty.Factory;
using Realty.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Realty.Business
{
    public class RealtyBsn : BaseBsn
    {
        public RealtyEntities CreateRealty(int addressId, int agentClientId, short squareMeters, decimal price, string objectType, string saleOrRent, string filePath)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            RealtyAddressEntities realtyAddressEntities = realty.GetRealtyAddressById(addressId);
            AgentClientEntities agentClient = realty.GetUser(agentClientId);
            return realty.CreateRealty(realtyAddressEntities, agentClient, squareMeters, price, objectType, saleOrRent, filePath);
        }
        public RealtyEntities EditRealty(int realtyId, short squareMeters, decimal price, string objectType, string saleOrRent)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.EditRealty(realtyId, squareMeters, price, objectType, saleOrRent);
        }
        public RealtyAddressEntities EditRealtyAddress(int realtyAddressId, string addressName, string addressNumber)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.EditRealtyAddress(realtyAddressId, addressName, addressNumber);
        }
        public AgentClientEntities EditAgentClient(int id, string firstName, string lastName, string emailAddress, string contactNumber)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.EditAgentClient(id, firstName, lastName, emailAddress, contactNumber);
        }

        public RealtyEntities GetRealtyById (int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetRealtyById(id);
        }
        public string GetRealtyInfo (int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData> ();
            return realty.GetRealtyInfo(id);
        }
        public RealtyAddressEntities GetAddressFromRealty(int realtyId)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            RealtyEntities realtyEntities = realty.GetRealtyById(realtyId);
            return realty.GetAddressFromRealty(realtyEntities);
        }
        public AgentClientEntities GetAgentForRealty(int realtyId)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAgentForRealty(realtyId);
        }
        public AgencyEntities GetAgencyForAgent(int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAgencyForAgent(id);
        }
        public IEnumerable<CityEntities> GetAllCities()
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllCities();
        }
        public IEnumerable<MunicipalityEntities> GetAllMunicipalities()
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllMunicipalities();
        }
        public string GetNumberOfRealties()
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetNumberOfRealties();
        }
        public List<ResidentialAreaEntities> GetAllResidentialAreas()
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllResidentialAreas();
        }
        public List<ResidentialAreaEntities> GetAllResidentialAreasFromCity(int cityId)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllResidentialAreasFromCity(cityId);
        }

        public List<RealtyEntities> GetAllRealtiesFromClient(int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllRealtiesFromClient(id);
        }
        public AgentClientEntities AuthenticateUser(string email, string passcode)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.AuthenticateUser(email, passcode);
        }
        public AgentClientEntities GetUser(int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetUser(id);
        }


        public AgentClientEntities CreateUser(string firstName, string lastName, string cityName, string emailAddress, string contactNumber, string passCode, string typeOfUser)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.CreateUser(firstName, lastName, cityName, emailAddress, contactNumber, passCode, typeOfUser);
        }
        public List<RealtyEntities> GetAllRealtiesFromArea(int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllRealtiesFromArea(id);
        }
        public IEnumerable<RealtyEntities> GetSearchedRealties(string objectType, string rentOrSale,
            ushort squareMetersFrom, ushort squareMetersTo, decimal priceFrom, decimal priceTo, string location)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetSearchedRealties(objectType, rentOrSale, squareMetersFrom, squareMetersTo, priceFrom, priceTo, location);

        }
        public IEnumerable<RealtyEntities> GetHighlightedOffers()
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetHighlightedOffers();

        }
        public List<string> GetAllLocations()
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetAllLocations();

        }
        public string GetCompleteLocation(int id)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.GetCompleteLocation(id);
        }

        public List<RealtyEntities> GetAllRealtiesFromAgent(int id)
        {
            RealtyData realty = new RealtyData();
            return realty.GetAllRealtiesFromAgent(id);
        }

        public void UpdateRealty(int id, short squareMeters, decimal price, string objectType,
        string saleOrRent, DateTime publishDate, string imageFilePath, bool deleted)
        {
            RealtyData realty = new RealtyData();
            realty.UpdateRealty(id, squareMeters, price, objectType,
                saleOrRent, publishDate, imageFilePath, deleted);
        }
        public void InsertRealty(RealtyEntities realtyEntities)
        {
            RealtyData realty = new RealtyData();
            realty.InsertRealty(realtyEntities.RealtyAddress.Id, realtyEntities.AgentClient.Id, realtyEntities.SquareMeters, realtyEntities.Price, realtyEntities.ObjectType,
                realtyEntities.SaleOrRent, realtyEntities.PublishDate.Value, realtyEntities.ImageFilePath);
        }

    }
}
