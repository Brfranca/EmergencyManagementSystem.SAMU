using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class ServiceHistory : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
        public virtual Emergency Emergency { get; set; }
        public long EmergencyId { get; set; }
        public ServiceHistoryStatus ServiceHistoryStatus { get; set; }
        public string Description { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<VehiclePositionHistory> VehiclePositionHistories { get; set; }

    }
}
