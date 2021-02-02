using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class AddressValidation : BaseValidation<Address>
    {
        public AddressValidation()
        {
            RuleFor(e => e.CEP)
                .Length(8)
                .WithMessage("O CEP deve conter 8 números.");

            RuleFor(e => e.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a cidade.")
                .Length(3, 100)
                .WithMessage("A cidade deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("O nome da cidade não deve conter números e caracteres especiais.");

            RuleFor(e => e.District)
                .Length(3, 60)
                .WithMessage("O bairro deve ter entre 3 e 60 letras.")
                .Must(IsValidName)
                .WithMessage("O nome do bairro não deve conter números e caracteres especiais.");

            RuleFor(e => e.Complement)
                .Length(3, 60)
                .WithMessage("O complemento deve ter entre 3 e 60 letras.");

            RuleFor(e => e.Number)
                .Length(3, 10)
                .WithMessage("O número deve ter entre 3 e 10 letras.");

            RuleFor(e => e.Reference)
                .Length(3, 60)
                .WithMessage("A referência deve ter entre 3 e 60 letras");

            RuleFor(e => e.State)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome do estado.")
                .Length(2)
                .WithMessage("O estado deve conter 2 letras.");

            RuleFor(e => e.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome da rua.")
                .Length(3, 60)
                .WithMessage("A rua deve conter entre 3 e 60 letras.");
        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }
    }
}
