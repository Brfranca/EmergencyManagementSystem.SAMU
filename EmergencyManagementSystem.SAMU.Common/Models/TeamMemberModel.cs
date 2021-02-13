namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class TeamMemberModel
    {
        public long Id { get; set; }
        public long ServiceHistoryId { get; set; }
        public ServiceHistoryModel ServiceHistoryModel { get; set; }
        public long MemberId { get; set; }
        public MemberModel MemberModel { get; set; }
    }
}
