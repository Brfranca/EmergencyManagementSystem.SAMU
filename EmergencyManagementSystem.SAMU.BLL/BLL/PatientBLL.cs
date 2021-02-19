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
    public class PatientBLL : BaseBLL<PatientModel, Patient>, IPatientBLL
    {
        private readonly IMapper _mapper;
        private readonly PatientValidation _patientValidation;
        private readonly IPatientDAL _patientDAL;

        public PatientBLL(IMapper mapper, PatientValidation patientValidation, IPatientDAL patientDAL)
            : base(patientDAL)
        {
            _mapper = mapper;
            _patientValidation = patientValidation;
            _patientDAL = patientDAL;
        }

        public override IQueryable<PatientModel> ApplyFilterPagination(IQueryable<Patient> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(PatientModel model)
        {
            try
            {
                Patient patient = _mapper.Map<Patient>(model);
                _patientDAL.Delete(patient);
                return _patientDAL.Save();
            }
            catch (Exception error)
            {

                return Result.BuildError("Erro ao deletar o registro de paciente", error);
            }
        }

        public override Result<PatientModel> Find(IFilter filter)
        {
            try
            {
                Patient patient = _patientDAL.Find((PatientFilter)filter);
                PatientModel patientModel = _mapper.Map<PatientModel>(patient);
                return Result<PatientModel>.BuildSuccess(patientModel);

            }
            catch (Exception error)
            {

                return Result<PatientModel>.BuildError("Erro ao localizar o paciente.", error);
            }
        }

        public override Result<List<PatientModel>> FindAll(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result<Patient> Register(PatientModel model)
        {
            try
            {
                Patient patient = _mapper.Map<Patient>(model);
                var result = _patientValidation.Validate(patient);

                if (!result.Success)
                    return result;

                return Result<Patient>.BuildSuccess(patient);
            }
            catch (Exception error)
            {

                return Result<Patient>.BuildError("Erro ao registrar o paciente.", error);
            }
        }

        public override Result Update(PatientModel model)
        {
            try
            {
                Patient patient = _mapper.Map<Patient>(model);
                var result = _patientValidation.Validate(patient);

                if (!result.Success)
                    return result;

                return _patientDAL.Update(patient);
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do paciente", error);
            }
        }
    }
}
