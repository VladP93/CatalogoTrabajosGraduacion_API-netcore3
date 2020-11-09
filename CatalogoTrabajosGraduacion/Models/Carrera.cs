using System;
using System.Collections.Generic;

namespace CatalogoTrabajosGraduacion.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            TrabajosGraduacion = new HashSet<TrabajosGraduacion>();
        }

        public int IdCarrera { get; set; }
        public int Facultad { get; set; }
        public string Nombre { get; set; }

        public virtual Facultad FacultadNavigation { get; set; }
        public virtual ICollection<TrabajosGraduacion> TrabajosGraduacion { get; set; }
    }
}
