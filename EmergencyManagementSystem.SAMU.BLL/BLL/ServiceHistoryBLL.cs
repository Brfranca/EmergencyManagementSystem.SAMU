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
    public class ServiceHistoryBLL : BaseBLL<ServiceHistoryModel, ServiceHistory>, IServiceHistoryBLL
    {
        private readonly IMapper _mapper;
        private readonly IServiceHistoryDAL _serviceHistoryDAL;
        private readonly ServiceHistoryValidation _serviceHistoryValidation;

        public ServiceHistoryBLL(IMapper mapper, IServiceHistoryDAL serviceHistoryDAL, ServiceHistoryValidation serviceHistoryValidation)
            : base(serviceHistoryDAL)
        {
            _mapper = mapper;
            _serviceHistoryDAL = serviceHistoryDAL;
            _serviceHistoryValidation = serviceHistoryValidation;
        }

        public override IQueryable<ServiceHistoryModel> ApplyFilterPagination(IQueryable<ServiceHistory> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(ServiceHistoryModel model)
        {
            try
            {
                ServiceHistory serviceHistory = _mapper.Map<ServiceHistory>(model);
                _serviceHistoryDAL.Delete(serviceHistory);
                return _serviceHistoryDAL.Save();
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
                ServiceHistory serviceHistory = _serviceHistoryDAL.Find((ServiceHistoryFilter)filter);
                ServiceHistoryModel serviceHistoryModel = _mapper.Map<ServiceHistoryModel>(serviceHistory);
                return Result<ServiceHistoryModel>.BuildSuccess(serviceHistoryModel);
            }
            catch (Exception error)
            {
                return Result<ServiceHistoryModel>.BuildError("Erro ao localizar o veículo empenhado na ocorrência.", error);
            }
        }

        public override Result<List<ServiceHistoryModel>> FindAll(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result<ServiceHistory> Register(ServiceHistoryModel model)
        {
            try
            {
                ServiceHistory serviceHistory = _mapper.Map<ServiceHistory>(model);

                var result = _serviceHistoryValidation.Validate(serviceHistory);
                if (!result.Success)
                    return result;

                _serviceHistoryDAL.Insert(serviceHistory);

                var resultSave = _serviceHistoryDAL.Save();
                if (!resultSave.Success)
                    return Result<ServiceHistory>.BuildError(resultSave.Messages);

                return Result<ServiceHistory>.BuildSuccess(serviceHistory);
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
                ServiceHistory serviceHistory = _mapper.Map<ServiceHistory>(model);

                var result = _serviceHistoryValidation.Validate(serviceHistory);
                if (!result.Success)
                    return result;

                _serviceHistoryDAL.Update(serviceHistory);
                return _serviceHistoryDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do veículo empenhado na ocorrência.", error);
            }
        }
    }
}
