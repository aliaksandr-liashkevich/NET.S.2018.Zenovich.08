using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.Model;

namespace NET.S._2018.Zenovich._08.Bank.API
{
    public interface IAccountService : IDisposable
    {
        Account Get(Guid id);

        IEnumerable<Account> GetAll();

        IEnumerable<Account> GetAllClosed();

        IEnumerable<Account> GetAllOpened();

        void AddedAmount(Guid id, decimal currency);

        void WithdrawalAmount(Guid id, decimal currency);

        void Add(Account account);

        void Close(Guid id);
    }
}
