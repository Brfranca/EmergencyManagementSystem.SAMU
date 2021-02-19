using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyController : BaseController<EmergencyModel, Emergency, EmergencyFilter>
    {
        readonly IEmergencyBLL _emergencyBLL;
        public EmergencyController(IEmergencyBLL emergencyBLL) : base(emergencyBLL)
        {
            _emergencyBLL = emergencyBLL;
        }

        [HttpPost("SimpleRegister")]
        public Result SimpleRegister(EmergencyModel model)
        {
            return _emergencyBLL.SimpleRegister(model);
        }

        [HttpPost("SimpleUpdate")]
        public Result SimpleUpdate(EmergencyModel model)
        {
            return _emergencyBLL.SimpleUpdate(model);
        }
    }
}
