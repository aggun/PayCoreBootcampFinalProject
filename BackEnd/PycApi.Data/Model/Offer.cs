using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data.Model
{
    public class Offer
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual double OfferPrice { get; set; }
        public virtual string BidderAccount { get; set; }
        public virtual string ProductOwner { get; set; }
        public virtual bool Approval { get; set; }

    }
}
