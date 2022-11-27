using BusinessEntities;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IRecipieService
    {
        Task<Guid> AddRecipe(Recipie recipie);
        Task<int> EditRecipe(Recipie recipie);
        Task DeleteRecipe(Guid id);

        Task<List<Recipie>> GetAllRecipes();
    }
}
