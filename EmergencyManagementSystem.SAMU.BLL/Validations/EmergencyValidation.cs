using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class EmergencyValidation : BaseValidation<Emergency>
    {
        public EmergencyValidation()
        {
            RuleFor(e => e.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome.")
                .Length(3, 60)
                .WithMessage("O nome deve conter entre 3 e 60 caracteres.");

            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.RequesterName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome completo do solicitante.")
                .Length(3, 100)
                .WithMessage("O nome do solicitante deve conter entre 3 e 100 caracteres.")
                .Must(IsValidName)
                .WithMessage("O nome do chamador não deve conter números ou caracteres especiais.");

            RuleFor(e => e.RequesterPhone)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o telefone do solicitante.")
                .Must(Extension.IsValidPhone)
                .WithMessage("Telefone inválido.");

            RuleFor(e => e.EmergencyStatus)
                .NotEmpty()
                .WithMessage("Favor informar o status da emergência.");

            RuleFor(e => e.Address)
                .NotNull()
                .WithMessage("Favor informar o Id do endereço.");
        }


        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }

    }

    public static class Extension
    {
        public static bool IsValidPhone(this string phone)
        {
            return Regex.IsMatch(phone, @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");
        }

    }
}
