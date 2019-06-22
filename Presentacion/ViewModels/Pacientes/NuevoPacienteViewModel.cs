using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Pacientes
{
    public class NuevoPacienteViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public NuevoPacienteViewModel()
        { }


    }
}