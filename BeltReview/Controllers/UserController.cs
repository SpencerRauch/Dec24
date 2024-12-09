using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeltReview.Models;

namespace BeltReview.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("users/register")]
    public IActionResult RegisterUser(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        PasswordHasher<User> hasher = new();
        newUser.Password = hasher.HashPassword(newUser,newUser.Password);
        _context.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UserId", newUser.UserId);
        return RedirectToAction("Success"); // ! TODO UPDATE TO DASHBOARD OF WIREFRAME

    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(LogUser logAttempt)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        User? dbUser = _context.Users.FirstOrDefault(u => u.Email == logAttempt.LogEmail);
        if (dbUser == null)
        {
            ModelState.AddModelError("LogPassword","Invalid Credentials");
            return View("Index");
        }
        PasswordHasher<LogUser> hasher = new();
        PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(logAttempt,dbUser.Password,logAttempt.LogPassword);
        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LogPassword","Invalid Credentials");
            return View("Index");
        }
        HttpContext.Session.SetInt32("UserId",dbUser.UserId);
        return RedirectToAction("Success"); // ! TODO UPDATE TO DASHBOARD OF WIREFRAME
    }

    [HttpPost("user/logout")]
    public RedirectToActionResult Logout()
    {
        // HttpContext.Session.Clear();
        HttpContext.Session.Remove("UserId");
        return RedirectToAction("Index");
    }

    [SessionCheck]
    [HttpGet("users/success")]
    public IActionResult Success()
    {
        int LoggedId = (int)HttpContext.Session.GetInt32("UserId");
        User? LoggedUser = _context.Users.FirstOrDefault(u => u.UserId == LoggedId);
        if (LoggedUser == null)
        {
            return Logout();
        }
        return View(LoggedUser);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
