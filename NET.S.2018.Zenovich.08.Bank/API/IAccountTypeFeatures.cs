using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.API
{
    public interface IAccountTypeFeatures
    {
        decimal WithdrawalPrice { get; }

        decimal AddedPrice { get; }
    }
}
