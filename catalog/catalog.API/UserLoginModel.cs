using System.ComponentModel.DataAnnotations;

namespace catalog.API
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
