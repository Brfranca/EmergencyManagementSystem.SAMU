using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class MedicalEvaluationModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public virtual Emergency Emergency { get; set; }
        public int EmergencyId { get; set; }
        public string Evaluation { get; set; }
        public virtual Patient Patient { get; set; }
        public long PatientId { get; set; }
    }
}
