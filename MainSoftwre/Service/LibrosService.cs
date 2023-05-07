namespace MainSoftwre.Service
{
    using MainSoftwre.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="LibrosService" />.
    /// </summary>
    public class LibrosService: ILibrosService
    {
        /// <summary>
        /// Defines the context.
        /// </summary>
        private readonly MainSoftwareContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrosService"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="MainSoftwareContext"/>.</param>
        public LibrosService(MainSoftwareContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// The ObtenerEditoriales.
        /// </summary>
        /// <returns>The <see cref="Task{List{SelectListItem}}"/>.</returns>
        public List<SelectListItem> ObtenerEditoriales()
        {
            var editoriales = context.Editoriales.ToList();
            List<SelectListItem> items = editoriales.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString(),
                    Selected = false
                };
            }
            );
            return items;
        }

        /// <summary>
        /// The ObtenerAutores.
        /// </summary>
        /// <returns>The <see cref="Task{List{SelectListItem}}"/>.</returns>
        public List<SelectListItem> ObtenerAutores()
        {
            var autores = context.Autores.ToList();
            List<SelectListItem> items = autores.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Nombre,
                    Value = x.Id.ToString(),
                    Selected = false
                };
            }
            );
            return items;
        }

        public AutoresHasLibro AgregarRelacion(Libro libro)
        {
            var autor = context.Autores.Where(x => x.Id == libro.AutorId).FirstOrDefault();
            return new AutoresHasLibro
            {
                AutoresId = (int)libro.AutorId,
                LibrosIsbn = libro.Isbn,
                Autores = autor,
                LibrosIsbnNavigation = libro
            };
        }

    }
}
