using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestRESTAPI.Data.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public DateTime CreatedDate { set; get; }

        public virtual ICollection<OrderItem>? ordersItems { get; set; }
    }
}
