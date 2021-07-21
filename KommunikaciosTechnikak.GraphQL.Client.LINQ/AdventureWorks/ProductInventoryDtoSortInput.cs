namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductInventoryDtoSortInput
    {
        public SortEnumType ProductId { get; set; }
        public SortEnumType LocationId { get; set; }
        public SortEnumType Shelf { get; set; }
        public SortEnumType Bin { get; set; }
        public SortEnumType Quantity { get; set; }
        public SortEnumType Rowguid { get; set; }
        public SortEnumType ModifiedDate { get; set; }
        public ProductDtoSortInput Product { get; set; }
        public LocationDtoSortInput Location { get; set; }
    }
}