using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data.Model
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string ProductName { get; set; }
        public  virtual string Descripton { get; set; }
        public virtual int CategoryId { get; set; }
        public  virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public  virtual double Price { get; set; }
        public virtual string AccountId { get; set; }
        public virtual bool isOfferable { get; set; }
        public virtual bool isSold { get; set; }
    }
}
