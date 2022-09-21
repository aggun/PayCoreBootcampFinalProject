using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Dto.Dto
{
    public class OrderDto
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string AccountId { get; set; }
    }
}
