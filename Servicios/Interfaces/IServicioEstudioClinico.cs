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

        void AddEstudioClinico(int turnoId, IEnumerable<int> secciones);

        IEnumerable<EstudioClinico> HistorialEstudiosClinicos(int id);

        IEnumerable<EstudioClinico> BuscarPorFecha(DateTime fecha);
    }
}
