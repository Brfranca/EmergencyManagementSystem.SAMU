using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class PatientValidation : BaseValidation<Patient>
    {
        public PatientValidation()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome completo.")
                .Length(3, 100)
                .WithMessage("O nome deve conter entre 3 e 100 caracteres.")
                .Must(ContainsFullName)
                .WithMessage("Favor inserir o nome completo.")
                .Must(IsValidName)
                .WithMessage("O nome não deve conter números ou caracteres especiais.");

            RuleFor(e => e.Telephone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o telefone.")
                .Must(IsValidPhone)
                .WithMessage("Telefone inválido.");

            RuleFor(e => e.Age)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a idade.");

            RuleFor(e => e.Gender)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o gênero.");
            //Acredito que seria interessante alterar o requerimento de gênero para sexo, uma vez que não constitui um elemento relevante para avaliação médica (gênero = identidade, sexo = composição biológica)
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
