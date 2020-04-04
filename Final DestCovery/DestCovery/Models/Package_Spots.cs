namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package_Spots
    {
        [Key]
        public int Spot_Id { get; set; }

        public int Package_Id { get; set; }

        public string Spot_Name { get; set; }

        public string Spot_Description { get; set; }

        public virtual Package_Master Package_Master { get; set; }
    }
}
