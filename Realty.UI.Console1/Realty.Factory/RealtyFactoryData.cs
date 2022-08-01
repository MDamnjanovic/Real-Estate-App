using Interfaces;
using Realty.Data.EntityFramework;
using Realty.Interfaces;
using Realty.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty.Factory
{
    public static class RealtyFactoryData
    {
        public static IRealtyData AccessData()
        {
            /*switch (ConfigurationManager.AppSettings["accessData"])
            {
                case "0": IRealtyData realtyData = new RealtyDataEF();
                        return realtyData;
                case "1":IRealtyData realtyData1 = new RealtyData();
                        return realtyData1;
                default: 
                        return null;
            }*/

            /*if (Convert.ToInt32(ConfigurationManager.AppSettings["accessData"]) == 0) 
            {
                IRealtyData realtyData = new RealtyDataEF();
                return realtyData;
            }
            else if(Convert.ToInt32(ConfigurationManager.AppSettings["accessData"]) == 1) 
            {
                IRealtyData realtyData = new RealtyData();
                return realtyData;
            }*/
            return null;
            
        }
    }
}
