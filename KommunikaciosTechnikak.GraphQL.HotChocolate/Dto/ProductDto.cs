using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Dto
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(25)]
        public string? ProductNumber { get; set; }
        [Required]
        public bool? MakeFlag { get; set; }
        [Required]
        public bool? FinishedGoodsFlag { get; set; }
        [StringLength(15)]
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        [StringLength(5)]
        public string? Size { get; set; }
        [StringLength(3)]
        public string? SizeUnitMeasureCode { get; set; }
        [StringLength(3)]
        public string? WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        [StringLength(2)]
        public string? ProductLine { get; set; }
        [StringLength(2)]
        public string? Class { get; set; }
        [StringLength(2)]
        public string? Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [UseFiltering]
        [UseSorting]
        public ICollection<ProductInventoryDto> ProductInventories { get; set; }
            = new List<ProductInventoryDto>();

        [UseFiltering]
        [UseSorting]
        public ICollection<WorkOrderDto> WorkOrders { get; set; }
            = new List<WorkOrderDto>();
    }
}
