using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using BudgetManagement.Shared.Security;
using System;
using System.Linq;

namespace BudgetManagement.Data
{
    public class BudgetManagementDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FinanceGoal> FinanceGoals { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }
        public DbSet<BudgetAmount> BudgetAmounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        public BudgetManagementDbContext(DbContextOptions<BudgetManagementDbContext> options) : base(options)
        {

        }
        public BudgetManagementDbContext()
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
                .HasMany(u => u.Budgets)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Budget>()
                .HasMany(u => u.BudgetAmounts)
                .WithOne(u => u.Budget)
                .HasForeignKey(p => p.BudgetId)
                .OnDelete(DeleteBehavior.Restrict);

              modelBuilder.Entity<Budget>()
                .HasMany(u => u.FinanceGoals)
                .WithOne(u => u.Budget)
                .HasForeignKey(p => p.BudgetId)
                .OnDelete(DeleteBehavior.Restrict);

              modelBuilder.Entity<Budget>()
                .HasOne(u => u.BudgetCategory)
                .WithMany(u => u.Budgets)
                .HasForeignKey(p => p.BudgetCategoryId)
                .OnDelete(DeleteBehavior.Restrict);




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