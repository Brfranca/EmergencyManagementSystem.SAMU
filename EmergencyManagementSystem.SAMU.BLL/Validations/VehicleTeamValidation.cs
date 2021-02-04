using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class VehicleTeamValidation : BaseValidation<VehicleTeam>
    {
        public VehicleTeamValidation()
        {
            RuleFor(e => e.Date)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.VehicleTeamStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o status da equipe do veículo.");

            RuleFor(e => e.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a descrição.")
                .Length(5, 150)
                .WithMessage("A descrição deve conter entre 5 e 150 caracteres.");

            //Faltou o limite de caracteres da descrição no mapping (a menos que seja intencional)?
            //corrigido
        }
    }
}
