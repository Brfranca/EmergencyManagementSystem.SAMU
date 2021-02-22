using AutoMapper;
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
    public class VehicleBLL : BaseBLL<VehicleModel, Vehicle>, IVehicleBLL
    {
        private readonly IMapper _mapper;
        private readonly IVehicleDAL _vehicleDAL;
        private readonly VehicleValidation _vehicleValidation;
        public VehicleBLL(IMapper mapper, IVehicleDAL vehicleDAL, VehicleValidation vehicleValidation)
            : base(vehicleDAL)
        {
            _mapper = mapper;
            _vehicleDAL = vehicleDAL;
            _vehicleValidation = vehicleValidation;
        }

        public override IQueryable<VehicleModel> ApplyFilterPagination(IQueryable<Vehicle> query, IFilter filter)
        {
            var vehicleFilter = (VehicleFilter)filter;

            if (!string.IsNullOrWhiteSpace(vehicleFilter.VehicleName))
                query = query.Where(d => d.VehicleName.Contains(vehicleFilter.VehicleName));
            if (!string.IsNullOrWhiteSpace(vehicleFilter.VehiclePlate))
                query = query.Where(d => d.VehiclePlate.Contains(vehicleFilter.VehiclePlate));
            if (!string.IsNullOrWhiteSpace(vehicleFilter.Codename))
                query = query.Where(d => d.Codename.Contains(vehicleFilter.Codename));
            if (!string.IsNullOrWhiteSpace(vehicleFilter.OperationCity))
                query = query.Where(d => d.OperationCity.Contains(vehicleFilter.OperationCity));

            return query.Select(d => _mapper.Map<VehicleModel>(d));
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

        public override Result<List<VehicleModel>> FindAll(IFilter filter)
        {
            try
            {
                var vehicles = _vehicleDAL.FindAll((VehicleFilter)filter);
                var vehiclesModel = _mapper.Map<List<VehicleModel>>(vehicles);
                return Result<List<VehicleModel>>.BuildSuccess(vehiclesModel);
            }
            catch (Exception error)
            {
                return Result<List<VehicleModel>>.BuildError("Erro ao localizar o veículo.", error);
            }
        }

        public override Result<Vehicle> Register(VehicleModel model)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(model);

                var result = _vehicleValidation.Validate(vehicle);
                if (!result.Success)
                    return result;

                _vehicleDAL.Insert(vehicle);

                var resultSave = _vehicleDAL.Save();
                if (!resultSave.Success)
                    return Result<Vehicle>.BuildError(resultSave.Messages);

                return Result<Vehicle>.BuildSuccess(vehicle);
            }
            catch (Exception error)
            {
                return Result<Vehicle>.BuildError("Erro no momento de registar o veículo.", error);
            }
        }

        public override Result<Vehicle> Update(VehicleModel model)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(model);

                var result = _vehicleValidation.Validate(vehicle);
                if (!result.Success)
                    return result;

                _vehicleDAL.Update(vehicle);
                var resultSave = _vehicleDAL.Save();
                if (!resultSave.Success)
                    return Result<Vehicle>.BuildError(resultSave.Messages);

                return Result<Vehicle>.BuildSuccess(vehicle);
            }
            catch (Exception error)
            {
                return Result<Vehicle>.BuildError("Erro ao alterar o registro do veículo.", error);
            }
        }
    }
}
