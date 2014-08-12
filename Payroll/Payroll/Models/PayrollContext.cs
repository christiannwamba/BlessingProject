namespace PayrollProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PayrollContext : DbContext
    {
        public PayrollContext()
            : base("name=PayrollContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SalaryGrade> SalaryGrades { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<WorkLocation> WorkLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DOB)
                .IsFixedLength();

            modelBuilder.Entity<SalaryGrade>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalaryGrade>()
                .Property(e => e.Grade)
                .IsUnicode(false);

            modelBuilder.Entity<WorkLocation>()
                .Property(e => e.Location)
                .IsUnicode(false);
        }
    }
}
