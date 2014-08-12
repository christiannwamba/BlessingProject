namespace PayrollProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalaryGrade")]
    public partial class SalaryGrade
    {
        public SalaryGrade()
        {
            Employees = new HashSet<Employee>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalaryGradeID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        [StringLength(50)]
        public string Grade { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
