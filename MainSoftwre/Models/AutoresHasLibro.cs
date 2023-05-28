#nullable disable

using System.ComponentModel.DataAnnotations;

namespace MainSoftwre.Models
{
    public partial class AutoresHasLibro
    {
        public int Id { get; set; }
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }

        public virtual Autore Autores { get; set; }
        [Display(Name = "Libros")]
        public virtual Libro LibrosIsbnNavigation { get; set; }
    }
}
