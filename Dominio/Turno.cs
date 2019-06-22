using System;

namespace Dominio
{

    [Serializable]
    public class Turno
    {
        #region Attributes

        public int Id { get; set; }
        public Estado Estado { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Tecnico Tecnico { get; set; }
        public virtual EstudioClinico EstudioClinico { get; set; }
        public DateTime Fecha { get; set; }

        #endregion

        #region Constructor

        public Turno() { }

        #endregion
    }
}
