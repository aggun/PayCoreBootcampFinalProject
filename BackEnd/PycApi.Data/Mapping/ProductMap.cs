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
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
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
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.AccountId, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.Descripton, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.Color, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.Brand, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.CategoryId, x =>
            {
                x.Type(NHibernateUtil.Int32);

                 x.NotNullable(true);
            });


            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });


            Property(b => b.isOfferable, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });


            Property(b => b.isSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });


            Table("product");
        }
    }
}

