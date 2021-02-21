using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class AddressValidation : BaseValidation<Address>
    {
        public AddressValidation()
        {
            RuleFor(e => e.CEP)
                .Cascade(CascadeMode.Stop)
                .Custom((cep, context) =>
                {
                    if (!String.IsNullOrWhiteSpace(cep) && cep.Length != 8)
                    {
                        context.AddFailure("O CEP deve conter 8 números.");
                    }
                })
                .Custom((cep, context) =>
                {
                    if (!String.IsNullOrWhiteSpace(cep) && !IsValidNumber(cep))
                    {
                        context.AddFailure("CEP inválido.");
                    }
                });

            RuleFor(e => e.City)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a cidade.")
                .Length(3, 100)
                .WithMessage("A cidade deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("O nome da cidade não deve conter números ou caracteres especiais.");

            RuleFor(e => e.District)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(60)
                .WithMessage("O bairro deve conter no máximo 60 letras.")
                .Custom((bairro, context) =>
                {
                    if (!String.IsNullOrWhiteSpace(bairro) && !IsValidName(bairro))
                    {
                        context.AddFailure("O nome do bairro não deve conter números ou caracteres especiais.");
                    }
                });

            RuleFor(e => e.Complement)
                .MaximumLength(60)
                .WithMessage("O complemento deve conter no máximo 60 caracteres.");

            RuleFor(e => e.Number)
                .MaximumLength(10)
                .WithMessage("O número deve conter no máximo 10 caracteres.")
                .Custom((number, context) =>
                {
                    if (!String.IsNullOrWhiteSpace(number) && !IsValidNumber(number))
                    {
                        context.AddFailure("Número inválido.");
                    }
                });

            RuleFor(e => e.Reference)
                .MaximumLength(60)
                .WithMessage("A referência deve conter no máximo 60 caracteres");

            RuleFor(e => e.Street)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a rua.")
                .Length(3, 60)
                .WithMessage("A rua deve ter entre 3 e 60 caracteres.");
        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }

        private bool IsValidNumber(string Number)
        {
            return Regex.IsMatch(Number, @"^[0-9]*$");
        }
    }
}
