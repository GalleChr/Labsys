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
        private readonly IServicioSeccion _ServicioSeccion;

        #endregion

        #region Constructor

        public TurnosController()
        {
            _ServicioTurno = new ServiciosTurno();
            _ServicioSeccion = new ServiciosSeccion();
        }

        #endregion

        [HttpGet]
        [Route("Index", Name = "Turnos_Index")]
        public ActionResult Index()
        {
            var model = new TurnosViewModel()
            {
                Turnos = _ServicioTurno.ObtenerTurnos().Select(x => new TurnoViewItem(x))
            };

            return View(model);
        }

        [HttpPost]
        [Route("BuscarEntreFechas", Name = "Turnos_BuscarEntreFechas_Post")]
        public ActionResult BuscarEntreFechas(DateTime? inicio, DateTime? fin)
        {
            var model = new TurnosViewModel()
            {
                Turnos = _ServicioTurno.BuscarEntreFechas(inicio.Value, fin.Value).Select(x => new TurnoViewItem(x))
            };

            return View("Index", model);
        }


        [HttpGet]
        [Route("Nuevo", Name = "Turnos_Nuevo")]
        public ActionResult Nuevo()
        {
            var model = new NuevoTurnoViewModel()
            {
                Fecha = DateTime.Now,
                Secciones = _ServicioSeccion.ObtenerSecciones()
            };

            return View(model);
        }

        [HttpPost]
        [Route("Nuevo", Name = "Turnos_Nuevo_Post")]
        public ActionResult Nuevo(NuevoTurnoViewModel model)
        {

            if (model.DniPaciente <= 0)
                ModelState.AddModelError("DniPaciente", "Debe ingresar un DNI");
            if (model.Fecha == null)
                ModelState.AddModelError("Fecha", "Debe ingresar una fecha");
            else if (model.Fecha <= DateTime.Now)
                ModelState.AddModelError("Fecha", "Se debe elegir una fecha hacia adelante");

            if (!model.SeccionesElegidas.Any())
                ModelState.AddModelError("Secciones", "Debe ingresar al menos una Seccion");

            model.Secciones = _ServicioSeccion.ObtenerSecciones();

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioTurno.AddTurno(
                    dniPac: model.DniPaciente,
                    fecha: model.Fecha,
                    secciones: model.SeccionesElegidas
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

        [HttpGet]
        [Route("TurnosPaciente", Name = "Turnos_TurnosPaciente")]
        public ActionResult TurnosPaciente(int id)
        {
            var model = new TurnosViewModel()
            {
                Turnos = _ServicioTurno.TurnosPaciente(id).Select(x => new TurnoViewItem(x))

            };

            return View(model);
        }

        //[HttpPost]
        //[Route("TurnosPaciente", Name = "Turnos_TurnosPaciente_Post")]
        //public ActionResult TurnosPaciente(int id)
        //{
        //    _ServicioTurno.TurnosPaciente(id);

        //    return RedirectToAction("Index");
        //}



    }
}