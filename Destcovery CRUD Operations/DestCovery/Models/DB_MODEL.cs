namespace DestCovery.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_MODEL : DbContext
    {
        public DB_MODEL()
            : base("name=DB_MODEL")
        {
        }

        public virtual DbSet<Admin_Info> Admin_Info { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Package_Grid_Image> Package_Grid_Image { get; set; }
        public virtual DbSet<Package_Master> Package_Master { get; set; }
        public virtual DbSet<Package_Review> Package_Review { get; set; }
        public virtual DbSet<Package_Spots> Package_Spots { get; set; }
        public virtual DbSet<Package_Tour> Package_Tour { get; set; }
        public virtual DbSet<User_Info> User_Info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package_Master>()
                .HasMany(e => e.Package_Tour)
                .WithRequired(e => e.Package_Master)
                .WillCascadeOnDelete(false);
        }
    }
}
