namespace DestCovery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package_Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package_Tour()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int Tour_Id { get; set; }

        public int Package_Id { get; set; }

        public DateTime Tour_Start_Date { get; set; }

        public DateTime Tour_End_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Package_Master Package_Master { get; set; }
    }
}
