using InstitutionManagmentSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace InstitutionManagmentSystem.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Halaqa> Halaqat { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<Teacher>(x =>
            {
                x.ToTable("Teachers");
                x.Property(x => x.FistName).HasColumnType("nvarchar(50)");
                x.HasData(new List<Teacher>
                    {
                        new Teacher{ Id = 1,FistName = "صالح",LastName = "محمد", PhoneNumber = "465"},
                        new Teacher{ Id = 2,FistName = "علي",LastName = "احمد", PhoneNumber = "56465"}
                });
            });


            builder.Entity<Halaqa>(x =>
            {
                x.ToTable("Halaqat");
                x.Property(x => x.Name).HasColumnType("nvarchar(50)");


                x.HasOne(h => h.Teacher)
                .WithOne(t => t.Halaqa)
                .HasForeignKey<Halaqa>(h => h.TeacherId);


                x.HasData(new List<Halaqa>
                    {
                        new Halaqa{ Id = 1,Name = "حلقة عمرابن الخطاب", TeacherId = 1},
                        new Halaqa{ Id = 2,Name = "حلقة عي ابن بي طالب", TeacherId = 2}
                    });
            });


            builder.Entity<Student>(x =>
            {

     
                x.ToTable("Students");
                x.Property(x => x.FistName).HasColumnType("nvarchar(50)");

                x.HasData(new List<Student>
                {
                    new Student{ Id = 1,FistName = "سالم",LastName = "علي",HalaqaId = 1 ,PhoneNumber = "564645"},
                    new Student{ Id = 2,FistName = "ناصر",LastName = "فادي",HalaqaId = 2, PhoneNumber = "564651"}

                });
            });


        }
    }
}
