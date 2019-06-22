
using Presentacion.ViewModels.Tecnicos;
using Servicios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class TecnicosController : Controller
    {
        #region Atributos

        private readonly IServicioTecnico _ServicioTecnico;

        #endregion

        #region Constructor

        public TecnicosController()
        {
            _ServicioTecnico = new ServiciosTecnico();
        }

        #endregion

        [HttpGet]
        [Route(Name = "Tecnicos_Index")]
        public ActionResult Index()
        {
            var model = new TecnicosViewModel()
            {
                Tecnicos = _ServicioTecnico.ObtenerTecnicos().Select(x => new TecnicoViewItem(x))
            };

            return View(model);
        }
    }
}