
using Dominio;
using Presentacion.ViewModels.Tecnicos;
using Servicios;
using Servicios.DB;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [Route("Index", Name = "Tecnicos_Index")]
        public ActionResult Index(string apellido)
        {
            var model = new TecnicosViewModel()
            {
                Tecnicos = _ServicioTecnico.ObtenerTecnicos(apellido).Select(x => new TecnicoViewItem(x))
            };

            return View(model);
        }


        [HttpGet]
        [Route("Nuevo", Name = "Tecnicos_Nuevo")]
        public ActionResult Nuevo()
        {
            return View(
                new NuevoTecnicoViewModel()
                {
                    FechaNacimiento = DateTime.Now
                });
        }

        [HttpPost]
        [Route("Nuevo", Name = "Tecnicos_Nuevo_Post")]    //Consultar con el profe
        public ActionResult Nuevo(NuevoTecnicoViewModel model)
        {
            bool containsIntNom = false;
            bool containsIntApe = false;

            if (model.Dni <= 0)
                ModelState.AddModelError("Dni", "Debe ingresar un DNI");

            if (string.IsNullOrWhiteSpace(model.Nombre))
                ModelState.AddModelError("Nombre", "Debe ingresar un nombre");
            else if (containsIntNom = model.Nombre.Any(char.IsDigit))
                ModelState.AddModelError("Nombre", "No se deben ingresar numeros");

            if (string.IsNullOrWhiteSpace(model.Apellido))
                ModelState.AddModelError("Apellido", "Debe ingresar un apellido");
            else if (containsIntApe = model.Apellido.Any(char.IsDigit))
                ModelState.AddModelError("Apellido", "No se deben ingresar numeros");

            if (model.FechaNacimiento == null)
                ModelState.AddModelError("FechaNacimiento", "Debe ingresar fecha de nacimiento");
            else if (model.FechaNacimiento > DateTime.Now.AddYears(-21))
                ModelState.AddModelError("FechaNacimiento", "El paciente debe ser mayor de 21");
            if (string.IsNullOrWhiteSpace(model.Legajo))
                ModelState.AddModelError("Legajo", "Debe ingresar un Legajo");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioTecnico.AddTecnico(
                        dni: model.Dni,
                        nombre: model.Nombre,
                        apellido: model.Apellido,
                        fecNac: model.FechaNacimiento,
                        legajo: model.Legajo
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


        [HttpGet]
        [Route("Eliminar", Name = "Tecnicos_Eliminar")]
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var database = new ConexionBD();

            Tecnico tecnico = database.Tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }


        [HttpPost]
        [Route("Eliminar", Name = "Tecnicos_Eliminar_Post")]
        public ActionResult Eliminar(int id)
        {
            _ServicioTecnico.DeleteTecnico(id);

            return RedirectToAction("Index");
        }
    }
}