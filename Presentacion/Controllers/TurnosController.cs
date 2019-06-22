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
    }
}