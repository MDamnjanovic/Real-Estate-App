using Microsoft.AspNetCore.Mvc.Rendering;
using Realty.Entities;
using System.Collections.Generic;

namespace Realty.UI.MVC.Models
{
    public class HomeViewModel
    {

        public RealtySearchEntities RealtySearch { get; set; }
        public HighlightedRealtiesViewModel highlightedRealties { get; set; }
        public AgentClientEntities AgentClient { get; set; }
        public IEnumerable<RealtyEntities> RealtiesFromUser { get; set; }

    }
}
