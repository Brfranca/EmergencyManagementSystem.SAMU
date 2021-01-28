using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class EmergencyHistory : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int EmergencyId { get; set; }
        public Guid EmployeeGuid { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public string Description { get; set; }
    }
}
