using Microsoft.AspNetCore.Mvc;
using SkillHub.Data;
using SkillHub.Models;

namespace SkillHub.Controllers;

public class RequestsController : BaseController
{
    [HttpGet]
    public IActionResult Create(int listingId)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Listing listing = DataStore.FindListing(listingId);
        if (listing == null || listing.IsActive == false)
        {
            return RedirectToAction("Index", "Listings");
        }
        if (listing.OwnerId == me.Id || me.Role == "Admin")
        {
            TempData["Message"] = "You cannot request this listing.";
            return RedirectToAction("Index", "Listings");
        }
        return View(listing);
    }

    [HttpPost]
    public IActionResult Create(int listingId, string message)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Listing listing = DataStore.FindListing(listingId);
        if (listing == null || listing.IsActive == false || listing.OwnerId == me.Id || me.Role == "Admin")
        {
            return RedirectToAction("Index", "Listings");
        }
        if (string.IsNullOrWhiteSpace(message))
        {
            TempData["Message"] = "Please write a short message.";
            return Redirect("/Requests/Create?listingId=" + listingId);
        }
        if (DataStore.HasPendingRequest(listingId, me.Id))
        {
            TempData["Message"] = "You already have a pending request for this listing.";
            return RedirectToAction("Sent");
        }

        DataStore.AddRequest(listingId, me.Id, message.Trim());
        TempData["Message"] = "Request sent!";
        return RedirectToAction("Sent");
    }

    // requests I sent
    public IActionResult Sent()
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }

        List<ServiceRequest> list = new List<ServiceRequest>();
        for (int i = 0; i < DataStore.Requests.Count; i++)
        {
            if (DataStore.Requests[i].RequesterId == me.Id)
            {
                list.Add(DataStore.Requests[i]);
            }
        }
        return View(list);
    }

    // requests sent to my listings
    public IActionResult Received()
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }

        List<ServiceRequest> list = new List<ServiceRequest>();
        for (int i = 0; i < DataStore.Requests.Count; i++)
        {
            Listing listing = DataStore.FindListing(DataStore.Requests[i].ListingId);
            if (listing != null && listing.OwnerId == me.Id)
            {
                list.Add(DataStore.Requests[i]);
            }
        }
        return View(list);
    }

    [HttpPost]
    public IActionResult ChangeStatus(int id, string newStatus)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login", "Account");
        }
        ServiceRequest request = DataStore.FindRequest(id);
        if (request == null)
        {
            return RedirectToAction("Sent");
        }

        Listing listing = DataStore.FindListing(request.ListingId);
        bool isOwner = listing.OwnerId == me.Id;
        bool isRequester = request.RequesterId == me.Id;

        if (isOwner && request.Status == "Pending" && (newStatus == "Accepted" || newStatus == "Declined"))
        {
            request.Status = newStatus;
        }
        else if (isOwner && request.Status == "Accepted" && newStatus == "Completed")
        {
            request.Status = newStatus;
        }
        else if (isRequester && request.Status == "Pending" && newStatus == "Cancelled")
        {
            request.Status = newStatus;
        }
        else
        {
            TempData["Message"] = "That change is not allowed.";
        }

        if (isOwner)
        {
            return RedirectToAction("Received");
        }
        return RedirectToAction("Sent");
    }
}