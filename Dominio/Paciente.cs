using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Paciente
    {

        #region Attributes

        public int Id { get; set; }
        public long Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CodPaciente { get; set; }
        public virtual ICollection<Turno> Turnos { get; set; }

        #endregion

        #region Constructor

        public Paciente()
        {
            Turnos = new HashSet<Turno>();
        }

        #endregion
    }
}
