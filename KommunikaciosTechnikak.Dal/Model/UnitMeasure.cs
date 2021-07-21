using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("UnitMeasure", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_UnitMeasure_Name", IsUnique = true)]
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            BillOfMaterials = new HashSet<BillOfMaterial>();
            ProductSizeUnitMeasureCodeNavigations = new HashSet<Product>();
            ProductVendors = new HashSet<ProductVendor>();
            ProductWeightUnitMeasureCodeNavigations = new HashSet<Product>();
        }

        [Key]
        [StringLength(3)]
        public string UnitMeasureCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(BillOfMaterial.UnitMeasureCodeNavigation))]
        public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
        [InverseProperty(nameof(Product.SizeUnitMeasureCodeNavigation))]
        public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; set; }
        [InverseProperty(nameof(ProductVendor.UnitMeasureCodeNavigation))]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        [InverseProperty(nameof(Product.WeightUnitMeasureCodeNavigation))]
        public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; set; }
    }
}
