using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRESTAPI.Data;
using TestRESTAPI.Data.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;

namespace TestRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cats = await _db.Categories.ToListAsync();
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories(int id)
        {
            var cats = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (cats == null)
            {
                return NotFound($"Category Id {id} not exists ");
            }
            return Ok(cats);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(string category)
        {
            Category c = new() { Name = category };
            await _db.Categories.AddAsync(c);
            _db.SaveChanges();
            return Ok(c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if (c == null)
            {
                return NotFound($"Category Id {category.Id} not exists ");
            }
            c.Name = category.Name;
            _db.SaveChanges();
            return Ok(c);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> 
            UpdateCategoryPatch([FromBody] JsonPatchDocument<Category> category, [FromRoute] int id )
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound($"Category Id {id} not exists ");
            }
            category.ApplyTo(c);
            await _db.SaveChangesAsync();
            return Ok(c);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound($"Category Id {id} not exists ");
            }
            _db.Categories.Remove(c);
            _db.SaveChanges();
            return Ok(c);
        }

    }
}
