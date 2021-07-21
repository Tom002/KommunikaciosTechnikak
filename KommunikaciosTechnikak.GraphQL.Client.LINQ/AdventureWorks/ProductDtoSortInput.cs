namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductDtoSortInput
    {
        public SortEnumType ProductId { get; set; }
        public SortEnumType Name { get; set; }
        public SortEnumType ProductNumber { get; set; }
        public SortEnumType MakeFlag { get; set; }
        public SortEnumType FinishedGoodsFlag { get; set; }
        public SortEnumType Color { get; set; }
        public SortEnumType SafetyStockLevel { get; set; }
        public SortEnumType ReorderPoint { get; set; }
        public SortEnumType StandardCost { get; set; }
        public SortEnumType ListPrice { get; set; }
        public SortEnumType Size { get; set; }
        public SortEnumType SizeUnitMeasureCode { get; set; }
        public SortEnumType WeightUnitMeasureCode { get; set; }
        public SortEnumType Weight { get; set; }
        public SortEnumType DaysToManufacture { get; set; }
        public SortEnumType ProductLine { get; set; }
        public SortEnumType Class { get; set; }
        public SortEnumType Style { get; set; }
        public SortEnumType ProductSubcategoryId { get; set; }
        public SortEnumType ProductModelId { get; set; }
        public SortEnumType SellStartDate { get; set; }
        public SortEnumType SellEndDate { get; set; }
        public SortEnumType DiscontinuedDate { get; set; }
        public SortEnumType Rowguid { get; set; }
        public SortEnumType ModifiedDate { get; set; }
    }
}