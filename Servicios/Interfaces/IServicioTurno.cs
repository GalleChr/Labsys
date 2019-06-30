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

        void AddTurno(long dniPac, long dniTec, DateTime fecha, ICollection<Seccion> secciones);

        void DeleteTurno(int id);

        IEnumerable<Turno> TurnosEntreFechas(DateTime inicio, DateTime fin);

        void SetEstadoCancelado(int id);

        void SetEstadoConfirmado();
    }
}
