using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.EstudiosClinicos
{
    public class HistorialEstudiosClinicosViewModel
    {
        public int Id { get; set; }
        public IEnumerable<EstudioClinico> EstudiosClinicos { get; set; }



        public HistorialEstudiosClinicosViewModel() { }

        public HistorialEstudiosClinicosViewModel(int id)
        {
            Id = id;
        }
    }



}