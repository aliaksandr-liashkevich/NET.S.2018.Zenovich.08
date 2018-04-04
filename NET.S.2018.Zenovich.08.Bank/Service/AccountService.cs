using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model;
using NET.S._2018.Zenovich._08.Bank.Storage;

namespace NET.S._2018.Zenovich._08.Bank.Service
{
    class AccountService : IAccountService
    {
        private readonly IDataAccessObject<Account> bankDataAccessObject;

        private readonly List<Account> _accounts;

        private bool disposed;

        public AccountService()
        {
            bankDataAccessObject = new BankDataAccessObject();
            _accounts = bankDataAccessObject.GetEntities();
            disposed = false;
        }

        ~AccountService()
        {
            CleanUp(false);
        }

        public Account Get(Guid id)
        {
            if (ReferenceEquals(id, null))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _accounts.Find((account) => account.Id.Equals(id));
        }

        public IEnumerable<Account> GetAll()
        {
            return _accounts;
        }

        public IEnumerable<Account> GetAllClosed()
        {
            return _accounts.Where((account) => account.IsClosed == true);
        }

        public IEnumerable<Account> GetAllOpened()
        {
            return _accounts.Where((account) => account.IsClosed == false);
        }

        public void Add(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            _accounts.Add(account);
        }

        public void Close(Guid id)
        {
            if (ReferenceEquals(id, null))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Account findedAccount = _accounts.Find((account) => account.Id.Equals(id));

            if (ReferenceEquals(findedAccount, null) == false)
            {
                findedAccount.IsClosed = true;
            }
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        protected void CleanUp(bool clean)
        {
            if (!disposed)
            {
                if (clean)
                {
                    bankDataAccessObject.PostEntities(_accounts);
                }
            }

            disposed = true;
        }
    }
}
