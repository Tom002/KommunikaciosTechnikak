using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Location", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_Location_Name", IsUnique = true)]
    public partial class Location
    {
        public Location()
        {
            ProductInventories = new HashSet<ProductInventory>();
            WorkOrderRoutings = new HashSet<WorkOrderRouting>();
        }

        [Key]
        [Column("LocationID")]
        public short LocationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal CostRate { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Availability { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductInventory.Location))]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        [InverseProperty(nameof(WorkOrderRouting.Location))]
        public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; }
    }
}
