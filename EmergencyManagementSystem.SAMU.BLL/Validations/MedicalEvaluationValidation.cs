using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class MedicalEvaluationValidation : BaseValidation<MedicalEvaluation>
    {
        public MedicalEvaluationValidation()
        {
            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.Evaluation)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o diagnóstico.")
                .Length(3, 150)
                .WithMessage("O diagnóstico deve conter entre 3 e 150 caracteres.");
        }
    }
}
