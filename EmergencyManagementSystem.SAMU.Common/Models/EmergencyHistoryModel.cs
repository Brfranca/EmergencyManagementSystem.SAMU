using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class EmergencyHistoryModel
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
