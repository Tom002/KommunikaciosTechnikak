using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
    [Index(nameof(DepartmentId), Name = "IX_EmployeeDepartmentHistory_DepartmentID")]
    [Index(nameof(ShiftId), Name = "IX_EmployeeDepartmentHistory_ShiftID")]
    public partial class EmployeeDepartmentHistory
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("DepartmentID")]
        public short DepartmentId { get; set; }
        [Key]
        [Column("ShiftID")]
        public byte ShiftId { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.EmployeeDepartmentHistories))]
        public virtual Employee BusinessEntity { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("EmployeeDepartmentHistories")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(ShiftId))]
        [InverseProperty("EmployeeDepartmentHistories")]
        public virtual Shift Shift { get; set; }
    }
}
