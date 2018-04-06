using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;

namespace NET.S._2018.Zenovich._08.Bank.Model
{
    public class BonusCounter : IBonusCounter
    {
        public long GetBonusFromRefill(IAccountTypeFeatures accountTypeFeatures, decimal amount)
        {
            return (long)(amount * 0.1m / accountTypeFeatures.AddedPrice);
        }

        public long GetBonusFromAdded(IAccountTypeFeatures accountTypeFeatures, decimal amount)
        {
            return (long)(amount * 0.1m / accountTypeFeatures.WithdrawalPrice);
        }
    }
}
