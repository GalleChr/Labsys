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
                    .AddOrUpdate(new Dominio.Paciente()
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

        public void UpdatePaciente(int id, long dni, string nombre, string apellido, DateTime fecNac, string codPac)
        {
            using (var database = new ConexionBD())
            {
                var paciente = database.Pacientes.Find(id);

                paciente.Dni = dni;
                paciente.Nombre = nombre;
                paciente.Apellido = apellido;
                paciente.FechaNacimiento = fecNac;
                paciente.CodPaciente = codPac;

                database.Save();
            }
        }

        public IEnumerable<Paciente> ObtenerPacientes()
        {
            using (var database = new ConexionBD())
            {
                return database
                    .Pacientes
                    .Include(Paciente => Paciente.Turnos)

                    .ToList();
            }
        }

        public static IEnumerable<Paciente> ObtenerPacientesPorApellido(string apellido)
        {
            var database = new ConexionBD();
            List<Paciente> list = new List<Paciente>();
            list = database.Pacientes.Where(b => b.Apellido.Contains(apellido)).ToList();


            IEnumerable<Paciente> pacientes = list;
            return pacientes;


        }

        /*
         * 
        public int Id { get; set; }
        public long Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CodPaciente { get; set; }
        public virtual ICollection<Turno> Turnos { get; set; }
         * */


    }
}
