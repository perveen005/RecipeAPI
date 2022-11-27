using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RecipieEntity
    {
        public Guid Id { get; set; }
        public string RecipieTitle { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public string RecipieTips { get; set; }
        public string NutritionFacts { get; set; }
        public Guid UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public string Image { get; set; }
    }
}
