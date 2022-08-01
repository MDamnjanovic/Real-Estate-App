using Realty.Entities;
using Realty.SQL;
using System;
using System.Collections.Generic;

namespace Realty.Business
{
    public class CityBsn : BaseBsn
    {

        public CityEntities getCityById (int id)
        {
            CityData cityData = new CityData();
            return cityData.GetCityById(id);
        }
        public List<CityEntities> GetAllCities()
        {
            CityData cityData = new CityData();
            return cityData.GetAllCities();
        }
    }
}
