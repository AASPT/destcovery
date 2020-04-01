namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package_Review
    {
        [Key]
        public int Package_Review_Id { get; set; }

        public int Package_Id { get; set; }

        public int User_Id { get; set; }

        public string Package_Comment { get; set; }

        public int Package_Rating { get; set; }

        public virtual Package_Master Package_Master { get; set; }

        public virtual User_Info User_Info { get; set; }
    }
}
