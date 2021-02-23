using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using EmergencyManagementSystem.SAMU.Entities.Enums;
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

                var resultFind = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                {
                    ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                    VehiclePosition = vehiclePositionHistory.VehiclePosition
                });

                if ((resultFind?.Id??0) > 0)
                {
                    _vehiclePositionHistoryDAL.Update(vehiclePositionHistory);
                    var resultUpdate = _vehiclePositionHistoryDAL.Save();
                    if (!resultUpdate.Success)
                        return Result<VehiclePositionHistory>.BuildError(resultUpdate.Messages);
                    return Result<VehiclePositionHistory>.BuildSuccess(vehiclePositionHistory);
                }
                if (vehiclePositionHistory.VehiclePosition == VehiclePosition.J10Local)
                {
                    var resultJ = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                    {
                        ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                        VehiclePosition = VehiclePosition.J9Local
                    });
                    if ((resultJ?.Id??0) == 0)
                        return Result<VehiclePositionHistory>.BuildError("Para cadastrar o J10 no local da ocorrência é necessário informar o J9.");
                }
                if (vehiclePositionHistory.VehiclePosition == VehiclePosition.J9Hospital)
                {
                    var resultJ = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                    {
                        ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                        VehiclePosition = VehiclePosition.J10Local
                    });
                    if ((resultJ?.Id ?? 0) == 0)
                        return Result<VehiclePositionHistory>.BuildError("Para cadastrar o J9 para o hospital é necessário informar o J10 no local da ocorrência.");
                }
                if (vehiclePositionHistory.VehiclePosition == VehiclePosition.J10Hospital)
                {
                    var resultJ = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                    {
                        ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                        VehiclePosition = VehiclePosition.J9Hospital
                    });
                    if ((resultJ?.Id ?? 0) == 0)
                        return Result<VehiclePositionHistory>.BuildError("Para cadastrar o J10 no hospital é necessário informar o J9 para o Hospital.");
                }
                if (vehiclePositionHistory.VehiclePosition == VehiclePosition.J11)
                {
                    var resultJ9H = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                    {
                        ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                        VehiclePosition = VehiclePosition.J9Hospital
                    });
                    if ((resultJ9H?.Id??0) > 0)
                    {
                        var resultJ10H = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                        {
                            ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                            VehiclePosition = VehiclePosition.J10Hospital
                        });
                        if ((resultJ10H?.Id??0) == 0)
                        {
                            return Result<VehiclePositionHistory>.BuildError("Para cadastrar o J11 é necessário informar o J10 no Hospital.");
                        }
                    }
                    else
                    {
                        var resultJ = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                        {
                            ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                            VehiclePosition = VehiclePosition.J10Local
                        });
                        if (resultJ.Id == 0)
                            return Result<VehiclePositionHistory>.BuildError("Para cadastrar o J11 é necessário informar o J10 no local.");
                    }
                    
                    //VehicleStatus-> liberado
                }
                if (vehiclePositionHistory.VehiclePosition == VehiclePosition.J12)
                {
                    var resultJ10Local = _vehiclePositionHistoryDAL.Find(new VehiclePositionHistoryFilter
                    {
                        ServiceHistoryId = vehiclePositionHistory.ServiceHistoryId,
                        VehiclePosition = VehiclePosition.J11
                    });
                    if (resultJ10Local.Id > 0)
                        return Result<VehiclePositionHistory>.BuildError("Para cadastrar o J12 é necessário informar o J11.");
                    //Emergency closed _> ver se não tem mais serices history em aberto
                    //service history pra finalizada
                }

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

        public override Result<VehiclePositionHistory> Update(VehiclePositionHistoryModel model)
        {
            try
            {
                VehiclePositionHistory vehiclePositionHistory = _mapper.Map<VehiclePositionHistory>(model);

                var result = _vehiclePositionHistoryValidation.Validate(vehiclePositionHistory);
                if (!result.Success)
                    return result;

                _vehiclePositionHistoryDAL.Update(vehiclePositionHistory);
                var resulSave = _vehiclePositionHistoryDAL.Save();
                if (!resulSave.Success)
                    return Result<VehiclePositionHistory>.BuildError(resulSave.Messages);

                return Result<VehiclePositionHistory>.BuildSuccess(vehiclePositionHistory);
            }
            catch (Exception error)
            {
                return Result<VehiclePositionHistory>.BuildError("Erro ao alterar o registro da posição do veículo.", error);
            }
        }
    }
}
