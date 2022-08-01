using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Realty.Entities
{
    public class RealtySearchEntities
    {

        public RealtySearchEntities()
        {
           
        }
        [DisplayName("Square meters from")]
        public ushort SquareMetersFrom { get; set; }     
        
        [DisplayName("Square meters to")]
        public ushort SquareMetersTo { get; set; }

        [DisplayName("Price from")]
        [Required(ErrorMessage = "Minimum price required!")]
        public decimal PriceFrom { get; set; } 
        
        [DisplayName("Price to")]
        [Required(ErrorMessage = "Maximum price required!")]
        public decimal PriceTo { get; set; } 
        
        [DisplayName("Object Type")]
        public string ObjectType { get; set; }
        
        [DisplayName("Sale or Rent")]
        public string SaleOrRent { get; set; }
        public string Location { get; set; }  
    }
}
