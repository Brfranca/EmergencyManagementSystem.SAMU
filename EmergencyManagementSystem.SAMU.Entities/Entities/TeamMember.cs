using EmergencyManagementSystem.SAMU.Entities.Enums;
using EmergencyManagementSystem.SAMU.Entities.Interfaces;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class TeamMember : IEntity<long>
    {
        public long Id { get; set; }
        public long ServiceHistoryId { get; set; }
        public ServiceHistory ServiceHistory { get; set; }
        public long MemberId { get; set; }
        public Member Member { get; set; }

        //Essa tabela repete por membro

    }
}
