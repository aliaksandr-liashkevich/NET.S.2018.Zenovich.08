using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Bank.API;
using NET.S._2018.Zenovich._08.Bank.Model;

namespace NET.S._2018.Zenovich._08.Bank.Storage
{
    public class BankDataAccessObject : IDataAccessObject<Account>
    {
        public const string DefaulFilePath = "Accounts.bin";

        public static readonly string FilePath;

        static BankDataAccessObject()
        {
            FilePath = ConfigurationManager.AppSettings.Get("FilePath");

            if (FilePath == null)
            {
                FilePath = DefaulFilePath;
            }

            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }

        public List<Account> GetEntities()
        {
            var accounts = new List<Account>();

            var stream = File.Open(FilePath, FileMode.OpenOrCreate);
            var formatter = new BinaryFormatter();

            accounts = formatter.Deserialize(stream) as List<Account>;
            stream.Close();

            return accounts;
        }

        public void PostEntities(List<Account> accounts)
        {
            if (ReferenceEquals(accounts, null))
            {
                throw new ArgumentNullException(nameof(accounts));
            }

            var stream = File.Open(FilePath, FileMode.Create);
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, accounts);
            stream.Close();
        }
    }
}
