using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class VehicleTeamModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
        public virtual Emergency Emergency { get; set; }
        public long EmergencyId { get; set; }
        public VehicleTeamStatus VehicleTeamStatus { get; set; }
        public string Description { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<VehiclePositionHistory> VehiclePositionHistories { get; set; }

    }
}
