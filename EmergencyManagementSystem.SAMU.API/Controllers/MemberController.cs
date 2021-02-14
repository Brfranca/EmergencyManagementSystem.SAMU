using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    public class MemberController : BaseController<MemberModel, Member, MemberFilter>
    {
        public MemberController(IMemberBLL memberBLL) : base(memberBLL)
        {

        }
    }
}
