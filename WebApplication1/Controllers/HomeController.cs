using Microsoft.AspNetCore.Mvc;
using SkillHub.Data;
using SkillHub.Models;

namespace SkillHub.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        List<Listing> featured = new List<Listing>();
        for (int i = 0; i < DataStore.Listings.Count; i++)
        {
            if (DataStore.Listings[i].IsActive && featured.Count < 6)
            {
                featured.Add(DataStore.Listings[i]);
            }
        }
        return View(featured);
    }

    public IActionResult About()
    {
        return View();
    }
}