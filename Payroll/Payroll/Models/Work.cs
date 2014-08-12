namespace PayrollProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Work")]
    public partial class Work
    {
        public Work()
        {
            WorkLocations = new HashSet<WorkLocation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkId { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WorkDate { get; set; }

        public int? EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<WorkLocation> WorkLocations { get; set; }
    }
}
