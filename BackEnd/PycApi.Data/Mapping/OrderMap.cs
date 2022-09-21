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

    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id, x =>
        {
            x.Type(NHibernateUtil.Int32);
            x.Column("Id");
            x.UnsavedValue(0);
            x.Generator(Generators.Increment);
        });


            Property(b => b.ProductName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.Price, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });


            Property(b => b.AccountId, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Table("order");
        }
    }

}
