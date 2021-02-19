using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class EmergencyHistory : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Emergency Emergency { get; set; }
        public long EmergencyId { get; set; }
        public Guid EmployeeGuid { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public string Description { get; set; }
    }
}
