using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopCarApi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebElectra.Entities
{
   
    public class EFDbContext : IdentityDbContext<DbUser, DbRole, int, IdentityUserClaim<int>,
    DbUserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TypeCar> TypeCars { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Make>()
            //.Property(f => f.Id)
            //.ValueGeneratedOnAdd();
            //builder.ForNpgsqlUseIdentityColumns();

            //builder.Entity<Make>()
            // .Property(b => b.Id)
            //.ValueGeneratedOnAdd();

            // builder.Entity<Make>()
            //.HasKey(p => new { p.Name, p.Id });


            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
