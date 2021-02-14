using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class Emergency : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RequesterName { get; set; }
        public string RequesterPhone { get; set; }
        public virtual Address Address { get; set; }
        public long AddressId { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public virtual ICollection<EmergencyRequiredVehicle> EmergencyRequiredVehicles { get; set; }
        public virtual ICollection<MedicalEvaluation> MedicalEvaluations { get; set; }
        public virtual ICollection<EmergencyHistory> EmergencyHistories { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<ServiceHistory> ServiceHistories { get; set; }

    }
}
