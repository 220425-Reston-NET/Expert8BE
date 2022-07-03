using Expert8Model;
using expert8BL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Expert8Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private ipatientBL _patientBL;

        public PatientController(ipatientBL patientBL)
        {
            _patientBL = patientBL;
        }

        [HttpPost("AddPatient")]
        public IActionResult AddPatient([FromBody] Patient p_patient)
        {
            try
            {
                _patientBL.addpatient(p_patient);

                return Created("Patient is added", p_patient);
            }
            catch (System.AccessViolationException)
            {
                return Conflict();
            }
            // catch (SqlException)
            // {
                
            //     return Conflict("Patient already has account");
            // }
        }

        [HttpGet("searchpatientbyemailandpassword")]
        public IActionResult SearchPatientByEmailAndPassword(string Email, string Password)
        {
            try
            {
                return Ok(_patientBL.searchpatientbyemailandpassword(Email, Password));
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            try
            {
                List<Patient>currentlistofpatients = _patientBL.GetAllPatients();
                return Ok(currentlistofpatients);
            }
            catch (System.AccessViolationException)
            {
                
                return Conflict();
            }
        }
    }
}