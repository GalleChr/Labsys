
using Presentacion.ViewModels.EstudiosClinicos;
using Servicios;
using Servicios.DB;
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
        [Route("Index", Name = "EstudiosClinicos_Index")]
        public ActionResult Index()
        {
            var model = new EstudiosClinicosViewModel()
            {
                EstudiosClinicos = _ServicioEstudioClinico.ObtenerEstudiosClinicos().Select(x => new EstudioClinicoViewItem(x))

            };

            return View(model);
        }

        [HttpPost]
        [Route("BuscarPorFecha", Name = "EstudiosClinicos_BuscarPorFecha_Post")]
        public ActionResult BuscarPorFecha(DateTime? fecha)
        {
            var model = new EstudiosClinicosViewModel()
            {
                EstudiosClinicos = _ServicioEstudioClinico.BuscarPorFecha(fecha.Value).Select(x => new EstudioClinicoViewItem(x))
            };

            return View("Index", model);
        }

        //[HttpGet]
        //[Route(Name = "EstudiosClinicos_HistorialEstudiosClinicos")]
        //public ActionResult HistorialEstudiosClinicos(int id)
        //{
        //    var database = new ConexionBD();

        //    EstudiosClinicosViewModel model = new EstudiosClinicosViewModel(id);

        //    return View(model);
        //}


        [HttpGet]
        [Route("HistorialEstudiosClinicos", Name = "EstudiosClinicos_HistorialEstudiosClinicos")]
        public ActionResult HistorialEstudiosClinicos(int id)
        {
            var model = new EstudiosClinicosViewModel()
            {
                EstudiosClinicos = _ServicioEstudioClinico.HistorialEstudiosClinicos(id).Select(x => new EstudioClinicoViewItem(x))

            };

            return View(model);
        }

        //[HttpPost]
        //[Route("HistorialEstudiosClinicos", Name = "EstudiosClinicos_HistorialEstudiosClinicos_Post")]
        //public ActionResult HistorialEstudiosClinicos(HistorialEstudiosClinicosViewModel model)
        //{

        //    model.EstudiosClinicos = _ServicioEstudioClinico.HistorialEstudiosClinicos(model.Id).Select(x => new EstudioClinicoViewItem(x));

        //    return View("Index", model);
        //}

        //[HttpPost]
        //[Route("HistorialEstudiosClinicos", Name = "EstudiosClinicos_HistorialEstudiosClinicos_Post")]
        //public ActionResult HistorialEstudiosClinicos(int id)
        //{
        //    var model = new EstudiosClinicosViewModel()
        //    {
        //        EstudiosClinicos = _ServicioEstudioClinico.HistorialEstudiosClinicos(id).Select(x => new EstudioClinicoViewItem(x))
        //    };

        //    return View("Index", model);
        //}
    };
}