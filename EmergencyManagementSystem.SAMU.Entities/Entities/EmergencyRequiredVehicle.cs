using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class EmergencyRequiredVehicle : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public VehicleType VehicleType { get; set; }
        public virtual Emergency Emergency { get; set; }
        public long EmergencyId { get; set; }
        public CodeColor CodeColor { get; set; }
        public VehicleRequiredStatus Status { get; set; }
    }
}
