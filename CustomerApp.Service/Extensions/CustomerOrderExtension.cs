using CustomerApp.Dto;
using CustomerApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Service.Extensions
{
    public static class CustomerOrderExtension
    {
        #region Entity Extensions
        public static CustomerOrderDto ToDto(this CustomerOrder entity)
        {
            return new CustomerOrderDto()
            {
                CustomerId = entity.CustomerId,
                Ammount = entity.Ammount,
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                ItemCount = entity.ItemCount,
                OrderDate = entity.OrderDate,
                OrderNo = entity.OrderNo,
            };
        }

        public static List<CustomerOrderDto> ToDtoList(this ICollection<CustomerOrder> entities)
        {
            var list = new List<CustomerOrderDto>();
            foreach (var item in entities)
            {
                list.Add(item.ToDto());
            }
            return list;
        }
        #endregion

        #region Dto Extensions
        public static CustomerOrder ToEntity(this CustomerOrderDto dto)
        {
            return new CustomerOrder()
            {
                CustomerId = dto.CustomerId,
                Ammount = dto.Ammount,
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                ItemCount = dto.ItemCount,
                OrderDate = dto.OrderDate,
                OrderNo = dto.OrderNo,
            };
        }

        public static List<CustomerOrder> ToEntityList(this List<CustomerOrderDto> dtos)
        {
            var list = new List<CustomerOrder>();
            foreach (var item in dtos)
            {
                list.Add(item.ToEntity());
            }
            return list;
        }

        #endregion
    }
}
