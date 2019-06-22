using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.EstudiosClinicos
{
    public class EstudiosClinicosViewModel
    {
        public IEnumerable<EstudioClinicoViewItem> EstudiosClinicos { get; set; }

        public EstudiosClinicosViewModel()
        {
            EstudiosClinicos = Enumerable.Empty<EstudioClinicoViewItem>();
        }
    }
}