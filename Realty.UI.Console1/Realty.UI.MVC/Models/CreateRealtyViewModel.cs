using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Realty.Entities;
using System.Collections.Generic;

namespace Realty.UI.MVC.Models
{
    public class CreateRealtyViewModel
    {
        public RealtyEntities Realty { get; set; }
        public RealtyAddressEntities RealtyAddress { get; set; }
        public SelectList Cities { get; set; }
        public string CitiesSelected { get; set; }

        public SelectList ResAreas { get; set; }
        public string ResAreasSelected { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
