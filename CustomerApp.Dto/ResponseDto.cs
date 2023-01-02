using CustomerApp.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Dto
{
    public class ResponseDto<T>
    {
        public ResponseDto()
        {
        }
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public string Title { get; set; }
        public ResponseStatus Status { get; set; }
        public T Result{ get; set; }
    }
}
