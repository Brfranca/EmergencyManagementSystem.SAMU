using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class MemberDAL : BaseDAL<Member>, IMemberDAL
    {
        public MemberDAL(Context context) : base(context)
        {

        }
        public Member Find(MemberFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
