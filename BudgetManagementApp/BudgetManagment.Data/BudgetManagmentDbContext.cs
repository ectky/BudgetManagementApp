using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PetShelter.Data
{
    public class PetShelterDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FinanceGoal> FinanceGoals { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }
        public DbSet<BudgetAmount> BudgetAmounts { get; set; }
        public DbSet<Budget> Budget { get; set; }
      
        public BudgetManagmentDbContext(DbContextOptions<BudgetManagmentDbContext> options) : base(options)
        {

        }
        public BudgetManagmentDbContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.Username)
                .WithOne(p => p.RoleId)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AdoptedPets)
                .WithOne(p => p.Adopter)
                .HasForeignKey(p => p.AdopterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.GivenPets)
                .WithOne(u => u.Giver)
                .HasForeignKey(p => p.GiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shelter>()
                .HasOne(a => a.Location)
                .WithOne(a => a.Shelter)
                .HasForeignKey<Location>(c => c.ShelterId);

            foreach (var role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>())
            {
                modelBuilder.Entity<Role>().HasData(new Role { Id = (int)role, Name = role.ToString() });
            }

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "admin",
                    RoleId = (int)UserRole.Admin,
                    FirstName = "Admin",
                    LastName = "User",
                    Password = PasswordHasher.HashPassword("string")
                });
        }
    }
}