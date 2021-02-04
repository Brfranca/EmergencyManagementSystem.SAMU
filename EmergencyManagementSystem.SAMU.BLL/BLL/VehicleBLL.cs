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
    public class VehicleBLL : BaseBLL<VehicleModel>, IVehicleBLL
    {
        private readonly IMapper _mapper;
        private readonly IVehicleDAL _vehicleDAL;
        private readonly VehicleValidation _vehicleValidation;
        public VehicleBLL(IMapper mapper, IVehicleDAL vehicleDAL, VehicleValidation vehicleValidation)
        {
            _mapper = mapper;
            _vehicleDAL = vehicleDAL;
            _vehicleValidation = vehicleValidation;
        }

        public override Result Delete(VehicleModel model)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(model);
                _vehicleDAL.Delete(vehicle);
                return _vehicleDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do veículo.", error);
            }
        }

        public override Result<VehicleModel> Find(IFilter filter)
        {
            try
            {
                Vehicle vehicle = _vehicleDAL.Find((VehicleFilter)filter);
                VehicleModel vehicleModel = _mapper.Map<VehicleModel>(vehicle);
                return Result<VehicleModel>.BuildSuccess(vehicleModel);
            }
            catch (Exception error)
            {
                return Result<VehicleModel>.BuildError("Erro ao localizar o veículo.", error);
            }
        }

        public override Result Register(VehicleModel model)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(model);

                var result = _vehicleValidation.Validate(vehicle);
                if (!result.Success)
                    return result;

                _vehicleDAL.Insert(vehicle);
                return _vehicleDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar o veículo.", error);
            }
        }

        public override Result Update(VehicleModel model)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(model);

                var result = _vehicleValidation.Validate(vehicle);
                if (!result.Success)
                    return result;

                _vehicleDAL.Update(vehicle);
                return _vehicleDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do veículo.", error);
            }
        }
    }
}
