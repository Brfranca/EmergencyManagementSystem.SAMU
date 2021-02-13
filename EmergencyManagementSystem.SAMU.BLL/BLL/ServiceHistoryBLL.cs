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
    public class ServiceHistoryBLL : BaseBLL<ServiceHistoryModel, ServiceHistory>, IServiceHistoryBLL
    {
        private readonly IMapper _mapper;
        private readonly IServiceHistoryDAL _vehicleTeamDAL;
        private readonly ServiceHistoryValidation _vehicleTeamValidation;

        public ServiceHistoryBLL(IMapper mapper, IServiceHistoryDAL vehicleTeamDAL, ServiceHistoryValidation vehicleTeamValidation)
            : base(vehicleTeamDAL)
        {
            _mapper = mapper;
            _vehicleTeamDAL = vehicleTeamDAL;
            _vehicleTeamValidation = vehicleTeamValidation;
        }

        public override IQueryable<ServiceHistoryModel> ApplyFilterPagination(IQueryable<ServiceHistory> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(ServiceHistoryModel model)
        {
            try
            {
                ServiceHistory vehicleTeam = _mapper.Map<ServiceHistory>(model);
                _vehicleTeamDAL.Delete(vehicleTeam);
                return _vehicleTeamDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do veículo empenhado na ocorrência.", error);
            }
        }

        public override Result<ServiceHistoryModel> Find(IFilter filter)
        {
            try
            {
                ServiceHistory vehicleTeam = _vehicleTeamDAL.Find((ServiceHistoryFilter)filter);
                ServiceHistoryModel vehicleTeamModel = _mapper.Map<ServiceHistoryModel>(vehicleTeam);
                return Result<ServiceHistoryModel>.BuildSuccess(vehicleTeamModel);
            }
            catch (Exception error)
            {
                return Result<ServiceHistoryModel>.BuildError("Erro ao localizar o veículo empenhado na ocorrência.", error);
            }
        }

        public override Result<ServiceHistory> Register(ServiceHistoryModel model)
        {
            try
            {
                ServiceHistory vehicleTeam = _mapper.Map<ServiceHistory>(model);

                var result = _vehicleTeamValidation.Validate(vehicleTeam);
                if (!result.Success)
                    return result;

                _vehicleTeamDAL.Insert(vehicleTeam);

                var resultSave = _vehicleTeamDAL.Save();
                if (!resultSave.Success)
                    return Result<ServiceHistory>.BuildError(resultSave.Messages);

                return Result<ServiceHistory>.BuildSuccess(vehicleTeam);
            }
            catch (Exception error)
            {
                return Result<ServiceHistory>.BuildError("Erro no momento de registar o veículo empenhado na ocorrência.", error);
            }
        }

        public override Result Update(ServiceHistoryModel model)
        {
            try
            {
                ServiceHistory vehicleTeam = _mapper.Map<ServiceHistory>(model);

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
