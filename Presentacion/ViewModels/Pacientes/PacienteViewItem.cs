using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Pacientes
{
    public class PacienteViewItem
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; }
        public long Dni { get; set; }
        public string Edad { get; set; }
        public string CodPaciente { get; set; }
        public int ContTurnos { get; set; }

        public PacienteViewItem(Paciente paciente)
        {
            int count = 0;
            var hoy = DateTime.Today;
            var edad = hoy.Year - paciente.FechaNacimiento.Year;
            if (paciente.FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            foreach (Turno turno in paciente.Turnos)
            {

                if (turno.Estado == Estado.PENDIENTE)
                {
                    count++;
                }
            }

            Id = paciente.Id;
            ApellidoNombre = $"{paciente.Apellido}, {paciente.Nombre}";
            Dni = paciente.Dni;
            Edad = $"{edad} años ({paciente.FechaNacimiento.ToString("dd/MM/yyyy")})";
            ContTurnos = count;

        }
    }
}