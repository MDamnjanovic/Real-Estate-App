namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Municipality")]
    public partial class Municipality
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Municipality()
        {
            ResidentialAreas = new HashSet<ResidentialArea>();
        }

        public int Id { get; set; }

        public int? CityId { get; set; }

        [Required]
        [StringLength(20)]
        public string MunicipalityName { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResidentialArea> ResidentialAreas { get; set; }
    }
}
