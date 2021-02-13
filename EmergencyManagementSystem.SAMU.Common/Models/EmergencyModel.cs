using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class EmergencyModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RequesterName { get; set; }
        public string RequesterPhone { get; set; }
        public AddressModel AddressModel { get; set; }
        public long AddressModelId { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public ICollection<MedicalEvaluationModel> MedicalEvaluationModels { get; set; }
        public ICollection<EmergencyHistoryModel> EmergencyHistoryModels { get; set; }
        public ICollection<PatientModel> PatientModels { get; set; }
        public ICollection<ServiceHistoryModel> ServiceHistoryModels { get; set; }
        public ICollection<EmergencyRequiredVehicleModel> EmergencyRequiredVehicleModels { get; set; }
    }
}
