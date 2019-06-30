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

        public IEnumerable<EstudioClinico> ObtenerEstudiosClinicosPorPaciente(int id)
        {
            using (var database = new ConexionBD())
            {
                return database
                    .EstudiosClinicos
                    .Include(ec => ec.Turno)
                    .Include(ec => ec.Secciones)
                    .Where(ec => ec.Turno.Paciente.Id.Equals(id))

                    .ToList();
            }
        }


        public void AddEstudioClinico(Turno turno, ICollection<Seccion> secciones)
        {

            using (var database = new ConexionBD())
            {
                database.EstudiosClinicos
                    .Add(new Dominio.EstudioClinico()
                    {
                        Turno = turno,
                        Secciones = secciones
                    }
                    );
                database.Save();
            }

        }

    }   
   }
