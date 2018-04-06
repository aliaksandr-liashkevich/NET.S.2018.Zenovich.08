using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.API
{
    public interface IBonusCounter
    {
        long GetBonusFromRefill(IAccountTypeFeatures accountTypeFeatures, decimal amount);

        long GetBonusFromAdded(IAccountTypeFeatures accountTypeFeatures, decimal amount);
    }
}
