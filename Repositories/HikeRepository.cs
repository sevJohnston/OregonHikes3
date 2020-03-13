using OregonHikes3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonHikes3.Repositories
{
    public class HikeRepository : IHikeRepository
    {
        private AppDbContext context;

        private static List<Hike> hikes = new List<Hike>();
        public List<Hike> Hikes { get { return context.Hikes.ToList(); } }

        //constructor
        public HikeRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public HikeRepository()
        {
            if (hikes.Count == 0)
            {
                AddHikeSeedData();
            }
        }

        public static void AddHikeSeedData()
        {
            Hike hike = new Hike()
            {
                TrailName = "Mary's Peak",
                Region = "Willamette Valley", //if I want to sort by region I think I need to add a new list?
                Description = "A wonderful example of a temperate rain forest " +
                "with views to the ocean from the top!"
            };
            //UserReview review = new UserReview();
            hikes.Add(hike);
            //hike.UserReviews.Add(review);
            hike = new Hike()
            {
                TrailName = "Cook's Ridge",
                Region = "Coast", //if I want to sort by region I think I need to add a new list?
                Description = "A mix of old growth and second growth in the Coast Range " +
                "near Cape Perpetua and Cumming's Creek."
            };
            hikes.Add(hike);
            //hike.UserReviews.Add(review);

            hike = new Hike()
            {
                TrailName = "Fall Creek Falls",
                Region = "Southern Oregon", //if I want to sort by region I think I need to add a new list?
                Description = "This short shady trail follows a cascading creek, squeezes through a crack in a house-sized boulder, " +
                "and takes you to a double waterfall. A popular hike for kids."
            };
            hikes.Add(hike);
            //hike.UserReviews.Add(review);
        }

        public void AddHike(Hike hike)
        {
            context.Hikes.Add(hike);
            context.SaveChanges();
        }

        public Hike GetHikeByID(int hikeID)
        {
            Hike hike;
            hike = context.Hikes.First(h => h.HikeID == hikeID);
            return hike;
        }
        public Hike GetHikeByRegion(string region)
        {
            Hike hike;
            hike = context.Hikes.First(h => h.Region == region);
            return hike;
        }

        public Hike GetHikeByTrailName(string trailName)
        {
            Hike hike;
            //FirstOrDefault will return a default value if queried with a bad goodName--
            //so no exception is thrown
            hike = context.Hikes.FirstOrDefault(h => h.TrailName == trailName);
            return hike;
        }
    }
}
