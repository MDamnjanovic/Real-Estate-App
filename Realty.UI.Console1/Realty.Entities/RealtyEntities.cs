using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Realty.Entities
{
    public class RealtyEntities
    {
        public RealtyEntities(RealtyEntities r)
        {
            Id = r.Id;
            AgentClient = r.AgentClient;
            RealtyAddress = r.RealtyAddress;
            SquareMeters = r.SquareMeters;
            Price = r.Price;
            ObjectType = r.ObjectType;
            SaleOrRent = r.SaleOrRent;
            PublishDate = r.PublishDate;
            ImageFilePath = r.ImageFilePath;
            Deleted = r.Deleted;
            Promoted = r.Promoted;
        }
        public RealtyEntities() 
        {
            AgentClient = new AgentClientEntities();
            RealtyAddress = new RealtyAddressEntities();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("AgentClientId")]
        public int AgentClientId { get; set; }
        public virtual AgentClientEntities AgentClient { get; set; }
        [ForeignKey("RealtyAddressId")]
        public int RealtyAddressId { get; set; }
        public virtual RealtyAddressEntities RealtyAddress { get; set; }
        [DisplayName("Square meters")]
        public short SquareMeters { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Object Type")]
        public string ObjectType { get; set; }
        [DisplayName("Sale or Rent")]
        public string SaleOrRent { get; set; }
        [DisplayName("Publish Date")]
        public DateTime? PublishDate { get; set; }
        [DisplayName("Images")]
        public string ImageFilePath { get; set; }       
        public bool? Deleted { get; set; }
        public bool? Promoted { get; set; }  
        public override string ToString()
        {
            return $"Address name: {RealtyAddress.AddressName}, Square meters: {SquareMeters}, Price : {Price}, Object Type: {ObjectType}, Sale or Rent: {SaleOrRent}";
        }
        [NotMapped]
        public string Characteristics { get
            {
                return $"Address name: {RealtyAddress.AddressName}, Square meters: {SquareMeters}, Price : {Price}, Object Type: {ObjectType}, Sale or Rent: {SaleOrRent}";
            }
        }
        [NotMapped]
        public string Location { get; set; }

    }
}

