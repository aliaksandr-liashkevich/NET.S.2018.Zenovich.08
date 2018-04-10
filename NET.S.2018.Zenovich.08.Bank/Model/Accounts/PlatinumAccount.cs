using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.Model.Accounts
{
    public class PlatinumAccount : Account
    {
        public const string AccountType = "Platinum";

        public override string Type
        {
            get
            {
                return AccountType;
            }
        }
    }
}
