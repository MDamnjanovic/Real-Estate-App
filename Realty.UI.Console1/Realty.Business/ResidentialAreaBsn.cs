using Realty.Data;
using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Realty.Business
{
    public class ResidentialAreaBsn : BaseBsn
    {
        public List<ResidentialAreaEntities> GetAllResidentialAreas()
        {
            ResidentialAreaData residentialAreaData = new ResidentialAreaData();
            return residentialAreaData.GetAllResidentialAreas();
        }

        public List<ResidentialAreaEntities> GetAllAreasFromCity(int cityId)
        {
            ResidentialAreaData residentialAreaData = new ResidentialAreaData();
            return residentialAreaData.GetAllAreasFromCity(cityId);
        }
    }
}
