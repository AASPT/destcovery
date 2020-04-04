namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Info()
        {
            Bookings = new HashSet<Bookings>();
            Package_Review = new HashSet<Package_Review>();
        }

        [Key]
        public int User_Id { get; set; }

        public string User_Image { get; set; }

        public string User_Name { get; set; }

        [Required]
        public string User_Email { get; set; }

        [Required]
        public string User_Password { get; set; }

        public string User_Address { get; set; }

        public DateTime User_Dob { get; set; }

        public string User_Aadhar { get; set; }

        public string User_Mobile { get; set; }

        public string User_Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bookings> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_Review> Package_Review { get; set; }
    }
}
