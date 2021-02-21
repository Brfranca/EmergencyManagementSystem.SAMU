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
using System.Text;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class MedicalEvaluationBLL : BaseBLL<MedicalEvaluationModel, MedicalEvaluation>, IMedicalEvaluationBLL
    {
        private readonly IMapper _mapper;
        private readonly MedicalEvaluationValidation _medicalEvaluationValidation;
        private readonly IMedicalEvaluationDAL _medicalEvaluationDAL;
        private readonly PatientValidation _patientValidation;
        private readonly IPatientBLL _patientBLL;
        public MedicalEvaluationBLL(IMapper mapper, MedicalEvaluationValidation medicalEvaluationValidation,
            IMedicalEvaluationDAL medicalEvaluationDAL, PatientValidation patientValidation, IPatientBLL patientBLL)
            : base(medicalEvaluationDAL)
        {
            _patientBLL = patientBLL;
            _patientValidation = patientValidation;
            _mapper = mapper;
            _medicalEvaluationDAL = medicalEvaluationDAL;
            _medicalEvaluationValidation = medicalEvaluationValidation;
        }

        public override IQueryable<MedicalEvaluationModel> ApplyFilterPagination(IQueryable<MedicalEvaluation> query, IFilter filter)
        {
            throw new NotImplementedException();
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

        public override Result<List<MedicalEvaluationModel>> FindAll(IFilter filter)
        {
            try
            {
                List<MedicalEvaluation> medicalEvaluations = _medicalEvaluationDAL.FindAll((MedicalEvaluationFilter)filter);
                List<MedicalEvaluationModel> medicalEvaluationModels = _mapper.Map<List<MedicalEvaluationModel>>(medicalEvaluations);
                return Result<List<MedicalEvaluationModel>>.BuildSuccess(medicalEvaluationModels);
            }
            catch (Exception error)
            {
                return Result<List<MedicalEvaluationModel>>.BuildError("Erro ao localizar ao localizar os registros das avaliações médicas.", error);
            }
        }

        public override Result<MedicalEvaluation> Register(MedicalEvaluationModel model)
        {
            try
            {
                MedicalEvaluation medicalEvaluation = _mapper.Map<MedicalEvaluation>(model);
                var result = _medicalEvaluationValidation.Validate(medicalEvaluation);
                if (!result.Success)
                    return result;

                _medicalEvaluationDAL.Insert(medicalEvaluation);

                var resultSave = _medicalEvaluationDAL.Save();
                if (!resultSave.Success)
                    return Result<MedicalEvaluation>.BuildError(resultSave.Messages);

                return Result<MedicalEvaluation>.BuildSuccess(medicalEvaluation);
            }
            catch (Exception error)
            {

                return Result<MedicalEvaluation>.BuildError("Erro no momento de registar avaliação médica.", error);
            }
        }

        public Result RegisterEvaluations(List<MedicalEvaluationModel> evaluationsModel)
        {
            foreach (var evaluationModel in evaluationsModel)
            {
                var evaluation = _mapper.Map<MedicalEvaluation>(evaluationModel);
               

                if (evaluation.Patient.Id > 0)
                {
                    var resultPatient = _patientBLL.Update(evaluationModel.PatientModel);
                    evaluation.Patient = resultPatient.Model;
                }
                else
                {
                    var resultPatient = _patientValidation.Validate(evaluation.Patient);
                    if (!resultPatient.Success)
                        return Result.BuildError(resultPatient.Messages);
                }
                if(evaluation.Evaluation != null)
                {
                    var result = _medicalEvaluationValidation.Validate(evaluation);
                    if (!result.Success)
                        return result;
                    _medicalEvaluationDAL.Insert(evaluation);
                }
            }
            return _medicalEvaluationDAL.Save();
        }

        public override Result<MedicalEvaluation> Update(MedicalEvaluationModel model)
        {
            try
            {
                MedicalEvaluation medicalEvaluation = _mapper.Map<MedicalEvaluation>(model);

                var result = _medicalEvaluationValidation.Validate(medicalEvaluation);
                if (!result.Success)
                    return result;

                _medicalEvaluationDAL.Update(medicalEvaluation);
                var resultSave = _medicalEvaluationDAL.Save();
                if (!resultSave.Success)
                    return Result<MedicalEvaluation>.BuildError(resultSave.Messages);

                return Result<MedicalEvaluation>.BuildSuccess(medicalEvaluation);
            }
            catch (Exception error)
            {
                return Result<MedicalEvaluation>.BuildError("Erro ao alterar o registro da avaliação médica.", error);
            }
        }
    }
}
