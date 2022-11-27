using DataAccess.DataContext.Configurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public class RecipieDbContext:DbContext
    {


        public RecipieDbContext(DbContextOptions<RecipieDbContext> options) : base(options)
        {

        }

        public DbSet<Recipie> Recipies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipieConfigurationMap());
            modelBuilder.ApplyConfiguration(new UserConfigurationMap());    


          

        }
    }
}
