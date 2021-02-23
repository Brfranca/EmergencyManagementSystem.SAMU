using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.BLL
{
    public interface IServiceHistoryBLL : IBaseBLL<ServiceHistoryModel, ServiceHistory>
    {
        Result SendVehicle(ServiceHistoryModel serviceHistoryModel);
        Result CancelServiceHistory(ServiceCancellationHistoryModel serviceCancellation);
    }
}
