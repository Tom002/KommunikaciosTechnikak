using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Illustration", Schema = "Production")]
    public partial class Illustration
    {
        public Illustration()
        {
            ProductModelIllustrations = new HashSet<ProductModelIllustration>();
        }

        [Key]
        [Column("IllustrationID")]
        public int IllustrationId { get; set; }
        [Column(TypeName = "xml")]
        public string Diagram { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductModelIllustration.Illustration))]
        public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; }
    }
}
