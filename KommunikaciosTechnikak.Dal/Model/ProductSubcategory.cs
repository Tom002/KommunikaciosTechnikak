using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductSubcategory", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_ProductSubcategory_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ProductSubcategory_rowguid", IsUnique = true)]
    public partial class ProductSubcategory
    {
        public ProductSubcategory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("ProductSubcategoryID")]
        public int ProductSubcategoryId { get; set; }
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        [InverseProperty("ProductSubcategories")]
        public virtual ProductCategory ProductCategory { get; set; }
        [InverseProperty(nameof(Product.ProductSubcategory))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
