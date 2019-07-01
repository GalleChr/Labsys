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
        private ServiciosEstudioClinico _ServiciosEC = new ServiciosEstudioClinico();

        public void AddTurno(long dniPac, long dniTec, DateTime fecha, ICollection<Seccion> secciones)
        {

            using (var database = new ConexionBD())
            {
                Paciente paciente = null;
                paciente = database.Pacientes.Find(paciente.Dni = dniPac);

                Tecnico tecnico = null;
                tecnico = database.Tecnicos.Find(tecnico.Dni = dniTec);

                Turno turno = new Turno
                {
                    Estado = Estado.PENDIENTE,
                    Paciente = paciente,
                    Tecnico = tecnico,
                    Fecha = fecha
                };

                database.Turnos.Add(turno);

                _ServiciosEC.AddEstudioClinico(turno, secciones);


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


        public IEnumerable<Turno> TurnosEntreFechas(DateTime inicio, DateTime fin) //REVISAR CON PROFE
        {
            using (var database = new ConexionBD())
            {
                return database
                    .Turnos
                    .Include(turno => turno.Paciente)
                    .Include(turno => turno.Tecnico)
                    .Include(turno => turno.Estado)
                    .Where(turno => turno.Fecha >= inicio && turno.Fecha <= fin)

                    .ToList();
            }
        }

        public void SetEstadoCancelado(int id)
        {

            using (var database = new ConexionBD())
            {
                var turno = database.Turnos.Find(id);

                turno.Estado = Estado.CANCELADO;

                database.Save();
            }

        }

        public void SetEstadoConfirmado() // REVISAR CON PROFE
        {
            using (var database = new ConexionBD())
            {
                IEnumerable<Turno> turnos = database.Turnos;

                foreach (Turno turno in turnos)
                {
                    if (turno.Fecha > DateTime.Now)
                    {
                        turno.Estado = Estado.CONFIRMADO;
                    }
                } 

                database.Save();
            }


        }
    }
}

