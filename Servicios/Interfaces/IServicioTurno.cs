using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IServicioTurno
    {
        IEnumerable<Turno> ObtenerTurnos();
    }
}
