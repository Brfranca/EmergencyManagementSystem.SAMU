using EmergencyManagementSystem.SAMU.Entities.Enums;
using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class VehiclePositionHistoryModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public VehiclePosition VehiclePosition { get; set; }
        public ServiceHistoryModel ServiceHistoryModel { get; set; }
        public long ServiceHistoryId { get; set; }
        public EmergencyModel EmergencyModel { get; set; }
        public long EmergencyId { get; set; }
    }
}
