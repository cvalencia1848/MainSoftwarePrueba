namespace MainSoftwre.Service
{
    using MainSoftwre.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ILibrosService" />.
    /// </summary>
    public interface ILibrosService
    {
        /// <summary>
        /// The ObtenerEditoriales.
        /// </summary>
        /// <returns>The <see cref="Task{List{SelectListItem}}"/>.</returns>
        List<SelectListItem> ObtenerEditoriales();

        /// <summary>
        /// The ObtenerAutores.
        /// </summary>
        /// <returns>The <see cref="Task{List{SelectListItem}}"/>.</returns>
        List<SelectListItem> ObtenerAutores();

        /// <summary>
        /// The AgregarRelacion.
        /// </summary>
        /// <param name="libro">The libro<see cref="Libro"/>.</param>
        /// <returns>The <see cref="AutoresHasLibro"/>.</returns>
        AutoresHasLibro AgregarRelacion(Libro libro);
    }
}
