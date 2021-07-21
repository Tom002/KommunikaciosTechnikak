using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductCategory", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_ProductCategory_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ProductCategory_rowguid", IsUnique = true)]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubcategories = new HashSet<ProductSubcategory>();
        }

        [Key]
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductSubcategory.ProductCategory))]
        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }
    }
}
