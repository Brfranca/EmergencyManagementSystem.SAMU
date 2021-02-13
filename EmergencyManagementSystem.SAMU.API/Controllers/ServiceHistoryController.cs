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
        public ServiceHistoryController(IServiceHistoryBLL serviceHistoryBLL) : base(serviceHistoryBLL)
        {
        }
    }
}
