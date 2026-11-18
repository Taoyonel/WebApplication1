using Microsoft.AspNetCore.Mvc;
using SkillHub.Data;
using SkillHub.Models;

namespace SkillHub.Controllers;

public class BaseController : Controller
{
    // Returns the logged-in user, or null if nobody is logged in
    protected UserAccount GetCurrentUser()
    {
        string idText = HttpContext.Session.GetString("UserId");
        if (idText == null)
        {
            return null;
        }
        int id = int.Parse(idText);
        return DataStore.FindUserById(id);
    }
}