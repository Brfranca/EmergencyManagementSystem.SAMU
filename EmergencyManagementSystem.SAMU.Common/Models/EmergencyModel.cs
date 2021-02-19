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
        public long AddressId { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public List<MedicalEvaluationModel> MedicalEvaluations { get; set; }
        public List<EmergencyHistoryModel> EmergencyHistoryModels { get; set; }
        public List<PatientModel> Patients { get; set; }
        public List<ServiceHistoryModel> ServiceHistoryModels { get; set; }
        public List<EmergencyRequiredVehicleModel> EmergencyRequiredVehicles { get; set; }
        public Guid EmployeeGuid { get; set; }
    }
}
