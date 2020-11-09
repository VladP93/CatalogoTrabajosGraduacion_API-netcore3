using System;
using System.Collections.Generic;

namespace CatalogoTrabajosGraduacion.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Carrera = new HashSet<Carrera>();
        }

        public int IdFacultad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }
    }
}
