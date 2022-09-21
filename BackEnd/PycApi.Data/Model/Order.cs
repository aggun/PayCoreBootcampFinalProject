using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data.Model
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string ProductName { get; set; }
        public virtual double Price { get; set; }
        public virtual string AccountId { get; set; }
    }
}
