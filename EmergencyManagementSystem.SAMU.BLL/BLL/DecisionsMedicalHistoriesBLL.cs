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
    public class DecisionsMedicalHistoriesBLL : BaseBLL<MedicalDecisionHistoryModel, MedicalDecisionHistory>, IMedicalDecisionHistoryBLL
    {
        private readonly IMedicalDecisionHistoryDAL _decisionsMedicalHistoriesDAL;
        private readonly IMapper _mapper;
        private readonly MedicalDecisionHistoryValidation _medicalDecisionValidation;

        public DecisionsMedicalHistoriesBLL(IMedicalDecisionHistoryDAL decisionsMedicalHistoriesDAL, IMapper mapper, MedicalDecisionHistoryValidation medicalDecisionValidation)
            : base(decisionsMedicalHistoriesDAL)
        {
            _mapper = mapper;
            _decisionsMedicalHistoriesDAL = decisionsMedicalHistoriesDAL;
            _medicalDecisionValidation = medicalDecisionValidation;
        }

        public override IQueryable<MedicalDecisionHistoryModel> ApplyFilterPagination
            (IQueryable<MedicalDecisionHistory> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(MedicalDecisionHistoryModel model)
        {
            throw new NotImplementedException();
        }

        public override Result<MedicalDecisionHistoryModel> Find(IFilter filter)
        {
            try
            {
                var decisionMedicalHistory = _decisionsMedicalHistoriesDAL.Find((DecisionsMedicalHistoriesFilter)filter);
                var model = _mapper.Map<MedicalDecisionHistoryModel>(decisionMedicalHistory);
                return Result<MedicalDecisionHistoryModel>.BuildSuccess(model);
            }
            catch (Exception error)
            {
                return Result<MedicalDecisionHistoryModel>.BuildError("Erro ao buscar histórico de decisões médicas", error);
            }
        }

        public override Result<List<MedicalDecisionHistoryModel>> FindAll(IFilter filter)
        {
            try
            {
                List<MedicalDecisionHistory> histories = _decisionsMedicalHistoriesDAL.FindAll((DecisionsMedicalHistoriesFilter)filter);
                List<MedicalDecisionHistoryModel> models = _mapper.Map<List<MedicalDecisionHistoryModel>>(histories);
                return Result<List<MedicalDecisionHistoryModel>>.BuildSuccess(models);
            }
            catch (Exception error)
            {
                return Result<List<MedicalDecisionHistoryModel>>.BuildError("Erro ao buscar históricos de decisões médicas", error);
            }
        }

        public override Result<MedicalDecisionHistory> Register(MedicalDecisionHistoryModel model)
        {
            MedicalDecisionHistory history = _mapper.Map<MedicalDecisionHistory>(model);

            var result = _medicalDecisionValidation.Validate(history);
            if (!result.Success)
                return result;

            _decisionsMedicalHistoriesDAL.Insert(history);

            var resultSave = _decisionsMedicalHistoriesDAL.Save();
            if (!resultSave.Success)
                return Result<MedicalDecisionHistory>.BuildError(resultSave.Messages);

            return Result<MedicalDecisionHistory>.BuildSuccess(history);
        }

        public override Result<MedicalDecisionHistory> Update(MedicalDecisionHistoryModel model)
        {
            MedicalDecisionHistory history = _mapper.Map<MedicalDecisionHistory>(model);

            var result = _medicalDecisionValidation.Validate(history);
            if (!result.Success)
                return result;

            _decisionsMedicalHistoriesDAL.Update(history);

            var resultSave = _decisionsMedicalHistoriesDAL.Save();
            if (!resultSave.Success)
                return Result<MedicalDecisionHistory>.BuildError(resultSave.Messages);

            return Result<MedicalDecisionHistory>.BuildSuccess(history);
        }
    }
}
