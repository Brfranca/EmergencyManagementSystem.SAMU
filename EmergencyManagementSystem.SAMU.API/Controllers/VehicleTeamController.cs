﻿using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTeamController : BaseController<VehicleTeamModel>
    {
        public VehicleTeamController(IVehicleTeamBLL vehicleTeamBLL) : base(vehicleTeamBLL)
        {
        }
    }
}