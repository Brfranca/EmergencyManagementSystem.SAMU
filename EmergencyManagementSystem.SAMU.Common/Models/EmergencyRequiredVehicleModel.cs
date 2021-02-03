using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class EmergencyRequiredVehicleModel
    {
        public DateTime Date { get; set; }
        public VehicleType VehicleType { get; set; }
        public virtual Emergency Emergency { get; set; }
        public long EmergencyId { get; set; }
        public CodeColor CodeColor { get; set; }
    }
}
