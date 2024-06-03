using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using proje1.Data;

namespace proje1.Controllers
{
    public class CourseController : Controller{
        
        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id, string searchString)
        {
            var videolar = await _context.Videolar
                .Where(v => string.IsNullOrEmpty(searchString) || v.Baslik.Contains(searchString))
                .Select(v => new proje1.Data.Videolar
                {
                    Id = v.Id,
                    Baslik = v.Baslik,
                    Resim = v.Resim,
                    Kategori = v.Kategori
                })
                .ToListAsync();

            ViewBag.SearchString = searchString;

            return View(videolar);
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Videolar model, IFormFile resim, IFormFile videoData)

        {
            var deneme = new Videolar
            {
                Baslik = model.Baslik,
                Aciklama = model.Aciklama,
                Kategori = model.Kategori,
                Resim = GetFileBytes(resim),
                VideoData = GetFileBytes(videoData),
            };

            _context.Videolar.Add(deneme);
            await _context.SaveChangesAsync();

            return View("Success");
        }

        private byte[] GetFileBytes(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null!;
        }

        public async Task<IActionResult> CourseView(int id)
        {
            var video = await _context.Videolar.FindAsync(id);

            return View(video);
        }

    }
}