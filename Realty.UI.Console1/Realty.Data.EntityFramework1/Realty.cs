namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Realty")]
    public partial class Realty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Realty()
        {
            AgentClients = new HashSet<AgentClient>();
            ApartmentProperties = new HashSet<ApartmentProperty>();
            HouseProperties = new HashSet<HouseProperty>();
            UserAgentChats = new HashSet<UserAgentChat>();
        }

        public int Id { get; set; }

        public int? RealtyAddressId { get; set; }

        public short SquareMeters { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(15)]
        public string ObjectType { get; set; }

        [Required]
        [StringLength(4)]
        public string SaleOrRent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublishDate { get; set; }

        [StringLength(50)]
        public string ImageFilePath { get; set; }

        public bool? Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentClient> AgentClients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApartmentProperty> ApartmentProperties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseProperty> HouseProperties { get; set; }

        public virtual RealtyAddress RealtyAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAgentChat> UserAgentChats { get; set; }
    }
}
