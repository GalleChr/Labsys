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
    public class ServiciosEstudioClinico : IServicioEstudioClinico
    {

        public IEnumerable<EstudioClinico> ObtenerEstudiosClinicos()
        {

            using (var database = new ConexionBD())
            {

                return database
                .EstudiosClinicos
                .Include(EstudioClinico => EstudioClinico.Secciones)
                .Include(EstudioClinico => EstudioClinico.Turno)
                .Include(EstudioClinico => EstudioClinico.Turno.Paciente)
                .Include(EstudioClinico => EstudioClinico.Turno.Tecnico)
                .Include(EstudioClinico => EstudioClinico.Secciones.Select(x => x.Tipo))
                .ToList();
            }
        }

        public IEnumerable<EstudioClinico> BuscarPorFecha(DateTime fecha) //REVISAR CON PROFE
        {

            using (var database = new ConexionBD())
            {
                return database
                .EstudiosClinicos
                .Include(EstudioClinico => EstudioClinico.Secciones)
                .Include(EstudioClinico => EstudioClinico.Turno)
                .Include(EstudioClinico => EstudioClinico.Turno.Paciente)
                .Include(EstudioClinico => EstudioClinico.Turno.Tecnico)
                .Include(EstudioClinico => EstudioClinico.Secciones.Select(x => x.Tipo))
                .Where(estudioClinico => estudioClinico.Turno.Fecha.Day == fecha.Day)
                .ToList();
            }
        }

        public IEnumerable<EstudioClinico> ObtenerEstudiosClinicosPorPaciente(int id)
        {
            using (var database = new ConexionBD())
            {
                return database
                    .EstudiosClinicos
                    .Include(ec => ec.Turno)
                    .Include(ec => ec.Secciones)
                    .Where(ec => ec.Turno.Paciente.Id == id)

                    .ToList();
            }
        }


        public void AddEstudioClinico(int turnoId, IEnumerable<int> secciones)
        {
            using (var database = new ConexionBD())
            {
                var turno = database.Turnos.Find(turnoId);

                var estudioClinico = new EstudioClinico()
                {
                    Turno = turno
                };

                foreach (var seccion in database.Secciones.Where(x => secciones.Contains(x.Id)))
                {
                    estudioClinico.Secciones.Add(seccion);
                    database.Secciones.Attach(seccion);
                }

                database.EstudiosClinicos.Add(estudioClinico);

                database.Turnos.Attach(turno);

                database.Save();
            }

        }


        public IEnumerable<EstudioClinico> HistorialEstudiosClinicos(int id)
        {
            using (var database = new ConexionBD())
            {
                return database
                .EstudiosClinicos
                .Include(EstudioClinico => EstudioClinico.Secciones)
                .Include(EstudioClinico => EstudioClinico.Turno)
                //             .Include(EstudioClinico => EstudioClinico.Turno.Paciente)
                //             .Include(EstudioClinico => EstudioClinico.Turno.Tecnico)
                //             .Include(EstudioClinico => EstudioClinico.Secciones.Select(x => x.Tipo))
                .Where(ec => ec.Turno.Paciente.Id == id && ec.Turno.Estado == Estado.CONFIRMADO)
                .ToList();
            }
        }




    }
}
