using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductReview", Schema = "Production")]
    [Index(nameof(ProductId), nameof(ReviewerName), Name = "IX_ProductReview_ProductID_Name")]
    public partial class ProductReview
    {
        [Key]
        [Column("ProductReviewID")]
        public int ProductReviewId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ReviewerName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReviewDate { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        [StringLength(3850)]
        public string Comments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductReviews")]
        public virtual Product Product { get; set; }
    }
}
