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

        void AddTurno(long dniPac, DateTime fecha, IEnumerable<int> secciones);

        void DeleteTurno(int id);

        IEnumerable<Turno> BuscarEntreFechas(DateTime inicio, DateTime fin);

        void SetEstadoCancelado(int id);

        void SetEstadoConfirmado();

        IEnumerable<Turno> TurnosPaciente(int id);
    }
}
