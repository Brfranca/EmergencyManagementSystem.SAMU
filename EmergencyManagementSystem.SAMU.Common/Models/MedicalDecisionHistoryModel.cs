using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class MedicalDecisionHistoryModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long EmergencyId { get; set; }
        public string EmployeeName { get; set; }
        public Guid EmployeeGuid { get; set; }
        public string Description { get; set; }
        public CodeColor CodeColor { get; set; }
    }
}
