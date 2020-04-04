//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Package_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package_Master()
        {
            this.Bookings = new HashSet<Booking>();
            this.Package_Grid_Image = new HashSet<Package_Grid_Image>();
            this.Package_Review = new HashSet<Package_Review>();
            this.Package_Spots = new HashSet<Package_Spots>();
            this.Package_Tour = new HashSet<Package_Tour>();
        }
        [Key]
        public int Package_Id { get; set; }
        public string Package_Name { get; set; }
        public string Package_Tagline { get; set; }
        public string Package_Description { get; set; }
        public double Package_Price { get; set; }
        public int Package_Total_Travellers { get; set; }
        public bool Package_Status { get; set; }
        public string Package_Header_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
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