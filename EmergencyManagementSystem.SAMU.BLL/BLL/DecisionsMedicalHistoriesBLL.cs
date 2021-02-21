using AutoMapper;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class DecisionsMedicalHistoriesBLL : BaseBLL<DecisionsMedicalHistoriesModel, DecisionsMedicalHistories>, IDecisionsMedicalHistoriesBLL
    {
        private readonly IDecisionsMedicalHistoriesDAL _decisionsMedicalHistoriesDAL;
        private readonly IMapper _mapper;
        public DecisionsMedicalHistoriesBLL(IDecisionsMedicalHistoriesDAL decisionsMedicalHistoriesDAL, IMapper mapper)
            : base(decisionsMedicalHistoriesDAL)
        {
            _mapper = mapper;
            _decisionsMedicalHistoriesDAL = decisionsMedicalHistoriesDAL;
        }

        public override IQueryable<DecisionsMedicalHistoriesModel> ApplyFilterPagination
            (IQueryable<DecisionsMedicalHistories> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(DecisionsMedicalHistoriesModel model)
        {
            throw new NotImplementedException();
        }

        public override Result<DecisionsMedicalHistoriesModel> Find(IFilter filter)
        {
            try
            {
                var decisionMedicalHistory = _decisionsMedicalHistoriesDAL.Find((DecisionsMedicalHistoriesFilter)filter);
                var model = _mapper.Map<DecisionsMedicalHistoriesModel>(decisionMedicalHistory);
                return Result<DecisionsMedicalHistoriesModel>.BuildSuccess(model);
            }
            catch (Exception error)
            {
                return Result<DecisionsMedicalHistoriesModel>.BuildError("Erro ao buscar histórico de decisões médicas", error);
            }
        }

        public override Result<List<DecisionsMedicalHistoriesModel>> FindAll(IFilter filter)
        {
            try
            {
                List<DecisionsMedicalHistories> histories = _decisionsMedicalHistoriesDAL.FindAll((DecisionsMedicalHistoriesFilter)filter);
                List<DecisionsMedicalHistoriesModel> models = _mapper.Map<List<DecisionsMedicalHistoriesModel>>(histories);
                return Result<List<DecisionsMedicalHistoriesModel>>.BuildSuccess(models);
            }
            catch (Exception error)
            {
                return Result<List<DecisionsMedicalHistoriesModel>>.BuildError("Erro ao buscar históricos de decisões médicas", error);
            }
        }

        public override Result<DecisionsMedicalHistories> Register(DecisionsMedicalHistoriesModel model)
        {
            DecisionsMedicalHistories history = _mapper.Map<DecisionsMedicalHistories>(model);

             _decisionsMedicalHistoriesDAL.Insert(history);

            var resultSave = _decisionsMedicalHistoriesDAL.Save();
            if (!resultSave.Success)
                return Result<DecisionsMedicalHistories>.BuildError(resultSave.Messages);

            return Result<DecisionsMedicalHistories>.BuildSuccess(history);
        }

        public override Result<DecisionsMedicalHistories> Update(DecisionsMedicalHistoriesModel model)
        {
            DecisionsMedicalHistories history = _mapper.Map<DecisionsMedicalHistories>(model);

            _decisionsMedicalHistoriesDAL.Update(history);

            var resultSave = _decisionsMedicalHistoriesDAL.Save();
            if (!resultSave.Success)
                return Result<DecisionsMedicalHistories>.BuildError(resultSave.Messages);

            return Result<DecisionsMedicalHistories>.BuildSuccess(history);
        }
    }
}
