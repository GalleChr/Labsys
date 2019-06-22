namespace Servicios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstudioClinico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turno", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Seccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descrip = c.String(nullable: false),
                        Tipo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descrip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Paciente_Id = c.Int(nullable: false),
                        Tecnico_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.Paciente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tecnico", t => t.Tecnico_Id, cascadeDelete: true)
                .Index(t => t.Paciente_Id)
                .Index(t => t.Tecnico_Id);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dni = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        FechaNacimiento = c.DateTime(nullable: false),
                        CodPaciente = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Dni, unique: true)
                .Index(t => t.CodPaciente, unique: true);
            
            CreateTable(
                "dbo.Tecnico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dni = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Legajo = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Dni, unique: true)
                .Index(t => t.Legajo, unique: true);
            
            CreateTable(
                "dbo.EstudioClinicoSeccions",
                c => new
                    {
                        EstudioClinico_Id = c.Int(nullable: false),
                        Seccion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EstudioClinico_Id, t.Seccion_Id })
                .ForeignKey("dbo.EstudioClinico", t => t.EstudioClinico_Id, cascadeDelete: true)
                .ForeignKey("dbo.Seccion", t => t.Seccion_Id, cascadeDelete: true)
                .Index(t => t.EstudioClinico_Id)
                .Index(t => t.Seccion_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstudioClinico", "Id", "dbo.Turno");
            DropForeignKey("dbo.Turno", "Tecnico_Id", "dbo.Tecnico");
            DropForeignKey("dbo.Turno", "Paciente_Id", "dbo.Paciente");
            DropForeignKey("dbo.EstudioClinicoSeccions", "Seccion_Id", "dbo.Seccion");
            DropForeignKey("dbo.EstudioClinicoSeccions", "EstudioClinico_Id", "dbo.EstudioClinico");
            DropForeignKey("dbo.Seccion", "Tipo_Id", "dbo.Tipo");
            DropIndex("dbo.EstudioClinicoSeccions", new[] { "Seccion_Id" });
            DropIndex("dbo.EstudioClinicoSeccions", new[] { "EstudioClinico_Id" });
            DropIndex("dbo.Tecnico", new[] { "Legajo" });
            DropIndex("dbo.Tecnico", new[] { "Dni" });
            DropIndex("dbo.Paciente", new[] { "CodPaciente" });
            DropIndex("dbo.Paciente", new[] { "Dni" });
            DropIndex("dbo.Turno", new[] { "Tecnico_Id" });
            DropIndex("dbo.Turno", new[] { "Paciente_Id" });
            DropIndex("dbo.Seccion", new[] { "Tipo_Id" });
            DropIndex("dbo.EstudioClinico", new[] { "Id" });
            DropTable("dbo.EstudioClinicoSeccions");
            DropTable("dbo.Tecnico");
            DropTable("dbo.Paciente");
            DropTable("dbo.Turno");
            DropTable("dbo.Tipo");
            DropTable("dbo.Seccion");
            DropTable("dbo.EstudioClinico");
        }
    }
}
