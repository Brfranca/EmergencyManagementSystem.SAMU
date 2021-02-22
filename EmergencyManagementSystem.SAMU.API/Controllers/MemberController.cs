using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    public class MemberController : BaseController<MemberModel, Member, MemberFilter>
    {
        public MemberController(IMemberBLL memberBLL) : base(memberBLL)
        {

        }
    }
}
