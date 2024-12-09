using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeltReview.Models;

namespace BeltReview.Controllers;

[SessionCheck]
public class SightingController : Controller
{
    private readonly ILogger<SightingController> _logger;

    private MyContext _context;

    public SightingController(ILogger<SightingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("dashboard")]
    public ViewResult Dashboard()
    {
        List<Sighting> AllSightings = _context.Sightings
                                                .Include(s => s.ReportingUser)
                                                .Include(s => s.UserBeliefs)
                                                .ToList();

        return View(AllSightings);
    }

    [HttpGet("sightings/new")]
    public ViewResult NewSighting()
    {
        return View();
    }

    [HttpPost("sighting/create")]
    public IActionResult CreateSighting(Sighting newSighting)
    {
        if (!ModelState.IsValid)
        {
            return View("NewSighting");
        }
        newSighting.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newSighting);
        _context.SaveChanges();

        return RedirectToAction("Dashboard"); // ! UPDATE TO VIEW ONE PAGE 
    }

    [HttpGet("sightings/{sightingId}")]
    public IActionResult ViewSighting(int sightingId)
    {
        Sighting? OneSighting = _context.Sightings
                                        .Include(s => s.ReportingUser)
                                        .Include(s => s.UserBeliefs)
                                        .ThenInclude(usb => usb.BelievingUser)
                                        .FirstOrDefault(s => s.SightingId == sightingId);
        if (OneSighting == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(OneSighting);

    }
}
