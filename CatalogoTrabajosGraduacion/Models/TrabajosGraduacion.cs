using System;
using System.Collections.Generic;

namespace CatalogoTrabajosGraduacion.Models
{
    public partial class TrabajosGraduacion
    {
        public int IdTrabajo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public int Carrera { get; set; }
        public int Tipo { get; set; }

        public virtual Carrera CarreraNavigation { get; set; }
        public virtual Tipo TipoNavigation { get; set; }
    }
}
