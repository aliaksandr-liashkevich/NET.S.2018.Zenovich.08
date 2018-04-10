using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model;
using NET.S._2018.Zenovich._08.Bank.Storage;
using NET.S._2018.Zenovich._08.Bank.ViewModel;

namespace NET.S._2018.Zenovich._08.Bank.Service
{
    /// <summary>
    /// Contains operations for working with data access object.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Bank.API.IAccountService" />
    public class AccountService : IAccountService
    {
        #region Private fields

        private readonly IAccountFactory factories;
        private readonly IDataAccessObject<Account> bankDataAccessObject;
        private readonly IBonusCounter bonusCounter;
        private readonly IAccountTypeFeatures accountTypeFeatures;
        private readonly List<Account> _accounts;

        private bool disposed;

        #endregion Private fields

        #region Public ctor

        public AccountService()
        {
            bankDataAccessObject = new BankDataAccessObject();
            _accounts = bankDataAccessObject.GetEntities();

            if (_accounts == null)
            {
                _accounts = new List<Account>();
            }

            disposed = false;
        }

        #endregion Public ctor

        ~AccountService()
        {
            CleanUp(false);
        }

        #region Public methods

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="id"/>
        /// </exception>
        public Account Get(Guid id)
        {
            if (ReferenceEquals(id, null))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Find(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>all accounts</returns>
        public IEnumerable<Account> GetAll()
        {
            return _accounts;
        }

        /// <summary>
        /// Gets all closed.
        /// </summary>
        /// <returns>closed accounts</returns>
        public IEnumerable<Account> GetAllClosed()
        {
            return _accounts.Where((account) => account.IsClosed == true);
        }

        /// <summary>
        /// Gets all opened.
        /// </summary>
        /// <returns>opened accounts</returns>
        public IEnumerable<Account> GetAllOpened()
        {
            return _accounts.Where((account) => account.IsClosed == false);
        }

        /// <summary>
        /// Adds the amount.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="viewModel"/>
        /// </exception>
        public void AddedAmount(BillViewModel viewModel)
        {
            if (ReferenceEquals(viewModel, null))
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (ReferenceEquals(viewModel.ClientId, null))
            {
                return;
            }

            Account account = Find(viewModel.ClientId);
            if (ReferenceEquals(account, null) == false)
            {
                account.Bonus = bonusCounter.GetBonusFromAdded(accountTypeFeatures, viewModel.Currency);
                account.Amount = account.Amount + account.Bonus + viewModel.Currency;
            }
        }

        /// <summary>
        /// Withdrawals the amount.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="viewModel"/>
        /// </exception>
        public void WithdrawalAmount(BillViewModel viewModel)
        {
            if (ReferenceEquals(viewModel, null))
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (ReferenceEquals(viewModel.ClientId, null))
            {
                return;
            }

            Account account = Find(viewModel.ClientId);

            if (ReferenceEquals(account, null) == false)
            {
                account.Bonus = bonusCounter.GetBonusFromRefill(accountTypeFeatures, viewModel.Currency);
                account.Amount = account.Amount  + account.Bonus - viewModel.Currency;
            }
        }

        /// <summary>
        /// Adds the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="viewModel"/>
        /// </exception>
        public void Add(CreatedAccountViewModel viewModel)
        {
            if (ReferenceEquals(viewModel, null))
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            Account account = factories.GetAccount(viewModel.AccountType);
            account.FirstName = viewModel.FirstName;
            account.LastName = viewModel.LastName;

            _accounts.Add(account);
        }

        public void Close(Guid id)
        {
            if (ReferenceEquals(id, null))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Account findedAccount = Find(id);

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

        #endregion Public methods

        #region Protected methods

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

        #endregion Protected methods

        #region Private methods

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>found account</returns>
        private Account Find(Guid id)
        {
            return _accounts.Find((account) => account.Id.Equals(id));
        }

        #endregion Private methods
    }
}
