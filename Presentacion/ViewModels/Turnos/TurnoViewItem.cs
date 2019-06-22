using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Turnos
{
    public class TurnoViewItem
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string NomPac { get; set; } 
        public string NomTec { get; set; }
        public string Fecha { get; set; }
     //   public int IdEstCli { get; set; }

        public TurnoViewItem(Turno turno)
        {
            Id = turno.Id;
            Estado = turno.Estado.ToString();
            NomPac = turno.Paciente.Nombre + " " + turno.Paciente.Apellido;
            NomTec = turno.Tecnico.Nombre + " " + turno.Tecnico.Apellido;
            Fecha = turno.Fecha.ToString("dd/MM/yyyy");
      //      IdEstCli = turno.EstudioClinico.Id;

        }



    }
}