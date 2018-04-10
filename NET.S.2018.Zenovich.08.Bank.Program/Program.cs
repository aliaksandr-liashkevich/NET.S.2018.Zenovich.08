using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model;
using NET.S._2018.Zenovich._08.Bank.Service;

namespace NET.S._2018.Zenovich._08.Bank.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IAccountService accountService = new AccountService())
            {
                //accountService.Add(new Account());
            }
        }
    }
}
