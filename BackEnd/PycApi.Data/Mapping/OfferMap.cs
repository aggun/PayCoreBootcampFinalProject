using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PycApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data.Mapping
{
 
        public class OfferMap : ClassMapping<Offer>
        {
            public OfferMap()
            {
                Id(x => x.Id, x =>
                {
                    x.Type(NHibernateUtil.Int32);
                    x.Column("Id");
                    x.UnsavedValue(0);
                    x.Generator(Generators.Increment);
                });


                Property(b => b.OfferPrice, x =>
                {
                    x.Type(NHibernateUtil.Double);
                    x.NotNullable(true);
                });


                Property(b => b.ProductOwner, x =>
                {
                    x.Type(NHibernateUtil.String);
                    x.NotNullable(true);
                });


                Property(b => b.ProductId, x =>
                {
                    x.Type(NHibernateUtil.Int32);
                    x.NotNullable(true);
                });


                Property(b => b.BidderAccount, x =>
                {
                    x.Length(150);
                    x.Type(NHibernateUtil.String);
                    x.NotNullable(true);
                });


                Property(b => b.Approval, x =>
                {
                    x.Type(NHibernateUtil.Boolean);
                });


                Table("offer");
            }
        }
    }
