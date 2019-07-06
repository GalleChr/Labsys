
using Dominio;
using Presentacion.ViewModels.Pacientes;
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
    [RoutePrefix("Pacientes")]
    public class PacientesController : Controller
    {
        #region Atributos

        private readonly IServicioPaciente _ServicioPaciente;

        #endregion

        #region Constructor

        public PacientesController()
        {
            _ServicioPaciente = new ServiciosPaciente();
        }

        #endregion

        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        [Route("Index", Name = "Pacientes_Index")]
        public ActionResult Index(string apellido)
        {
            var model = new PacientesViewModel()
            {
                Pacientes = _ServicioPaciente.ObtenerPacientes(apellido).Select(x => new PacienteViewItem(x))
            };

            return View(model);
        }

        [HttpGet]
        [Route("Nuevo", Name = "Pacientes_Nuevo")]
        public ActionResult Nuevo()
        {
            return View(
                new NuevoPacienteViewModel()
            {
                FechaNacimiento = DateTime.Now
                });
        }

        [HttpPost]
        [Route("Nuevo", Name = "Pacientes_Nuevo_Post")]    //Consultar con el profe
        public ActionResult Nuevo(NuevoPacienteViewModel model)
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
            else if (model.FechaNacimiento > DateTime.Now.AddYears(-5))
                ModelState.AddModelError("FechaNacimiento", "El paciente debe ser mayor de 5");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioPaciente.AddPaciente(
                        dni: model.Dni,
                        nombre: model.Nombre,
                        apellido: model.Apellido,
                        fecNac: model.FechaNacimiento);

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
        [Route("Eliminar", Name = "Pacientes_Eliminar")]
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var database = new ConexionBD();

                Paciente paciente = database.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }


        [HttpPost]
        [Route("Eliminar", Name = "Pacientes_Eliminar_Post")]
        public ActionResult Eliminar(int id)
        {
            _ServicioPaciente.DeletePaciente(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Editar", Name = "Pacientes_Editar")]
        public ActionResult Editar()
        {
            return View(
            new EditarPacienteViewModel()
            { });
        }


        [HttpPost]
        [Route("Editar", Name = "Pacientes_Editar_Post")]
        public ActionResult Editar(int id, long dni, string nombre, string apellido, DateTime fecNac) //revisar pasandole el paciente que viene del GET
        {
            _ServicioPaciente.UpdatePaciente(id,dni,nombre,apellido,fecNac);

            return RedirectToAction("Index");
        }


    }
}