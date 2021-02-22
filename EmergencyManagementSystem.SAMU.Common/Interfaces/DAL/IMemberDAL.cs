using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Common.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using EmergencyManagementSystem.SAMU.Common.Models;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface IMemberDAL : IBaseDAL<Member>
    {
        Member Find(MemberFilter filter);
        List<Member> FindAll(MemberFilter filterImpl);
    }
}
