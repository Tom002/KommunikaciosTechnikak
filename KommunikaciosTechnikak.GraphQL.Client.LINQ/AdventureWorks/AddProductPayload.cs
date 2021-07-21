namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class AddProductPayload
    {
        public ProductDto Product { get; set; }
        public List<UserError> Errors { get; set; }
    }
}