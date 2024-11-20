// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace FirstWeb.Controllers;   

// [Route("cake")]
public class FirstController : Controller   // Remember inheritance?    
{

    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public string Index()        
    {            
    	return "Hello World from HelloController!";        
    } 

    [HttpGet("two")]
    public string PageTwo()
    {
        return "<h1>This is page two </h1>";
    }

    [HttpGet("params/{id}/{name}")]
    public string Params(int id, string name)
    {
        return $"{name} provided id {id}";
    }

    [HttpGet("view/{id}/{name}")]
    public ViewResult ViewParams(int id, string name)
    {
        ViewBag.id = id;
        ViewBag.name = name;
        return View();
    }

    [HttpGet("view")]
    public ViewResult ViewPage()
    {
        return View("ViewPage");
    }

    [HttpGet("razor")]
    public ViewResult RazorFun()
    {
        return View("RazorFun");
    }

    [HttpGet("form")]
    public ViewResult FormPage()
    {
        return View();
    }

    // [HttpPost("process")]
    // public RedirectResult ProcessForm(int id, string name)
    // {
    //     Console.WriteLine($"{name} supplied id {id}");
        
    //     return Redirect("form");
    // }

    // [HttpPost("process")]
    // public RedirectToActionResult ProcessForm(int id, string name)
    // {
    //     Console.WriteLine($"{name} supplied id {id}");
        
    //     return RedirectToAction("ViewParams", new {id,name=name});
    // }

    [HttpPost("process")]
    public IActionResult ProcessForm(int id, string name)
    {
        if (id == 123)
        {
            return View("SecretPage");
        }
        
        return RedirectToAction("ViewParams", new {id,name=name});
    }


    

    [HttpGet("{**path}")]
    public string Lost()
    {
        return "Not found, you are lost!";
    }
}