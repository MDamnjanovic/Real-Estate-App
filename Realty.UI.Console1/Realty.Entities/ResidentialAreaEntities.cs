using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Realty.Entities
{
    public class ResidentialAreaEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("MunicipalityId")]
        public int MunicipalityId { get; set; }
        public virtual MunicipalityEntities Municipality { get; set; }
        public string ResidentialAreaName { get; set; }
        public string ResidentialAreaType { get; set; }

        public ResidentialAreaEntities()
        {
            Municipality = new MunicipalityEntities();
        }

    }

}
