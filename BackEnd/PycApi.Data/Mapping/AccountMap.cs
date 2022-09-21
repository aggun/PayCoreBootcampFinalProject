using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PycApi.Data.Model;

namespace PycApi.Data
{
    public class AccountMap : ClassMapping<Account>
    {
        public AccountMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("Id");
            });


            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.Email, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.PasswordHash, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Binary);
                x.NotNullable(true);
            });

            Property(b => b.PasswordSalt, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.Binary);
                x.NotNullable(true);
            });


            Property(b => b.LastActivity, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });

            Table("account");
        }
    }
}