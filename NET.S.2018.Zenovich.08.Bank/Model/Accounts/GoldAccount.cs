using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.Model.Accounts
{
    public class GoldAccount : Account
    {
        public const string AccountType = "Gold";

        public override string Type
        {
            get
            {
                return AccountType;
            }
        }
    }
}
