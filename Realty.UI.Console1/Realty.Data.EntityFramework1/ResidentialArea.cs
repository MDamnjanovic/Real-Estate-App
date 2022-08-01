namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResidentialArea")]
    public partial class ResidentialArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResidentialArea()
        {
            RealtyAddresses = new HashSet<RealtyAddress>();
        }

        public int Id { get; set; }

        public int? MunicipalityId { get; set; }

        [Required]
        [StringLength(30)]
        public string ResidentialAreaName { get; set; }

        [Required]
        [StringLength(20)]
        public string ResidentialAreaType { get; set; }

        public virtual Municipality Municipality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RealtyAddress> RealtyAddresses { get; set; }
    }
}
