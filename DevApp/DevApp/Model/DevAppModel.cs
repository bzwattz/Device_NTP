using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DevApp.Model
{
    public partial class DevAppModel : DbContext
    {
        public DevAppModel()
            : base("name=DevAppModel")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tb_Branch> tb_Branch { get; set; }
        public virtual DbSet<tb_Department> tb_Department { get; set; }
        public virtual DbSet<tb_Destroy> tb_Destroy { get; set; }
        public virtual DbSet<tb_Dev_Status> tb_Dev_Status { get; set; }
        public virtual DbSet<tb_Device> tb_Device { get; set; }
        public virtual DbSet<tb_Service> tb_Service { get; set; }
        public virtual DbSet<tb_Service_Status> tb_Service_Status { get; set; }
        public virtual DbSet<tb_Sub_Type> tb_Sub_Type { get; set; }
        public virtual DbSet<tb_Type> tb_Type { get; set; }
        public virtual DbSet<tb_User> tb_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Branch>()
                .Property(e => e.branch_no)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_Department>()
                .Property(e => e.Dep_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_Device>()
                .Property(e => e.Dev_Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tb_Device>()
                .Property(e => e.Dep_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_Service>()
                .Property(e => e.Serv_Price)
                .HasPrecision(10, 2);
        }
    }
}
