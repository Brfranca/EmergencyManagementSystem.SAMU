using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class VehicleValidation : BaseValidation<Vehicle>
    {
        public VehicleValidation()
        {
            RuleFor(e => e.VehiclePlate)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a placa.")
                .Length(7)
                .WithMessage("A placa deve conter 7 caracteres.");

            RuleFor(e => e.VehicleName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome do veículo.")
                .Length(3, 40)
                .WithMessage("O nome do veículo deve conter entre 3 e 40 caracteres.");

            RuleFor(e => e.Year)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o ano.");

            RuleFor(e => e.VehicleType)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o tipo de veículo.");

            RuleFor(e => e.VehicleStatus)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a situação do veículo.");
        }
    }
}
