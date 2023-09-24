namespace TestRESTAPI.Models
{
    public class dtoOrders
    {
        public int orderId {get; set;}

        public DateTime OrderDate { get; set; }

        public ICollection<dtoOrdersItems> items { get; set; } = new List<dtoOrdersItems>();
    }

    public class dtoOrdersItems
    { 
        public int itemId { get; set;}
        public string? itemName { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }

}
