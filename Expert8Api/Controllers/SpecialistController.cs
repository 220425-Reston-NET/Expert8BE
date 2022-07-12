using expert8BL;
using Expert8Model;
using Microsoft.AspNetCore.Mvc;

namespace Expert8Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private ispecialistBL _specialistBL;

        public SpecialistController(ispecialistBL specialistBL)
        {
            _specialistBL = specialistBL;
        }

        [HttpPost("AddServices")]
        public IActionResult AddServices(JoinTable s_services)
        {
            try
            {
                _specialistBL.addservices(s_services);
                return Ok();
            }
            catch (System.Exception)
            {
                return Conflict();
            }
        }
    }
}