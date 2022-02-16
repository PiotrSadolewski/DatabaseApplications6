using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DTOs.Requests;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IDatabaseService _db;
        public PrescriptionController(IDatabaseService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecificPrescription(CreateSpecificPrescriptionRequestDto request)
        {
            return Ok(await _db.GetSpecificPrescription(request));
        }

    }
}
