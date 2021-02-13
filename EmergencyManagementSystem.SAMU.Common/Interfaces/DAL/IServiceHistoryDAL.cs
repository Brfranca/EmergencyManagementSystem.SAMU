using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IServiceHistoryDAL : IBaseDAL<ServiceHistory>
    {
        ServiceHistory Find(ServiceHistoryFilter filter);
    }
}
