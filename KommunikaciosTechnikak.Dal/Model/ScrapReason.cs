using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ScrapReason", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_ScrapReason_Name", IsUnique = true)]
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            WorkOrders = new HashSet<WorkOrder>();
        }

        [Key]
        [Column("ScrapReasonID")]
        public short ScrapReasonId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(WorkOrder.ScrapReason))]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
