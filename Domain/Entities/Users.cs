using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Users
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public ICollection<Todos> Todos { get; set; }

    }
}
