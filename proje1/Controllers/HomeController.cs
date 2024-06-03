using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proje1.Data;
using proje1.Models;

namespace proje1.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
        return View();
    }

}
