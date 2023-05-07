namespace MainSoftwre.Controllers
{
    using MainSoftwre.DTOs;
    using MainSoftwre.Models;
    using MainSoftwre.Service;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="LibrosController" />.
    /// </summary>
    public class LibrosController : Controller
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private readonly MainSoftwareContext _context;
        private readonly ILibrosService librosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrosController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="MainSoftwareContext"/>.</param>
        public LibrosController(MainSoftwareContext context, ILibrosService librosService)
        {
            _context = context;
            this.librosService = librosService;
        }

        // GET: Libros
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        public async Task<IActionResult> Index()
        {
            var mainSoftwareContext = _context.Libros.Include(l => l.Editoriales);
            return View(await mainSoftwareContext.ToListAsync());
        }

        // GET: Libros/Details/5
        /// <summary>
        /// The Details.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroDto =  _context.LibroDTo.FromSqlInterpolated($"EXEC ObtenerLibroDetalle @IdLibro={id}").AsAsyncEnumerable();

            if (libroDto == null)
            {
                return NotFound();
            }

            await foreach (var item in libroDto)
            {
                return View(item);
            }
            return NotFound();
        }

        // GET: Libros/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        public IActionResult Create()
        {
            ViewBag.Editoriales = _context.Editoriales.ToList();
            ViewBag.Autores = _context.Autores.ToList();
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="libro">The libro<see cref="Libro"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librosService.AgregarRelacion(libro));
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["EditorialesId"] = new SelectList(_context.Editoriales, "Id", "Id", libro.EditorialesId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="libro">The libro<see cref="Libro"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Isbn,EditorialesId,Titulo,Sinopsis,NPaginas")] Libro libro)
        {
            if (id != libro.Isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Isbn))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorialesId"] = new SelectList(_context.Editoriales, "Id", "Id", libro.EditorialesId);
            return View(libro);
        }

        // GET: Libros/Delete/5
        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Editoriales)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        /// <summary>
        /// The DeleteConfirmed.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// The LibroExists.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Isbn == id);
        }
    }
}
