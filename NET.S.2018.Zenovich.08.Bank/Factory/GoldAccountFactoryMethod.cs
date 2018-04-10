using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model;
using NET.S._2018.Zenovich._08.Bank.Model.Accounts;

namespace NET.S._2018.Zenovich._08.Bank.Factory
{
    /// <summary>
    /// Implements gold account factory method.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Bank.API.IAccountFactoryMethod" />
    class GoldAccountFactoryMethod : IAccountFactoryMethod
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public Account Create()
        {
            return new GoldAccount();
        }
    }
}
