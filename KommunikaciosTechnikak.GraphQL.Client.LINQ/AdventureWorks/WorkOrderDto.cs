namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class WorkOrderDto
    {
        public int WorkOrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderQty { get; set; }
        public int StockedQty { get; set; }
        public string ScrappedQty { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DueDate { get; set; }
    }
}