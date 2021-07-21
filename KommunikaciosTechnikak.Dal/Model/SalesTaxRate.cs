using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SalesTaxRate", Schema = "Sales")]
    [Index(nameof(StateProvinceId), nameof(TaxType), Name = "AK_SalesTaxRate_StateProvinceID_TaxType", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_SalesTaxRate_rowguid", IsUnique = true)]
    public partial class SalesTaxRate
    {
        [Key]
        [Column("SalesTaxRateID")]
        public int SalesTaxRateId { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        public byte TaxType { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal TaxRate { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty("SalesTaxRates")]
        public virtual StateProvince StateProvince { get; set; }
    }
}
