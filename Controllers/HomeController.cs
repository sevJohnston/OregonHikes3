using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OregonHikes3.Models;
using OregonHikes3.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
    }
}
