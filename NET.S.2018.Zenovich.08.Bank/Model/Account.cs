using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.Model
{
    /// <summary>
    /// Account type
    /// </summary>
    [Serializable]
    public abstract class Account
    {
        protected Account()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Amount = 0;
            IsClosed = false;
        }

        public Guid Id
        {
            get; private set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public DateTime CreationDate
        {
            get; set;
        }

        public abstract string Type { get; }

        public decimal Amount
        {
            get; set;
        }

        public long Bonus
        {
            get; set;
        }

        public bool IsClosed
        {
            get; set;
        }
    }
}
