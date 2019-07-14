using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.ViewModels.EstudiosClinicos
{
    public class EstudioClinicoViewItem
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; }
        public string Fecha { get; set; }
        public string Tipo { get; set; }
        public int ContSecciones { get; set; }



        public EstudioClinicoViewItem(EstudioClinico estudioClinico)
        {
            Id = estudioClinico.Id;
            //    ApellidoNombre = $"{estudioClinico.Turno.Paciente.Apellido}, {estudioClinico.Turno.Paciente.Nombre}";
            ApellidoNombre = estudioClinico.Turno.Paciente.Nombre + " " + estudioClinico.Turno.Paciente.Apellido;
            Fecha = estudioClinico.Turno.Fecha.ToString("dd/MM/yyyy");
            Tipo = estudioClinico.Secciones.FirstOrDefault().Tipo.Descrip;
            ContSecciones = estudioClinico.Secciones.Count();
        }
    }
}