using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class MedicalDecisionHistoryValidation : BaseValidation<MedicalDecisionHistory>
    {
        public MedicalDecisionHistoryValidation()
        {
            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar a data.")
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar a descrição.")
                .NotEmpty()
                .WithMessage("Favor informar a descrição.")
                .Length(5, 150)
                .WithMessage("A descrição deve conter entre 5 e 150 caracteres.");

            RuleFor(e => e.CodeColor)
                .NotEmpty()
                .WithMessage("Favor informar o código da coloração.");

            RuleFor(e => e.EmergencyId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da ocorrência.");

            RuleFor(e => e.EmployeeGuid)
                .NotNull()
                .WithMessage("Favor informar o Guid da funcionário.")
                .NotEmpty()
                .WithMessage("Favor informar o Guid da funcionário.");

            RuleFor(e => e.EmployeeName)
                .NotNull()
                .WithMessage("Favor informar o nome do funcionário.")
                .NotEmpty()
                .WithMessage("Favor informar o nome do funcionário.");
        }
    }
}
