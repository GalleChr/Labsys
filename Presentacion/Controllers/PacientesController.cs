
using Presentacion.ViewModels.Pacientes;
using Servicios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        [Route(Name = "Pacientes_Index")]
        public ActionResult Index()
        {
            var model = new PacientesViewModel()
            {
                Pacientes = _ServicioPaciente.ObtenerPacientes().Select(x => new PacienteViewItem(x))
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
        [Route("Nuevo", Name = "Pacientes_Nuevo")]    //Consultar con el profe
        public ActionResult Nuevo(NuevoPacienteViewModel model)
        {
      //      bool containsIntNom = model.Nombre.Any(char.IsDigit);
      //      bool containsIntApe = model.Apellido.Any(char.IsDigit);


            if (model.Dni <= 0)
                ModelState.AddModelError("Dni", "Debe ingresar un DNI");

            if (string.IsNullOrWhiteSpace(model.Nombre))
                ModelState.AddModelError("Nombre", "Debe ingresar un nombre");
      //      else if (containsIntNom)
      //          ModelState.AddModelError("Nombre", "No se deben ingresar numeros en el campo Nombre");

            if (string.IsNullOrWhiteSpace(model.Apellido))
                ModelState.AddModelError("Apellido", "Debe ingresar un apellido");
     //       else if (containsIntApe)
     //           ModelState.AddModelError("Apellido", "No se deben ingresar numeros en el campo Apellido");

            if (model.FechaNacimiento == null)
                ModelState.AddModelError("FechaNacimiento", "Debe ingresar fecha de nacimiento");
            else if (model.FechaNacimiento > DateTime.Now.AddYears(-18))
                ModelState.AddModelError("FechaNacimiento", "El alumno debe ser mayor de 18");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioPaciente.AddPaciente(
                        dni: model.Dni,
                        nombre: model.Nombre,
                        apellido: model.Apellido,
                        fecNac: model.FechaNacimiento);

                    return RedirectToRoute("Pacientes_Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }


    }
}