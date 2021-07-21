namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public string SafetyStockLevel { get; set; }
        public string ReorderPoint { get; set; }
        public string StandardCost { get; set; }
        public string ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public string Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public string SellStartDate { get; set; }
        public string SellEndDate { get; set; }
        public string DiscontinuedDate { get; set; }
        public Guid Rowguid { get; set; }
        public string ModifiedDate { get; set; }
        public List<ProductInventoryDto> ProductInventories { get; set; }
        public List<WorkOrderDto> WorkOrders { get; set; }
    }
}