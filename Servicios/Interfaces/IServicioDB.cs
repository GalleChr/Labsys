using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IServicioDB
    {
        IDbSet<Paciente> Pacientes { get; set; }
        IDbSet<Tecnico> Tecnicos { get; set; }
        IDbSet<EstudioClinico> EstudiosClinicos { get; set; }
        IDbSet<Turno> Turnos { get; set; }
        IDbSet<Seccion> Secciones { get; set; }
        IDbSet<Tipo> Tipos { get; set; }

        void Save();
    }
}
