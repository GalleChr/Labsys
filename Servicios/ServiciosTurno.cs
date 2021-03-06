﻿using Dominio;
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

                if (paciente != null && paciente.Status == true)
                {

                    var maxId = database.Tecnicos.Max(x => x.Id);

                    Tecnico tecnico = database.Tecnicos.Find(new Random().Next(1, maxId));

                    while (tecnico.Status == false)
                    {
                        tecnico = database.Tecnicos.Find(new Random().Next(1, maxId));
                    }

                    Turno existente = database.Turnos.FirstOrDefault(x => x.Fecha == fecha);

                    if (existente == null)
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
                    else
                    {
                        throw new Exception("Ya existe un turno en el dia seleccionado.");
                    }
                }
                else
                {
                    throw new Exception("El paciente no existe o fue deshabilitado.");
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

                 .Include(turno => turno.Paciente)
                 .Include(turno => turno.Tecnico)
                 .Where(turno => turno.Paciente.Status == true && turno.Tecnico.Status == true)

                 .ToList();


            }
        }


        public IEnumerable<Turno> BuscarEntreFechas(DateTime inicio, DateTime fin)
        {
            var fechaInicio = inicio.Date.AddMilliseconds(-1);
            var fechaFin = fin.Date.Date.AddDays(1).AddMilliseconds(-1);

            using (var database = new ConexionBD())
            {
                return database
                    .Turnos
                    .Include(turno => turno.Paciente)
                    .Include(turno => turno.Tecnico)

                    .Where(turno => turno.Fecha >= fechaInicio && turno.Fecha <= fechaFin && turno.Tecnico.Status == true && turno.Paciente.Status == true)

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
                return database
                    .Turnos
                    .Include(turno => turno.Paciente)
                    .Include(turno => turno.Tecnico)
                    .Where(turno => turno.Paciente.Id == id && turno.Estado == Estado.PENDIENTE && turno.Tecnico.Status == true)

                    .ToList();
            }
        }
    }
}

