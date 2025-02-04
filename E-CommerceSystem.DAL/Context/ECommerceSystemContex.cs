using E_CommerceSystem.Entities.Common;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Context
{
    public class ECommerceSystemContex : IdentityDbContext<AppUser, AppRole, string>
    {
        public ECommerceSystemContex(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
              .HasOne(c => c.Parent)  // A category can have one parent
              .WithMany(c => c.Children)  // A category can have many children
              .HasForeignKey(c => c.ParentId)  // Foreign key is ParentId
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
     .HasOne(o => o.AppUser)  // Assuming AppUser is related to Order
     .WithMany(u => u.Orders)
     .HasForeignKey(o => o.AppUserId)
     .OnDelete(DeleteBehavior.NoAction);  // Change to NoAction or SetNull if needed

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.AppUser)  // Assuming AppUser is related to Payment
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
        .Property(o => o.TotalAmount)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
           .Property(o => o.UnitPrice)
           .HasColumnType("decimal(18,2)");

        }






        //// Role Seed Data
        //modelBuilder.Entity<AppRole>().HasData(
        //    new AppRole { Id = Admin, Name = "Admin", NormalizedName = "ADMIN" },
        //    new AppRole { Id = User, Name = "User", NormalizedName = "USER" }
        //);

        //// User Seed Data
        //var hasher = new PasswordHasher<AppUser>();

        //var user = new AppUser
        //{
        //    Id = guidAdminCreat,
        //    UserName = "Admin",
        //    NormalizedUserName = "ADMIN",
        //    Email = "admin@example.com",
        //    NormalizedEmail = "ADMIN@EXAMPLE.COM",
        //    EmailConfirmed = true,
        //    FirstName = "default",
        //    LastName = "default",
        //    BirthDate = DateTime.UtcNow,
        //    SecurityStamp = Guid.NewGuid().ToString(),
        //    //ConcurrencyStamp = Guid.NewGuid().ToString(),
        //    LockoutEnabled = true
        //};

        //user.PasswordHash = hasher.HashPassword(user, "Admin!23");

        //modelBuilder.Entity<AppUser>().HasData(user);

        //// User - Role Relationship Seed Data
        //modelBuilder.Entity<AppUserRoles>().HasData(
        //    new AppUserRoles { UserId = AdminCreat, RoleId = Admin } // Admin user is assigned the Admin role
        //);


    }

}

