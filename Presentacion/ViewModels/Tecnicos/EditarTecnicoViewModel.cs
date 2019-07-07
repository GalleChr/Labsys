using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Tecnicos
{
    public class EditarTecnicoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Legajo { get; set; }

        public EditarTecnicoViewModel()
        { }

        public EditarTecnicoViewModel(int id)
        {
            Id = id;
        }
    }
}