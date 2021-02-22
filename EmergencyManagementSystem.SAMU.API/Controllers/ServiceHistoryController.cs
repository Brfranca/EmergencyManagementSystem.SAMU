using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  ServiceHistoryController : BaseController<ServiceHistoryModel, ServiceHistory, ServiceHistoryFilter>
    {
        private readonly IServiceHistoryBLL _serviceHistoryBLL;
        public ServiceHistoryController(IServiceHistoryBLL serviceHistoryBLL) : base(serviceHistoryBLL)
        {
            _serviceHistoryBLL = serviceHistoryBLL;
        }

        [HttpPost("SendVehicle")]
        public Result SendVehicle(ServiceHistoryModel serviceHistoryModel)
        {
            return _serviceHistoryBLL.SendVehicle(serviceHistoryModel);
        }
    }
}
