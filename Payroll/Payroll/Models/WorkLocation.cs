namespace PayrollProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkLocation")]
    public partial class WorkLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? WorkID { get; set; }

        public int? EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Work Work { get; set; }
    }
}
