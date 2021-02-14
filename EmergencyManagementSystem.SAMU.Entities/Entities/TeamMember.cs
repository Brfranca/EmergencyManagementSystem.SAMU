using EmergencyManagementSystem.SAMU.Entities.Interfaces;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class TeamMember : IEntity<long>
    {
        public long Id { get; set; }
        public long ServiceHistoryId { get; set; }
        public virtual ServiceHistory ServiceHistory { get; set; }
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }

        //Essa tabela repete por membro

    }
}
