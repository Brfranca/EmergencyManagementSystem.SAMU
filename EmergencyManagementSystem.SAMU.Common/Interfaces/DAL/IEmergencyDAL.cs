using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IEmergencyDAL : IBaseDAL<Emergency>
    {
        Emergency Find(EmergencyFilter filter);
    }
}
