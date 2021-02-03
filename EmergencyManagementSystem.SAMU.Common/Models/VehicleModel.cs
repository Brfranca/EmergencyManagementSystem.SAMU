using EmergencyManagementSystem.SAMU.Entities.Enums;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class VehicleModel
    {
        public long Id { get; set; }
        public string Plaque { get; set; }
        public string VehicleName { get; set; }
        public int Year { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleSituation VehicleSituation { get; set; }
    }
}
