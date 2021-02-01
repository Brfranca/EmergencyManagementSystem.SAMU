using EmergencyManagementSystem.SAMU.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.BLL
{
    public interface IBaseBLL<T> where T : class
    {
        Result Register(T model);
        Result Update(T model);
        Result Delete(T model);
        Result<T> Find(IFilter filter);
    }
}
