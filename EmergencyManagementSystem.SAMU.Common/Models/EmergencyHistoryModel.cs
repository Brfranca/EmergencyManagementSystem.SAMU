using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class EmergencyHistoryModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public EmergencyModel EmergencyModel { get; set; }
        public long EmergencyModelId { get; set; }
        public Guid EmployeeGuid { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public string Description { get; set; }
    }
}
