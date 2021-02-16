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
    public class EmergencyBLL : BaseBLL<EmergencyModel, Emergency>, IEmergencyBLL
    {
        private readonly IMapper _mapper;
        private readonly IEmergencyDAL _emergencyDAL;
        private readonly EmergencyValidation _emergencyValidation;
        public EmergencyBLL(IMapper mapper, IEmergencyDAL emergencyDAL, EmergencyValidation emergencyValidation)
            : base(emergencyDAL)
        {
            _mapper = mapper;
            _emergencyDAL = emergencyDAL;
            _emergencyValidation = emergencyValidation;
        }

        public override IQueryable<EmergencyModel> ApplyFilterPagination(IQueryable<Emergency> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);
                _emergencyDAL.Delete(emergency);
                return _emergencyDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro da emergência.", error);
            }
        }

        public override Result<EmergencyModel> Find(IFilter filter)
        {
            try
            {
                Emergency emergency = _emergencyDAL.Find((EmergencyFilter)filter);
                EmergencyModel emergencyModel = _mapper.Map<EmergencyModel>(emergency);
                return Result<EmergencyModel>.BuildSuccess(emergencyModel);
            }
            catch (Exception error)
            {
                return Result<EmergencyModel>.BuildError("Erro ao localizar o registro da emergência.", error);
            }
        }

        public override Result<Emergency> Register(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);

                var result = _emergencyValidation.Validate(emergency);
                if (!result.Success)
                    return result;

                _emergencyDAL.Insert(emergency);

                var resultSave = _emergencyDAL.Save();
                if (!resultSave.Success)
                    return Result<Emergency>.BuildError(resultSave.Messages);

                return Result<Emergency>.BuildSuccess(emergency);

            }
            catch (Exception error)
            {
                return Result<Emergency>.BuildError("Erro no momento de registar a emergência.", error);
            }
        }

        public Result SimpleRegister(EmergencyModel model)
        {
            Emergency emergency = _mapper.Map<Emergency>(model);

            if (string.IsNullOrWhiteSpace(emergency.RequesterPhone))
                return Result.BuildError("Número do solicitante é obrigatório.");

            _emergencyDAL.Insert(emergency);

            var resultSave = _emergencyDAL.Save();
            if (!resultSave.Success)
                return Result<Emergency>.BuildError(resultSave.Messages);

            return Result<Emergency>.BuildSuccess(emergency);
        }

        public override Result Update(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);

                Result result = _emergencyValidation.Validate(emergency);
                if (!result.Success)
                    return result;

                _emergencyDAL.Update(emergency);
                return _emergencyDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro da ocorrência.", error);
            }
        }
    }
}
