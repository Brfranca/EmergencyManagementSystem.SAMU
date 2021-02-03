using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class TeamMemberModel
    {
        public long Id { get; set; }
        public Guid EmployeeGuid { get; set; }
        public long VehicleTeamId { get; set; }
        public virtual VehicleTeam VehicleTeam { get; set; }
    }
}
