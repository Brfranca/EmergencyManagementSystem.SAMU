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
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a cidade.")
                .Length(3, 100)
                .WithMessage("A cidade deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("O nome da cidade não deve conter números e caracteres especiais.");

            RuleFor(e => e.District)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(60)
                .WithMessage("O bairro deve ter no máximo 60 letras.")
                .Must(IsValidName)
                .WithMessage("O nome do bairro não deve conter números e caracteres especiais.");

            RuleFor(e => e.Complement)
                .MaximumLength(60)
                .WithMessage("O complemento deve ter no máximo 60 caractertes.");

            RuleFor(e => e.Number)
                .MaximumLength(10)
                .WithMessage("O número deve ter no máximo 10 caractertes.");

            RuleFor(e => e.Reference)
                .MaximumLength(60)
                .WithMessage("A referência deve ter no máximo 60 caractertes");

            RuleFor(e => e.State)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome do estado.")
                .Length(2)
                .WithMessage("O estado deve conter 2 caractertes.");

            RuleFor(e => e.Street)
                .Cascade(CascadeMode.Stop)
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
