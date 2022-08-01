using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Realty.Entities
{
    public class AgencyEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public int? NumberOfAgents { get; set; }
        public int? NumberOfActiveRealties { get; set; }
        public string AgencyDescription { get; set; }
        public string ContactNumber { get; set; }
        public string AddressName { get; set; }
        public string AddressNumber { get; set; }
        public bool? Deleted { get; set; }

        public AgencyEntities()
        {
        }
    }
}
