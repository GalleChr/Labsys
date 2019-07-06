
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

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [Route(Name = "EstudiosClinicos_Index")]
        public ActionResult Index(string fecha)
        {
            var model = new EstudiosClinicosViewModel()
            {
                EstudiosClinicos =
                _ServicioEstudioClinico
                .ObtenerEstudiosClinicos(fecha)
                .Select(x => new EstudioClinicoViewItem(x))
                .ToList()
            };

            return View(model);
        }

        [HttpGet]
        [Route(Name = "EstudiosClinicos_HistorialEstudiosClinicos")]
        public ActionResult HistorialEstudiosClinicos()
        {
            return View(
            new EstudiosClinicosViewModel()
            { });
        }

        [HttpPost]
        [Route(Name = "EstudiosClinicos_HistorialEstudiosClinicos_Post")]
        public ActionResult HistorialEstudiosClinicos(int id)
        {
            _ServicioEstudioClinico.HistorialEstudiosClinicos(id);

            return RedirectToAction("Index");
        }
    };
}