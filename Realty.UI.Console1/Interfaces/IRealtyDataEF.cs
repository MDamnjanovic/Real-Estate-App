using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Realty.Interfaces
{
    public interface IRealtyDataEF
    {
        public List<RealtyEntities> GetAllRealtiesFromArea(int id);
    }
}
