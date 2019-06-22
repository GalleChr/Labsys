using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class EstudioClinico
    {
        #region Attributes

        public int Id { get; set; }
        public virtual ICollection<Seccion> Secciones { get; set; }
        public virtual Turno Turno { get; set; }

        #endregion

        #region Constructor

        public EstudioClinico()
        {
            Secciones = new HashSet<Seccion>();
        }

        #endregion
    }
}
