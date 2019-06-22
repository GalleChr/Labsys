using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Turnos
{
    public class TurnosViewModel
    {
        public IEnumerable<TurnoViewItem> Turnos { get; set; }

        public TurnosViewModel()
        {
            Turnos = Enumerable.Empty<TurnoViewItem>();
        }
    }
}