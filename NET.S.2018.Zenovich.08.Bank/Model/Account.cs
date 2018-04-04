using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.Model
{
    [Serializable]
    public class Account
    {
        protected Account(AccountType type, string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Type = type;
            Amount = 0;
            IsClosed = false;

            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id
        {
            get; private set;
        }

        public string FirstName
        {
            get; private set;
        }

        public string LastName
        {
            get; private set;
        }

        public DateTime CreationDate
        {
            get; private set;
        }

        public AccountType Type
        {
            get; private set;
        }

        public decimal Amount
        {
            get; private set;
        }

        public bool IsClosed
        {
            get; set;
        }
    }
}
