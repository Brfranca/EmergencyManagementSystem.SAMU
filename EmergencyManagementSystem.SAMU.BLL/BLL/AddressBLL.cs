using AutoMapper;
using EmergencyManagementSystem.SAMU.BLL.Validations;
using EmergencyManagementSystem.SAMU.Common.Filters;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Interfaces.DAL;
using EmergencyManagementSystem.SAMU.Common.Models;
using EmergencyManagementSystem.SAMU.Entities.Entities;
using System;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public class AddressBLL : BaseBLL<AddressModel>, IAddressBLL
    {
        private readonly IMapper _mapper;
        private readonly IAddressDAL _addressDAL;
        private readonly AddressValidation _addressValidation;

        public AddressBLL(IAddressDAL addressDAL, AddressValidation addressValidation, IMapper mapper)
        {
            _addressDAL = addressDAL;
            _addressValidation = addressValidation;
            _mapper = mapper;
        }

        public override Result Delete(AddressModel model)
        {
            try
            {
                Address address = _mapper.Map<Address>(model);
                _addressDAL.Delete(address);
                return _addressDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do endereço.", error);
            }
        }

        public override Result<AddressModel> Find(IFilter filter)
        {
            try
            {
                Address address = _addressDAL.Find((AddressFilter)filter);
                AddressModel addressModel = _mapper.Map<AddressModel>(address);
                return Result<AddressModel>.BuildSuccess(addressModel);
            }
            catch (Exception error)
            {
                return Result<AddressModel>.BuildError("Erro ao localizar o endereço.", error);
            }
        }

        public override Result Register(AddressModel addressModel)
        {
            try
            {
                Address address = _mapper.Map<Address>(addressModel);

                var result = _addressValidation.Validate(address);
                if (!result.Success)
                    return result;

                _addressDAL.Insert(address);
                return _addressDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar o endereço.", error);
            }
        }

        public override Result Update(AddressModel model)
        {
            try
            {
                Address address = _mapper.Map<Address>(model);

                var result = _addressValidation.Validate(address);
                if (!result.Success)
                    return result;

                _addressDAL.Update(address);
                return _addressDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do endereço.", error);
            }
        }
    }
}
