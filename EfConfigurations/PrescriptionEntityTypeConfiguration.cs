using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> opt)
        {
            opt.HasKey(e => e.IdPrescription);
            opt.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

            opt.HasOne(e => e.Patient)
                .WithMany(s => s.Prescriptions)
                .HasForeignKey(s => s.IdPatient);

            opt.HasOne(e => e.Doctor)
                .WithMany(s => s.Prescriptions)
                .HasForeignKey(s => s.IdDoctor);

            opt.HasData(
                new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 1, IdDoctor = 1 },
                new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 2, IdDoctor = 2 }
                );
        }
    }
}
