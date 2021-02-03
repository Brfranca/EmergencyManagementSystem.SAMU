using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class TeamMemberBLL : BaseBLL<TeamMemberModel>, ITeamMemberBLL
    {
        private readonly IMapper _mapper;
        private readonly ITeamMemberDAL _teamMemberDAL;
        private readonly TeamMemberValidation _teamMemberValidation;
        public TeamMemberBLL(IMapper mapper, ITeamMemberDAL teamMemberDAL, TeamMemberValidation teamMemberValidation)
        {
            _mapper = mapper;
            _teamMemberDAL = teamMemberDAL;
            _teamMemberValidation = teamMemberValidation;
        }

        public override Result Delete(TeamMemberModel model)
        {
            try
            {
                TeamMember teamMember = _mapper.Map<TeamMember>(model);
                _teamMemberDAL.Delete(teamMember);
                return _teamMemberDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do integrante do veículo.", error);
            }
        }

        public override Result<TeamMemberModel> Find(IFilter filter)
        {
            try
            {
                TeamMember teamMember = _teamMemberDAL.Find((TeamMemberFilter)filter);
                TeamMemberModel teamMemberModel = _mapper.Map<TeamMemberModel>(teamMember);
                return Result<TeamMemberModel>.BuildSuccess(teamMemberModel);
            }
            catch (Exception error)
            {
                return Result<TeamMemberModel>.BuildError("Erro ao localizar o integrante do veículo.", error);
            }
        }

        public override Result Register(TeamMemberModel model)
        {
            try
            {
                TeamMember teamMember = _mapper.Map<TeamMember>(model);

                Result result = _teamMemberValidation.Validate(teamMember);
                if (!result.Success)
                    return result;

                _teamMemberDAL.Insert(teamMember);
                return _teamMemberDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar do integrante do veículo.", error);
            }
        }

        public override Result Update(TeamMemberModel model)
        {
            try
            {
                TeamMember teamMember = _mapper.Map<TeamMember>(model);
                _teamMemberDAL.Update(teamMember);
                return _teamMemberDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do integrante do veículo.", error);
            }
        }
    }
}
