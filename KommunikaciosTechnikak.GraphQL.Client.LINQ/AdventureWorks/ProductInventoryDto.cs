namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductInventoryDto
    {
        public int ProductId { get; set; }
        public string LocationId { get; set; }
        public string Shelf { get; set; }
        public string Bin { get; set; }
        public string Quantity { get; set; }
        public Guid Rowguid { get; set; }
        public string ModifiedDate { get; set; }
        public ProductDto Product { get; set; }
        public LocationDto Location { get; set; }
    }
}