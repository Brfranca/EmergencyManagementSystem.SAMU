using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class EmergencyHistoryValidation : BaseValidation<EmergencyHistory>
    {
        public EmergencyHistoryValidation()
        {
            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.EmergencyStatus)
                .NotEmpty()
                .WithMessage("Favor informar o status da emergência.");

            RuleFor(e => e.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar a descrição.")
                .NotEmpty()
                .WithMessage("Favor informar a descrição.")
                .Length(3, 150)
                .WithMessage("A descrição deve conter entre 3 e 150 caracteres.");

            RuleFor(e => e.EmergencyId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da ocorrência.");

            RuleFor(e => e.EmployeeGuid)
                .NotNull()
                .WithMessage("Favor informar o Guid da funcionário.")
                .NotEmpty()
                .WithMessage("Favor informar o Guid da funcionário.");

        }
    }
}
