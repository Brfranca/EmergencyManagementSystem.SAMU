using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class EmergencyRequiredVehicleValidation : BaseValidation<EmergencyRequiredVehicle>
    {
        public EmergencyRequiredVehicleValidation()
        {
            RuleFor(e => e.Date)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.VehicleType)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o tipo de veículo.");

            RuleFor(e => e.CodeColor)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o código da coloração.");
        }
    }
}
