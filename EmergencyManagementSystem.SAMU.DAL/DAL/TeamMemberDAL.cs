using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class TeamMemberDAL : BaseDAL<TeamMember>, ITeamMemberDAL
    {
        public TeamMemberDAL(Context context) : base(context)
        {
        }

        public TeamMember Find(TeamMemberFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
