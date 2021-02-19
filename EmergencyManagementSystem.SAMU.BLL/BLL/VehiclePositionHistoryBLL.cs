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
    public class VehiclePositionHistoryBLL : BaseBLL<VehiclePositionHistoryModel, VehiclePositionHistory>, IVehiclePositionHistoryBLL
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionHistoryDAL _vehiclePositionHistoryDAL;
        private readonly VehiclePositionHistoryValidation _vehiclePositionHistoryValidation;

        public VehiclePositionHistoryBLL(IMapper mapper, IVehiclePositionHistoryDAL vehiclePositionHistoryDAL, VehiclePositionHistoryValidation vehiclePositionHistoryValidation)
            : base(vehiclePositionHistoryDAL)
        {
            _mapper = mapper;
            _vehiclePositionHistoryDAL = vehiclePositionHistoryDAL;
            _vehiclePositionHistoryValidation = vehiclePositionHistoryValidation;
        }

        public override IQueryable<VehiclePositionHistoryModel> ApplyFilterPagination(IQueryable<VehiclePositionHistory> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(VehiclePositionHistoryModel model)
        {
            try
            {
                VehiclePositionHistory vehiclePositionHistory = _mapper.Map<VehiclePositionHistory>(model);
                _vehiclePositionHistoryDAL.Delete(vehiclePositionHistory);
                return _vehiclePositionHistoryDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro da posição do veículo.", error);
            }
        }

        public override Result<VehiclePositionHistoryModel> Find(IFilter filter)
        {
            try
            {
                VehiclePositionHistory vehiclePositionHistory = _vehiclePositionHistoryDAL.Find((VehiclePositionHistoryFilter)filter);
                VehiclePositionHistoryModel vehiclePositionHistoryModel = _mapper.Map<VehiclePositionHistoryModel>(vehiclePositionHistory);
                return Result<VehiclePositionHistoryModel>.BuildSuccess(vehiclePositionHistoryModel);
            }
            catch (Exception error)
            {
                return Result<VehiclePositionHistoryModel>.BuildError("Erro ao localizar o registro da posição do veículo.", error);
            }
        }

        public override Result<List<VehiclePositionHistoryModel>> FindAll(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result<VehiclePositionHistory> Register(VehiclePositionHistoryModel model)
        {
            try
            {
                VehiclePositionHistory vehiclePositionHistory = _mapper.Map<VehiclePositionHistory>(model);

                var result = _vehiclePositionHistoryValidation.Validate(vehiclePositionHistory);
                if (!result.Success)
                    return result;

                _vehiclePositionHistoryDAL.Insert(vehiclePositionHistory);

                var resultSave = _vehiclePositionHistoryDAL.Save();
                if (!resultSave.Success)
                    return Result<VehiclePositionHistory>.BuildError(resultSave.Messages);

                return Result<VehiclePositionHistory>.BuildSuccess(vehiclePositionHistory);
            }
            catch (Exception error)
            {
                return Result<VehiclePositionHistory>.BuildError("Erro no momento de registar a posição do veículo.", error);
            }
        }

        public override Result Update(VehiclePositionHistoryModel model)
        {
            try
            {
                VehiclePositionHistory vehiclePositionHistory = _mapper.Map<VehiclePositionHistory>(model);

                var result = _vehiclePositionHistoryValidation.Validate(vehiclePositionHistory);
                if (!result.Success)
                    return result;

                _vehiclePositionHistoryDAL.Update(vehiclePositionHistory);
                return _vehiclePositionHistoryDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro da posição do veículo.", error);
            }
        }
    }
}
