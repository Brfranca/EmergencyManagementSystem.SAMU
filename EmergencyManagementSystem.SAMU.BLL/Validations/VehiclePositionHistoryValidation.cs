using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class VehiclePositionHistoryValidation : BaseValidation<VehiclePositionHistory>
    {

        public VehiclePositionHistoryValidation()
        {

            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar a data.")
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.VehiclePosition)
                .NotEmpty()
                .WithMessage("Favor informar o status do veículo.");

            RuleFor(e => e.ServiceHistoryId)
                .NotEmpty()
                .WithMessage("Favor informar o Id histórico de atendimento.");
        }

    }
}
