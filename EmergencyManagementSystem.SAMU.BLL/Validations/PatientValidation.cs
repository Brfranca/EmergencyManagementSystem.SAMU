using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class PatientValidation : BaseValidation<Patient>
    {
        public PatientValidation()
        {
            RuleFor(e => e.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome.")
                .Length(3, 100)
                .WithMessage("O nome deve conter entre 3 e 100 caracteres.")
                .Must(IsValidName)
                .WithMessage("O nome não deve conter números ou caracteres especiais.");

            RuleFor(e => e.Age)
                .NotEmpty()
                .WithMessage("Favor informar a idade.");

            RuleFor(e => e.Gender)
                .NotEmpty()
                .WithMessage("Favor informar o sexo.");

            RuleFor(e => e.EmergencyId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da ocorrência.");


        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }
    }
}
