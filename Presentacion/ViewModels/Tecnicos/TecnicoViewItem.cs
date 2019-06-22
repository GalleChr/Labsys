using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Tecnicos
{
    public class TecnicoViewItem
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; }
        public long Dni { get; set; }
        public string Edad { get; set; }
        public string Legajo { get; set; }


        public TecnicoViewItem(Tecnico tecnico)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - tecnico.FechaNacimiento.Year;
            if (tecnico.FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            Id = tecnico.Id;
            ApellidoNombre = $"{tecnico.Apellido}, {tecnico.Nombre}";
            Dni = tecnico.Dni;
            Edad = $"{edad} años ({tecnico.FechaNacimiento.ToString("dd/MM/yyyy")})";
            Legajo = tecnico.Legajo;

        }
    }
}