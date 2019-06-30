using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IServicioTecnico
    {
        IEnumerable<Tecnico> ObtenerTecnicos(string apellido);

        void AddTecnico(long dni, string nombre, string apellido, DateTime fecNac, string legajo);

        void DeleteTecnico(int id);

        void UpdateTecnico(int id, long dni, string nombre, string apellido, DateTime fecNac, string legajo);
        
    }
}
