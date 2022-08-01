using Microsoft.AspNetCore.Http;
using Realty.Entities;
using System.Collections.Generic;

namespace Realty.UI.MVC.Models
{
    public class DisplayRealtyViewModel
    {
        public RealtyEntities Realty { get; set; }
        public string[] ImageNames { get; set; }
        public AgentClientEntities Agent { get; set; }
        public string RealtyInfo { get; set; }  
        public AgentClientEntities User { get; set; }
        public AgencyEntities Agency { get; set; }

    }
}
