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
    public class EmergencyRequiredVehicleBLL : BaseBLL<EmergencyRequiredVehicleModel>, IEmergencyRequiredVehicleBLL
    {
        private readonly IMapper _mapper;
        private readonly IEmergencyRequiredVehicleDAL _emergencyRequiredVehicleDAL;
        private readonly EmergencyRequiredVehicleValidation _emergencyRequiredVehicleValidation;

        public EmergencyRequiredVehicleBLL(IMapper mapper, IEmergencyRequiredVehicleDAL emergencyDataDAL, EmergencyRequiredVehicleValidation emergencyDataValidation)
        {
            _mapper = mapper;
            _emergencyRequiredVehicleDAL = emergencyDataDAL;
            _emergencyRequiredVehicleValidation = emergencyDataValidation;
        }

        public override Result Delete(EmergencyRequiredVehicleModel model)
        {
            try
            {
                EmergencyRequiredVehicle emergencyRequiredVehicle = _mapper.Map<EmergencyRequiredVehicle>(model);
                _emergencyRequiredVehicleDAL.Delete(emergencyRequiredVehicle);
                return _emergencyRequiredVehicleDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do veículo requerido para a ocorrência.", error);
            }
        }

        public override Result<EmergencyRequiredVehicleModel> Find(IFilter filter)
        {
            try
            {
                EmergencyRequiredVehicle emergencyData = _emergencyRequiredVehicleDAL.Find((EmergencyRequiredVehicleFilter)filter);
                EmergencyRequiredVehicleModel emergencyRequiredVehicleModel = _mapper.Map<EmergencyRequiredVehicleModel>(emergencyData);
                return Result<EmergencyRequiredVehicleModel>.BuildSuccess(emergencyRequiredVehicleModel);
            }
            catch (Exception error)
            {
                return Result<EmergencyRequiredVehicleModel>.BuildError("Erro ao localizar o registro do veículo requerido para a ocorrência.", error);
            }
        }

        public override Result Register(EmergencyRequiredVehicleModel model)
        {
            try
            {
                EmergencyRequiredVehicle emergencyRequiredVehicle = _mapper.Map<EmergencyRequiredVehicle>(model);

                var result = _emergencyRequiredVehicleValidation.Validate(emergencyRequiredVehicle);
                if (!result.Success)
                    return result;

                _emergencyRequiredVehicleDAL.Insert(emergencyRequiredVehicle);
                return _emergencyRequiredVehicleDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar do veículo requerido para a ocorrência.", error);
            }
        }

        public override Result Update(EmergencyRequiredVehicleModel model)
        {
            try
            {
                EmergencyRequiredVehicle emergencyRequiredVehicle = _mapper.Map<EmergencyRequiredVehicle>(model);

                var result = _emergencyRequiredVehicleValidation.Validate(emergencyRequiredVehicle);
                if (!result.Success)
                    return result;

                _emergencyRequiredVehicleDAL.Update(emergencyRequiredVehicle);
                return _emergencyRequiredVehicleDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do veículo requerido para a ocorrência.", error);
            }
        }
    }
}
