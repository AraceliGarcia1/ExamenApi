using Microsoft.EntityFrameworkCore;
using MyExam.Models;
namespace MyExam
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options){

        }
        public DbSet<Propietario>? Propietarios { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propietario>().HasData(
                new Propietario()
                {
                    Id = 1,
                    Nombre = "Araceli",
                    Apellidos="Garcia",
                    Direccion = "Jiutepec,Morelos",
                    CorreoElectronico = "araceligarcia@gmail.com",
                    Telefono="7771234567"
                },
                new Propietario()
                {
                    Id = 2,
                    Nombre = "Thayli",
                    Apellidos="Villegas",
                    Direccion = "Jiutepec,Morelos",
                    CorreoElectronico = "thay_villegas@gmail.com",
                    Telefono="7771234897"
                }
            );
        }

    }


}