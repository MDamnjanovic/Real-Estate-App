namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAgentChat")]
    public partial class UserAgentChat
    {
        public int Id { get; set; }

        public int? RealtyId { get; set; }

        public int? RecieverId { get; set; }

        public int? SenderId { get; set; }

        public bool? ReservationMade { get; set; }

        public string ChatHistory { get; set; }

        public virtual AgentClient AgentClient { get; set; }

        public virtual AgentClient AgentClient1 { get; set; }

        public virtual Realty Realty { get; set; }
    }
}
