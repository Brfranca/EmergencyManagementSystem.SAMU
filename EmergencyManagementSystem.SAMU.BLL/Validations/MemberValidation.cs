using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class MemberValidation : BaseValidation<Member>
    {
        public MemberValidation()
        {
            RuleFor(e => e.EmployeeStatus)
                .NotEmpty()
                .WithMessage("Status inválido.");

            RuleFor(e => e.StartedWork)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data e hora do início do plantão do funcionário.");

            RuleFor(e => e.VehicleId)
                .NotEmpty()
                .WithMessage("Favor informar o Id do veículo.");

            RuleFor(e => e.EmployeeGuid)
                .NotNull()
                .WithMessage("Favor informar o Guid da funcionário.")
                .NotEmpty()
                .WithMessage("Favor informar o Guid da funcionário.");
        }
    }
}
