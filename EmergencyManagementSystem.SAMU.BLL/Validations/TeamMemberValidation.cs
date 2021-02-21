using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class TeamMemberValidation : BaseValidation<TeamMember>
    {
        public TeamMemberValidation()
        {
            RuleFor(e => e.MemberId)
                .NotEmpty()
                .WithMessage("Favor informar o Id membro da equipe.");

            RuleFor(e => e.ServiceHistoryId)
                .NotNull()
                .WithMessage("Favor informar o Id histórico de atendimento.");
        }
    }
}
