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

        //public void Test()
        //{
        //    using (var database = new ConexionBD())
        //    {
        //        var turno1 = database.Turnos.Find(1);
        //        var seccion1 = database.Secciones.Find(1);
        //        var seccion2 = database.Secciones.Find(2);

        //        var estudioClinico = new EstudioClinico()
        //        {
        //            Turno = turno1
        //        };

        //        estudioClinico.Secciones.Add(seccion1);
        //        estudioClinico.Secciones.Add(seccion2);

        //        database.EstudiosClinicos.Add(estudioClinico);
        //        database.Turnos.Attach(turno1);
        //        database.Secciones.Attach(seccion1);
        //        database.Secciones.Attach(seccion2);
        //        database.SaveChanges();
        //    }

        //}
    }
}
