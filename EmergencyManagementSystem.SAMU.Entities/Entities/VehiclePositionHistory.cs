using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class VehiclePositionHistory :IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public int VehicleTeamId { get; set; }
        public int EmergencyId { get; set; }
    }
}
