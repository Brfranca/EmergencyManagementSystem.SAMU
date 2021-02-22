using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class MedicalEvaluationValidation : BaseValidation<MedicalEvaluation>
    {
        public MedicalEvaluationValidation()
        {
            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.Evaluation)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o diagnóstico.")
                .Length(3, 150)
                .WithMessage("O diagnóstico deve conter entre 3 e 150 caracteres.");

            RuleFor(e => e.EmergencyId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da ocorrência.");

            RuleFor(e => e.EmployeeGuid)
                .NotNull()
                .WithMessage("Favor informar o Guid da funcionário.")
                .NotEmpty()
                .WithMessage("Favor informar o Guid da funcionário.");


            RuleFor(e => e.PatientId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da paciente.");


            RuleFor(e => e.EmployeeName)
                .NotNull()
                .WithMessage("Favor informar o nome do funcionário.")
                .NotEmpty()
                .WithMessage("Favor informar o nome do funcionário.");
        }
    }
}
