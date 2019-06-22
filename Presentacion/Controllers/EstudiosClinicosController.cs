
using Presentacion.ViewModels.EstudiosClinicos;
using Servicios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EstudiosClinicosController : Controller
    { 
    #region Atributos

    private readonly IServicioEstudioClinico _ServicioEstudioClinico;

    #endregion

    #region Constructor

    public EstudiosClinicosController()
    {
            _ServicioEstudioClinico = new ServiciosEstudioClinico();
    }

    #endregion

    [HttpGet]
    [Route(Name = "EstudiosClinicos_Index")]
    public ActionResult Index()
    {
        var model = new EstudiosClinicosViewModel()
        {
            EstudiosClinicos = 
            _ServicioEstudioClinico
            .ObtenerEstudiosClinicos()
            .Select(x => new EstudioClinicoViewItem(x))
            .ToList()
        };

        return View(model);
    }
}
}