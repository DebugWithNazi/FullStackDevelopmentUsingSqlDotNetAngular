using CustomerApp.Dto.Enums;
using CustomerApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace CustomerApp.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<EntityStatus> DeleteById(long id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return EntityStatus.NotUpdated;
            }
            else
            {
                customer.IsDeleted = true;
                await _context.SaveChangesAsync();
                return EntityStatus.Deleted;
            }
        }

        public async Task<Customer?> GetById(long id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<List<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<EntityStatus> Save(Customer customer)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (entity == null)
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return EntityStatus.New;
            }
            else
            {
                entity.RegisterationDate = customer.RegisterationDate;
                entity.FirstName = customer.FirstName;
                entity.LastName = customer.LastName;
                entity.Address1 = customer.Address1;
                entity.Address2 = customer.Address2;
                entity.City = customer.City;
                entity.CountryIso = customer.CountryIso;
                await _context.SaveChangesAsync();
                return EntityStatus.Updated;
            }
        }
        public async Task<Tuple<List<Customer>, long>> Filter(string filter, string sortColumn, string sortOrder, int pageNo, int pageSize)
        {
            long totalRecords = await _context.Customers.Where(x => !(x.IsDeleted ?? false) && (x.FirstName + " " + x.LastName).Contains(filter))
                                    .CountAsync();
            var customers = await _context.Customers.Where(x => !(x.IsDeleted ?? false) && (x.FirstName + " " + x.LastName)
                            .Contains(filter))
                            .OrderBy(sortColumn + " " + sortOrder).Skip(pageNo * pageSize).Take(pageSize).ToListAsync();

            return Tuple.Create(customers, totalRecords);
        }
    }
}
