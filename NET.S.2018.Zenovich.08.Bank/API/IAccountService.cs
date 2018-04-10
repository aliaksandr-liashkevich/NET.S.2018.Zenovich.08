using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.Model;
using NET.S._2018.Zenovich._08.Bank.ViewModel;

namespace NET.S._2018.Zenovich._08.Bank.API
{
    public interface IAccountService : IDisposable
    {
        Account Get(Guid id);

        IEnumerable<Account> GetAll();

        IEnumerable<Account> GetAllClosed();

        IEnumerable<Account> GetAllOpened();

        void AddedAmount(BillViewModel viewModel);

        void WithdrawalAmount(BillViewModel viewModel);

        void Add(CreatedAccountViewModel viewModel);

        void Close(Guid id);
    }
}
