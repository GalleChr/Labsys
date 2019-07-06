using Dominio;
using System.Collections.Generic;

namespace Servicios.Interfaces
{
    public interface IServicioSeccion
    {
        IEnumerable<Seccion> ObtenerSecciones();
    }
}
