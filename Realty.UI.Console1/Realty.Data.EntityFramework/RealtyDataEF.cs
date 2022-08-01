using Interfaces;
using Microsoft.EntityFrameworkCore;
using Realty.Entities;
using Realty.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Realty.Data.EntityFramework
{
    public class RealtyDataEF : IRealtyData
    {
        public AgentClientEntities GetAgentForRealty (int realtyId)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyEntities realtyEntities = dBContext.Realty.Where(r => r.Id == realtyId).FirstOrDefault();
                AgentClientEntities agent = dBContext.AgentClient.Where(a => a.Id == realtyEntities.AgentClientId).FirstOrDefault();
                return agent;
            }
        }
        public AgencyEntities GetAgencyForAgent(int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                AgencyEntities agency = dBContext.Agency.Where(a=>a.Id == id).FirstOrDefault();
                return agency;
            }
        }
        
        public RealtyAddressEntities GetAddressFromRealty(RealtyEntities realty)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyAddressEntities address = dBContext.RealtyAddress.Where(a => a.Id == realty.RealtyAddressId).FirstOrDefault();
                return address;
            }
        }

        public RealtyEntities GetRealtyById (int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            { 
                RealtyEntities realtyEntities = dBContext.Realty.Where(r=>r.Id == id).FirstOrDefault();
                return realtyEntities;
            }

        }
        public string GetRealtyInfo(int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyEntities realtyEntities = dBContext.Realty.Where(r => r.Id == id).FirstOrDefault();
                RealtyAddressEntities addressEntities = dBContext.RealtyAddress.Where(r => r.Id == realtyEntities.RealtyAddressId).FirstOrDefault();
                return $"{realtyEntities.ObjectType} for {realtyEntities.SaleOrRent}, {addressEntities.AddressName}, {realtyEntities.SquareMeters}m2, {realtyEntities.Price}€";
            }
        }
        public RealtyAddressEntities GetRealtyAddressById(int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyAddressEntities realtyAddressEntities = dBContext.RealtyAddress.Where(r => r.Id == id).FirstOrDefault();
                return realtyAddressEntities;
            }

        }
        public RealtyEntities EditRealty(int realtyId, short squareMeters, decimal price, string objectType, string saleOrRent)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyEntities realty = dBContext.Realty.Where(r=>r.Id==realtyId).FirstOrDefault();
                realty.SquareMeters = squareMeters;
                realty.Price = price;   
                realty.ObjectType = objectType;
                realty.SaleOrRent = saleOrRent;

                dBContext.Entry(realty).State = EntityState.Modified;

                dBContext.SaveChanges();
                return realty;
            }

        }
        public AgentClientEntities EditAgentClient(int id, string firstName, string lastName, string emailAddress, string contactNumber)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                AgentClientEntities client = dBContext.AgentClient.Where(r => r.Id == id).FirstOrDefault();
                client.FirstName = firstName;
                client.LastName = lastName;
                client.EmailAddress = emailAddress;
                client.ContactNumber = contactNumber;


                dBContext.Entry(client).State = EntityState.Modified;

                dBContext.SaveChanges();
                return client;
            }
        }
        public RealtyAddressEntities EditRealtyAddress(int realtyAddressId, string addressName, string addressNumber)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyAddressEntities realtyAddress = dBContext.RealtyAddress.Where(r => r.Id == realtyAddressId).FirstOrDefault();
                realtyAddress.AddressName = addressName;
                realtyAddress.AddressNumber = addressNumber;


                dBContext.Entry(realtyAddress).State = EntityState.Modified;

                dBContext.SaveChanges();
                return realtyAddress;
            }

        }
        public RealtyEntities CreateRealty(RealtyAddressEntities address, AgentClientEntities agentCLient, short squareMeters, decimal price, string objectType, string saleOrRent, string filePath)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                RealtyEntities newRealty = new RealtyEntities
                {
                    RealtyAddress = address,
                    SquareMeters = squareMeters,
                    Price = price,
                    ObjectType = objectType,
                    SaleOrRent = saleOrRent,
                    PublishDate = DateTime.Now,
                    ImageFilePath = filePath, 
                    Deleted = false,
                    Promoted = false,
                    AgentClient = agentCLient
                };
                //dBContext.Entry(newRealty.RealtyAddress).State = EntityState.Detached;
                //dBContext.Entry(newRealty.AgentClient).State = EntityState.Detached;
                dBContext.Entry(newRealty).State = EntityState.Modified;

                dBContext.Realty.Add(newRealty);
                dBContext.SaveChanges();

                return newRealty;
            }
        }

        public string GetNumberOfRealties()
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                int numberOfRealties = dBContext.Realty.Count();
                return numberOfRealties.ToString();
            }
        }
        public RealtyAddressEntities CreateRealtyAddress(int resAreaId, string addressName, string addressNumber)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {

                RealtyAddressEntities newAddress = new RealtyAddressEntities{
                    ResidentialArea = dBContext.ResidentialArea.Where(r => r.Id == resAreaId).FirstOrDefault(),
                    AddressName = addressName,
                    AddressNumber = addressNumber,
                };
                dBContext.RealtyAddress.Add(newAddress);
                dBContext.SaveChanges();

                return newAddress;
            }
        }

        public IEnumerable<CityEntities> GetAllCities()
        {
            using(RealtyDBContext dBContext = new RealtyDBContext())
            {
                IEnumerable<CityEntities> cities = dBContext.City.ToList();
                return cities;
            }
        }
        public IEnumerable<MunicipalityEntities> GetAllMunicipalities()
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                IEnumerable<MunicipalityEntities> municipalities = dBContext.Municipality.ToList();
                return municipalities;
            }
        }
        public List<ResidentialAreaEntities> GetAllResidentialAreas()
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                List<ResidentialAreaEntities> areas = dBContext.ResidentialArea.ToList();
                return areas;
            }
        }
        public List<ResidentialAreaEntities> GetAllResidentialAreasFromCity(int cityId)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                List<ResidentialAreaEntities> areas = dBContext.ResidentialArea.Include(r => r.Municipality.City).
                    Where(r => r.Municipality.City.Id == cityId).ToList();
                return areas;
            }
        }

        public List<RealtyEntities> GetAllRealtiesFromClient(int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                List<RealtyEntities> realtiesFromClient = dBContext.Realty.Where(r=>r.AgentClient.Id == id).ToList();
                return realtiesFromClient;
            }
        }

        public AgentClientEntities AuthenticateUser(string email, string passcode)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                AgentClientEntities agentClientEntities = dBContext.AgentClient.Where(c => c.EmailAddress == email && c.PassCode == passcode).FirstOrDefault();
                return agentClientEntities;
            }
        }
        public AgentClientEntities GetUser(int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                return dBContext.AgentClient.Where(c => c.Id == id).FirstOrDefault();
            }
        }


        public AgentClientEntities CreateUser(string firstName, string lastName, string cityName, string emailAddress, string contactNumber, string passCode, string typeOfUser)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                AgentClientEntities agentClientEntities = new AgentClientEntities();
                agentClientEntities.FirstName = firstName;
                agentClientEntities.LastName = lastName;    
                agentClientEntities.CityName = cityName;
                agentClientEntities.EmailAddress = emailAddress;
                agentClientEntities.ContactNumber = contactNumber;
                agentClientEntities.PassCode = passCode;
                agentClientEntities.TypeOfUser = typeOfUser;
                dBContext.AgentClient.Add(agentClientEntities);
                dBContext.SaveChanges();
                return agentClientEntities;
            }

        }

        public List<RealtyEntities> GetAllRealtiesFromArea(int id)
        {
            using (RealtyDBContext dBContext = new RealtyDBContext())
            {
                List<RealtyEntities> realties = dBContext.Realty.Include(r => r.RealtyAddress.ResidentialArea)
                    .Where(r => r.RealtyAddress.ResidentialArea.Id == id).ToList();

                return realties;

                //eager loading, explicit loading, lazy loading...
            }
        }

        public IEnumerable<RealtyEntities> GetSearchedRealties (string objectType, string rentOrSale,
            ushort squareMetersFrom, ushort squareMetersTo, decimal priceFrom, decimal priceTo, string location)
        {
            using (RealtyDBContext dbContext = new RealtyDBContext())
            {
                if (string.IsNullOrEmpty(location))
                {
                    IEnumerable<RealtyEntities> realtiesNoLocation = dbContext.Realty
                    .Where(r => r.ObjectType == objectType && r.SaleOrRent == rentOrSale &&
                    (r.SquareMeters > squareMetersFrom && r.SquareMeters < squareMetersTo) &&
                    (r.Price > priceFrom && r.Price < priceTo)
                    ).ToList();

                    return realtiesNoLocation;
                }
                IEnumerable<RealtyEntities> realties = dbContext.Realty.Include(r => r.RealtyAddress.ResidentialArea.Municipality.City)
                    .Where(r => r.ObjectType == objectType && r.SaleOrRent == rentOrSale &&
                    (r.SquareMeters > squareMetersFrom && r.SquareMeters< squareMetersTo) &&
                    (r.Price > priceFrom && r.Price < priceTo) &&
                    (r.RealtyAddress.ResidentialArea.ResidentialAreaName == location
                    || r.RealtyAddress.ResidentialArea.Municipality.MunicipalityName == location 
                    || r.RealtyAddress.ResidentialArea.Municipality.City.CityName == location)
                    ).ToList();

                return realties;
            }
        }

        public List<string> GetAllLocations()
        {
            using (RealtyDBContext dbContext = new RealtyDBContext())
            {

                List<string> locations = dbContext.ResidentialArea
                    .Select(r => r.ResidentialAreaName).ToList();
                locations.AddRange(dbContext.Municipality
                    .Select(r => r.MunicipalityName));
                locations.AddRange(dbContext.City
                    .Select(r => r.CityName));
                return locations;
            }
        }

        public string GetCompleteLocation(int id)
        {
            using (RealtyDBContext dbContext = new RealtyDBContext())
            {
                string location = dbContext.Realty
                    .Where(r => r.Id == id)
                    .Select(s => s.RealtyAddress.ResidentialArea.ResidentialAreaName).FirstOrDefault();
                return location;

            }
        }

        public IEnumerable<RealtyEntities> GetHighlightedOffers()
        {
            using (RealtyDBContext dbContext = new RealtyDBContext())
            {
                var random = new Random();
                IEnumerable<RealtyEntities> realties = dbContext.Realty.Where(r => r.Promoted == true).ToList();
                return realties;    
            }
        }
    }
}
