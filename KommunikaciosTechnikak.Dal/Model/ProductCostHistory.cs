﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductCostHistory", Schema = "Production")]
    public partial class ProductCostHistory
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductCostHistories")]
        public virtual Product Product { get; set; }
    }
}
