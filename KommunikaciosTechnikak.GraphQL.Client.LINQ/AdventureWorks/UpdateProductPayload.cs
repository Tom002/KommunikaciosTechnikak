namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class UpdateProductPayload
    {
        public ProductDto Product { get; set; }
        public List<UserError> Errors { get; set; }
    }
}