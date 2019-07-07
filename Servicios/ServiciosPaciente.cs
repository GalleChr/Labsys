using Dominio;
using Servicios.DB;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServiciosPaciente : IServicioPaciente
    {
        public void AddPaciente(long dni, string nombre, string apellido, DateTime fecNac)
        {

            using (var database = new ConexionBD())
            {
                database.Pacientes
                    .Add(new Paciente()
                    {
                        Dni = dni,
                        Nombre = nombre,
                        Apellido = apellido,
                        FechaNacimiento = fecNac,
                    }
                    );
                database.Save();
            }

        }

        public void DeletePaciente(int id)
        {
            using (var database = new ConexionBD())
            {
                var paciente = database.Pacientes.Find(id);

                database.Pacientes.Remove(paciente);
                database.Save();
            }
        }

        public void UpdatePaciente(int id, long dni, string nombre, string apellido, DateTime fecNac)
        {
            using (var database = new ConexionBD())
            {
                var paciente = database.Pacientes.Find(id);

                paciente.Dni = dni;
                paciente.Nombre = nombre;
                paciente.Apellido = apellido;
                paciente.FechaNacimiento = fecNac;

                database.Save();
            }
        }

        public IEnumerable<Paciente> ObtenerPacientes(string apellido)
        {
            using (var database = new ConexionBD())
            {
                if(!string.IsNullOrWhiteSpace(apellido))
                {
                    return database
                        .Pacientes
                        .Include(Paciente => Paciente.Turnos)
                        .Where(paciente => paciente.Apellido.StartsWith(apellido))
                        .ToList();
                }

                return database
                    .Pacientes
                    .Include(Paciente => Paciente.Turnos)
                    .ToList();

            }
        }
    }
}
