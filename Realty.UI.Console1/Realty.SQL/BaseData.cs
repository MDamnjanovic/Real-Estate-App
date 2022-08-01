using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Realty.Data
{
    public abstract class BaseData
    {
        public static string connString = "Server=DESKTOP-7HU06SQ; Database=RealtyDb; Integrated Security=True;";
        //protected access modifier

        protected void CheckOpenConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        protected void AddValueToParameter(SqlCommand command, string parameter, object value)
        {
            command.Parameters.AddWithValue(parameter, value);
        }
        protected void AddValueToNullableParameter(SqlCommand command, string parameter, object value)
        {
            if(value == null) 
            {
                command.Parameters.AddWithValue(parameter, DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(parameter, value);
            }
            
        }

        protected void CloseConnection (SqlConnection connection, SqlCommand command, SqlDataReader dataReader = null)
        {
            if (dataReader != null)
            {
                dataReader.Close();
                command.Dispose();
            }
            
            connection.Close();
        }
    }

    public static class ExtensionMethods
    {

        public static T GetColumnValue<T>(this SqlDataReader reader, string columnName) 
        {
            
            var type = typeof(T);
            if(type == typeof(int))
            {
                return GetColumnInt<T>(reader, columnName);

            }
            else if (type == typeof(decimal))
            {
                return GetColumnDecimal<T>(reader, columnName);
            }
            else if (type == typeof(double))
            {
                return GetColumnDouble<T>(reader, columnName);
            }
             else if (type == typeof(string))
            {
                return GetColumnString<T>(reader, columnName);
            }
            else if (type == typeof(short))
            {
                return GetColumnShort<T>(reader, columnName);
            }
            else
            {
                return default;
            }
            
        }

        private static T GetColumnInt<T>(SqlDataReader reader, string columnName)
        {
            bool parsable = Int32.TryParse(reader.GetValue(reader.GetOrdinal(columnName)).ToString(), out int result);
            if (parsable)
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
            {
                return default;
            }
        }
        private static T GetColumnShort<T>(SqlDataReader reader, string columnName)
        {
            bool parsable = short.TryParse(reader.GetValue(reader.GetOrdinal(columnName)).ToString(), out short result);
            if (parsable)
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
            {
                return default;
            }
        }
        private static T GetColumnDecimal<T>(SqlDataReader reader, string columnName)
        {
            bool parsable = decimal.TryParse(reader.GetValue(reader.GetOrdinal(columnName)).ToString(), out decimal result);
            if (parsable)
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
            {
                return default;
            }
        }
        private static T GetColumnDouble<T>(SqlDataReader reader, string columnName)
        {
            bool parsable = double.TryParse(reader.GetValue(reader.GetOrdinal(columnName)).ToString(), out double result);
            if (parsable)
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
            {
                return default;
            }
        }
        private static T GetColumnString<T>(SqlDataReader reader, string columnName)
        {
            string result = reader.GetValue(reader.GetOrdinal(columnName)).ToString();
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static string GetColumnValue(this SqlDataReader reader, string columnName)
        {
            return reader.GetValue(reader.GetOrdinal(columnName)).ToString();
        }
    }
}
