using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
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
            return View("Index");
        }
        Console.WriteLine($"{newPet.Name} is a {newPet.Age} years old {newPet.Species}");
        Console.WriteLine($"{(newPet.Cute ? "They are very cute" : "I'm sure their mother thinks they're cute")}");
        
        //a real database will work much like this!
        FakePetDb.Add(newPet);
        // FakePetDb.SaveChanges(); <-- this is the difference

        return RedirectToAction("Result");
    }

    [HttpGet("results")]
    public ViewResult Result()
    {
        return View(FakePetDb);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
