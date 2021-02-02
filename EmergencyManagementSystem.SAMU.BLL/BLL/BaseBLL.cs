using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        public abstract Result Register(T model);
        public abstract Result Update(T model);
        public abstract Result Delete(T model);
        public abstract Result<T> Find(IFilter filter);
    }
}
