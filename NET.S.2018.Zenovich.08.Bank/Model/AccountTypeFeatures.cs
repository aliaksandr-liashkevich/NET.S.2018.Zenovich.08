using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.Model
{
    class AccountTypeFeatures
    {
        public AccountTypeFeatures(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Base:
                {
                    SetPricesForBase();
                    break;
                }

                case AccountType.Gold:
                {
                    SetPriceForGold();
                    break;
                }

                case AccountType.Platinum:
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

        public decimal WithdrawalPrice { get; private set; }

        public decimal AddedPrice { get; private set; }

        private void SetPricesForBase()
        {
            AddedPrice = 6;
            WithdrawalPrice = 5;
        }

        private void SetPriceForGold()
        {
            AddedPrice = 5;
            WithdrawalPrice = 4;
        }

        private void SetPriceForPlatinum()
        {
            AddedPrice = 3;
            WithdrawalPrice = 2;
        }
    }
}
