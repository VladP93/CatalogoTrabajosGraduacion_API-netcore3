using System;
using System.Collections.Generic;

namespace CatalogoTrabajosGraduacion.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            TrabajosGraduacion = new HashSet<TrabajosGraduacion>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TrabajosGraduacion> TrabajosGraduacion { get; set; }
    }
}
