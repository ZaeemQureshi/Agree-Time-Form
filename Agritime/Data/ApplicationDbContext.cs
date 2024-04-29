using Agritime.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agritime.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            { 
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            
            }

            modelBuilder.Entity<LeaveApplication>()
                    .HasOne(f => f.Status)
                    .WithMany()
                    .HasForeignKey(f => f.StatusId)
                    .OnDelete(DeleteBehavior.Cascade);
            
        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Department> Departments  { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<SystemCode> SystemCodes { get; set; }

        public DbSet<SystemCodeDetails> SystemCodeDetails { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveApplication> LeaveApplications { get; set; }

        public DbSet<Attendance> Attendance { get; set; }

        


    }
}
