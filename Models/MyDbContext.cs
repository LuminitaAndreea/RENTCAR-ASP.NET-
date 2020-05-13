using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Models
{
     class MyDbContext:DbContext
    {
        public MyDbContext():base("MyDbConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>("MyDbConnectionString"));
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Cupon> Cupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
            .HasKey(c => new { c.UserId, c.CarID });

            modelBuilder.Entity<Car>().HasKey(c => new { c.CarID });

            modelBuilder.Entity<Cupon>().HasKey(c => new { c.CouponCode });

            modelBuilder.Entity<Customer>().HasKey(c => new { c.CustomerID });

            modelBuilder.Entity<Permission>().HasKey(c => new { c.PermissionID });

            modelBuilder.Entity<Role>().HasKey(c => new { c.RoleID });

            modelBuilder.Entity<User>().HasKey(c => new { c.UserID });
        }
    }
}
