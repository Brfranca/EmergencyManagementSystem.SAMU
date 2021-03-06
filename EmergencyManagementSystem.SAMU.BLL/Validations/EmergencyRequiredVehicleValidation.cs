﻿using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class EmergencyRequiredVehicleValidation : BaseValidation<EmergencyRequiredVehicle>
    {
        public EmergencyRequiredVehicleValidation()
        {
            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar a data.")
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.VehicleType)
                .NotEmpty()
                .WithMessage("Favor informar o tipo de veículo.");

            RuleFor(e => e.CodeColor)
                .NotEmpty()
                .WithMessage("Favor informar o código da coloração.");

            RuleFor(e => e.EmergencyId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da ocorrência.");

            RuleFor(e => e.Status)
                .NotEmpty()
                .WithMessage("Favor informar o status.");

        }
    }
}
