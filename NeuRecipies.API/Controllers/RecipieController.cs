using BusinessEntities;
using BusinessLogic.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using NeuRecipies.API.Models;

namespace NeuRecipies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RecipieController : ControllerBase
    {

        readonly IRecipieService recipieService;

        public RecipieController(IRecipieService recipieService)
        {
            this.recipieService = recipieService;
        }


        [HttpPost]

        public async Task<IActionResult> AddRecipeAsync([FromBody] RecipieModel recipieModel)
        {

            
            try
            {
                  Recipie recipie =  new Recipie();
                recipie.Id = Guid.Empty;
                recipie.RecipieTitle = recipieModel.RecipieTitle;
                recipie.Description = recipieModel.Description;
                recipie.Ingredients = recipieModel.Ingredients;
                recipie.Steps = recipieModel.Steps;
                recipie.RecipieTips = recipieModel.RecipieTips;
                recipie.NutritionFacts = recipieModel.NutritionFacts;
                recipie.UserId = recipieModel.UserId;
                recipie.CreatedBy = recipieModel.CreatedBy;
                recipie.CreatedDate = recipieModel.CreatedDate;
                recipie.ModifiedBy = recipieModel.ModifiedBy;
                recipie.ModifiedDate = recipieModel.ModifiedDate;
                recipie.IsDeleted = false;
                recipie.Image = recipieModel.Image;

                var recipeId = await recipieService.AddRecipe(recipie);
                return Ok(recipeId);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPut]
        public async Task<IActionResult> EditRecipeAsync(RecipieModel recipieModel)
        {
            try
            {
                Recipie recipie = new Recipie();
                recipie.Id = recipieModel.Id;
                recipie.RecipieTitle = recipieModel.RecipieTitle;
                recipie.Description = recipieModel.Description;
                recipie.Ingredients = recipieModel.Ingredients;
                recipie.Steps = recipieModel.Steps;
                recipie.RecipieTips = recipieModel.RecipieTips;
                recipie.NutritionFacts = recipieModel.NutritionFacts;
                recipie.UserId = recipieModel.UserId;
                recipie.CreatedBy = recipieModel.CreatedBy;
                recipie.CreatedDate = recipieModel.CreatedDate;
                recipie.ModifiedBy = recipieModel.ModifiedBy;
                recipie.ModifiedDate = recipieModel.ModifiedDate;
                recipie.IsDeleted = false;
                recipie.Image = recipieModel.Image;

                int editResult = await recipieService.EditRecipe(recipie);
                if (editResult > 0)
                {
                    return Ok("Updated successfully");
                }
                else
                {
                    return BadRequest("You are not authorized to Update ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRecipeAsync(Guid id)
        {
            await recipieService.DeleteRecipe(id);
            return Ok("Deleted Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            try
            {
                //return Ok(await recipieService.GetAllRecipes());
                List<Recipie> recipies = await recipieService.GetAllRecipes();
                if(recipies.Count > 0)
                {
                    return Ok(await recipieService.GetAllRecipes());
                }
                else
                {
                    return BadRequest("No Recipe to show");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
