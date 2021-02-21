using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalEvaluationController : BaseController<MedicalEvaluationModel, MedicalEvaluation, MedicalEvaluationFilter>
    {
        private readonly IMedicalEvaluationBLL _medicalEvaluationBLL;
        public MedicalEvaluationController(IMedicalEvaluationBLL medicalEvaluationBLL) : base(medicalEvaluationBLL)
        {
            _medicalEvaluationBLL = medicalEvaluationBLL;
        }

        [HttpPost("RegisterEvaluations")]
        public Result RegisterEvaluations(List<MedicalEvaluationModel> evaluations)
        {
            return _medicalEvaluationBLL.RegisterEvaluations(evaluations);
        }
    }
}
