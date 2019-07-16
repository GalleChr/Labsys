using Dominio;
using Servicios.DB;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServiciosTecnico : IServicioTecnico
    {
        public void AddTecnico(long dni, string nombre, string apellido, DateTime fecNac, string legajo)
        {
            Tecnico tec = null;

            using (var database = new ConexionBD())
            {
                tec = database.Tecnicos.FirstOrDefault(x => x.Dni == dni);

                if (tec != null)
                {
                    throw new Exception("Ya existe un tecnico con el Dni ingresado.");

                }
                else
                {
                    database.Tecnicos
                    .AddOrUpdate(new Dominio.Tecnico()
                    {
                        Dni = dni,
                        Nombre = nombre,
                        Apellido = apellido,
                        FechaNacimiento = fecNac,
                        Legajo = legajo,
                        Status = true
                    }
                    );
                    database.Save();
                }
            }

        }

        public void DeleteTecnico(int id)
        {
            using (var database = new ConexionBD())
            {
                var tecnico = database.Tecnicos.Find(id);

                tecnico.Status = false;

                database.Save();

            }
        }

        public void UpdateTecnico(int id, long dni, string nombre, string apellido, DateTime fecNac, string legajo)
        {
            using (var database = new ConexionBD())
            {
                var tecnico = database.Tecnicos.Find(id);

                tecnico.Dni = dni;
                tecnico.Nombre = nombre;
                tecnico.Apellido = apellido;
                tecnico.FechaNacimiento = fecNac;
                tecnico.Legajo = legajo;

                database.Save();
            }
        }

        public IEnumerable<Tecnico> ObtenerTecnicos(string apellido)
        {
            using (var database = new ConexionBD())
            {
                if (!string.IsNullOrWhiteSpace(apellido))
                {
                    return database
                        .Tecnicos
                        .Where(tecnico => tecnico.Apellido.StartsWith(apellido) && tecnico.Status == true)
                        .ToList();
                }

                return database
                    .Tecnicos
                    .Where(tecnico => tecnico.Status == true)
                    .ToList();

            }
        }
    }
}
