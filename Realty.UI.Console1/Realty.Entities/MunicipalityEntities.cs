using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Realty.Entities
{
    public class MunicipalityEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public CityEntities City { get; set; }
        public string MunicipalityName { get; set; }
    }
}
