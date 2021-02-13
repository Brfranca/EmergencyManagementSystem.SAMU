﻿using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class ServiceHistoryModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public long VehicleModelId { get; set; }
        public EmergencyModel EmergencyModel { get; set; }
        public long EmergencyModelId { get; set; }
        public ServiceHistoryStatus ServiceHistoryStatus { get; set; }
        public string Description { get; set; }
        public ICollection<TeamMemberModel> TeamMemberModels { get; set; }
        public ICollection<VehiclePositionHistoryModel> VehiclePositionHistoryModels { get; set; }

    }
}