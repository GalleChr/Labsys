using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Servicios.DB
{

    public class ConexionBD : DbContext
    {

        public IDbSet<Paciente> Pacientes { get; set; }
        public IDbSet<Tecnico> Tecnicos { get; set; }
        public IDbSet<EstudioClinico> EstudiosClinicos { get; set; }
        public IDbSet<Turno> Turnos { get; set; }
        public IDbSet<Seccion> Secciones { get; set; }
        public IDbSet<Tipo> Tipos { get; set; }


        public ConexionBD() : base("ConexionPrincipal")
        {
            Database.SetInitializer(new Inicializacion());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region Pacientes

            modelBuilder.Entity<Paciente>().ToTable("Paciente").HasKey(paciente => paciente.Id);
            modelBuilder.Entity<Paciente>().Property(paciente => paciente.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Paciente>().Property(paciente => paciente.Dni).IsRequired();
            modelBuilder.Entity<Paciente>().HasIndex(paciente => paciente.Dni).IsUnique();
            modelBuilder.Entity<Paciente>().Property(paciente => paciente.Nombre).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Paciente>().Property(paciente => paciente.Apellido).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Paciente>().Property(paciente => paciente.FechaNacimiento).IsRequired();
            modelBuilder.Entity<Paciente>().HasMany(paciente => paciente.Turnos).WithRequired(turno => turno.Paciente); //un paciente tiene muchos turnos

            #endregion


            #region Tecnicos

            modelBuilder.Entity<Tecnico>().ToTable("Tecnico").HasKey(tecnico => tecnico.Id);
            modelBuilder.Entity<Tecnico>().Property(tecnico => tecnico.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Tecnico>().Property(tecnico => tecnico.Dni).IsRequired();
            modelBuilder.Entity<Tecnico>().HasIndex(tecnico => tecnico.Dni).IsUnique();
            modelBuilder.Entity<Tecnico>().Property(tecnico => tecnico.Nombre).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Tecnico>().Property(tecnico => tecnico.Apellido).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Tecnico>().Property(tecnico => tecnico.FechaNacimiento).IsRequired();
            modelBuilder.Entity<Tecnico>().Property(tecnico => tecnico.Legajo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Tecnico>().HasIndex(tecnico => tecnico.Legajo).IsUnique();

            #endregion


            #region EstudiosClinicos

            modelBuilder.Entity<EstudioClinico>().ToTable("EstudioClinico").HasKey(EstudioClinico => EstudioClinico.Id);
            modelBuilder.Entity<EstudioClinico>().Property(EstudioClinico => EstudioClinico.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EstudioClinico>().HasRequired(EstudioClinico => EstudioClinico.Turno).WithOptional(Turno => Turno.EstudioClinico).Map(x => { x.MapKey("Turno_Id"); });
            modelBuilder.Entity<EstudioClinico>().HasMany(EstudioClinico => EstudioClinico.Secciones).WithMany(Secciones => Secciones.EstudiosClinicos);

            #endregion

            #region Turnos

            modelBuilder.Entity<Turno>().ToTable("Turno").HasKey(turno => turno.Id);
            modelBuilder.Entity<Turno>().Property(turno => turno.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Turno>().Property(turno => turno.Fecha).IsRequired();
            modelBuilder.Entity<Turno>().HasRequired(turno => turno.Paciente);
            modelBuilder.Entity<Turno>().HasRequired(turno => turno.Tecnico);

            #endregion


            #region Secciones

            modelBuilder.Entity<Seccion>().ToTable("Seccion").HasKey(seccion => seccion.Id);
            modelBuilder.Entity<Seccion>().Property(seccion => seccion.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Seccion>().HasRequired(seccion => seccion.Tipo);
            modelBuilder.Entity<Seccion>().Property(seccion => seccion.Descrip).IsRequired();
            modelBuilder.Entity<Seccion>().HasMany(Seccion => Seccion.EstudiosClinicos).WithMany(EstudiosClinicos => EstudiosClinicos.Secciones);

            #endregion


            #region Tipos

            modelBuilder.Entity<Tipo>().ToTable("Tipo").HasKey(tipo => tipo.Id);
            modelBuilder.Entity<Tipo>().Property(tipo => tipo.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Tipo>().Property(tipo => tipo.Descrip).IsRequired(); ;

            #endregion
        }
    }
}

