using OregonHikes3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonHikes3.Repositories
{
    public class SeedData
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Hikes.Any())
            {
                /*
                AppUser user = new AppUser { UserName = "Bob", Email = "Bob@Bob.net", Password = "secret" };
                context.Users.Add(user);
                */

                Hike hike = new Hike
                {
                    TrailName = "Mary's Peak",
                    Region = "Willamette Valley", //if I want to sort by region I think I need to add a new list?
                    Description = "A wonderful example of a temperate rain forest " +
                                    "with views to the ocean from the top!"
                };
                context.Hikes.Add(hike);
                context.SaveChanges();
            }
        }
    }
}
