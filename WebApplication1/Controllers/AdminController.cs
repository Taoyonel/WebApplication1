using Microsoft.AspNetCore.Mvc;
using SkillHub.Data;
using SkillHub.Models;

namespace SkillHub.Controllers;

public class AdminController : BaseController
{
    public IActionResult Index()
    {
        UserAccount me = GetCurrentUser();
        if (me == null || me.Role != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }

    [HttpPost]
    public IActionResult DeleteUser(int id)
    {
        UserAccount me = GetCurrentUser();
        if (me == null || me.Role != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        UserAccount user = DataStore.FindUserById(id);
        if (user != null && user.Role != "Admin")
        {
            DataStore.RemoveUser(id);
            TempData["Message"] = "User removed, along with their listings and requests.";
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteListing(int id)
    {
        UserAccount me = GetCurrentUser();
        if (me == null || me.Role != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        DataStore.RemoveListing(id);
        TempData["Message"] = "Listing removed.";
        return RedirectToAction("Index");
    }
}