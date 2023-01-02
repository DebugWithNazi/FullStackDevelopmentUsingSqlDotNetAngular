using CustomerApp.Dto;
using CustomerApp.Dto.Enums;
using CustomerApp.Dto.Pagination;
using CustomerApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<ResponseDto<CustomerDto?>> GetById(long id);
        Task<ResponseDto<EntityStatus>> Save(CustomerDto customer);
        Task<ResponseDto<EntityStatus>> DeleteById(long id);
        Task<ResponseDto<PageData<CustomerDto>>> Filter(string filter, string sortColumn, string sortOrder, int pageNo, int pageSize);
        Task<ResponseDto<List<CountryDto>>> GetCountries();

    }
}
