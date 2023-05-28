using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MainSoftwre.Models
{
    public partial class Autore
    {
        public Autore()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellidos}"; } }

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
