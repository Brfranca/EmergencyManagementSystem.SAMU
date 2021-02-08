using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .WithMessage("Favor informar o nome completo do chamador.")
                .Length(3, 100)
                .WithMessage("O nome do chamador deve conter entre 3 e 100 caracteres.")
                .Must(ContainsFullName)
                .WithMessage("Favor inserir o nome completo do solicitante.")
                .Must(IsValidName)
                .WithMessage("O nome do chamador não deve conter números ou caracteres especiais.");

            RuleFor(e => e.RequesterPhone)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o telefone do solicitante.")
                .Must(IsValidPhone)
                .WithMessage("Telefone inválido.");

            RuleFor(e => e.EmergencyStatus)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o status da emergência.");
        }

        private bool ContainsFullName(string fullName)
        {
            var names = fullName.Split(' ').Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
            if (names.Count <= 1)
            {
                return false;
            }
            return true;
        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");
        }
    }
}
