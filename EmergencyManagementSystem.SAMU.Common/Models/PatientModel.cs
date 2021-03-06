﻿using EmergencyManagementSystem.SAMU.Entities.Enums;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class PatientModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public EmergencyModel EmergencyModel { get; set; }
        public long EmergencyId { get; set; }
    }
}
