using DataAccess.Models;

namespace DataAccess.Interface
{
    public interface IRecipieData
    {
        Task<Guid> AddRecipe(Recipie recipie);
        Task<int> EditRecipe(Recipie recipie);
        Task DeleteRecipe(Guid id);

        Task<List<Recipie>> GetAllRecipes();


    }
}
