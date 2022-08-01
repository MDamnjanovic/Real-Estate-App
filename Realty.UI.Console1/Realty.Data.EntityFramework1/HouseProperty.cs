namespace Realty.Data.EntityFramework1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HouseProperty
    {
        public int Id { get; set; }

        public int? RealtyId { get; set; }

        public byte NumberOfFloors { get; set; }

        public decimal NumberOfRooms { get; set; }

        public byte NumberOFBathrooms { get; set; }

        [StringLength(15)]
        public string FurnishingLevel { get; set; }

        [StringLength(15)]
        public string HeatingType { get; set; }

        [StringLength(15)]
        public string RealtyState { get; set; }

        public bool? HasBalcony { get; set; }

        public bool? HasGarage { get; set; }

        public bool? Deleted { get; set; }

        public virtual Realty Realty { get; set; }
    }
}
