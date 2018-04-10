using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model;

namespace NET.S._2018.Zenovich._08.Bank.Factory
{
    /// <summary>
    /// Factory for created account.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Bank.API.IAccountFactory" />
    public class AccountFactory : IAccountFactory
    {
        #region Private fields

        private readonly Dictionary<string, IAccountFactoryMethod> factories;

        #endregion Private fields

        #region Public ctor

        public AccountFactory()
        {
            factories = new Dictionary<string, IAccountFactoryMethod>();
        }

        #endregion Public ctor

        #region Public methods

        /// <summary>
        /// Adds the factory.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="accountFactoryMethod">The account factory method.</param>
        public void AddFactory(string type, IAccountFactoryMethod accountFactoryMethod)
        {
            factories.Add(type, accountFactoryMethod);
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Account type not founded
        /// </exception>
        public Account GetAccount(string type)
        {
            IAccountFactoryMethod accountFactoryMethod;

            if (factories.TryGetValue(type, out accountFactoryMethod))
            {
                return accountFactoryMethod.Create();
            }

            throw new ArgumentOutOfRangeException(type);
        }

        #endregion Public methods
    }
}
