using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class MedicalEvaluationBLL : BaseBLL<MedicalEvaluationModel>, IMedicalEvaluationBLL
    {
        private readonly IMapper _mapper;
        private readonly MedicalEvaluationValidation _medicalEvaluationValidation;
        private readonly IMedicalEvaluationDAL _medicalEvaluationDAL;

        public MedicalEvaluationBLL(IMapper mapper, MedicalEvaluationValidation medicalEvaluationValidation, 
            IMedicalEvaluationDAL medicalEvaluationDAL)
        {
            _mapper = mapper;
            _medicalEvaluationDAL = medicalEvaluationDAL;
            _medicalEvaluationValidation = medicalEvaluationValidation;
        }

        public override Result Delete(MedicalEvaluationModel model)
        {
            try
            {
                MedicalEvaluation medicalEvaluation = _mapper.Map<MedicalEvaluation>(model);
                _medicalEvaluationDAL.Delete(medicalEvaluation);
                return _medicalEvaluationDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro de avaliação médica.", error);
            }
        }

        public override Result<MedicalEvaluationModel> Find(IFilter filter)
        {
            try
            {
                MedicalEvaluation medicalEvaluation = _medicalEvaluationDAL.Find((MedicalEvaluationFilter)filter);
                MedicalEvaluationModel medicalEvaluationModel = _mapper.Map<MedicalEvaluationModel>(medicalEvaluation);

                return Result<MedicalEvaluationModel>.BuildSuccess(medicalEvaluationModel);
            }
            catch (Exception error)
            {

                return Result<MedicalEvaluationModel>.BuildError("Erro ao localizar a avaliação médica.", error);
            }
        }

        public override Result Register(MedicalEvaluationModel model)
        {
            try
            {
                MedicalEvaluation medicalEvaluation = _mapper.Map<MedicalEvaluation>(model);
                var result = _medicalEvaluationValidation.Validate(medicalEvaluation);
                if (!result.Success)
                    return result;

                _medicalEvaluationDAL.Insert(medicalEvaluation);
                return _medicalEvaluationDAL.Save();
            }
            catch (Exception error)
            {

                return Result.BuildError("Erro no momento de registar avaliação médica.", error);
            }
        }

        public override Result Update(MedicalEvaluationModel model)
        {
            try
            {
                MedicalEvaluation medicalEvaluation = _mapper.Map<MedicalEvaluation>(model);
                var result = _medicalEvaluationValidation.Validate(medicalEvaluation);
                if (!result.Success)
                    return result;

                _medicalEvaluationDAL.Update(medicalEvaluation);
                return _medicalEvaluationDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro da avaliação médica.", error);
            }
        }
    }
}
