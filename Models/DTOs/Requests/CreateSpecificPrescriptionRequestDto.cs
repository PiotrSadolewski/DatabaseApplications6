using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTOs.Requests
{
    public class CreateSpecificPrescriptionRequestDto
    {
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public virtual ICollection<Medicament> Medicaments { get; set; }

    }
}
