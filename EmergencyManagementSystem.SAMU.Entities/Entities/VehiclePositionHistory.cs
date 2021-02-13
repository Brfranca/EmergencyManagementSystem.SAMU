using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class VehiclePositionHistory :IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public VehiclePosition VehiclePosition { get; set; }
        public virtual ServiceHistory ServiceHistory { get; set; }
        public long ServiceHistoryId { get; set; }
    }
}
