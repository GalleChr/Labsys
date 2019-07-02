using Presentacion.ViewModels.Turnos;
using Servicios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class TurnosController : Controller
    {
        #region Atributos

        private readonly IServicioTurno _ServicioTurno;
        private readonly IServicioEstudioClinico _ServicioEstudioClinico;

        #endregion

        #region Constructor

        public TurnosController()
        {
            _ServicioTurno = new ServiciosTurno();
        }

        #endregion

        [HttpGet]
        [Route(Name = "Turnos_Index")]
        public ActionResult Index()
        {
            var model = new TurnosViewModel()
            {
                Turnos = _ServicioTurno.ObtenerTurnos().Select(x => new TurnoViewItem(x))
            };

            return View(model);
        }


        [HttpGet]
        [Route(Name = "Turnos_BuscarEntreFechas")]
        public ActionResult BuscarEntreFechas()
        {
            return View(
                new TurnosViewModel()
                {});
        }


        [HttpPost]
        [Route(Name = "Turnos_BuscarEntreFechas_Post")]
        public ActionResult BuscarEntreFechas(DateTime inicio, DateTime fin)
        {
            var model = new TurnosViewModel()
            {
                Turnos = _ServicioTurno.BuscarEntreFechas(inicio, fin).Select(x => new TurnoViewItem(x))
            };

            return View(model);
        }


        [HttpGet]
        [Route("Nuevo", Name = "Turnos_Nuevo")]
        public ActionResult Nuevo()
        {
            return View(
                new NuevoTurnoViewModel()
                {
                    Fecha = DateTime.Now
                });
        }

        [HttpPost]
        [Route("Nuevo", Name = "Turnos_Nuevo_Post")]
        public ActionResult Nuevo(NuevoTurnoViewModel model)
        {

            if (model.DniPaciente <= 0)
                ModelState.AddModelError("DniPaciente", "Debe ingresar un DNI");

            if (model.DniTecnico <= 0)
                ModelState.AddModelError("DniTecnico", "Debe ingresar un DNI");

            if (model.Fecha == null)
                ModelState.AddModelError("Fecha", "Debe ingresar una fecha");
            else if (model.Fecha <= DateTime.Now)
                ModelState.AddModelError("Fecha", "Se debe elegir una fecha hacia adelante");

            if (model.Secciones == null)
                ModelState.AddModelError("Secciones", "Debe ingresar al menos una Seccion");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioTurno.AddTurno(
                        dniPac: model.DniPaciente,
                        dniTec: model.DniTecnico,
                        fecha: model.Fecha,
                        secciones: model.Secciones
                        );


                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }


        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [Route("Cancelar", Name = "Turnos_Cancelar_Post")]
        public ActionResult Cancelar(int id)
        {
            _ServicioTurno.SetEstadoCancelado(id);

            return RedirectToAction("Index");
        }


    }
}