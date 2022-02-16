using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private IDatabaseService _db;
        public DoctorsController(IDatabaseService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            return Ok( await _db.GetDoctors());
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            return Ok(await _db.AddDoctor(doctor));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            return Ok(await _db.UpdateDoctor(doctor));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(Doctor doctor)
        {
            return Ok(await _db.DeleteDoctor(doctor));
        }
    }
}
