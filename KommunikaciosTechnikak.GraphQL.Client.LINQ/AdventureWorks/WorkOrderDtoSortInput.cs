namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class WorkOrderDtoSortInput
    {
        public SortEnumType WorkOrderId { get; set; }
        public SortEnumType ProductId { get; set; }
        public SortEnumType OrderQty { get; set; }
        public SortEnumType StockedQty { get; set; }
        public SortEnumType ScrappedQty { get; set; }
        public SortEnumType StartDate { get; set; }
        public SortEnumType EndDate { get; set; }
        public SortEnumType DueDate { get; set; }
    }
}