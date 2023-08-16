using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestRESTAPI.Data;

namespace TestRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db; 



    }
}
