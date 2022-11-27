using System.ComponentModel.DataAnnotations;

namespace NeuRecipies.API.Models
{
    public class UserModel
    {
        
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50, ErrorMessage = "Name not to be exceed")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Email length not to be exceed")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        [Required]

        public string Password { get; set; }

    }
}
