using System;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class TeamMemberModel
    {
        public long Id { get; set; }
        public Guid EmployeeGuid { get; set; }
        public long ServiceHistoryModelId { get; set; }
        public ServiceHistoryModel ServiceHistoryModel { get; set; }
    }
}
