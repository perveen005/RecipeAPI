using System.ComponentModel.DataAnnotations;

namespace NeuRecipies.API.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Email length not to be exceed")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        [Required]

        public string Password { get; set; }
    }
}
