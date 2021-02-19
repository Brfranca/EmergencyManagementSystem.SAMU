using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.BLL
{
    public interface IEmergencyBLL : IBaseBLL<EmergencyModel, Emergency>
    {
        Result SimpleRegister(EmergencyModel model);
        Result SimpleUpdate(EmergencyModel model);

    }
}
