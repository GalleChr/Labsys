using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Turnos
{
    public class NuevoTurnoViewModel
    {
        public long DniPaciente { get; set; }
        public long DniTecnico { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Seccion> Secciones { get; set; }
        public DateTime Fecha { get; set; }

        public NuevoTurnoViewModel() { }

    }
}