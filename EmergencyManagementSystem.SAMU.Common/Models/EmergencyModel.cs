using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class EmergencyModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RequesterName { get; set; }
        public string RequesterPhone { get; set; }
        public virtual Address Address { get; set; }
        public long AddressId { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public ICollection<MedicalEvaluation> MedicalEvaluations { get; set; }
        public ICollection<EmergencyHistory> EmergencyHistories { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<VehicleTeam> VehicleTeams { get; set; }
        public ICollection<EmergencyRequiredVehicle> EmergencyDatas { get; set; }
    }
}
