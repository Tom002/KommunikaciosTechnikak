namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class LocationDtoFilterInput
    {
        public List<LocationDtoFilterInput> And { get; set; }
        public List<LocationDtoFilterInput> Or { get; set; }
        public ComparableInt16OperationFilterInput LocationId { get; set; }
        public StringOperationFilterInput Name { get; set; }
        public ComparableDecimalOperationFilterInput CostRate { get; set; }
        public ComparableDecimalOperationFilterInput Availability { get; set; }
        public ComparableDateTimeOperationFilterInput ModifiedDate { get; set; }
        public ListFilterInputTypeOfProductInventoryDtoFilterInput ProductInventories { get; set; }
    }
}