using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class VehicleFilter : FilterBase
    {
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
    }
}
