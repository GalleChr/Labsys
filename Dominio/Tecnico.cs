using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Tecnico
    {
        #region Attributes

        public int Id { get; set; }
        public long Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Legajo { get; set; }
        public Boolean Status { get; set; }


        #endregion

        #region Constructor

        public Tecnico() { }

        #endregion
    }
}
