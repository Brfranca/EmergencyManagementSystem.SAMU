using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class Member
    {
        public long Id { get; set; }
        public DateTime StartedWork { get; set; }
        public DateTime? FinishedWork { get; set; }
        public Guid EmployeeGuid { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
