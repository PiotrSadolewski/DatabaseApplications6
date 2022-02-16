using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> opt)
        {
            opt.HasKey(e => e.IdDoctor);
            opt.Property(e => e.IdDoctor).ValueGeneratedOnAdd();

            opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            opt.Property(e => e.Email).IsRequired().HasMaxLength(100);

            opt.HasData(
                new Doctor {IdDoctor = 1, FirstName = "Doctor1", LastName = "1", Email = "email1"},
                new Doctor { IdDoctor = 2, FirstName = "Doctor2", LastName = "2", Email = "email1" }
                );
        }
    }
}
