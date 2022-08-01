using Microsoft.AspNetCore.Http;
using Realty.Entities;
using System.Collections.Generic;

namespace Realty.UI.MVC.Models
{
    public class EditRealtyViewModel
    {
        public RealtyAddressEntities RealtyAddress { get; set; }
        public RealtyEntities Realty { get; set; }
        public string[] ImageNames { get; set; }
        public string[] ImageNamesList { get; set; }
        public AgentClientEntities AgentClient { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
