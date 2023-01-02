using CustomerApp.Dto;
using CustomerApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Service.Extensions
{
    public static class CountryExtension
    {
        public static CountryDto ToDto(this Country entity)
        {
            return new CountryDto()
            {
                Iso = entity.Iso,
                Name = entity.Name
            };
        }

        public static List<CountryDto> ToDtoList(this List<Country> entities)
        {
            var list = new List<CountryDto>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToDto());
            }
            return list;
        }
    }
}
