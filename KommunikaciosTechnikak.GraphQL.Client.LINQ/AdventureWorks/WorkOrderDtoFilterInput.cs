namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class WorkOrderDtoFilterInput
    {
        public List<WorkOrderDtoFilterInput> And { get; set; }
        public List<WorkOrderDtoFilterInput> Or { get; set; }
        public ComparableInt32OperationFilterInput WorkOrderId { get; set; }
        public ComparableInt32OperationFilterInput ProductId { get; set; }
        public ComparableInt32OperationFilterInput OrderQty { get; set; }
        public ComparableInt32OperationFilterInput StockedQty { get; set; }
        public ComparableInt16OperationFilterInput ScrappedQty { get; set; }
        public ComparableDateTimeOperationFilterInput StartDate { get; set; }
        public ComparableNullableOfDateTimeOperationFilterInput EndDate { get; set; }
        public ComparableDateTimeOperationFilterInput DueDate { get; set; }
    }
}