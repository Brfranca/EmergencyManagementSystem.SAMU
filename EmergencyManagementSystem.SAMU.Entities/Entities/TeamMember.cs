using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class TeamMember : IEntity<long>
    {
        public long Id { get; set; }
        public Guid EmployeeGuid { get; set; }
        public long ServiceHistoryId { get; set; }
        public virtual ServiceHistory ServiceHistory { get; set; }

        //verificar como isso ficará registrado na ocorrência. quem estava no veiculo durante a ocorrencia
        // Conferir porq o Employee tinha uma lista de TeamMember
    }
}
