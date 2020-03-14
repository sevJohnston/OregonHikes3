using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonHikes3.Models
{
    public class ResourceRepo
    {
        private static List<Resource> resources = new List<Resource>();     //creates a list for resources
        public static List<Resource> Resources { get { return resources; } }

        static ResourceRepo()
        {
            AddResourceSeedData();    //adds the hard coded list of people/
        }

        public static void AddResource(Resource resource)
        {
            resources.Add(resource);
        }

        public static void AddResourceSeedData()
        {
            Resource resource = new Resource()
            {
                ResourceName = "Willamette Valley Great Old Broads for Wilderness",
                Link = "https://www.greatoldbroads.org/directory-of-broadbands/oregon-willamette-valley-broadband/",
                Description = "Great Old Broads for Wilderness is a national grassroots organization, led by women, " +
                "that engages and inspires activism to preserve and protect wilderness and wild lands. " +
                "Our local chapters hike together and work with other conservation groups to " +
                "advocate for local wildlands."
            };
            resources.Add(resource);

            resource = new Resource()
            {
                ResourceName = "William Sullivan",
                Link = "http://www.oregonhiking.com/william-l-sullivan",
                Description = "William L. Sullivan is the author of 22 books and numerous articles about Oregon, " +
                "including a feature column for the Eugene Register-Guard."
            };
            resources.Add(resource);

            resource = new Resource()
            {
                ResourceName = "Mazamas",
                Link = "https://mazamas.org/",
                Description = "The Mazamas is a robust community of individuals" +
                "who love to recreate in and protect the outdoors."
            };
            resources.Add(resource);

            resource = new Resource()
            {
                ResourceName = "Obsidians",
                Link = "http://www.obsidians.org/",
                Description = "Organized in 1927 by a group of men from Eugene" +
                " who were concerned about a mountaineering accident," +
                "the Obsidians have grown to more than 400 people " +
                "actively involved in a wide variety of outdoor activities."

            };
            resources.Add(resource);
        }
    }
}
