﻿using Dominio;
using System;
using System.Data.Entity;
using System.Linq;

namespace Servicios.DB
{
    public class Inicializacion
        : DropCreateDatabaseIfModelChanges<ConexionBD>, IDatabaseInitializer<ConexionBD>
    {
        public Inicializacion()
        {
        }

        protected override void Seed(ConexionBD database)
        {
            if (database.Tecnicos.Any())
                return;

            #region Tecnicos Seed

            database.Tecnicos.Add(new Tecnico() { Nombre = "Tec1", Apellido = "Nico1", FechaNacimiento = DateTime.Now.AddDays(-10000), Legajo = "T1", Dni = 123456789 });
            database.Tecnicos.Add(new Tecnico() { Nombre = "Tec2", Apellido = "Nico2", FechaNacimiento = DateTime.Now.AddDays(-11000), Legajo = "T2", Dni = 123456788 });
            database.Tecnicos.Add(new Tecnico() { Nombre = "Tec3", Apellido = "Nico3", FechaNacimiento = DateTime.Now.AddDays(-12000), Legajo = "T3", Dni = 123456787 });
            database.Tecnicos.Add(new Tecnico() { Nombre = "Tec4", Apellido = "Nico4", FechaNacimiento = DateTime.Now.AddDays(-13000), Legajo = "T4", Dni = 123456786 });
            database.Tecnicos.Add(new Tecnico() { Nombre = "Tec5", Apellido = "Nico5", FechaNacimiento = DateTime.Now.AddDays(-14000), Legajo = "T5", Dni = 123456785 });

            database.SaveChanges();

            var tecnico1 = database.Tecnicos.FirstOrDefault(x => x.Nombre == "Tec1");
            var tecnico2 = database.Tecnicos.FirstOrDefault(x => x.Nombre == "Tec2");
            var tecnico3 = database.Tecnicos.FirstOrDefault(x => x.Nombre == "Tec3");
            var tecnico4 = database.Tecnicos.FirstOrDefault(x => x.Nombre == "Tec4");
            var tecnico5 = database.Tecnicos.FirstOrDefault(x => x.Nombre == "Tec5");

            #endregion

            #region Pacientes Seed

            database.Pacientes.Add(new Paciente() { Nombre = "Paci1", Apellido = "Ente1", FechaNacimiento = DateTime.Now.AddDays(-5000), Dni = 123456779 });
            database.Pacientes.Add(new Paciente() { Nombre = "Paci2", Apellido = "Ente2", FechaNacimiento = DateTime.Now.AddDays(-6000), Dni = 123456778 });
            database.Pacientes.Add(new Paciente() { Nombre = "Paci3", Apellido = "Ente3", FechaNacimiento = DateTime.Now.AddDays(-7000), Dni = 123456777 });
            database.Pacientes.Add(new Paciente() { Nombre = "Paci4", Apellido = "Ente4", FechaNacimiento = DateTime.Now.AddDays(-8000), Dni = 123456776 });
            database.Pacientes.Add(new Paciente() { Nombre = "Paci5", Apellido = "Ente5", FechaNacimiento = DateTime.Now.AddDays(-9000), Dni = 123456775 });

            database.SaveChanges();

            var paciente1 = database.Pacientes.FirstOrDefault(x => x.Nombre == "Paci1");
            var paciente2 = database.Pacientes.FirstOrDefault(x => x.Nombre == "Paci2");
            var paciente3 = database.Pacientes.FirstOrDefault(x => x.Nombre == "Paci3");
            var paciente4 = database.Pacientes.FirstOrDefault(x => x.Nombre == "Paci4");
            var paciente5 = database.Pacientes.FirstOrDefault(x => x.Nombre == "Paci5");

            #endregion

            #region Turnos Seed

            var turno1 = new Turno() { Paciente = paciente1, Tecnico = tecnico1, Fecha = DateTime.Now.AddDays(+10) };
            var turno2 = new Turno() { Paciente = paciente2, Tecnico = tecnico2, Fecha = DateTime.Now.AddDays(+15) };
            var turno3 = new Turno() { Paciente = paciente3, Tecnico = tecnico3, Fecha = DateTime.Now.AddDays(+20) };
            var turno4 = new Turno() { Paciente = paciente4, Tecnico = tecnico4, Fecha = DateTime.Now.AddDays(+25) };
            var turno5 = new Turno() { Paciente = paciente4, Tecnico = tecnico4, Fecha = DateTime.Now.AddDays(+30) };


            database.Turnos.Add(turno1);
            database.Turnos.Add(turno2);
            database.Turnos.Add(turno3);
            database.Turnos.Add(turno4);
            database.Turnos.Add(turno5);

            database.SaveChanges();

            #endregion

            #region Tipos Seed

            var tipo1 = new Tipo() { Descrip = "Sangre" };
            var tipo2 = new Tipo() { Descrip = "Orina" };

            database.Tipos.Add(tipo1);
            database.Tipos.Add(tipo2);

            database.SaveChanges();

            #endregion


            #region Secciones Seed

            database.Secciones.Add(new Seccion() { Descrip = "Bioquimica", Tipo = tipo1 });
            database.Secciones.Add(new Seccion() { Descrip = "Coagulacion", Tipo = tipo1 });
            database.Secciones.Add(new Seccion() { Descrip = "Alergias", Tipo = tipo1 });
            database.Secciones.Add(new Seccion() { Descrip = "Bacteriologia", Tipo = tipo1 });
            database.Secciones.Add(new Seccion() { Descrip = "Marcadores Tumorales", Tipo = tipo2 });
            database.Secciones.Add(new Seccion() { Descrip = "Inmunologia", Tipo = tipo2 });
            database.Secciones.Add(new Seccion() { Descrip = "Endocrinologia", Tipo = tipo2 });
            database.Secciones.Add(new Seccion() { Descrip = "Toxicologia", Tipo = tipo2 });

            database.SaveChanges();

            var seccion1 = database.Secciones.FirstOrDefault(x => x.Descrip == "Bioquimica");
            var seccion2 = database.Secciones.FirstOrDefault(x => x.Descrip == "Coagulacion");
            var seccion3 = database.Secciones.FirstOrDefault(x => x.Descrip == "Alergias");
            var seccion4 = database.Secciones.FirstOrDefault(x => x.Descrip == "Bacteriologia");
            var seccion5 = database.Secciones.FirstOrDefault(x => x.Descrip == "Marcadores Tumorales");
            var seccion6 = database.Secciones.FirstOrDefault(x => x.Descrip == "Inmunologia");
            var seccion7 = database.Secciones.FirstOrDefault(x => x.Descrip == "Endocrinologia");
            var seccion8 = database.Secciones.FirstOrDefault(x => x.Descrip == "Toxicologia");

            #endregion


            #region EstudiosClinicos Seed // REVISAR CARGA DE HASHSET


            /*
                        HashSet<Seccion> ec1 = new HashSet<Seccion>();
                        HashSet<Seccion> ec2 = new HashSet<Seccion>();
                        HashSet<Seccion> ec3 = new HashSet<Seccion>();
                        HashSet<Seccion> ec4 = new HashSet<Seccion>();

                        ec1.Add(seccion1);
                        ec1.Add(seccion2);
                        ec2.Add(seccion3);
                        ec2.Add(seccion4);
                        ec3.Add(seccion5);
                        ec3.Add(seccion6);
                        ec4.Add(seccion7);
                        ec4.Add(seccion8);
             */

            //var estudioClinico1 = new EstudioClinico() { Turno = turno1, Secciones = { seccion1, seccion2 } };
            //var estudioClinico2 = new EstudioClinico() { Turno = turno2, Secciones = { seccion3, seccion4 } };

            //database.EstudiosClinicos.Add(estudioClinico1);

            //database.Turnos.Attach(turno1);
            //database.Secciones.Attach(seccion1);
            //database.Secciones.Attach(seccion2);
            //database.EstudiosClinicos.Add(estudioClinico2);
            //database.Turnos.Attach(turno2);
            //database.Secciones.Attach(seccion3);
            //database.Secciones.Attach(seccion4);

            var t1 = database.Turnos.Find(1);
            var s1 = database.Secciones.Find(1);
            var s2 = database.Secciones.Find(2);

            var estudioClinico = new EstudioClinico()
            {
                Turno = t1
            };

            estudioClinico.Secciones.Add(s1);
            estudioClinico.Secciones.Add(s2);

            database.EstudiosClinicos.Add(estudioClinico);
            database.Turnos.Attach(t1);
            database.Secciones.Attach(s1);
            database.Secciones.Attach(s2);

            database.SaveChanges();


            #endregion
        }


    }
}
