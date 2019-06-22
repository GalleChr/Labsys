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
    public class ServiciosTurno : IServicioTurno
    {
        public void AddTurno(Paciente paciente, Tecnico tecnico, EstudioClinico estudio, DateTime fecha)
        {

            using (var database = new ConexionBD())
            {
                database.Turnos
                    .AddOrUpdate(new Dominio.Turno()
                    {
                        Estado = Estado.PENDIENTE,
                        Paciente = paciente,
                        Tecnico = tecnico,
                        Fecha = fecha
                    }
                    );
                database.Save();
            }

        }

        public void DeleteTurno(int id)
        {
            using (var database = new ConexionBD())
            {
                var turno = database.Turnos.Find(id);

                database.Turnos.Remove(turno);
                database.Save();
            }
        }

        public IEnumerable<Turno> ObtenerTurnos()
        {
            using (var database = new ConexionBD())
            {
                return database
                    .Turnos

                    .Include(Turno => Turno.Paciente)
                    .Include(Turno => Turno.Tecnico)

                    .ToList();
            }
        }
    }
}
