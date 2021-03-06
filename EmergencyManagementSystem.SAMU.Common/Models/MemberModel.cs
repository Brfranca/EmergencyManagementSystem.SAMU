﻿using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class MemberModel
    {
        public long Id { get; set; }
        public DateTime StartedWork { get; set; }
        public DateTime? FinishedWork { get; set; }
        public Guid EmployeeGuid { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public long VehicleId { get; set; }
        public VehicleModel VehicleModel { get; set; }
    }
}
