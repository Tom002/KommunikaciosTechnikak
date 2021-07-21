namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductInventoryDtoFilterInput
    {
        public List<ProductInventoryDtoFilterInput> And { get; set; }
        public List<ProductInventoryDtoFilterInput> Or { get; set; }
        public ComparableInt32OperationFilterInput ProductId { get; set; }
        public ComparableInt16OperationFilterInput LocationId { get; set; }
        public StringOperationFilterInput Shelf { get; set; }
        public ComparableByteOperationFilterInput Bin { get; set; }
        public ComparableInt16OperationFilterInput Quantity { get; set; }
        public ComparableGuidOperationFilterInput Rowguid { get; set; }
        public ComparableDateTimeOperationFilterInput ModifiedDate { get; set; }
        public ProductDtoFilterInput Product { get; set; }
        public LocationDtoFilterInput Location { get; set; }
    }
}