using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Product", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_Product_Name", IsUnique = true)]
    [Index(nameof(ProductNumber), Name = "AK_Product_ProductNumber", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_Product_rowguid", IsUnique = true)]
    public partial class Product
    {
        public Product()
        {
            BillOfMaterialComponents = new HashSet<BillOfMaterial>();
            BillOfMaterialProductAssemblies = new HashSet<BillOfMaterial>();
            ProductCostHistories = new HashSet<ProductCostHistory>();
            ProductInventories = new HashSet<ProductInventory>();
            ProductListPriceHistories = new HashSet<ProductListPriceHistory>();
            ProductProductPhotos = new HashSet<ProductProductPhoto>();
            ProductReviews = new HashSet<ProductReview>();
            ProductVendors = new HashSet<ProductVendor>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
            TransactionHistories = new HashSet<TransactionHistory>();
            WorkOrders = new HashSet<WorkOrder>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }
        [Required]
        public bool? MakeFlag { get; set; }
        [Required]
        public bool? FinishedGoodsFlag { get; set; }
        [StringLength(15)]
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
        [StringLength(5)]
        public string Size { get; set; }
        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }
        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        [StringLength(2)]
        public string ProductLine { get; set; }
        [StringLength(2)]
        public string Class { get; set; }
        [StringLength(2)]
        public string Style { get; set; }
        [Column("ProductSubcategoryID")]
        public int? ProductSubcategoryId { get; set; }
        [Column("ProductModelID")]
        public int? ProductModelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SellStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SellEndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("Products")]
        public virtual ProductModel ProductModel { get; set; }
        [ForeignKey(nameof(ProductSubcategoryId))]
        [InverseProperty("Products")]
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        [ForeignKey(nameof(SizeUnitMeasureCode))]
        [InverseProperty(nameof(UnitMeasure.ProductSizeUnitMeasureCodeNavigations))]
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        [ForeignKey(nameof(WeightUnitMeasureCode))]
        [InverseProperty(nameof(UnitMeasure.ProductWeightUnitMeasureCodeNavigations))]
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
        [InverseProperty(nameof(BillOfMaterial.Component))]
        public virtual ICollection<BillOfMaterial> BillOfMaterialComponents { get; set; }
        [InverseProperty(nameof(BillOfMaterial.ProductAssembly))]
        public virtual ICollection<BillOfMaterial> BillOfMaterialProductAssemblies { get; set; }
        [InverseProperty(nameof(ProductCostHistory.Product))]
        public virtual ICollection<ProductCostHistory> ProductCostHistories { get; set; }
        [InverseProperty(nameof(ProductInventory.Product))]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        [InverseProperty(nameof(ProductListPriceHistory.Product))]
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        [InverseProperty(nameof(ProductProductPhoto.Product))]
        public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; }
        [InverseProperty(nameof(ProductReview.Product))]
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        [InverseProperty(nameof(ProductVendor.Product))]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        [InverseProperty(nameof(PurchaseOrderDetail.Product))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        [InverseProperty(nameof(ShoppingCartItem.Product))]
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        [InverseProperty(nameof(SpecialOfferProduct.Product))]
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        [InverseProperty(nameof(TransactionHistory.Product))]
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
        [InverseProperty(nameof(WorkOrder.Product))]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
