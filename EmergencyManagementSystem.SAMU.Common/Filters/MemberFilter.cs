using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class MemberFilter : FilterBase
    {
        public long Id { get; set; }
        public Guid EmployeeGuid { get; set; }
        public long VehicleId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}
