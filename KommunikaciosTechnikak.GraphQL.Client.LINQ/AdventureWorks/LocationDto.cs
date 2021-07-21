namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class LocationDto
    {
        public string LocationId { get; set; }
        public string Name { get; set; }
        public string CostRate { get; set; }
        public string Availability { get; set; }
        public string ModifiedDate { get; set; }
        public List<ProductInventoryDto> ProductInventories { get; set; }
    }
}