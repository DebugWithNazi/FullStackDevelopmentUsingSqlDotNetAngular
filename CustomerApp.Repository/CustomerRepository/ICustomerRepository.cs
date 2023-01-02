using CustomerApp.Dto.Enums;
using CustomerApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<List<Country>> GetCountries();
        Task<Customer?> GetById(long id);
        Task<EntityStatus> Save(Customer customer);
        Task<EntityStatus> DeleteById(long id);
        Task<Tuple<List<Customer>, long>> Filter(string filter, string sortColumn, string sortOrder, int pageNo, int pageSize);
    }
}
