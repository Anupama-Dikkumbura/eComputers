using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eComputer.Models;
using Microsoft.AspNetCore.Hosting.Server;
using eComputer.Data.Services;

namespace eComputer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomeService _service;

    public HomeController(ILogger<HomeController> logger, IHomeService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allComs = await _service.GetAllAsync();
        return View(allComs);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}

