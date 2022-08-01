namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agency")]
    public partial class Agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agency()
        {
            AgentClients = new HashSet<AgentClient>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string AgencyName { get; set; }

        public byte? NumberOfAgents { get; set; }

        public short? NumberOfActiveRealties { get; set; }

        [StringLength(400)]
        public string AgencyDescription { get; set; }

        [StringLength(10)]
        public string ContactNumber { get; set; }

        [StringLength(30)]
        public string AddressName { get; set; }

        [StringLength(4)]
        public string AddressNumber { get; set; }

        public bool? Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentClient> AgentClients { get; set; }
    }
}
