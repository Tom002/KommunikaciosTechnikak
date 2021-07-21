using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("TransactionHistoryArchive", Schema = "Production")]
    [Index(nameof(ProductId), Name = "IX_TransactionHistoryArchive_ProductID")]
    [Index(nameof(ReferenceOrderId), nameof(ReferenceOrderLineId), Name = "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID")]
    public partial class TransactionHistoryArchive
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("ReferenceOrderID")]
        public int ReferenceOrderId { get; set; }
        [Column("ReferenceOrderLineID")]
        public int ReferenceOrderLineId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        [Required]
        [StringLength(1)]
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal ActualCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
    }
}
