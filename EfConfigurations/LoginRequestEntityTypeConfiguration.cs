using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EfConfigurations
{
    public class LoginRequestEntityTypeConfiguration : IEntityTypeConfiguration<LoginRequest>
    {

        public void Configure(EntityTypeBuilder<LoginRequest> opt)
        {
            opt.HasKey(e => e.Login);
            opt.HasData(
                new LoginRequest {Login = "jan", Password = "siema"},
                new LoginRequest {Login = "Pan", Password = "Paweł"}
                );
        }
    }
}
