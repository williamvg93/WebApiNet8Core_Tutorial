using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Context
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rol> Roles { get; set; }

        //Crear el modelado de las tablas para la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rol>(table =>
            {

                //Asignar el nombre que llevara la tabla en la DB
                table.ToTable("rol");

                //Agisnando la llave primaria para la table
                table.HasKey(col => col.IdRol);
                //Crear Columna o campo y Configurar para que la columna se llene sola cuando se agrege un registro(AutoIncrement)
                table.Property(col => col.IdRol)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                //Crear Columna o campo y Configurar para que solo permita un max de 50 caracteres
                table.Property(col => col.Name)
                .HasMaxLength(50);

                //Agregar datos a la tabla al momento de que se cree
                table.HasData(
                    new Rol { IdRol = 1, Name = "Seller" },
                    new Rol { IdRol = 2, Name = "Cashier" }
                );

            });

            modelBuilder.Entity<Employee>(table =>
            {
                table.ToTable("employee");

                table.HasKey(key => key.IdEmployee);
                table.Property(id => id.IdEmployee)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                table.Property(nam => nam.Name)
                .HasMaxLength(50);
                table.Property(col => col.Salary);

                // Llave foranea
                table.HasOne(rol => rol.Roles)
                .WithMany(emp => emp.Employees)
                .HasForeignKey(fkr => fkr.FkIdRol);
            });
        }
    }
}
