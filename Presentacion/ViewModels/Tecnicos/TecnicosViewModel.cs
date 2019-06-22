using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.Tecnicos
{
    public class TecnicosViewModel
    {
        public IEnumerable<TecnicoViewItem> Tecnicos { get; set; }

        public TecnicosViewModel()
        {
            Tecnicos = Enumerable.Empty<TecnicoViewItem>();
        }
    }
}