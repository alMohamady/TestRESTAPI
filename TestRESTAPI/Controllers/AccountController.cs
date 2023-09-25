using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestRESTAPI.Data.Models;
using TestRESTAPI.Models;

namespace TestRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        private readonly UserManager<AppUser> _userManager;

        [HttpPost]
        public async Task<IActionResult> RegisterNewUser(dtoNewUser user) 
        {
            if(ModelState.IsValid) 
            {
                AppUser appUser = new()
                {
                    UserName = user.userName,
                    Email = user.email,
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, user.password);
                if (result.Succeeded)
                {
                    return Ok("Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }
    }
}
