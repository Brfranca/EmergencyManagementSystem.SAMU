using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class TeamMemberValidation : BaseValidation<TeamMember>
    {
        public TeamMemberValidation()
        {
            RuleFor(e => e.EmployeeGuid)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o identificador único universal do funcionário.");
            //Não tenho certeza do que validar aqui
        }
    }
}
