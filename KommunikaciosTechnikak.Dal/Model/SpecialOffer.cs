using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SpecialOffer", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_SpecialOffer_rowguid", IsUnique = true)]
    public partial class SpecialOffer
    {
        public SpecialOffer()
        {
            SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
        }

        [Key]
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal DiscountPct { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        public int MinQty { get; set; }
        public int? MaxQty { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(SpecialOfferProduct.SpecialOffer))]
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
    }
}
