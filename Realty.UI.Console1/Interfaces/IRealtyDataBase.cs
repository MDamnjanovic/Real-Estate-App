using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Realty.Interfaces
{
    public interface IRealtyDataBase
    {
        public List<RealtyEntities> GetAllRealtiesFromArea(int id);
    }
}
