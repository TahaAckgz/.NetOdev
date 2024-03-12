using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Odev.Models.Entities;


namespace Odev.Controllers;

public class HomeController : Controller
{
    private readonly kitapdbContext db = new kitapdbContext();

    public HomeController(kitapdbContext _db)
    {
        db=_db;
    }

    public IActionResult Index()
    {
        var kitapListesi = db.Kitaplars.ToList();
        return View(kitapListesi);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
}
