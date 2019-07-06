using Dominio;
using Servicios.DB;
using Servicios.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Servicios
{
    public class ServiciosSeccion : IServicioSeccion
    {
        public IEnumerable<Seccion> ObtenerSecciones()
        {
            using (var database = new ConexionBD())
            {
                    return database
                     .Secciones
                     .Include(s => s.Tipo)
                     .ToList();
            }
        }
    }
}

