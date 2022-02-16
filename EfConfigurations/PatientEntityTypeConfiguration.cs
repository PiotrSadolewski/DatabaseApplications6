using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> opt)
        {
            opt.HasKey(e => e.IdPatient);
            opt.Property(e => e.IdPatient).ValueGeneratedOnAdd();

            opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);

            opt.HasData(
                new Patient { IdPatient = 1, FirstName = "Patient1", LastName = "1", Birthdate = DateTime.Now },
                new Patient { IdPatient = 2, FirstName = "Patient2", LastName = "2", Birthdate = DateTime.Now }
                );
        }
    }
}
