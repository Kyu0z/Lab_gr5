using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab_gr5.Model
{
    public partial class NVDBContext : DbContext
    {
        public NVDBContext()
            : base("name=StudentDBContext")
        {
        }

        public virtual DbSet<Phongban> Falculty { get; set; }
        public virtual DbSet<Nhanvien> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phongban>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Falculty)
                .HasForeignKey(e => e.FalcutyID)
                .WillCascadeOnDelete(false);
        }
    }
}
