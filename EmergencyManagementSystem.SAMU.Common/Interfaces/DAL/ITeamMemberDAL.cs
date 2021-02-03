using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.DAL
{
    public interface ITeamMemberDAL : IBaseDAL<TeamMember>
    {
        TeamMember Find(TeamMemberFilter filter);
    }
}
