﻿using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class EmergencyHistoryBLL : BaseBLL<EmergencyHistoryModel, EmergencyHistory>, IEmergencyHistoryBLL
    {

        private readonly IMapper _mapper;
        private readonly IEmergencyHistoryDAL _emergencyHistoryDAL;
        private readonly IEmergencyBLL _emergencyBLL;
        private readonly EmergencyHistoryValidation _emergencyHistoryValidation;
        private readonly IEmergencyDAL _emergencyDAL;

        public EmergencyHistoryBLL(IEmergencyHistoryDAL emergencyHistoryDAL, EmergencyHistoryValidation emergencyHistoryValidation,
            IMapper mapper, IEmergencyBLL emergencyBLL, IEmergencyDAL emergencyDAL)
            : base(emergencyHistoryDAL)
        {
            _emergencyDAL = emergencyDAL;
            _emergencyHistoryDAL = emergencyHistoryDAL;
            _emergencyHistoryValidation = emergencyHistoryValidation;
            _mapper = mapper;
            _emergencyBLL = emergencyBLL;
        }

        public override Result Delete(EmergencyHistoryModel model)
        {
            try
            {
                EmergencyHistory emergencyHistory = _mapper.Map<EmergencyHistory>(model);
                _emergencyHistoryDAL.Delete(emergencyHistory);
                return _emergencyHistoryDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do histórico de ocorrência.", error);
            }
        }

        public override Result<EmergencyHistory> Register(EmergencyHistoryModel model)
        {
            try
            {
                EmergencyHistory emergencyHistory = _mapper.Map<EmergencyHistory>(model);

                var emergency = _emergencyDAL.Find(new EmergencyFilter { Id = model.EmergencyId });
                emergency.EmergencyStatus = model.EmergencyStatus;
                _emergencyDAL.Update(emergency);

                //var resultEmergency = _emergencyBLL.SimpleUpdate(model.EmergencyModel);
                //if (!resultEmergency.Success)
                //    return Result<EmergencyHistory>.BuildError(resultEmergency.Messages);

                var result = _emergencyHistoryValidation.Validate(emergencyHistory);
                if (!result.Success)
                    return result;

                _emergencyHistoryDAL.Insert(emergencyHistory);

                var resultSave = _emergencyHistoryDAL.Save();
                if (!resultSave.Success)
                    return Result<EmergencyHistory>.BuildError(resultSave.Messages);

                return Result<EmergencyHistory>.BuildSuccess(null);
            }
            catch (Exception error)
            {
                return Result<EmergencyHistory>.BuildError("Erro no momento de registar o histórico de ocorrência.", error);
            }
        }

        public override Result<EmergencyHistory> Update(EmergencyHistoryModel model)
        {
            try
            {
                EmergencyHistory emergencyHistory = _mapper.Map<EmergencyHistory>(model);
                var result = _emergencyHistoryValidation.Validate(emergencyHistory);
                if (!result.Success)
                    return result;

                _emergencyHistoryDAL.Update(emergencyHistory);
                var resultSave = _emergencyHistoryDAL.Save();
                if (!resultSave.Success)
                    return Result<EmergencyHistory>.BuildError(resultSave.Messages);
                return Result<EmergencyHistory>.BuildSuccess(emergencyHistory);
            }
            catch (Exception error)
            {
                return Result<EmergencyHistory>.BuildError("Erro ao alterar o registro do histórico da ocorrência.", error);
            }
        }

        public override Result<EmergencyHistoryModel> Find(IFilter filter)
        {
            try
            {
                EmergencyHistory emergencyHistory = _emergencyHistoryDAL.Find((EmergencyHistoryFilter)filter);
                EmergencyHistoryModel emergencyHistoryModel = _mapper.Map<EmergencyHistoryModel>(emergencyHistory);
                return Result<EmergencyHistoryModel>.BuildSuccess(emergencyHistoryModel);
            }
            catch (Exception error)
            {
                return Result<EmergencyHistoryModel>.BuildError("Erro ao localizar o histórico da ocorrência.", error);
            }
        }

        public override IQueryable<EmergencyHistoryModel> ApplyFilterPagination(IQueryable<EmergencyHistory> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result<List<EmergencyHistoryModel>> FindAll(IFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
