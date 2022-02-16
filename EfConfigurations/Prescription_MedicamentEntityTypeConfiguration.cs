using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class Prescription_MedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> opt)
        {
            opt.HasKey(t => new { t.IdPrescription, t.IdMedicament });
            opt.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
            opt.Property(e => e.IdMedicament).ValueGeneratedOnAdd();

            opt.HasOne(e => e.Medicament)
                .WithMany(s => s.Prescription_Medicaments)
                .HasForeignKey(s => s.IdMedicament);

            opt.HasOne(e => e.Prescription)
                .WithMany(s => s.Prescription_Medicaments)
                .HasForeignKey(s => s.IdPrescription);

            opt.Property(e => e.Details).IsRequired().HasMaxLength(100);

            opt.HasData(
                new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Details = "det1"},
                new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "det1" }
                );
        }
    }
}
