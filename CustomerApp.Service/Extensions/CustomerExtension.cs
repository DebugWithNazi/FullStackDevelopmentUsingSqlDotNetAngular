using CustomerApp.Dto;
using CustomerApp.Repository.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Service.Extensions
{
    public static class CustomerExtension
    {
        #region Entity Extensions
        public static CustomerDto ToDto(this Customer entity)
        {
            if (entity == null)
                return null;
            return new CustomerDto()
            {
                Id = entity.Id,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                City = entity.City,
                CountryIso = entity.CountryIso,
                FirstName = entity.FirstName,
                IsActive = entity.IsActive,
                IsDeleted = entity.IsDeleted,
                LastName = entity.LastName,
                RegisterationDate = entity.RegisterationDate,
                CustomerOrders = entity.CustomerOrders.ToDtoList()
            };
        }
        public static List<CustomerDto> ToDtoList(this List<Customer> entities)
        {
            var list = new List<CustomerDto>();
            foreach (var item in entities)
            {
                list.Add(item.ToDto());
            }
            return list;
        }
        #endregion 
        #region Dto Extensions
        public static Customer ToEntity(this CustomerDto dto)
        {
            return new Customer()
            {
                Id = dto.Id ?? 0,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                CountryIso = dto.CountryIso,
                FirstName = dto.FirstName,
                IsActive = dto.IsActive,
                IsDeleted = dto.IsDeleted,
                LastName = dto.LastName,
                RegisterationDate = dto.RegisterationDate,
                CustomerOrders = dto.CustomerOrders.ToEntityList()
            };
        }
        public static List<Customer> ToEntityList(this List<CustomerDto> dtos)
        {
            var list = new List<Customer>();
            foreach (var item in dtos)
            {
                list.Add(item.ToEntity());
            }
            return list;
        }

        #endregion

    }
}
