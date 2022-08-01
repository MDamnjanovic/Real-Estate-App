using Interfaces;
using Realty.Data;
using Realty.Entities;
using Realty.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Realty.SQL
{
    public class RealtyData : BaseData, IRealtyData
    {
        public void UpdateRealty (int id, short squareMeters, decimal price, string objectType,
        string saleOrRent, DateTime publishDate, string imageFilePath, bool deleted)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("UpdateRealty", connection);
            try
                {

                    CheckOpenConnection(connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RealtyId", id);
                    command.Parameters.AddWithValue("@SquareMeters", squareMeters);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@ObjectType", objectType);
                    command.Parameters.AddWithValue("@SaleOrRent", saleOrRent);
                    command.Parameters.AddWithValue("@PublishDate", publishDate);
                    command.Parameters.AddWithValue("@ImageFilePath", imageFilePath);
                    command.Parameters.AddWithValue("@Deleted", deleted);

                    command.ExecuteNonQuery();
                }
                catch (SqlException e) 
                {
                throw e;
                    //exception handling i logging
                }
                finally
                {
                CloseConnection(connection, command);
                }
        }

        public void InsertRealty(int adressId, int agentClientId, short squareMeters, decimal price, string objectType,
        string saleOrRent, DateTime publishDate, string imageFilePath)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("InsertRealty", connection);
            try
            {

                CheckOpenConnection(connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@RealtyAddressId", adressId);
                command.Parameters.AddWithValue("@AgentClientId", agentClientId);
                command.Parameters.AddWithValue("@SquareMeters", squareMeters);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@ObjectType", objectType);
                command.Parameters.AddWithValue("@SaleOrRent", saleOrRent);
                command.Parameters.AddWithValue("@PublishDate", publishDate);
                command.Parameters.AddWithValue("@ImageFilePath", imageFilePath);

                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection(connection, command);
            }
        }


        public List<RealtyEntities> GetAllRealtiesFromArea(int id)
        {
            List<RealtyEntities> realtiesInArea = new List<RealtyEntities>();
            SqlConnection connection = new SqlConnection(connString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            
                //execute reader i open connection uvek u try, u finally uvek zatvaranje konekcije
                SqlCommand command = new SqlCommand("GetAllRealtiesFromArea", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ResidentialAreaId", SqlDbType.Int);
                command.Parameters["@ResidentialAreaId"].Value = id;
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                RealtyEntities realty = new RealtyEntities();
                    realty.RealtyAddress.Id = dataReader.GetColumnValue<int>("RealtyAddressId");
                    realty.AgentClient.Id = dataReader.GetColumnValue<int>("AgentClientId");
                    realty.SquareMeters = dataReader.GetColumnValue<short>("SquareMeters");
                    realty.Price = dataReader.GetColumnValue<decimal>("Price");
                    realty.ObjectType = dataReader.GetColumnValue<string>("ObjectType");
                    realty.SaleOrRent = dataReader.GetColumnValue<string>("SaleOrRent");
                    realtiesInArea.Add(realty);
                }
                dataReader = null;
                command = null;

                CloseConnection(connection, command, dataReader);
                return realtiesInArea;
            }
            else
            {
                connection.Close();
                return null; 
            }

        }
        public List<RealtyEntities> GetAllRealtiesFromClient(int id)
        {
            return GetAllRealtiesFrom(id);
        }

        public List<RealtyEntities> GetAllRealtiesFromAgent(int id)
        {
            return GetAllRealtiesFrom(id);
        }
        private List<RealtyEntities> GetAllRealtiesFrom(int id)
        {
            List<RealtyEntities> realtiesFromAgent = new List<RealtyEntities>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                CheckOpenConnection(connection);

                using (SqlCommand command = new SqlCommand("GetAllRealtiesFromAgent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@AgentId", SqlDbType.Int);
                    command.Parameters["@AgentId"].Value = id;
                    using (SqlDataReader sqlDataReader = command.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            RealtyEntities realty = new RealtyEntities();

                            realty.RealtyAddress.Id = sqlDataReader.GetColumnValue<int>("RealtyAddressId");
                            realty.AgentClient.Id = sqlDataReader.GetColumnValue<int>("AgentClientId");
                            realty.SquareMeters = sqlDataReader.GetColumnValue<short>("SquareMeters");
                            realty.Price = sqlDataReader.GetColumnValue<decimal>("Price");
                            realty.ObjectType = sqlDataReader.GetColumnValue<string>("ObjectType");
                            realty.SaleOrRent = sqlDataReader.GetColumnValue<string>("SaleOrRent");
                            realtiesFromAgent.Add(realty);
                        }
                    }
                       
                    return realtiesFromAgent;
                }
            }
        }

        public IEnumerable<RealtyEntities> GetSearchedRealties(string objectType, string rentOrSale,
            ushort squareMetersFrom, ushort squareMetersTo, decimal priceFrom, decimal priceTo, string location)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RealtyEntities> GetHighlightedOffers()
        {
            throw new NotImplementedException();
        }
        public string GetCompleteLocation(int id)
        {
            throw new NotImplementedException();
        }

        public AgentClientEntities CreateUser(string firstName, string lastName, string cityName, string emailAddress, string contactNumber, string passCode, string typeOfUser)
        {
            throw new NotImplementedException();
        }

        public AgentClientEntities AuthenticateUser(string email, string passcode)
        {
            throw new NotImplementedException();
        }

        public AgentClientEntities GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityEntities> GetAllResidentialAreas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResidentialAreaEntities> GetAllCities()
        {
            throw new NotImplementedException();
        }

        List<ResidentialAreaEntities> IRealtyData.GetAllResidentialAreas()
        {
            throw new NotImplementedException();
        }

        IEnumerable<CityEntities> IRealtyData.GetAllCities()
        {
            throw new NotImplementedException();
        }

        public List<ResidentialAreaEntities> GetAllResidentialAreasFromCity(int cityId)
        {
            throw new NotImplementedException();
        }

        public RealtyAddressEntities CreateRealtyAddress(int resAreaId, string addressName, string addressNumber)
        {
            throw new NotImplementedException();
        }

        public RealtyEntities GetRealtyById(int id)
        {
            throw new NotImplementedException();
        }
        public RealtyEntities CreateRealty(RealtyAddressEntities address, AgentClientEntities agentClient, short squareMeters, decimal price, string objectType, string saleOrRent, string filePath)
        {
            throw new NotImplementedException();
        }

        public string GetNumberOfRealties()
        {
            throw new NotImplementedException();
        }

        public AgentClientEntities GetAgentForRealty(int realtyId)
        {
            throw new NotImplementedException();
        }

        public RealtyAddressEntities GetRealtyAddressById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MunicipalityEntities> GetAllMunicipalities()
        {
            throw new NotImplementedException();
        }

        public RealtyAddressEntities GetAddressFromRealty(RealtyEntities realty)
        {
            throw new NotImplementedException();
        }

        public RealtyEntities EditRealty(int realtyId, short squareMeters, decimal price, string objectType, string saleOrRent)
        {
            throw new NotImplementedException();
        }

        public RealtyAddressEntities EditRealtyAddress(int realtyAddressId, string addressName, string addressNumber)
        {
            throw new NotImplementedException();
        }

        public AgentClientEntities EditAgentClient(int id, string firstName, string lastName, string emailAddress, string contactNumber)
        {
            throw new NotImplementedException();
        }

        public string GetRealtyInfo(int id)
        {
            throw new NotImplementedException();
        }

        public AgencyEntities GetAgencyForAgent(int id)
        {
            throw new NotImplementedException();
        }
    }

}
