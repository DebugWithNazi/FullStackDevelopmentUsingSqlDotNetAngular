using CustomerApp.Dto.Enums;
using CustomerApp.Dto.Pagination;
using CustomerApp.Dto;
using Microsoft.AspNetCore.Mvc;
using CustomerApp.Service.CustomerService;

namespace CustomerApp.Web.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ResponseDto<CustomerDto?>> GetById(long id)
        {
            return await _customerService.GetById(id);
        }
        [Route("GetCountries")]
        [HttpGet]
        public async Task<ResponseDto<List<CountryDto>>> GetCountries()
        {
            return await _customerService.GetCountries();
        }
        
        [Route("Save")]
        [HttpPost]
        public Task<ResponseDto<EntityStatus>> Save([FromBody] CustomerDto customer)
        {
            return _customerService.Save(customer);
        }

        [Route("DeleteById")]
        [HttpDelete]
        public Task<ResponseDto<EntityStatus>> DeleteById(long id)
        {
            return _customerService.DeleteById(id);
        }

        [Route("Filter")]
        [HttpGet]
        public Task<ResponseDto<PageData<CustomerDto>>> Filter(string sortColumn, string sortOrder, int pageNo, int pageSize, string filter = "")
        {
            return _customerService.Filter(filter, sortColumn, sortOrder, pageNo, pageSize);
        }
    }
}
