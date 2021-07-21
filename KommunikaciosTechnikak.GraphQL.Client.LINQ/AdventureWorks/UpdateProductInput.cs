namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public partial class UpdateProductInput
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string SafetyStockLevel { get; set; }
        public string ReorderPoint { get; set; }
        public string StandardCost { get; set; }
        public string ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public string SellStartDate { get; set; }
    }
}