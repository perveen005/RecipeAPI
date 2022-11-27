using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class User
    {
       
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50,ErrorMessage ="Name not to be exceed")]
        public string Name { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Email length not to be exceed")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }

        [Required]
      
        public string Password { get; set; }

        public virtual List<Recipie> Recipies { get; set; }
        //public virtual List<Recipie> RecipiesModified { get; set; } 


    }
}
