using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetParty.Models;

namespace PetParty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static List<Pet> FakePetDb = [];

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<SelectListItem> Options = 
        [
            new SelectListItem("-- please choose --","",true,true),
            new("Bear","Bear"),
            new("Raccoon","Raccoon"),
            new("Squirrel","Squirrel")
        ];
        ViewBag.Options = Options;
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("vmfun")]
    public ViewResult VMFun()
    {
        int NumberImPassing = 9493;
        List<string> Names = ["Bob","Alice"];
        return View(Names);
    }

    [HttpPost("process")]
    public IActionResult Process(Pet newPet)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
        } 
        if (!ModelState.IsValid)
        {

            return Index();
        }
        Console.WriteLine($"{newPet.Name} is a {newPet.Age} years old {newPet.Species}");
        Console.WriteLine($"{(newPet.Cute ? "They are very cute" : "I'm sure their mother thinks they're cute")}");
        
        //a real database will work much like this!
        FakePetDb.Add(newPet);
        HttpContext.Session.SetString("LastPet",newPet.Name);
        // FakePetDb.SaveChanges(); <-- this is the difference

        return RedirectToAction("Results");
    }

    [HttpGet("results")]
    public IActionResult Results()
    {
        string? LastPet = HttpContext.Session.GetString("LastPet");
        if (LastPet == null)
        {
            return RedirectToAction("Index");
        }
        return View(FakePetDb);
    }

    [HttpPost("set")]
    public RedirectToActionResult SetFilter(int limit)
    {
        HttpContext.Session.SetInt32("Limit",limit);
        return RedirectToAction("Results");
    }

    [HttpPost("clear")]
    public RedirectToActionResult ClearFilter()
    {
        // HttpContext.Session.Clear();
        HttpContext.Session.Remove("Limit");
        return RedirectToAction("Results");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
