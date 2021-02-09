using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyHistoryController : BaseController<EmergencyHistoryModel, EmergencyHistory, EmergencyHistoryFilter>
    {
        public EmergencyHistoryController(IEmergencyHistoryBLL emergencyHistoryBLL) : base(emergencyHistoryBLL)
        {

        }
    }
}
