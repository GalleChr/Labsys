using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IServicioPaciente
    {
        IEnumerable<Paciente> ObtenerPacientes(string apellido);

        void AddPaciente(long dni, string nombre, string apellido, DateTime fecNac);

        void DeletePaciente(int id);

        void UpdatePaciente(int id, long dni, string nombre, string apellido, DateTime fecNac, string codPac);

    }
}
