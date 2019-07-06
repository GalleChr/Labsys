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
        public virtual IEnumerable<Seccion> Secciones { get; set; }
        public DateTime Fecha { get; set; }

        public IEnumerable<int> SeccionesElegidas { get; set; }

        public NuevoTurnoViewModel()
        {
            SeccionesElegidas = Enumerable.Empty<int>();
        }

    }
}