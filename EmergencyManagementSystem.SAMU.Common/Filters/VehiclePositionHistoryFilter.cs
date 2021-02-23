using EmergencyManagementSystem.SAMU.Entities.Enums;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class VehiclePositionHistoryFilter : FilterBase
    {
        public long Id { get; set; }
        public long ServiceHistoryId { get; set; }
        public VehiclePosition VehiclePosition { get; set; }
    }
}
