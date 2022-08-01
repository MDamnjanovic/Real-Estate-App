using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Realty.Data
{
    public class RealtyAddressData : BaseData
    {
        public void InsertRealtyAddress (int residentialAreaId, string addressName,
            string addressNumber, string urlLinkMap)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("InsertRealtyAddress", connection);
            try
            {
                CheckOpenConnection(connection);
                
                command.CommandType = CommandType.StoredProcedure;

                AddValueToParameter(command, "@ResidentialAreaId", residentialAreaId);
                AddValueToParameter(command, "@AddressName", addressName);
                AddValueToParameter(command, "@AddressNumber", addressNumber);
                AddValueToParameter(command, "@UrlLinkMap", urlLinkMap);

                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConnection(connection, command);
            }
        }
        public int InsertRealtyAddressAndGetId(int residentialAreaId, string addressName,
            string addressNumber, string urlLinkMap)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("InsertRealtyAddressAndReturnId", connection);
            int returnId = -1;
            try
            {
                CheckOpenConnection(connection);

                command.CommandType = CommandType.StoredProcedure;

                AddValueToParameter(command, "@ResidentialAreaId", residentialAreaId);
                AddValueToParameter(command, "@AddressName", addressName);
                AddValueToParameter(command, "@AddressNumber", addressNumber);
                AddValueToParameter(command, "@UrlLinkMap", urlLinkMap);

                SqlParameter parameterReturn = new SqlParameter();
                parameterReturn.ParameterName = "@ReturnId";
                parameterReturn.SqlDbType = SqlDbType.Int;
                parameterReturn.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameterReturn);

                command.ExecuteNonQuery();

                returnId = Convert.ToInt32(command.Parameters["@ReturnId"].Value);
                //razlika null, dbnull
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConnection(connection, command);
                
            }
            return returnId;
        }
    }
}
