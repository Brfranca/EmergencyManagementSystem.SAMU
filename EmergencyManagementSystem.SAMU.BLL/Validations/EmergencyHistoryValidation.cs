using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class EmergencyHistoryValidation : BaseValidation<EmergencyHistory>
    {
        public EmergencyHistoryValidation()
        {
            RuleFor(e => e.Date)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.EmergencyStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o status da emergência.");

            RuleFor(e => e.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a descrição.")
                .Length(3, 60)
                .WithMessage("A descrição deve conter entre 3 e 60 caracteres.");
        }
    }
}
