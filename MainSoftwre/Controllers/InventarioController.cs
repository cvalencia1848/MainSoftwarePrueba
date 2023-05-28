using MainSoftwre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MainSoftwre.Controllers
{
    public class InventarioController : Controller
    {
        private readonly MainSoftwareContext mainSoftwareContext;

        public InventarioController(MainSoftwareContext mainSoftwareContext)
        {
            this.mainSoftwareContext = mainSoftwareContext;
        }

        public async Task<IActionResult> Index()
        {
            var inventario = await mainSoftwareContext.AutoresHasLibros.Include(a => a.Autores).Include(b => b.LibrosIsbnNavigation).ToListAsync();
            return View(inventario);
        }
    }
}
