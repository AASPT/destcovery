namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package_Master()
        {
            Bookings = new HashSet<Bookings>();
            Package_Grid_Image = new HashSet<Package_Grid_Image>();
            Package_Review = new HashSet<Package_Review>();
            Package_Spots = new HashSet<Package_Spots>();
            Package_Tour = new HashSet<Package_Tour>();
        }

        [Key]
        public int Package_Id { get; set; }

        [Required]
        public string Package_Name { get; set; }

        public string Package_Tagline { get; set; }

        public string Package_Description { get; set; }

        public double Package_Price { get; set; }

        public int Package_Total_Travellers { get; set; }

        public bool Package_Status { get; set; }

        public string Package_Header_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bookings> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_Grid_Image> Package_Grid_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_Review> Package_Review { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_Spots> Package_Spots { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_Tour> Package_Tour { get; set; }
    }
}
