using System.ComponentModel.DataAnnotations;

namespace TestRESTAPI.Models
{
    public class dtoOrders
    {
        public int orderId {get; set;}

        [Required]
        public DateTime OrderDate { get; set; }

        [MaxLength(100)]
        public string OrederName { get; set;  }

        public ICollection<dtoOrdersItems> items { get; set; } = new List<dtoOrdersItems>();
    }

    public class dtoOrdersItems
    {
        [Required]
        public int itemId { get; set;}
        public string? itemName { get; set; }

        [Required]
        public decimal price { get; set; }
        
        public int quantity { get; set; }
    }

}
