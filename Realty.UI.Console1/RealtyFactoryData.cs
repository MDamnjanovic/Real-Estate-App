using Interfaces;
using Realty.Data.EntityFramework;
using Realty.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty.Factory
{
    public static class RealtyFactoryData
    {
        public static IRealtyData AccessData(int option)
        {
            if (option == 0) 
            {
                IRealtyData realtyData = new RealtyDataEF();
                return realtyData;
            }
            else 
            {
                IRealtyData realtyData = new RealtyData();
                return realtyData;
            }
            
        }
    }
}
