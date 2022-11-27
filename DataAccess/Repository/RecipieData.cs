using BusinessEntities;
using DataAccess.DataContext;
using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RecipieData: IRecipieData
    {
        public RecipieData(RecipieDbContext recipieDbContext)
        {
            this.recipieDbContext = recipieDbContext;
        }
        RecipieDbContext recipieDbContext;

        public  async Task<Guid> AddRecipe(Recipie recipie)
        {
           var name= recipieDbContext.Users.Where(x=>x.Id==recipie.UserId).FirstOrDefault();
            //var recipe = new Models.Recipie
            //{
            //    RecipieTitle = recipieEntity.RecipieTitle,
            //    Description = recipieEntity.Description,
            //    Ingredients = recipieEntity.Ingredients,
            //    Steps = recipieEntity.Steps,
            //    RecipieTips = recipieEntity.RecipieTips,
            //    NutritionFacts = recipieEntity.NutritionFacts,
            //    CreatedBy = recipieEntity.CreatedBy,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    ModifiedBy = recipieEntity.ModifiedBy,
            //    IsDeleted = false,
            //    Image= recipieEntity.Image,

            //    UserId= recipieEntity.UserId,



            //};
            recipie.CreatedBy = name.Name;
            recipie.ModifiedBy = name.Name;
            recipieDbContext.Recipies.Add(recipie);
            await recipieDbContext.SaveChangesAsync();
            Guid id = recipie.Id;
            return id;
        }


        public async Task<int> EditRecipe(Recipie recipie)
        {
            try
            {
                var editResult = recipieDbContext.Recipies.Where(x => x.Id == recipie.Id && x.UserId==recipie.UserId).FirstOrDefault();
                var name = recipieDbContext.Users.Where(x => x.Id == recipie.UserId).FirstOrDefault();
                if(editResult != null)
                {
                    editResult.Id =recipie.Id;
                    editResult.RecipieTitle = recipie.RecipieTitle;
                    editResult.Description = recipie.Description;
                    editResult.Ingredients = recipie.Ingredients;
                    editResult.Steps = recipie.Steps;
                    editResult.RecipieTips = recipie.RecipieTips;
                    editResult.NutritionFacts = recipie.NutritionFacts;
                     editResult.UserId = recipie.UserId;
                    editResult.CreatedBy = name.Name; 
                    editResult.CreatedDate = recipie.CreatedDate;
                    editResult.ModifiedBy = name.Name;
                    editResult.ModifiedDate = recipie.ModifiedDate;
                    editResult.IsDeleted = false;
                    editResult.Image = recipie.Image;

                    await recipieDbContext.SaveChangesAsync();
                    return 1;
                }


            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
            return 0;
        }



        public async Task DeleteRecipe(Guid id)
        {
            var recipe= recipieDbContext.Recipies.Where(x=> x.Id == id).FirstOrDefault();
            recipe.IsDeleted = true;
            ////recipieDbContext.Remove(recipe);
            await recipieDbContext.SaveChangesAsync();
        }



        public async Task<List<Recipie>> GetAllRecipes()
        {
            var allrecipe= new List<Recipie>();
            var availableRecipes= recipieDbContext.Recipies.Where(x=>x.IsDeleted==false).ToList();
            
            

                if (availableRecipes != null)
                {

                    foreach (var recipies in availableRecipes)
                    {
                        Recipie recipie = new Recipie();
                        recipie.Id = recipies.Id;
                        recipie.UserId = recipies.UserId;
                        recipie.RecipieTitle = recipies.RecipieTitle;
                        recipie.Description = recipies.Description;
                        recipie.Ingredients = recipies.Ingredients;
                        recipie.Steps = recipies.Steps;
                        recipie.RecipieTips = recipies.RecipieTips;
                        recipie.NutritionFacts = recipies.NutritionFacts;
                        recipie.CreatedBy = recipies.CreatedBy;
                        recipie.CreatedDate = recipies.CreatedDate;
                        recipie.ModifiedDate = recipies.ModifiedDate;
                        recipie.ModifiedBy = recipies.ModifiedBy;
                        recipie.IsDeleted = recipies.IsDeleted;
                        recipie.Image = recipies.Image;

                        //recipieEntity.UserId = recipieEntity.UserId;
                        allrecipe.Add(recipie);


                    }
                    
                }
            return allrecipe;











        }



    }
}
