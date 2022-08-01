using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Realty.Data
{
    public class ResidentialAreaData : BaseData
    {
        public List<ResidentialAreaEntities> GetAllResidentialAreas()
        {
            List<ResidentialAreaEntities> areas = new List<ResidentialAreaEntities>();

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("GetAllAreas", connection);

            try
            {
                CheckOpenConnection(connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ResidentialAreaEntities residential = new ResidentialAreaEntities();
                        residential.Id = Int32.Parse(dataReader.GetColumnValue("Id"));
                        residential.Municipality.Id = Int32.Parse(dataReader.GetColumnValue("MunicipalityId"));
                        residential.ResidentialAreaName = dataReader.GetColumnValue("ResidentialAreaName");
                        residential.ResidentialAreaType = dataReader.GetColumnValue("ResidentialAreaType");
                        areas.Add(residential);
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

            return areas;
        }

        public List<ResidentialAreaEntities> GetAllAreasFromCity(int cityId)
        {
            List<ResidentialAreaEntities> residentialAreas = new List<ResidentialAreaEntities>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                CheckOpenConnection(connection);

                using (SqlCommand command = new SqlCommand("GetAllAreasFromCity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@CityId", SqlDbType.Int);
                    command.Parameters["@CityId"].Value = cityId;

                    using (SqlDataReader sqlDataReader = command.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ResidentialAreaEntities residentialArea = new ResidentialAreaEntities();
                            bool parsable = Int32.TryParse(sqlDataReader.GetColumnValue("Id"), out int id);
                            if (parsable)
                            {
                                residentialArea.Id = id;
                            }
                            bool parsable2 = Int32.TryParse(sqlDataReader.GetColumnValue("MunicipalityId"), out int municipalityId);
                            if (parsable2)
                            {
                                residentialArea.Municipality.Id = municipalityId;
                            }
                            residentialArea.ResidentialAreaName = Convert.ToString(sqlDataReader.GetColumnValue("ResidentialAreaName"));
                            residentialArea.ResidentialAreaType = Convert.ToString(sqlDataReader.GetColumnValue("ResidentialAreaType"));
                            residentialAreas.Add(residentialArea);
                        }
                    }

                    return residentialAreas;
                }
            }
        }
    }
}
