﻿using AutoMapper;
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
    public class MemberBLL : BaseBLL<MemberModel, Member>, IMemberBLL
    {
        private readonly IMapper _mapper;
        private readonly IMemberDAL _memberDAL;
        private readonly MemberValidation _memberValidation;
        private readonly IVehicleBLL _vehicleBLL;

        public MemberBLL(IMapper mapper, IMemberDAL memberDAL, MemberValidation memberValidation, IVehicleBLL vehicleBLL) : base(memberDAL)
        {
            _mapper = mapper;
            _memberDAL = memberDAL;
            _memberValidation = memberValidation;
            _vehicleBLL = vehicleBLL;
        }
        public override IQueryable<MemberModel> ApplyFilterPagination(IQueryable<Member> query, IFilter filter)
        {
            var memberFilter = (MemberFilter)filter;
            if (memberFilter.VehicleId > 0)
                query = query.Where(d => d.VehicleId == memberFilter.VehicleId);

            return query.Select(d => _mapper.Map<MemberModel>(d));
        }

        public override Result Delete(MemberModel model)
        {
            try
            {
                Member member = _mapper.Map<Member>(model);
                _memberDAL.Delete(member);
                return _memberDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o membro.", error);
            }
        }

        public override Result<MemberModel> Find(IFilter filter)
        {
            try
            {
                Member member = _memberDAL.Find((MemberFilter)filter);
                MemberModel memberModel = _mapper.Map<MemberModel>(member);
                return Result<MemberModel>.BuildSuccess(memberModel);
            }
            catch (Exception error)
            {
                return Result<MemberModel>.BuildError("Erro ao localizar o membro.", error);
            }
        }

        public override Result<List<MemberModel>> FindAll(IFilter filter)
        {
            try
            {
                var filterImpl = (MemberFilter)filter;
                var members = _memberDAL.FindAll(filterImpl);
                var memberModels = _mapper.Map<List<MemberModel>>(members);
                return Result<List<MemberModel>>.BuildSuccess(memberModels);
            }
            catch (Exception error)
            {
                return Result<List<MemberModel>>.BuildError("Erro ao localizar o membro.", error);
            }
        }

        public override Result<Member> Register(MemberModel model)
        {
            try
            {
                Member member = _mapper.Map<Member>(model);

                var result = _memberValidation.Validate(member);
                if (!result.Success)
                    return result;

                _memberDAL.Insert(member);

                var resultSave = _memberDAL.Save();
                if (!resultSave.Success)
                    return Result<Member>.BuildError(resultSave.Messages);

                return Result<Member>.BuildSuccess(member);
            }
            catch (Exception error)
            {
                return Result<Member>.BuildError("Erro no momento de registar o membro.", error);
            }
        }

        public override Result<Member> Update(MemberModel model)
        {
            try
            {
                Member member = _mapper.Map<Member>(model);

                var result = _memberValidation.Validate(member);
                if (!result.Success)
                    return result;

                _memberDAL.Update(member);
                var resultSave = _memberDAL.Save();
                if (!resultSave.Success)
                    return Result<Member>.BuildError(resultSave.Messages);

                return Result<Member>.BuildSuccess(member);
            }
            catch (Exception error)
            {
                return Result<Member>.BuildError("Erro ao alterar o registro do membro.", error);
            }
        }
    }
}
