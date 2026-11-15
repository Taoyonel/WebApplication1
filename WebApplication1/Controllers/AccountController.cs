using Microsoft.AspNetCore.Mvc;
using SkillConnect.Data;
using SkillConnect.Models;

namespace SkillConnect.Controllers;

public class AccountController : BaseController
{
    // ---------- REGISTER ----------
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string fullName, string email, string password, string confirmPassword, string accountType)
    {
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            TempData["Message"] = "Please fill in all fields.";
            return View();
        }
        if (password != confirmPassword)
        {
            TempData["Message"] = "Passwords do not match.";
            return View();
        }
        if (DataStore.FindUserByEmail(email) != null)
        {
            TempData["Message"] = "That email is already registered.";
            return View();
        }

        string role = accountType == "Professional" ? "Professional" : "Regular";
        DataStore.AddUser(fullName.Trim(), email.Trim(), password, role);

        TempData["Message"] = "Account created! You can now log in.";
        return RedirectToAction("Login");
    }

    // ---------- LOGIN / LOGOUT ----------
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            TempData["Message"] = "Please enter your email and password.";
            return View();
        }

        UserAccount user = DataStore.FindUserByEmail(email.Trim());
        if (user == null || user.Password != password)
        {
            TempData["Message"] = "Wrong email or password.";
            return View();
        }

        HttpContext.Session.SetString("UserId", user.Id.ToString());

        if (user.Role == "Admin")
        {
            return RedirectToAction("Index", "Admin");
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    // ---------- PROFILE ----------
    [HttpGet]
    public IActionResult Profile()
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login");
        }
        return View(me);
    }

    [HttpPost]
    public IActionResult Profile(string fullName, string location, string bio)
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login");
        }
        if (string.IsNullOrWhiteSpace(fullName))
        {
            TempData["Message"] = "Full name is required.";
            return RedirectToAction("Profile");
        }

        me.FullName = fullName.Trim();
        me.Location = location == null ? "" : location.Trim();
        me.Bio = bio == null ? "" : bio.Trim();

        TempData["Message"] = "Profile updated.";
        return RedirectToAction("Profile");
    }

    [HttpPost]
    public IActionResult DeleteAccount()
    {
        UserAccount me = GetCurrentUser();
        if (me == null)
        {
            return RedirectToAction("Login");
        }
        if (me.Role == "Admin")
        {
            TempData["Message"] = "The admin account cannot be deleted.";
            return RedirectToAction("Profile");
        }

        DataStore.RemoveUser(me.Id);
        HttpContext.Session.Clear();
        TempData["Message"] = "Your account was deleted.";
        return RedirectToAction("Index", "Home");
    }
}