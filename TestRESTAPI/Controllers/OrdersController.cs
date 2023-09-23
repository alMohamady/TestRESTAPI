using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestRESTAPI.Data;
using TestRESTAPI.Data.Models;
using TestRESTAPI.Models;

namespace TestRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = _db.Orders.ToArray();
            return Ok(orders); 
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            return Ok(order);
        }
    }
}