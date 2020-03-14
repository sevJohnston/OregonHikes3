using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OregonHikes3.Models;
using OregonHikes3.Repositories;


namespace OregonHikes3.Controllers
{
    public class HomeController : Controller
    {
        private IHikeRepository repo;
        public HomeController(IHikeRepository r)
        {
            repo = r;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Hike> hikes = repo.Hikes;
            ViewData["newestHike"] = hikes[hikes.Count - 1].TrailName;
            ViewBag.hikeCount = hikes.Count;
            return View(hikes);
        }

        public IActionResult About()    //view for the about/history page
        {
            return View("About");
        }

        public IActionResult Resources()
        {
            List<Resource> resources = ResourceRepo.Resources;
            resources.Sort((r1, r2) => string.Compare(r1.ResourceName, r2.ResourceName, StringComparison.Ordinal));
            return View(resources);
        }

        public IActionResult Hikes()        // see if the name change messes it up!
        {
            List<Hike> hikes = repo.Hikes;
            hikes.Sort((h1, h2) => string.Compare(h1.Region, h2.Region, StringComparison.Ordinal));
            return View(hikes);
        }

        public IActionResult AddHike()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddHike(string trailName, string region, string description)
        {
            Hike hike = new Hike { TrailName = trailName, Region = region, Description = description };
            repo.AddHike(hike);

            return RedirectToAction("Hikes");
        }
    }
}
