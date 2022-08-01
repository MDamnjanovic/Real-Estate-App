using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Realty.Data
{
    public class MunicipalityData : BaseData
    {
        public List<MunicipalityEntities> GetAllResidentialAreas()
        {
            List<MunicipalityEntities> municipalities = new List<MunicipalityEntities>();

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("GetAllAreas", connection);
            //SqlDataReader dataReader;

            try
            {
                CheckOpenConnection(connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        MunicipalityEntities municipality = new MunicipalityEntities();
                        municipality.Id = Int32.Parse(dataReader.GetColumnValue("Id"));
                        municipality.City.Id = Int32.Parse(dataReader.GetColumnValue("CityId"));
                        municipality.MunicipalityName = dataReader.GetColumnValue("MunicipalityName");
                        municipalities.Add(municipality);
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

            return municipalities;
        }
    }
}
