using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Controllers
{
    public class DestinosController : Controller
    {
        private readonly AppDbContext _context;

        public DestinosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var destinos = await _context.Destinos.ToListAsync();
            return View(destinos);
        }
    }
}
