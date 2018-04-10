using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.Model;

namespace NET.S._2018.Zenovich._08.Bank.API
{
    public interface IAccountFactory
    {
        void AddFactory(string type, IAccountFactoryMethod accountFactoryMethod);

        Account GetAccount(string type);
    }
}
