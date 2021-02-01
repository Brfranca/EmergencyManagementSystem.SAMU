using EmergencyManagementSystem.SAMU.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces
{
    public interface IBaseDAL<T>
    {
        Result Insert(T entity);
        Result Update(T entity);
        Result Delete(T entity);
        Result Save();
    }
}

