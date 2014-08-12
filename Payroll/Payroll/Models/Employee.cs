namespace PayrollProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Works = new HashSet<Work>();
            WorkLocations = new HashSet<WorkLocation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        public int? SalaryGradeID { get; set; }

        [StringLength(10)]
        public string DOB { get; set; }

        public virtual SalaryGrade SalaryGrade { get; set; }

        public virtual ICollection<Work> Works { get; set; }

        public virtual ICollection<WorkLocation> WorkLocations { get; set; }
    }
}
