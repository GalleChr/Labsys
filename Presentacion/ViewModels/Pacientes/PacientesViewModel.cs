using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Pacientes
{
    public class PacientesViewModel
    {
        public IEnumerable<PacienteViewItem> Pacientes { get; set; }

        public PacientesViewModel()
        {
            Pacientes = Enumerable.Empty<PacienteViewItem>();
        }
    }
}