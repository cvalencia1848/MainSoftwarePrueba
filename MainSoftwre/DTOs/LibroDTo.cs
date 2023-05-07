using System.ComponentModel.DataAnnotations;

namespace MainSoftwre.DTOs
{
    /// <summary>
    /// Defines the <see cref="LibroDTo" />.
    /// </summary>
    public class LibroDTo
    {
        /// <summary>
        /// Gets or sets the IdLibro.
        /// </summary>
        [Key]
        public int IdLibro { get; set; }

        /// <summary>
        /// Gets or sets the Titulo.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets the Sinopsis.
        /// </summary>
        public string Sinopsis { get; set; }

        /// <summary>
        /// Gets or sets the Paginas.
        /// </summary>
        public string Paginas { get; set; }

        /// <summary>
        /// Gets or sets the NombreAutor.
        /// </summary>
        public string NombreAutor { get; set; }

        /// <summary>
        /// Gets or sets the NombreEditorial.
        /// </summary>
        public string NombreEditorial { get; set; }

        /// <summary>
        /// Gets or sets the Sede.
        /// </summary>
        public string Sede { get; set; }
    }
}
