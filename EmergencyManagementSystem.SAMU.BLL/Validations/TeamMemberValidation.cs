using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class TeamMemberValidation : BaseValidation<TeamMember>
    {
        public TeamMemberValidation()
        {
            RuleFor(e => e.Member)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o membro da equipe.");

            RuleFor(e => e.ServiceHistory)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar o histórico de atendimento.");
        }
    }
}
