namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package_Grid_Image
    {
        [Key]
        public int Package_GridImg_Id { get; set; }

        public int Package_Id { get; set; }

        public string Package_GridImg { get; set; }

        public virtual Package_Master Package_Master { get; set; }
    }
}
