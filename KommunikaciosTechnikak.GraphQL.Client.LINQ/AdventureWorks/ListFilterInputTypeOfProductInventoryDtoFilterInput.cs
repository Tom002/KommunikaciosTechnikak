namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class ListFilterInputTypeOfProductInventoryDtoFilterInput
    {
        public ProductInventoryDtoFilterInput All { get; set; }
        public ProductInventoryDtoFilterInput None { get; set; }
        public ProductInventoryDtoFilterInput Some { get; set; }
        public bool? Any { get; set; }
    }
}