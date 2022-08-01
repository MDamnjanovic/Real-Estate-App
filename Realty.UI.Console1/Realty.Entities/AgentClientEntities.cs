using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Realty.Entities
{
    public class AgentClientEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? AgencyId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string CityName { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Contact")]
        public string ContactNumber { get; set; }
        public string PassCode { get; set; }
        public string TypeOfUser { get; set; }
        public bool? Deleted { get; set; }
        public string ConnectionId { get; set; }
        public AgentClientEntities()
        {
        }

    }
}
