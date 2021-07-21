using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductModelProductDescriptionCulture", Schema = "Production")]
    public partial class ProductModelProductDescriptionCulture
    {
        [Key]
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        [Key]
        [Column("ProductDescriptionID")]
        public int ProductDescriptionId { get; set; }
        [Key]
        [Column("CultureID")]
        [StringLength(6)]
        public string CultureId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CultureId))]
        [InverseProperty("ProductModelProductDescriptionCultures")]
        public virtual Culture Culture { get; set; }
        [ForeignKey(nameof(ProductDescriptionId))]
        [InverseProperty("ProductModelProductDescriptionCultures")]
        public virtual ProductDescription ProductDescription { get; set; }
        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("ProductModelProductDescriptionCultures")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
