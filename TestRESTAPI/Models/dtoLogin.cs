using System.ComponentModel.DataAnnotations;

namespace TestRESTAPI.Models
{
    public class dtoLogin
    {
        [Required]
        public string userName { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}
