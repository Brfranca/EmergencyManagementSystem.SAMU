using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class VehiclePositionHistoryValidation : BaseValidation<VehiclePositionHistory>
    {
        public VehiclePositionHistoryValidation()
        {
            RuleFor(e => e.Date)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.VehicleStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o status do veículo.");
        }
    }
}
