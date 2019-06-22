using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models.Tecnicos
{
    public class TecnicosViewModel
    {
        public IEnumerable<TecnicosViewModel> Tecnicos { get; set; }

        public TecnicosViewModel()
        {
            Tecnicos = Enumerable.Empty<TecnicosViewModel>();
        }
    }
}