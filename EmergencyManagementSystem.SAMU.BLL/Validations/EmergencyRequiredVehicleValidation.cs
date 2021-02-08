using EmergencyManagementSystem.SAMU.Entities.Entities;
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
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.VehicleType)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o tipo de veículo.");

            RuleFor(e => e.CodeColor)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o código da coloração.");
        }
    }
}
