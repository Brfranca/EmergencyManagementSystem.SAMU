using EmergencyManagementSystem.SAMU.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.SAMU.BLL.Validations
{
    public class ServiceHistoryValidation : BaseValidation<ServiceHistory>
    {
        public ServiceHistoryValidation()
        {
            RuleFor(e => e.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a data.");

            RuleFor(e => e.ServiceHistoryStatus)
                .NotEmpty()
                .WithMessage("Favor informar o status da equipe do veículo.");

            RuleFor(e => e.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a descrição.")
                .Length(5, 150)
                .WithMessage("A descrição deve conter entre 5 e 150 caracteres.");

            RuleFor(e => e.VehicleId)
                .NotEmpty()
                .WithMessage("Favor informar o Id do veículo.");

            RuleFor(e => e.EmergencyId)
                .NotEmpty()
                .WithMessage("Favor informar o Id da ocorrência.");
        }
    }
}
