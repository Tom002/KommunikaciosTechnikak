namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class LocationDtoSortInput
    {
        public SortEnumType LocationId { get; set; }
        public SortEnumType Name { get; set; }
        public SortEnumType CostRate { get; set; }
        public SortEnumType Availability { get; set; }
        public SortEnumType ModifiedDate { get; set; }
    }
}