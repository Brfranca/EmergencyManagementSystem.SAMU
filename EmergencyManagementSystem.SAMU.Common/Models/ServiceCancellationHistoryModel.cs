﻿namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class ServiceCancellationHistoryModel
    {
        public ServiceHistoryModel ServiceHistoryModel { get; set; }
        public MedicalDecisionHistoryModel MedicalDecisionHistoryModel { get; set; }
        public EmergencyHistoryModel EmergencyHistoryModel { get; set; }
    }
}
