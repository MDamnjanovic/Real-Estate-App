using Autofac;
using Interfaces;
using Realty.Data;
using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Realty.Business
{
    public class RealtyAddressBsn : BaseBsn
    {
        public RealtyAddressEntities CreateRealtyAddress(int resAreaId, string addressName, string addressNumber)
        {
            IRealtyData realty = Container.Resolve<IRealtyData>();
            return realty.CreateRealtyAddress(resAreaId, addressName, addressNumber);
        }
        public void InsertRealtyAddress(int residentialAreaId, string addressName,
            string addressNumber, string urlLinkMap)
        {
            RealtyAddressData realtyAddress = new RealtyAddressData();
            realtyAddress.InsertRealtyAddress(residentialAreaId, addressName, addressNumber, urlLinkMap);
        }

        public int InsertRealtyAddressAndGetId(RealtyAddressEntities realtyAddressEntities)
        {
            RealtyAddressData realtyAddress = new RealtyAddressData();
            int id = realtyAddress.InsertRealtyAddressAndGetId(realtyAddressEntities.ResidentialArea.Id, realtyAddressEntities.AddressName,
                realtyAddressEntities.AddressNumber, realtyAddressEntities.UrlLinkMap);
            return id;

        }
    }
}
