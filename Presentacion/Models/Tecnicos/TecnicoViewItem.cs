using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models.Tecnicos
{
    public class TecnicoViewItem
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public string Edad { get; set; }
        public string Legajo { get; set; }


        public TecnicoViewItem(Tecnico tecnico)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - tecnico.FechaNacimiento.Year;
            if (tecnico.FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            Nombre = tecnico.Nombre;
            Apellido = tecnico.Apellido;
            Dni = tecnico.Dni;
            Edad = $"{edad} años {tecnico.FechaNacimiento.ToString("dd/MM/yyyy")}";
            Legajo = tecnico.Legajo;

        }
    }
}