using CustomerApp.Dto;
using CustomerApp.Dto.Enums;
using CustomerApp.Dto.Pagination;
using CustomerApp.Repository.CustomerRepository;
using CustomerApp.Repository.Entities;
using CustomerApp.Service.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ResponseDto<EntityStatus>> DeleteById(long id)
        {
            var response = new ResponseDto<EntityStatus>();
            try
            {
                response.Result = await _customerRepository.DeleteById(id);
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.Error;
            }
            return response;
        }

        public async Task<ResponseDto<PageData<CustomerDto>>> Filter(string filter, string sortColumn, string sortOrder, int pageNo, int pageSize)
        {
            var response = new ResponseDto<PageData<CustomerDto>>();
            try
            {
                var tuple = await _customerRepository.Filter(filter, sortColumn, sortOrder, pageNo, pageSize);
                var customerlist = tuple.Item1.ToDtoList();
                response.Result = new PageData<CustomerDto>(customerlist, (int)tuple.Item2, pageNo, pageSize);
                response.Status = ResponseStatus.Success;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.Error;
            }
            return response;

        }

        public async Task<ResponseDto<CustomerDto?>> GetById(long id)
        {
            var response = new ResponseDto<CustomerDto>();
            try
            {
                var entity = await _customerRepository.GetById(id);
                response.Result = entity.ToDto();
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.Error;
            }
            return response;

        }

        public async Task<ResponseDto<List<CountryDto>>> GetCountries()
        {

            var response = new ResponseDto<List<CountryDto>>();
            try
            {
                var data=await _customerRepository.GetCountries();
                response.Result = data.ToDtoList();
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.Error;
            }
            return response;
        }

        public async Task<ResponseDto<EntityStatus>> Save(CustomerDto customer)
        {
            var response = new ResponseDto<EntityStatus>();
            try
            {
                response.Result = await _customerRepository.Save(customer.ToEntity());
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.Error;
            }
            return response;

        }
    }
}
