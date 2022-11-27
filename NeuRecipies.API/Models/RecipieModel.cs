using DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace NeuRecipies.API.Models
{
    public class RecipieModel
    {

        
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Recipe Title not to be exceeded")]
        public string RecipieTitle { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Description not to be exceeded")]
        public string Description { get; set; }
        [Required]
        [StringLength(500)]
        public string Ingredients { get; set; }
        [Required]
        [StringLength(500)]
        public string Steps { get; set; }
        [Required]
        [StringLength(500)]
        public string RecipieTips { get; set; }
        [Required]
        [StringLength(500)]
        public string NutritionFacts { get; set; }
        
        public Guid UserId { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "CreatedBy not be exceeed")]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        [StringLength(int.MaxValue)]
        public string Image { get; set; }
       
    }
}
