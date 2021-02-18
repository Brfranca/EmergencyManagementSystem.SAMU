using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class MemberValidation : BaseValidation<Member>
    {
        public MemberValidation()
        {
            RuleFor(e => e.EmployeeStatus)
                    .Cascade(CascadeMode.Stop)
                    .NotNull()
                    .WithMessage("Favor informar o status do funcionário.")
                    .IsInEnum()
                    .WithMessage("Status inválido.");

            RuleFor(e => e.StartedWork)
                    .Cascade(CascadeMode.Stop)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Favor informar a data e hora do início do plantão do funcionário.");

            //RuleFor(e => e.Vehicle)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithMessage("Favor informar o veículo.");
        }
    }
}
