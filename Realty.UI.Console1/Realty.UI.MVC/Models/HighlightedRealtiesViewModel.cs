using Realty.Entities;
using System.Collections.Generic;

namespace Realty.UI.MVC.Models
{
    public class HighlightedRealtiesViewModel
    {
        public List<RealtyEntities> Realties { get; set; }
        public List<string> ImageFilePaths { get; set; }
    }
}
