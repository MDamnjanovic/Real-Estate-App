using Realty.Data;
using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Realty.SQL
{
    public class CityData : BaseData
    {


        public CityEntities GetCityById (int id)
        {
            CityEntities city = null;
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            SqlCommand command = new SqlCommand("GetCityById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CityId", SqlDbType.Int);
            command.Parameters["@CityId"].Value = id;
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                city = new CityEntities();
                city.RegionId = dataReader.GetInt32(1);
                city.CityName = dataReader.GetString(2);
                dataReader = null;
                command = null;
            }
            connection.Close();
            return city;
        
        }

        public List<CityEntities> GetAllCities()
        {
            List<CityEntities> cities = new List<CityEntities>();

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("GetAllCities", connection);
            //SqlDataReader dataReader;

            try
            {
                CheckOpenConnection(connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        CityEntities city = new CityEntities();
                        city.Id = Int32.Parse(dataReader.GetColumnValue("Id"));
                        city.RegionId = Int32.Parse(dataReader.GetColumnValue("RegionId"));
                        city.CityName = dataReader.GetColumnValue("CityName");
                        cities.Add(city);
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConnection(connection, command);
            }

            return cities;
        }

    }
}
