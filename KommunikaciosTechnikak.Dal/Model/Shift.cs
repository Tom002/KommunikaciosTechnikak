using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Shift", Schema = "HumanResources")]
    [Index(nameof(Name), Name = "AK_Shift_Name", IsUnique = true)]
    [Index(nameof(StartTime), nameof(EndTime), Name = "AK_Shift_StartTime_EndTime", IsUnique = true)]
    public partial class Shift
    {
        public Shift()
        {
            EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
        }

        [Key]
        [Column("ShiftID")]
        public byte ShiftId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(EmployeeDepartmentHistory.Shift))]
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}
