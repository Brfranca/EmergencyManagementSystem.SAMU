using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class MedicalEvaluation : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int EmergencyId { get; set; }
        public string Evaluation { get; set; }
        public int PatientId { get; set; }
    }
}
