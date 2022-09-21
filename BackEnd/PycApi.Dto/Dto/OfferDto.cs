using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Dto.Dto
{
    public class OfferDto
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public double OfferPrice { get; set; }
        public string BidderAccount { get; set; }
        public string ProductOwner { get; set; }
        public bool Approval { get; set; }
    }
}
