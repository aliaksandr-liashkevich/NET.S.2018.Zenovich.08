using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model.Accounts;

namespace NET.S._2018.Zenovich._08.Bank.Model
{
    public class AccountTypeFeatures : IAccountTypeFeatures
    {
        public AccountTypeFeatures(string accountType)
        {
            Initialized(accountType);
        }

        public decimal WithdrawalPrice { get; protected set; }

        public decimal AddedPrice { get; protected set; }

        protected void SetPricesForBase()
        {
            AddedPrice = 6;
            WithdrawalPrice = 5;
        }

        protected void SetPriceForGold()
        {
            AddedPrice = 5;
            WithdrawalPrice = 4;
        }

        protected void SetPriceForPlatinum()
        {
            AddedPrice = 3;
            WithdrawalPrice = 2;
        }

        protected virtual void Initialized(string accountType)
        {
            switch (accountType)
            {
                case BaseAccount.AccountType:
                {
                    SetPricesForBase();
                    break;
                }

                case GoldAccount.AccountType:
                {
                    SetPriceForGold();
                    break;
                }

                case PlatinumAccount.AccountType:
                {
                    SetPriceForPlatinum();
                    break;
                }

                default:
                {
                    throw new ArgumentException("No such type of bank account.", nameof(accountType));
                }
            }
        }
    }
}
