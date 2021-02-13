using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class MedicalEvaluationModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeGuid { get; set; }
        public EmergencyModel EmergencyModel { get; set; }
        public int EmergencyModelId { get; set; }
        public string Evaluation { get; set; }
        public PatientModel PatientModel { get; set; }
        public long PatientModelId { get; set; }
    }
}
