using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Common.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IMemberDAL : IBaseDAL<Member>
    {
        Member Find(MemberFilter filter);
    }
}
