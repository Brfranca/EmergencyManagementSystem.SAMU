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
    public class EmergencyBLL : BaseBLL<EmergencyModel, Emergency>, IEmergencyBLL
    {
        private readonly IMapper _mapper;
        private readonly IEmergencyDAL _emergencyDAL;
        private readonly EmergencyValidation _emergencyValidation;
        private readonly IPatientBLL _patientBLL;
        private readonly IAddressBLL _addressBLL;
        private readonly AddressValidation _addressValidation;
        private readonly PatientValidation _patientValidation;
        private readonly IEmergencyHistoryDAL _emergencyHistoryDAL;
        public EmergencyBLL(IMapper mapper, IEmergencyDAL emergencyDAL,
            EmergencyValidation emergencyValidation, IPatientBLL patientBLL,
            IAddressBLL addressBLL, AddressValidation addressValidation,
            PatientValidation patientValidation, IEmergencyHistoryDAL emergencyHistoryDAL)
            : base(emergencyDAL)
        {
            _emergencyHistoryDAL = emergencyHistoryDAL;
            _addressValidation = addressValidation;
            _patientValidation = patientValidation;
            _addressBLL = addressBLL;
            _patientBLL = patientBLL;
            _mapper = mapper;
            _emergencyDAL = emergencyDAL;
            _emergencyValidation = emergencyValidation;
        }

        public override IQueryable<EmergencyModel> ApplyFilterPagination(IQueryable<Emergency> query, IFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Result Delete(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);
                _emergencyDAL.Delete(emergency);
                return _emergencyDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro da emergência.", error);
            }
        }

        public override Result<EmergencyModel> Find(IFilter filter)
        {
            try
            {
                Emergency emergency = _emergencyDAL.Find((EmergencyFilter)filter);
                EmergencyModel emergencyModel = _mapper.Map<EmergencyModel>(emergency);
                return Result<EmergencyModel>.BuildSuccess(emergencyModel);
            }
            catch (Exception error)
            {
                return Result<EmergencyModel>.BuildError("Erro ao localizar o registro da emergência.", error);
            }
        }

        public override Result<List<EmergencyModel>> FindAll(IFilter filter)
        {
            try
            {
                List<Emergency> emergencies = _emergencyDAL.FindAll((EmergencyFilter)filter);
                List<EmergencyModel> emergenciesModel = _mapper.Map<List<EmergencyModel>>(emergencies);
                return Result<List<EmergencyModel>>.BuildSuccess(emergenciesModel);
            }
            catch (Exception error)
            {
                return Result<List<EmergencyModel>>.BuildError("Erro ao localizar o registro da emergência.", error);
            }
        }

        public override Result<Emergency> Register(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);

                foreach (var patient in model.PatientModels)
                {
                    var resultPatient = _patientBLL.Register(patient);
                    if (!resultPatient.Success)
                        return Result<Emergency>.BuildError(resultPatient.Messages);
                }

                var result = _emergencyValidation.Validate(emergency);
                if (!result.Success)
                    return result;

                _emergencyDAL.Insert(emergency);

                var resultSave = _emergencyDAL.Save();
                if (!resultSave.Success)
                    return Result<Emergency>.BuildError(resultSave.Messages);

                return Result<Emergency>.BuildSuccess(emergency);

            }
            catch (Exception error)
            {
                return Result<Emergency>.BuildError("Erro no momento de registar a emergência.", error);
            }
        }

        public Result SimpleRegister(EmergencyModel model)
        {
            model.RequesterPhone = model.RequesterPhone.Trim().Replace("-", "").Replace("(", "").Replace(")", "");
            if (!model.RequesterPhone.IsValidPhone())
            {
                return Result.BuildError("Favor digitar um telefone válido.");
            }

            Emergency emergency = _mapper.Map<Emergency>(model);
            emergency.Address = null;
            emergency.AddressId = 0;
            if (emergency.EmergencyHistories == null)
                emergency.EmergencyHistories = new List<EmergencyHistory>();

            emergency.EmergencyHistories.Add(new EmergencyHistory
            {
                Date = DateTime.Now,
                Description = "Ocorrência Aberta",
                Emergency = emergency,
                EmergencyStatus = emergency.EmergencyStatus,
                EmployeeGuid = model.EmployeeGuid
            });

            if (string.IsNullOrWhiteSpace(emergency.RequesterPhone))
                return Result.BuildError("Número do solicitante é obrigatório.");

            _emergencyDAL.Insert(emergency);

            var resultSave = _emergencyDAL.Save();
            if (!resultSave.Success)
                return Result.BuildError(resultSave.Messages);

            return Result.BuildSuccess(idGerado: emergency.Id);
        }

        public override Result<Emergency> Update(EmergencyModel model)
        {
            try
            {
                //lógica para remover pacientes vazios
                var patientsRemove = model.PatientModels.Where
                    (
                        d => d.Age == 0
                        && d.Gender == Entities.Enums.Gender.Invalido
                        && string.IsNullOrWhiteSpace(d.Name)
                        && d.Id == 0
                    ).ToList();
                patientsRemove.ForEach(d => model.PatientModels.Remove(d));

                Emergency emergency = _mapper.Map<Emergency>(model);

                var history = _emergencyHistoryDAL
                    .Find(new EmergencyHistoryFilter { EmergencyId = emergency.Id, EmergencyStatus = EmergencyStatus.InEvaluation });

                if (history == null)
                {
                    if (emergency.EmergencyHistories == null)
                        emergency.EmergencyHistories = new List<EmergencyHistory>();

                    emergency.EmergencyHistories.Add(new EmergencyHistory
                    {
                        Date = DateTime.Now,
                        Description = "Ocorrência em Avaliação",
                        Emergency = emergency,
                        EmergencyStatus = emergency.EmergencyStatus,
                        EmployeeGuid = model.EmployeeGuid
                    });
                }

                if ((model?.AddressModel?.Id ?? 0) == 0)
                {
                    var resultAddress = _addressBLL.Register(model.AddressModel);
                    if (!resultAddress.Success)
                        return Result<Emergency>.BuildError(resultAddress.Messages);
                    emergency.Address = resultAddress.Model;
                }
                else
                {
                    var resultAddress = _addressValidation.Validate(emergency.Address);
                    if (!resultAddress.Success)
                        return Result<Emergency>.BuildError(resultAddress.Messages);
                }

                foreach (var patientModel in model.PatientModels)
                {
                    if ((patientModel?.Id ?? 0) == 0)
                    {
                        patientModel.EmergencyId = emergency.Id;
                        var resultPatient = _patientBLL.Register(patientModel);
                        if (!resultPatient.Success)
                            return Result<Emergency>.BuildError(resultPatient.Messages);
                    }
                    else
                    {
                        var patient = emergency.Patients.FirstOrDefault(d => d.Id == patientModel.Id);
                        patient.EmergencyId = emergency.Id;
                        var resultPatient = _patientValidation.Validate(patient);
                        if (!resultPatient.Success)
                            return Result<Emergency>.BuildError(resultPatient.Messages);
                    }
                }

                var result = _emergencyValidation.Validate(emergency);
                if (!result.Success)
                    return result;

                _emergencyDAL.Update(emergency);
                var resultSave = _emergencyDAL.Save();
                if (!resultSave.Success)
                    return Result<Emergency>.BuildError(resultSave.Messages);

                return Result<Emergency>.BuildSuccess(null);
            }
            catch (Exception error)
            {
                return Result<Emergency>.BuildError("Erro ao alterar o registro da ocorrência.", error);
            }
        }

        public Result SimpleUpdate(EmergencyModel model)
        {
            try
            {
                Emergency emergency = _mapper.Map<Emergency>(model);

                var result = _emergencyValidation.Validate(emergency);

                _emergencyDAL.Update(emergency);
                if (!result.Success)
                    return result;

                return Result.BuildSuccess();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro da ocorrência.", error);
            }
        }

        public Result Finish(EmergencyModel model)
        {
            var emergency = _emergencyDAL.Find(new EmergencyFilter { Id = model.Id });
            var anyInProgress = emergency.ServiceHistories.Any(d => d.ServiceHistoryStatus == ServiceHistoryStatus.InProgress);
            if (anyInProgress)
                return Result.BuildError("Ocorrência não pode ser finalizada pois possui veículos empenhados.");

            emergency.EmergencyStatus = EmergencyStatus.Closed;
            emergency.EmergencyRequiredVehicles.ToList()
                .ForEach(d => d.Status =
                (d.Status == VehicleRequiredStatus.Opened)
                ? VehicleRequiredStatus.Canceled
                : d.Status);

            _emergencyDAL.Update(emergency);

            return _emergencyDAL.Save();
        }
    }
}
