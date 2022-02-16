using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTOs.Requests;

namespace WebApplication1.Service
{
    public interface IDatabaseService
    {
        public Task<IEnumerable> GetDoctors();
        public Task<int> AddDoctor(Doctor doctor);
        public Task<IEnumerable> UpdateDoctor(Doctor doctor);
        public Task<IEnumerable> DeleteDoctor(Doctor doctor);
        public Task<IEnumerable> GetSpecificPrescription(CreateSpecificPrescriptionRequestDto request);
    }
}
