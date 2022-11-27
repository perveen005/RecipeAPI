using BusinessLogic.Interface;
using DataAccess.DataContext;
using DataAccess.Interface;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class RecipieService:IRecipieService
    {
        readonly IRecipieData recipieData;

        public RecipieService(IRecipieData recipieData, RecipieDbContext recipieDbContext)
        {
            this.recipieData = recipieData;
            this.recipieDbContext = recipieDbContext;
        }
        RecipieDbContext recipieDbContext;
        public async Task<Guid> AddRecipe(Recipie recipie)
        {
            return await this.recipieData.AddRecipe(recipie);
        }

        public async Task<int> EditRecipe(Recipie recipie)
        {
            return await recipieData.EditRecipe(recipie);
           
        }

        public async Task DeleteRecipe(Guid id)
        {
             await recipieData.DeleteRecipe(id);
        }



        public async Task<List<Recipie>> GetAllRecipes()
        {
            return await recipieData.GetAllRecipes();
        }
    }
}
