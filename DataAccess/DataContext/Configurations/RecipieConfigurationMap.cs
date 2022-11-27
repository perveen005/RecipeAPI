using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext.Configurations
{
    public class RecipieConfigurationMap: IEntityTypeConfiguration<Recipie>
    {
        public void Configure(EntityTypeBuilder<Recipie> builder)
        {
            builder.ToTable("Recipie");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.user)
                .WithMany(x => x.Recipies)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.ModifiedByUser)
            //    .WithMany(x => x.RecipiesModified);

        }
    }
}
