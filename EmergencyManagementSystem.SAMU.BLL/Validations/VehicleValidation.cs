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
            RuleFor(e => e.Plaque)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a placa.")
                .Length(7)
                .WithMessage("A placa deve conter 7 caracteres.");
            //Possível erro ortográfico na designação inglesa da placa. "Plaque" deveria ser "Plate", abreviação de "Vehicle Registration Plate"

            RuleFor(e => e.VehicleName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome do veículo.")
                .Length(3, 40)
                .WithMessage("O nome do veículo deve conter entre 3 e 40 caracteres.");

            RuleFor(e => e.Year)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o ano.");

            RuleFor(e => e.VehicleType)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o tipo de veículo.");

            RuleFor(e => e.VehicleSituation)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a situação do veículo.");
        }
    }
}
