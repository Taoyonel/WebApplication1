using Microsoft.AspNetCore.Mvc;
using SkillConnect.Data;
using SkillConnect.Models;

namespace SkillConnect.Controllers;

public class ListingsController : BaseController
{
    // READ: browse, search, and filter
    public IActionResult Index(string search, string category, string type)
    {
        List<Listing> results = new List<Listing>();

        for (int i = 0; i < DataStore.Listings.Count; i++)
        {
            Listing listing = DataStore.Listings[i];

            if (listing.IsActive == false)
            {
                continue;
            }
            if (!string.IsNullOrWhiteSpace(category) && listing.Category != category)
            {
                continue;
            }
            if (!string.IsNullOrWhiteSpace(type) && listing.Type != type)
            {
                continue;
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                string words = search.ToLower();
                UserAccount owner = DataStore.FindUserById(listing.OwnerId);

                bool found = listing.Title.ToLower().Contains(words)
                          || listing.Description.ToLower().Contains(words)
                          || listing.Category.ToLower().Contains(words)
                          || owner.FullName.ToLower().Contains(words);
                if (found == false)
                {
                    continue;
                }
            }
            results.Add(listing);
        }

        ViewBag.Search = search;
        ViewBag.Category = category;
        return View(results);
    }

    public IActionResult Details(int id)
    {
        Listing listing = DataStore.FindListing(id);
        if (listing == null)
        {
            return RedirectToAction("Index");
        }
        return View(listing);
    }

    // READ: my own listings
    public IActionResult Mine()
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        if (me.Role != "Professional")
        {
            return RedirectToAction("Index", "Home");
        }

        List<Listing> mine = new List<Listing>();
        for (int i = 0; i < DataStore.Listings.Count; i++)
        {
            if (DataStore.Listings[i].OwnerId == me.Id)
            {
                mine.Add(DataStore.Listings[i]);
            }
        }
        return View(mine);
    }

    // CREATE
    [HttpGet]
    public IActionResult Create()
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        if (me.Role != "Professional")
        {
            TempData["Message"] = "Only professional accounts can post listings.";
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Create(string title, string description, string category, string type, decimal rate)
    {
        UserAccount me = GetCurrentUser();
        if (me == null || me.Role != "Professional")
        {
            return RedirectToAction("Index", "Home");
        }
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || rate <= 0)
        {
            TempData["Message"] = "Please fill in the title, description, and a rate above 0.";
            return View();
        }

        DataStore.AddListing(me.Id, title.Trim(), description.Trim(), category, type, rate);
        TempData["Message"] = "Listing published.";
        return RedirectToAction("Mine");
    }

    // UPDATE
    [HttpGet]
    public IActionResult Edit(int id)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Listing listing = DataStore.FindListing(id);
        if (listing == null || listing.OwnerId != me.Id)
        {
            return RedirectToAction("Mine");
        }
        return View(listing);
    }

    [HttpPost]
    public IActionResult Edit(int id, string title, string description, string category, string type, decimal rate)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Listing listing = DataStore.FindListing(id);
        if (listing == null || listing.OwnerId != me.Id)
        {
            return RedirectToAction("Mine");
        }
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || rate <= 0)
        {
            TempData["Message"] = "Please fill in the title, description, and a rate above 0.";
            return Redirect("/Listings/Edit/" + id);
        }

        listing.Title = title.Trim();
        listing.Description = description.Trim();
        listing.Category = category;
        listing.Type = type;
        listing.HourlyRate = rate;

        TempData["Message"] = "Listing updated.";
        return RedirectToAction("Mine");
    }

    // ACTIVATE / DEACTIVATE
    [HttpPost]
    public IActionResult Toggle(int id)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Listing listing = DataStore.FindListing(id);
        if (listing != null && listing.OwnerId == me.Id)
        {
            listing.IsActive = !listing.IsActive;
        }
        return RedirectToAction("Mine");
    }

    // DELETE
    [HttpPost]
    public IActionResult Delete(int id)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Listing listing = DataStore.FindListing(id);
        if (listing != null && listing.OwnerId == me.Id)
        {
            DataStore.RemoveListing(id);
            TempData["Message"] = "Listing deleted.";
        }
        return RedirectToAction("Mine");
    }
}