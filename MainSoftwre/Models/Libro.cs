namespace MainSoftwre.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Libro" />.
    /// </summary>
    public partial class Libro
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Libro"/> class.
        /// </summary>
        public Libro()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        /// <summary>
        /// Gets or sets the Isbn.
        /// </summary>
        public int Isbn { get; set; }

        /// <summary>
        /// Gets or sets the EditorialesId.
        /// </summary>
        [Required(ErrorMessage = "Debe seleccionar una editrial")]
        [Display(Name = "Editorial")]
        public int? EditorialesId { get; set; }

        /// <summary>
        /// Gets or sets the AutorId.
        /// </summary>
        [Required(ErrorMessage = "Debe seleccionar un autor")]
        [NotMapped]
        public int? AutorId { get; set; }

        /// <summary>
        /// Gets or sets the Titulo.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets the Sinopsis.
        /// </summary>
        public string Sinopsis { get; set; }

        /// <summary>
        /// Gets or sets the NPaginas.
        /// </summary>
        [Required(ErrorMessage = "Este campo es ebligado")]
        [Display(Name = "Numero de páginas")]
        public string NPaginas { get; set; }

        /// <summary>
        /// Gets or sets the Editoriales.
        /// </summary>
        public virtual Editoriale Editoriales { get; set; }

        /// <summary>
        /// Gets or sets the AutoresHasLibros.
        /// </summary>
        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
