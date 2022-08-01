namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RealtyAddress")]
    public partial class RealtyAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RealtyAddress()
        {
            Realties = new HashSet<Realty>();
        }

        public int Id { get; set; }

        public int? ResidentialAreaId { get; set; }

        [StringLength(30)]
        public string AddressName { get; set; }

        [StringLength(4)]
        public string AddressNumber { get; set; }

        [StringLength(80)]
        public string UrlLinkMap { get; set; }

        public bool? Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Realty> Realties { get; set; }

        public virtual ResidentialArea ResidentialArea { get; set; }
    }
}
