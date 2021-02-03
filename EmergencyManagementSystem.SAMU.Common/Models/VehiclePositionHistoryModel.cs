using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class VehiclePositionHistoryModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public virtual VehicleTeam VehicleTeam { get; set; }
        public long VehicleTeamId { get; set; }
        public virtual Emergency Emergency { get; set; }
        public long EmergencyId { get; set; }
    }
}
