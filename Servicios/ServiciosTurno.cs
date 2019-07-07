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

        public void AddTurno(long dniPac, DateTime fecha, IEnumerable<int> secciones)
        {
            Turno turno = null;

            using (var database = new ConexionBD())
            {
                Paciente paciente = database.Pacientes.FirstOrDefault(p => p.Dni == dniPac);

                var maxId = database.Tecnicos.Max(x => x.Id);

                Tecnico tecnico = database.Tecnicos.Find(new Random().Next(1, maxId));

                Turno existente = database.Turnos.FirstOrDefault(x => x.Fecha == fecha);

                if (existente == null && paciente != null)
                {
                    turno = new Turno
                    {
                        Estado = Estado.PENDIENTE,
                        Paciente = paciente,
                        Tecnico = tecnico,
                        Fecha = fecha
                    };

                    database.Turnos.Add(turno);

                    database.Save();
                }
            }

            if (turno != null)
                _ServiciosEC.AddEstudioClinico(turno.Id, secciones);
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

                SetEstadoConfirmado();

                return database
                 .Turnos

                 .Include(Turno => Turno.Paciente)
                 .Include(Turno => Turno.Tecnico)

                 .ToList();


            }
        }


        public IEnumerable<Turno> BuscarEntreFechas(DateTime inicio, DateTime fin) //REVISAR CON PROFE
        {
            var fechaInicio = inicio.Date.AddMilliseconds(-1);
            var fechaFin = fin.Date.Date.AddDays(1).AddMilliseconds(-1);

            using (var database = new ConexionBD())
            {
                return database
                    .Turnos
                    .Include(turno => turno.Paciente)
                    .Include(turno => turno.Tecnico)

                    .Where(turno => turno.Fecha >= fechaInicio && turno.Fecha <= fechaFin)

                    .ToList();
            }
        }

        public void SetEstadoCancelado(int id)
        {

            using (var database = new ConexionBD())
            {
                var turno = database.Turnos.Find(id);

                if (turno.Estado == Estado.PENDIENTE)
                {
                    turno.Estado = Estado.CANCELADO;
                }
                database.Save();
            }

        }

        public void SetEstadoConfirmado()
        {
            using (var database = new ConexionBD())
            {
                IEnumerable<Turno> turnos = database.Turnos;

                foreach (Turno turno in turnos)
                {
                    if (turno.Estado != Estado.CANCELADO)
                    {
                        if (turno.Fecha < DateTime.Now)
                        {
                            turno.Estado = Estado.CONFIRMADO;
                        }
                    }
                }

                database.Save();
            }


        }

        public IEnumerable<Turno> TurnosPaciente(int id)
        {

            using (var database = new ConexionBD())
            {
                IEnumerable<Turno> turnos = database.Turnos;
                IEnumerable<Turno> turnosPaciente = null;

                foreach (Turno turno in turnos)
                {
                    if (turno.Paciente.Id == id && turno.Estado == Estado.PENDIENTE)
                    {
                        turnosPaciente.Append(turno);
                    }
                }
                return turnosPaciente.ToList();
            }
        }
    }
}

