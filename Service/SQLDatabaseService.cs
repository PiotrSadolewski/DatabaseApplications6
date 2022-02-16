using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs.Requests;

namespace WebApplication1.Service
{
    public class SQLDatabaseService : IDatabaseService
    {

        private readonly MainDbContext _context;

        public SQLDatabaseService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<IEnumerable> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }
        
        public async Task<IEnumerable> UpdateDoctor(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Doctors.ToListAsync();
        }
        
        public async Task<IEnumerable> DeleteDoctor(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return await _context.Doctors.ToListAsync();
        }

        public Task<IEnumerable> GetSpecificPrescription(CreateSpecificPrescriptionRequestDto request)
        {
            var doctor = new Doctor
            {
                FirstName = request.DoctorFirstName,
                LastName = request.DoctorLastName
            };
            var patient = new Doctor
            {
                FirstName = request.PatientFirstName,
                LastName = request.PatientLastName
            };

            throw new NotImplementedException();
        }
    }
}
