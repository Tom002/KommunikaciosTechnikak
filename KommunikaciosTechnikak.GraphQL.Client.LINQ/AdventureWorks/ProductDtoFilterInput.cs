namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductDtoFilterInput
    {
        public List<ProductDtoFilterInput> And { get; set; }
        public List<ProductDtoFilterInput> Or { get; set; }
        public StringOperationFilterInput Name { get; set; }
        public StringOperationFilterInput ProductNumber { get; set; }
        public BooleanOperationFilterInput MakeFlag { get; set; }
        public BooleanOperationFilterInput FinishedGoodsFlag { get; set; }
        public StringOperationFilterInput Color { get; set; }
        public ComparableInt16OperationFilterInput SafetyStockLevel { get; set; }
        public ComparableInt16OperationFilterInput ReorderPoint { get; set; }
        public ComparableDecimalOperationFilterInput StandardCost { get; set; }
        public ComparableDecimalOperationFilterInput ListPrice { get; set; }
        public StringOperationFilterInput Size { get; set; }
        public StringOperationFilterInput SizeUnitMeasureCode { get; set; }
        public StringOperationFilterInput WeightUnitMeasureCode { get; set; }
        public ComparableNullableOfDecimalOperationFilterInput Weight { get; set; }
        public ComparableInt32OperationFilterInput DaysToManufacture { get; set; }
        public StringOperationFilterInput ProductLine { get; set; }
        public StringOperationFilterInput Class { get; set; }
        public StringOperationFilterInput Style { get; set; }
        public ComparableNullableOfInt32OperationFilterInput ProductSubcategoryId { get; set; }
        public ComparableNullableOfInt32OperationFilterInput ProductModelId { get; set; }
        public ComparableDateTimeOperationFilterInput SellStartDate { get; set; }
        public ComparableNullableOfDateTimeOperationFilterInput SellEndDate { get; set; }
        public ComparableNullableOfDateTimeOperationFilterInput DiscontinuedDate { get; set; }
        public ComparableDateTimeOperationFilterInput ModifiedDate { get; set; }
    }
}