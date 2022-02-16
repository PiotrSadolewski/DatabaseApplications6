using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class MedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> opt)
        {
            opt.HasKey(e => e.IdMedicament);
            opt.Property(e => e.IdMedicament).ValueGeneratedOnAdd();

            opt.Property(e => e.Name).IsRequired().HasMaxLength(100);
            opt.Property(e => e.Description).IsRequired().HasMaxLength(100);
            opt.Property(e => e.Type).IsRequired().HasMaxLength(100);

            opt.HasData(
                new Medicament { IdMedicament = 1, Name = "Medicament1", Description = "desc1", Type = "type1" },
                new Medicament { IdMedicament = 2, Name = "Medicament2", Description = "desc2", Type = "type1" }
                );
        }
    }
}
