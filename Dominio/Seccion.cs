using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Seccion
    {
        public int Id { get; set; }
        public string Descrip { get; set; }
        public virtual Tipo Tipo { get; set; } //virtual = permite que se sobreescriba
        public virtual ICollection<EstudioClinico> EstudiosClinicos { get; set; }


        public Seccion() {

            EstudiosClinicos = new HashSet<EstudioClinico>();
        }
    }


}