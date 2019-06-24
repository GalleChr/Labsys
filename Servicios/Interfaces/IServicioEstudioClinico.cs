using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IServicioEstudioClinico
    {
        IEnumerable<EstudioClinico> ObtenerEstudiosClinicos();

        IEnumerable<EstudioClinico> ObtenerEstudiosClinicosPorPaciente(int id);
    }
}
