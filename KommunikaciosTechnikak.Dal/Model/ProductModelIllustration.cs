using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductModelIllustration", Schema = "Production")]
    public partial class ProductModelIllustration
    {
        [Key]
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        [Key]
        [Column("IllustrationID")]
        public int IllustrationId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IllustrationId))]
        [InverseProperty("ProductModelIllustrations")]
        public virtual Illustration Illustration { get; set; }
        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("ProductModelIllustrations")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
