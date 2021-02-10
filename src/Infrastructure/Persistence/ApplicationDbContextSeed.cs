using prooram.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace prooram.Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedCategoriesAsync(ApplicationDbContext context)
        {
            
            if (!context.Categories.Any()) // if categories table = empty
            {
                string[] categories = { "Vacation", "Food", "Movie", "Music", "Information Technologies" };
                foreach (string category in categories)
                {
                    context.Categories.Add(new Domain.Entities.Category { CategoryName = category });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
