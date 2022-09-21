using System;

namespace PycApi.Data.Model
{
    public class Account
    {
        public virtual string Id { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }
}
