using System;

namespace EmergencyManagementSystem.SAMU.Entities.Entities
{
    public class TeamMember
    {
        public Guid EmployeeGuid { get; set; }
        //public virtual Employee Employee { get; set; }
        public int VehicleTeamId { get; set; }
        public virtual VehicleTeam VehicleTeam { get; set; }

        //verificar como isso ficará registrado na ocorrência. quem estava no veiculo durante a ocorrencia
        // Conferir porq o Employee tinha uma lista de TeamMember
    }
}
