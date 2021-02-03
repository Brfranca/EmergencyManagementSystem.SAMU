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
    public class EmergencyBLL : BaseBLL<EmergencyModel>, IEmergencyBLL
    {
        private readonly IMapper _mapper;
        private readonly IEmergencyDAL _emergencyDAL;
        private readonly EmergencyValidation _emergencyValidation;
        public EmergencyBLL(IMapper mapper, IEmergencyDAL emergencyDAL, EmergencyValidation emergencyValidation)
        {
            _mapper = mapper;
            _emergencyDAL = emergencyDAL;
            _emergencyValidation = emergencyValidation;
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

        public override Result Register(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);

                Result result = _emergencyValidation.Validate(emergency);
                if (!result.Success)
                    return result;

                _emergencyDAL.Insert(emergency);
                return _emergencyDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar a emergência.", error);
            }
        }

        public override Result Update(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);
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
