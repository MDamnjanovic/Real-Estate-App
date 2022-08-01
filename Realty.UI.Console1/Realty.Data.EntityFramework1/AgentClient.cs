namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgentClient")]
    public partial class AgentClient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgentClient()
        {
            UserAgentChats = new HashSet<UserAgentChat>();
            UserAgentChats1 = new HashSet<UserAgentChat>();
        }

        public int Id { get; set; }

        public int? RealtyId { get; set; }

        public int? AgencyId { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string CityName { get; set; }

        [StringLength(35)]
        public string EmailAddress { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

        [StringLength(30)]
        public string Passcode { get; set; }

        [StringLength(6)]
        public string TypeOfUser { get; set; }

        public bool? Deleted { get; set; }

        public virtual Agency Agency { get; set; }

        public virtual Realty Realty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAgentChat> UserAgentChats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAgentChat> UserAgentChats1 { get; set; }
    }
}
