using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Tecnicos
{
    public class NuevoTecnicoViewModel
    {
        public long Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Legajo { get; set; }

        public NuevoTecnicoViewModel()
        { }


    }
}