using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Entities.Enums;

namespace EmergencyManagementSystem.SAMU.Common.Filters
{
    public class EmergencyFilter : FilterBase
    {
        public long Id { get; set; }
        public EmergencyStatus EmergencyStatus { get; set; }
        public EmergencyStatus[] EmergenciesStatus { get; set; }
    }
}
