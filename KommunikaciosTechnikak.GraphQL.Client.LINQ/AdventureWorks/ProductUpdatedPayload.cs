namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ProductUpdatedPayload
    {
        public ProductDto Product { get; set; }
        public string ProductId { get; set; }
    }
}