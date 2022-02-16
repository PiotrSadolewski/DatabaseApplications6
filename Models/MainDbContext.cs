using Microsoft.EntityFrameworkCore;
using WebApplication1.EfConfigurations;

namespace WebApplication1.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public DbSet<LoginRequest> LoginRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new MedicamentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new Prescription_MedicamentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new LoginRequestEntityTypeConfiguration());
        }
    }
}
