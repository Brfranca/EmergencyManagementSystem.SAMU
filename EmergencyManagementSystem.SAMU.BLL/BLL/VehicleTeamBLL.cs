using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class VehicleTeamBLL : BaseBLL<VehicleTeamModel, VehicleTeam>, IVehicleTeamBLL
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTeamDAL _vehicleTeamDAL;
        private readonly VehicleTeamValidation _vehicleTeamValidation;

        public VehicleTeamBLL(IMapper mapper, IVehicleTeamDAL vehicleTeamDAL, VehicleTeamValidation vehicleTeamValidation)
            : base(vehicleTeamDAL)
        {
            _mapper = mapper;
            _vehicleTeamDAL = vehicleTeamDAL;
            _vehicleTeamValidation = vehicleTeamValidation;
        }

        public override IQueryable<VehicleTeamModel> ApplyFilterPagination(IQueryable<VehicleTeam> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(VehicleTeamModel model)
        {
            try
            {
                VehicleTeam vehicleTeam = _mapper.Map<VehicleTeam>(model);
                _vehicleTeamDAL.Delete(vehicleTeam);
                return _vehicleTeamDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do veículo empenhado na ocorrência.", error);
            }
        }

        public override Result<VehicleTeamModel> Find(IFilter filter)
        {
            try
            {
                VehicleTeam vehicleTeam = _vehicleTeamDAL.Find((VehicleTeamFilter)filter);
                VehicleTeamModel vehicleTeamModel = _mapper.Map<VehicleTeamModel>(vehicleTeam);
                return Result<VehicleTeamModel>.BuildSuccess(vehicleTeamModel);
            }
            catch (Exception error)
            {
                return Result<VehicleTeamModel>.BuildError("Erro ao localizar o veículo empenhado na ocorrência.", error);
            }
        }

        public override Result<VehicleTeam> Register(VehicleTeamModel model)
        {
            try
            {
                VehicleTeam vehicleTeam = _mapper.Map<VehicleTeam>(model);

                var result = _vehicleTeamValidation.Validate(vehicleTeam);
                if (!result.Success)
                    return result;

                _vehicleTeamDAL.Insert(vehicleTeam);

                var resultSave = _vehicleTeamDAL.Save();
                if (!resultSave.Success)
                    return Result<VehicleTeam>.BuildError(resultSave.Messages);

                return Result<VehicleTeam>.BuildSuccess(vehicleTeam);
            }
            catch (Exception error)
            {
                return Result<VehicleTeam>.BuildError("Erro no momento de registar o veículo empenhado na ocorrência.", error);
            }
        }

        public override Result Update(VehicleTeamModel model)
        {
            try
            {
                VehicleTeam vehicleTeam = _mapper.Map<VehicleTeam>(model);

                var result = _vehicleTeamValidation.Validate(vehicleTeam);
                if (!result.Success)
                    return result;

                _vehicleTeamDAL.Update(vehicleTeam);
                return _vehicleTeamDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do veículo empenhado na ocorrência.", error);
            }
        }
    }
}
