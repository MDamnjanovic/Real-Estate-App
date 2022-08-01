using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Realty.Entities
{
    public class RealtyAddressEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ResidentialAreaEntities ResidentialArea { get; set; }
        [DisplayName("Address name")]
        public string AddressName { get; set; }
        [DisplayName("Address number")]
        public string AddressNumber { get; set; }
        public string UrlLinkMap { get; set; }
        public bool? Deleted { get; set; }

        public RealtyAddressEntities()
        {
            ResidentialArea = new ResidentialAreaEntities();   
        }
    }
}
