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

            using (var database = new ConexionBD())
            {
                database.Tecnicos
                    .AddOrUpdate(new Dominio.Tecnico()
                    {
                        Dni = dni,
                        Nombre = nombre,
                        Apellido = apellido,
                        FechaNacimiento = fecNac,
                        Legajo = legajo
                    }
                    );
                database.Save();
            }

        }

        public void DeleteTecnico(int id)
        {
            using (var database = new ConexionBD())
            {
                var tecnico = database.Tecnicos.Find(id);

                database.Tecnicos.Remove(tecnico);
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

        public IEnumerable<Tecnico> ObtenerTecnicos()
        {
            using (var database = new ConexionBD())
            {
                return database
                    .Tecnicos

                    .ToList();
            }
        }
    }
}
